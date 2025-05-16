using ArvoreComponentesCenaPrincipal;
using CenaPrincipal;
using DadosAdicionais;
using System;
using System.Collections.Generic;
using System.Linq;
using TrocaCena;
using UIResultadosSimulacao;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using OutlineSceneBuild = OutlineCenaBuild.OutlineSceneBuild;


namespace SelecaoDinamicaCenaPrincipal
{
    public class SelectionManager : MonoBehaviour
    {
        [Header("GENERAL")]
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Canvas _canvas;
        bool isUI = true;

        [Header("HOVER HIGHLIGHT")]
        [SerializeField] private Color _hoverColor;
        [SerializeField] private float _hoverWidth = 5f;

        [Header("SELECTION")]
        [SerializeField] private Color _selectedColor;
        [SerializeField] private float _selectedWidth = 5f;

        [Header("TOOLTIP")]
        [SerializeField] private GameObject _tooltipPrefab;
        [SerializeField] private Vector2 _adjustPositionTooltip = new Vector2(-40, 40);
        private GameObject[] _instatiatedTooltip = new GameObject[2];

        [Header("HIERARCHY")]
        [SerializeField] private Transform _worldRepresentation;
        [SerializeField] private Button _hierarchyPrefab;
        [SerializeField] private Vector3 _initialPosition = new Vector3(5, 5, 0);
        public event Action OnChangeLevel;
        private List<Objects> _objects = new List<Objects>();
        private Dictionary<int, Button> _hierarchyButtons = new Dictionary<int, Button>();
        public int _currentLevel = 0;

        [Header("PIE MENU")]
        [SerializeField] public List<MenuButton> _pieButtons = new List<MenuButton>();
        [SerializeField] private GameObject _menuPieUi;
        [SerializeField] private int _currentMenuItem;
        [SerializeField] private int _previousMenuItem;
        private bool _isActiveMenu = false;

        [Header("RAIO - X")]
        [SerializeField] private Image mouseImage;
        private bool _isCut = false;
        private Material transparent;
        private Material opaque;

        [Header("UI RESULTADOS DE SIMULAÇÃO")]
        [SerializeField] private GameObject _UIResultadosSimulacao;

        // NOTE: Variáveis necessários para integração dos Documentos Técnicos no menu contextual
        [Header("DOCUMENTOS TÉCNICOS")]
        [SerializeField] private GameObject _UIDocumentosTecnicos;
        [SerializeField] private DocumentManager documentManager;

        [Header("CONTROLLER ENTRE CENAS")]
        [SerializeField] private ControllerTrocaEntreCenas _controllerObjetos;

        private void Start()
        {
            TreeManager treeManager = FindObjectOfType<TreeManager>();
            treeManager.InputField.onSelect.AddListener(delegate { isUI = false; });
            treeManager.InputField.onDeselect.AddListener(delegate { isUI = true; });
            InstantiateOutline();
            _inputManager.OnClickTarget += HandleClickOutline;
            _inputManager.OnChangeTarget += HandleClickOutline;
            _inputManager.OnChangeHover += HandleMouseHoverOutline;
            _inputManager.OnChangeHover += HandleMouseHoverTooltip;
            StartHierarchy();
            StartPie();
            StartRaio();
        }

        private void Update()
        {
            UpdateTooltip();

            if (Input.GetKeyDown(KeyCode.Space) && _inputManager.Target != null && isUI)
            {
                _isActiveMenu = !_isActiveMenu;
            }

            _menuPieUi.SetActive(_isActiveMenu);
            UpdatePie();
            UpdateRaio();

            if (_inputManager.Target == null)
            {
                _inputManager.Target = _worldRepresentation;
            }
        }

        private void LateUpdate()
        {
            UpdateHierarchy();
        }

        #region CONFIGURAÇÕES
        // Adiciona o outline a todos os objetos da layer específica.
        private void InstantiateOutline()
        {
            GameObject[] allObjects = FindObjectsOfType<GameObject>(); // Encontra todos os objetos ativos na cena.

            foreach (GameObject obj in allObjects)
            {
                if (obj.layer == _inputManager.LayerMask)
                {
                    var outline = obj.AddComponent<OutlineSceneBuild>();
                    outline.enabled = false;
                }
            }
        }

        #endregion
        #region RF 002.1 - Iluminação de destaque de objetos por sobreposição (Hover Highlight)

        // Constroi e Destroi o Outline em torno do objeto de uma layer especifica
        private void HandleMouseHoverOutline()
        {
            if (_inputManager.Hover != null &&
                _inputManager.Hover.gameObject.GetComponent<OutlineSceneBuild>() != null &&
                InputUtilities.IsInLayer(_inputManager.Hover, _inputManager.LayerMask) &&
                _inputManager.Hover != _inputManager.Target)
            {
                var outline = _inputManager.Hover.GetComponent<OutlineSceneBuild>();
                outline.isTree = false;
                outline.enabled = true;
                outline.OutlineColor = _hoverColor;
                outline.OutlineWidth = _hoverWidth;
            }

            if (_inputManager.PreviousHover != null &&
                _inputManager.PreviousHover.GetComponent<OutlineSceneBuild>() != null &&
                _inputManager.PreviousHover != _inputManager.Target)
            {
                _inputManager.PreviousHover.GetComponent<OutlineSceneBuild>().enabled = false;
            }
        }
        #endregion
        #region RF 002.2 - Exibição de informação do nome do componente (Tooltip)

        private void UpdateTooltip()
        {
            UpdateTooltipPosition();
        }

        // Atualiza a posicao do tooltip baseado na posicao do mouse dentro da tela
        private Vector2 TooltipPosition()
        {
            if (Input.mousePosition.x > (Screen.width / 2))
            {
                return Input.mousePosition + new Vector3(_adjustPositionTooltip.x, _adjustPositionTooltip.y);
            }

            else
            {
                return Input.mousePosition - new Vector3(_adjustPositionTooltip.x, _adjustPositionTooltip.y);
            }

        }

        // Instancia o tooltip e destroi o anterior
        private void HandleMouseHoverTooltip()
        {
            _instatiatedTooltip[0] = _instatiatedTooltip[1];
            if (_inputManager.Hover != null &&
                InputUtilities.IsInLayer(_inputManager.Hover, _inputManager.LayerMask))
            {
                _instatiatedTooltip[1] = Instantiate(_tooltipPrefab, TooltipPosition(), Quaternion.identity, _canvas.transform);
                var tooltipPrefab = _instatiatedTooltip[1].GetComponent<TooltipPrefabSceneBuild>();
                tooltipPrefab.ComponentText.text = _inputManager.Hover.transform.name;
            }
            Destroy(_instatiatedTooltip[0]);
        }

        // Atualiza a posicao do tooltip para seguir o mouse
        private void UpdateTooltipPosition()
        {
            if (_instatiatedTooltip[1] != null)
            {
                // Verifica se o mouse está fora dos limites da tela
                if ((Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width ||
                    Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height) ||
                    InputUtilities.IsPointerOverUI())
                {
                    Destroy(_instatiatedTooltip[1]);
                    _instatiatedTooltip[1] = null;
                }
                else
                {
                    _instatiatedTooltip[1].transform.position = TooltipPosition();
                }
            }
        }

        #endregion
        //RF 002.3 – Seleção de objeto. O requisito não faz sentido como parte deste conjunto de requisitos.
        #region RF 002.4 – Iluminação de destaque de objetos por seleção (Click Highlight)

        // Constroi e Destroi o Outline em torno do objeto de uma layer especifica
        public void HandleClickOutline(Transform t)
        {
            if (t != null &&
                t.gameObject.GetComponent<OutlineSceneBuild>() != null &&
                InputUtilities.IsInLayer(t, _inputManager.LayerMask))
            {
                var outline = t.GetComponent<OutlineSceneBuild>();
                outline.isTree = false;
                outline.OnDisable();
                outline.OnEnable();
                outline.enabled = true;
                outline.OutlineColor = _selectedColor;
                outline.OutlineWidth = _selectedWidth;
            }

            if (_inputManager.PreviousTarget != null &&
                _inputManager.PreviousTarget.GetComponent<OutlineSceneBuild>() != null)
            {
                var outline = _inputManager.PreviousTarget.GetComponent<OutlineSceneBuild>();
                outline.OnDisable();
                outline.enabled = false;
            }
        }

        public void HandleClickOutline()
        {
            if (_inputManager.PreviousTarget != null &&
                _inputManager.PreviousTarget.GetComponent<OutlineSceneBuild>() != null)
            {
                var outline = _inputManager.PreviousTarget.GetComponent<OutlineSceneBuild>();
                outline.OnDisable();
                outline.enabled = false;
            }
        }
        #endregion
        #region RF 002.5 – Alteração do nível de seleção hierárquica 
        #region GENERAL
        public class Objects
        {
            public Objects() { }
            public Objects(int Level, Transform Self)
            {
                this.Level = Level;
                this.Self = Self;
            }

            public Transform Self;
            public int Level;
        }

        private void StartHierarchy()
        {
            BuildParentHierarchy();
            InstantiateButton(0);
        }

        private void UpdateHierarchy()
        {
            if (InputUtilities.GetDoubleClick(_inputManager.LayerMask))
            {
                HierarchyRelation();
            }
        }

        // Método responsável por distribuir a lógica de hierarquia
        public void HierarchyRelation()
        {
            if (_inputManager.Target != _worldRepresentation)
            {
                ProcessSameObject();
            }
        }

        #endregion
        #region REMOCAO

        // Caso 1: Duplo clique em objeto igual e mesma hierarquia
        private void ProcessSameObject()
        {
            // Se eu estou no primeiro nivel entao capturo a lista inicial de objetos a percorrer
            BuildParentHierarchy();

            // O objeto do nivel que eu estou tem filhos
            if (_objects[_currentLevel].Self.childCount > 0)
            {
                // Desativo visualmente este objeto
                DisableColliderAndHide(_objects[_currentLevel].Self);

                // Caso 1.1: O nivel da hierarquia não é o mesmo do objeto sob duplo clique
                if (_inputManager.Target != _objects[_currentLevel].Self)
                {
                    NotSameTargetObject();
                }

                // Caso 1.2: O nivel da hierarquia é o mesmo do objeto sob duplo clique
                else
                {
                    SameTargetObject();
                }
            }
        }

        private void NotSameTargetObject()
        {
            // Percorro os meus filhos desativando eles menos o filho que está contido na hierarquia
            for (int i = 0; i < _objects[_currentLevel].Self.childCount; i++)
            {
                if (_objects[_currentLevel].Self.GetChild(i) != _objects[_currentLevel + 1].Self)
                {
                    DisableGameObject(_objects[_currentLevel].Self.GetChild(i));
                }
            }

            _currentLevel++;
            InstantiateButton(_currentLevel);

            OnChangeLevel?.Invoke();
            if (_objects[_currentLevel].Self != _inputManager.Target)
            {
                _inputManager.PreviousTarget = _inputManager.Target;
                _inputManager.Target = _objects[_currentLevel].Self;
            }
        }

        private void SameTargetObject()
        {
            if (!_hierarchyButtons.ContainsKey(_currentLevel))
            {
                InstantiateButton(_currentLevel);
            }

            OnChangeLevel?.Invoke();
            // O usuario escolhe o novo caminho
            _inputManager.PreviousTarget = _inputManager.Target;
            _inputManager.Target = null;
        }
        #endregion
        #region INSERCAO

        // Método inscrito nos botôes instanciados responsável por voltar ao nivel correspondente na hierarquia
        public void HandleButton(int key)
        {
            // Vou do botao clicado mais um até o último botao
            for (int i = key; i < _objects.Count; i++)
            {
                // Reativo o objeto correspondente ao botao clicado mais um
                EnableColliderAndShow(_objects[i].Self);

                // Percorro cada filho de mesmo indice que o botao clicado mais um na hierarquia
                for (int j = 0; j < _objects[i].Self.childCount; j++)
                {
                    EnableColliderAndShow(_objects[i].Self.GetChild(j));
                    EnableGameObject(_objects[i].Self.GetChild(j));
                }
                if (i + 1 < _objects.Count)
                {
                    // Destruo o botão
                    DestroyButton(i + 1);
                }
            }

            var button = _hierarchyButtons[key].GetComponent<HierarchyPrefab>();
            button.ComponentText.text = _objects[key].Self.name;

            _currentLevel = key;
            OnChangeLevel?.Invoke();
            _inputManager.PreviousTarget = _inputManager.Target;
            _inputManager.Target = _objects[key].Self;

            // Atualizo a hierarquia com os botoes removidos.
            BuildParentHierarchy();
        }
        #endregion
        #region MÉTODOS AUXILIARES

        // Desativa um gameObject de um transform qualquer
        private void DisableGameObject(Transform t)
        {
            t.gameObject.SetActive(false);
        }

        // Desativa mesh e collider de um transform qualquer
        private void DisableColliderAndHide(Transform transform)
        {
            var mesh = transform.GetComponent<MeshRenderer>();
            var collider = transform.GetComponent<Collider>();
            if (mesh != null && collider != null)
            {
                mesh.enabled = false;
                collider.enabled = false;
            }
        }

        // Ativa um gameObject de um transform qualquer
        private void EnableGameObject(Transform t)
        {
            t.gameObject.SetActive(true);
        }

        // Ativa mesh e collider de um transform qualquer
        private void EnableColliderAndShow(Transform transform)
        {
            var mesh = transform.GetComponent<MeshRenderer>();
            var collider = transform.GetComponent<Collider>();
            if (mesh != null && collider != null)
            {
                mesh.enabled = true;
                collider.enabled = true;
            }
        }

        // Método responsável por criar a hierarquia do objeto clicado.
        private void BuildParentHierarchy()
        {
            _objects.Clear();
            _objects = ParentRecursive(0, _inputManager.Target);
        }

        // Método recursivo que retorna uma lista de objetos que vai do objeto clicado até um objeto de referência
        private List<Objects> ParentRecursive(int key, Transform t)
        {
            if (t == null || t.CompareTag(_worldRepresentation.tag))
            {
                return new List<Objects> { new Objects(0, t) };
            }

            List<Objects> parentObjects = ParentRecursive(key + 1, t.parent);
            parentObjects.Add(new Objects(parentObjects.Count, t));

            return parentObjects;
        }
        // Armazena as chaves na ordem em que os botões foram adicionados
        private List<int> _insertionOrder = new List<int>();

        // Método que instancia um botao com base em uma chave no dicionario de botoes.
        private void InstantiateButton(int key)
        {
            // Instancia o botão e armazena no dicionário
            Button newButton = Instantiate(_hierarchyPrefab, _canvas.transform);
            _hierarchyButtons[key] = newButton;

            // Registra a chave na ordem de inserção
            _insertionOrder.Add(key);

            var button = newButton.GetComponent<HierarchyPrefab>();
            button.ComponentText.text = _objects[key].Self.name;



            newButton.onClick.AddListener(() => HandleButton(key));
            TruncatedButtons();
        }


        private void TruncatedButtons()
        {
            // Obtém o último botão inserido com base na lista de ordem de inserção
            Button lastButton = _hierarchyButtons[_insertionOrder.Last()];
            Vector3 nowPosition = _initialPosition;

            // Itera os botões na ordem de inserção
            foreach (var key in _insertionOrder)
            {
                Button buttonObject = _hierarchyButtons[key];
                var button = buttonObject.GetComponent<HierarchyPrefab>();
                var rectTransform = buttonObject.GetComponent<RectTransform>();

                // Posiciona o botão de acordo com a posição atual
                rectTransform.anchoredPosition = nowPosition;
                rectTransform.localScale = Vector3.one;

                // Se não for o último botão, trunca o texto
                if (buttonObject != lastButton)
                {
                    string fullText = _objects[key].Self.name;
                    int underscoreIndex = fullText.IndexOf('_');

                    string truncatedText = underscoreIndex > 0
                        ? fullText.Substring(0, underscoreIndex) + "..."
                        : fullText;

                    button.ComponentText.text = truncatedText;
                }

                // Força a atualização do layout
                var panelRect = button.Panel.GetComponent<RectTransform>();
                LayoutRebuilder.ForceRebuildLayoutImmediate(panelRect);

                // Atualiza a posição horizontal para o próximo botão
                nowPosition.x += panelRect.rect.width + 10f;
            }
        }


        // Método que destroi um botao com base em uma chave no dicionario de botoes.
        private void DestroyButton(int key)
        {
            if (_hierarchyButtons.ContainsKey(key) && _hierarchyButtons[key] != null)
            {
                var button = _hierarchyButtons[key].GetComponent<HierarchyPrefab>();
                Destroy(_hierarchyButtons[key].gameObject);
                _hierarchyButtons[key] = null;
                _hierarchyButtons.Remove(key);
                _insertionOrder.Remove(key);
            }
        }
        #endregion
        #endregion
        #region RF 002.6 - Menu de ações circular (Pie menu - Radial menu)
        // Método de inicialização do menu radial
        private void StartPie()
        {
            // Reseta todas as cores dos botões para o estado normal
            foreach (MenuButton i in _pieButtons)
            {
                i.buttonImage.color = i.NormalColor;
                i.sceneImage.SetActive(false);
            }

            _pieButtons[_currentMenuItem].sceneImage.SetActive(true);

            // Inicializa os índices do item atual e anterior
            _currentMenuItem = _previousMenuItem = 0;
        }

        // Método chamado a cada frame para atualizar o menu radial
        private void UpdatePie()
        {
            // Atualiza o item do menu sob o cursor
            GetCurrentMenuItem();

            // Verifica clique do botão esquerdo do mouse
            if (Input.GetKeyDown(KeyCode.Mouse0) && _isActiveMenu)
            {
                ButtonAction();
            }
        }

        // Calcula qual item do menu está sob o cursor usando posição angular
        private void GetCurrentMenuItem()
        {
            // Captura posição atual do mouse
            var mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            // Converte para coordenadas normalizadas (0-1) da tela
            Vector2 toVector2M = new Vector2(mousePosition.x / Screen.width, mousePosition.y / Screen.height);

            Vector2 fromVector2M = new Vector2(0.5f, 0.5f);
            Vector2 centerCircle = new Vector2(0.5f, 0.5f);

            // Calcula ângulo entre posição inicial e atual do mouse em relação ao centro
            float angle = (Mathf.Atan2(fromVector2M.y - centerCircle.y, fromVector2M.x - centerCircle.x) -
                            Mathf.Atan2(toVector2M.y - centerCircle.y, toVector2M.x - centerCircle.x)) *
                            Mathf.Rad2Deg; // Converte radianos para graus

            // Ajusta ângulos negativos para intervalo de 0-360 graus
            if (angle < 0)
            {
                angle += 360;
            }

            // Mapeia o ângulo para um índice de item do menu
            _currentMenuItem = (int)(angle / (360 / _pieButtons.Count));

            // Atualiza elementos visuais apenas se o item mudou
            if (_currentMenuItem != _previousMenuItem)
            {
                // Restaura cor do item anterior
                _pieButtons[_previousMenuItem].buttonImage.color = _pieButtons[_previousMenuItem].NormalColor;

                // Ativa/desativa elementos visuais
                _pieButtons[_currentMenuItem].sceneImage.SetActive(true);
                _pieButtons[_previousMenuItem].sceneImage.SetActive(false);

                // Atualiza índice guardado
                _previousMenuItem = _currentMenuItem;

                // Aplica cor de destaque ao novo item
                _pieButtons[_currentMenuItem].buttonImage.color = _pieButtons[_currentMenuItem].HighlightedColor;
            }
        }

        // Executa ação do botão clicado
        private void ButtonAction()
        {
            // Altera cor para estado pressionado
            _pieButtons[_currentMenuItem].buttonImage.color = _pieButtons[_currentMenuItem].PressedColor;

            // Dispara evento de clique do botão
            _pieButtons[_currentMenuItem].button.onClick.Invoke();

            _isActiveMenu = false;
        }

        // Classe que define as propriedades de um botão do menu radial
        [Serializable]
        public class MenuButton
        {
            public Button button;               // Componente Button do Unity
            public Image buttonImage;           // Componente Image para alterar cores
            public GameObject sceneImage;       // Objeto associado (ex: ícone ou preview)
            public Color NormalColor = Color.white;        // Cor normal
            public Color HighlightedColor = Color.grey;    // Cor ao passar o mouse
            public Color PressedColor = Color.gray;        // Cor ao clicar
        }
        #endregion
        #region RF 002.7 - Modo de visualização Raio-X (Lupa de oclusão)

        private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

        private void StartRaio()
        {
            transparent = Resources.Load<Material>("Transparency");
        }

        private void UpdateRaio()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                _isCut = !_isCut;
                Cursor.visible = !_isCut;

                if (!_isCut)
                {
                    RestoreAllMaterials();
                }
            }

            if (_isCut)
            {
                mouseImage.enabled = true;
                mouseImage.rectTransform.position = Input.mousePosition;

                if (_inputManager.Hover != null &&
                    _inputManager.Hover.TryGetComponent(out Renderer hoverRenderer) &&
                    InputUtilities.IsInLayer(_inputManager.Hover, _inputManager.LayerMask))
                {
                    if (!originalMaterials.ContainsKey(hoverRenderer))
                    {
                        originalMaterials[hoverRenderer] = hoverRenderer.material;
                    }

                    hoverRenderer.material = transparent;
                }

                if (_inputManager.PreviousHover != null &&
                    _inputManager.PreviousHover.TryGetComponent(out Renderer previousRenderer))
                {
                    if (originalMaterials.ContainsKey(previousRenderer))
                    {
                        previousRenderer.material = originalMaterials[previousRenderer];
                        originalMaterials.Remove(previousRenderer);
                    }
                }
            }
            else
            {
                mouseImage.enabled = false;

                if (_inputManager.Hover != null &&
                    _inputManager.Hover.TryGetComponent(out Renderer hoverRenderer))
                {
                    if (originalMaterials.ContainsKey(hoverRenderer))
                    {
                        hoverRenderer.material = originalMaterials[hoverRenderer];
                        originalMaterials.Remove(hoverRenderer);
                    }
                }
            }
        }

        private void RestoreAllMaterials()
        {
            foreach (var pair in originalMaterials)
            {
                if (pair.Key != null)
                {
                    pair.Key.material = pair.Value;
                }
            }

            originalMaterials.Clear();
        }
        #endregion

        public void Isolar()
        {

            BuildParentHierarchy();

            while (_objects[_currentLevel] != _objects[_objects.Count - 1])
            {
                DisableColliderAndHide(_objects[_currentLevel].Self);
                NotSameTargetObject();
            }

        }

        public void DadosAdicionais()
        {
            var objComDadosAdicionais = _inputManager.Target.GetComponent<ComponenteComDadosAdicionais>();

            if (objComDadosAdicionais is not null)
            {
                ValidarExibirDadosAdicionais(objComDadosAdicionais);
            }
        }

        private void ValidarExibirDadosAdicionais(ComponenteComDadosAdicionais obj)
        {
            DadosAdicionaisClickListener dacl = FindAnyObjectByType<DadosAdicionaisClickListener>();

            if (obj is not null)
            {
                if (dacl.ValidarNomeObjeto(obj.GetID()))
                {
                    dacl.CarregarDadosAdicionais();
                }
            }
            else
            {
                dacl.DestroyPrefab();
            }
        }

        /// <summary>
        /// Exibe o painel de Documentos Técnicos para o objeto atualmente selecionado,
        /// desde que ele contenha o componente ObjectInfo com as tags apropriadas.
        /// </summary>
        public void DocumentosTecnicos()
        {
            if (_inputManager == null || _inputManager.Target == null)
            {
                Debug.LogWarning("DocumentosTecnicos: InputManager ou Target está nulo.");
                return;
            }

            GameObject selectedObject = _inputManager.Target.gameObject;

            if (selectedObject == null)
            {
                Debug.LogWarning("DocumentosTecnicos: Objeto selecionado é nulo.");
                return;
            }

            // Verifica se o objeto possui o componente ObjectInfo
            ObjectInfo objectInfo = selectedObject.GetComponent<ObjectInfo>();

            if (objectInfo == null)
            {
                Debug.LogWarning($"DocumentosTecnicos: O objeto '{selectedObject.name}' não possui o componente ObjectInfo.");
                return;
            }

            // Atualiza o painel de documentos técnicos e o torna visível
            documentManager.GetDocTecPanelInfo();
            _UIDocumentosTecnicos.SetActive(true);
        }

        public void DetalhesConstrutivos()
        {
            GameObject objSelecionado = _inputManager.Target.gameObject;
            if (objSelecionado is not null)
            {
                ComponenteComDetalhesConstrutivos cdc = objSelecionado.gameObject.GetComponent<ComponenteComDetalhesConstrutivos>();
                if (cdc is not null)
                {
                    InvocarMudancaCena();
                }
            }
        }


        private void InvocarMudancaCena()
        {
            // Pausa o tempo na cena principal
            Time.timeScale = 0f;

            if (_controllerObjetos != null)
            {
                _controllerObjetos.ToggleAllObjetos(false);
            }

            if (GameManagerEntreCenas.Instance != null && GameManagerEntreCenas.Instance.mainCamera != null)
            {
                GameManagerEntreCenas.Instance.mainCamera.gameObject.SetActive(false);
            }

            SceneManager.LoadScene("DetalhesConstrutivos", LoadSceneMode.Additive);
            //Invoke(nameof(ActivateDCCamera), 0.1f);	//Câmera secundária ativa por padrão, então não invocar
        }

        private void ActivateDCCamera()
        {
            Scene dcScene = SceneManager.GetSceneByName("DetalhesConstrutivos");
            if (dcScene.isLoaded)
            {
                Camera[] cameras = dcScene.GetRootGameObjects()
                    .SelectMany(go => go.GetComponentsInChildren<Camera>())
                    .ToArray();

                foreach (var cam in Camera.allCameras)
                {
                    cam.gameObject.SetActive(cameras.Contains(cam));
                }
            }
        }

        public void Simulacoes()
        {
            var objComResSimulacao = _inputManager.Target.GetComponent<ComponenteComResultadoSimulacao>();

            if (objComResSimulacao is not null)
            {
                if (_UIResultadosSimulacao is not null)
                {
                    _UIResultadosSimulacao.SetActive(true);
                    CarregarSimulacao cs = FindAnyObjectByType<CarregarSimulacao>();
                    if (cs is not null)
                    {
                        cs.LimparResultados();
                    }
                }
            }
        }
    }
}