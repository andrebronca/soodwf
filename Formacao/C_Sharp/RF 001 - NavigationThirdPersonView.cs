using CenaPrincipal;
using UnityEngine;

namespace NavegacaoGlobalCenaPrincipal
{

    [RequireComponent(typeof(NavigationManager))]
    public class NavigationThirdPerson : MonoBehaviour
    {
        [SerializeField] private LayerMask _collisionLayers;
        [SerializeField] private float _zoomSpeedOrbitar = 5f;
        [SerializeField] private float _defaultDistance = 3.5f;
        [SerializeField] private float _smoothSpeed = 5f;
        [SerializeField] private float _sensibilityOrbitalMode = 5f;
        [SerializeField] private float _zoomMin = 1.5f;

        private InputManager _navigationInputs;
        private float _zoomLevel;
        private float _distance;
        private bool _isChangedTarget;

        // Inicializa o componente com as entradas de navegação fornecidas.
        public void Initialize(InputManager navigationInputs)
        {
            _navigationInputs = navigationInputs;
        }

        // Ativa o modo orbital, registra a mudança de alvo e configura a distância inicial e o estado do Rigidbody.
        public void StartOrbitalMode()
        {
            _navigationInputs.OnChangeTarget += TargetChangedOrbitalMode;
            _distance = _defaultDistance + _zoomMin;
            _navigationInputs.Player.GetComponent<Rigidbody>().isKinematic = true;
        }

        // Ajusta o nível de zoom com base no input do scroll do mouse, mantendo-o dentro dos limites definidos.
        public void ZoomOrbitalMode()
        {
            float zoom = Input.GetAxis("Mouse ScrollWheel");
            if (zoom != 0) _isChangedTarget = false;
            _zoomLevel -= zoom * _zoomSpeedOrbitar;
            _zoomLevel = Mathf.Clamp(_zoomLevel, 0f, 30f);
        }

        // Atualiza a rotação do player e executa a transição suave de posição conforme o modo orbital.
        public void HandleOrbitalUpdates()
        {
            _navigationInputs.RotatePlayerFirstPerson(_sensibilityOrbitalMode);
            SmoothTransition();
        }

        // Reseta o nível de zoom e sinaliza que houve mudança no alvo.
        private void TargetChangedOrbitalMode()
        {
            _zoomLevel = _defaultDistance + _zoomMin;
            _isChangedTarget = true;
        }

        // Realiza a transição suave da posição do player, ajustando-a instantaneamente ou interpolando conforme o input do mouse e colisões.
        private void SmoothTransition()
        {
            if (_isChangedTarget)
            {
                // Verifica se o botão do meio do mouse foi pressionado
                if (Input.GetMouseButtonDown(2))
                {
                    // Ajusta a posição imediatamente
                    _navigationInputs.Player.transform.position = AdjustForCollision();
                    _isChangedTarget = false; // Encerra a transição
                }
                else
                {
                    // Suaviza a transição até a posição-alvo
                    _navigationInputs.Player.transform.position = Vector3.Lerp(
                        _navigationInputs.Player.transform.position,
                        AdjustForCollision(),
                        _smoothSpeed * Time.deltaTime
                    );

                    // Verifica se chegou na posição-alvo usando um pequeno valor de distância
                    if (Vector3.Distance(_navigationInputs.Player.transform.position, AdjustForCollision()) < 0.01f)
                    {
                        _isChangedTarget = false; // Encerra a transição
                    }
                }
            }
            else
            {
                //AdjustForCollision ajusta a posição do player a cada quadro.
                _navigationInputs.Player.transform.position = AdjustForCollision();
            }
        }

        // Calcula e retorna a posição ajustada do player para evitar colisões entre o target e o player.
        private Vector3 AdjustForCollision()
        {
            float epsilon = 0.2f;

            // A distancia definida entre o target e o player
            float targetDistance = _defaultDistance + _zoomLevel;

            // Raio que vai da posicao do target em direcao ao player
            // Se existe algo entre o player e o alvo
            if (Physics.Raycast(_navigationInputs.Target.position,
                _navigationInputs.Player.transform.position - _navigationInputs.Target.position,
                out RaycastHit hit,
                targetDistance,
                _collisionLayers))
            {
                // Se a diferenca da minha distancia atual com a distancia que eu deveria estar
                // for tao pequena a ponto de ser indiferente entao nao faço nada
                if (Mathf.Abs(_distance - hit.distance) > epsilon)
                {
                    // A distancia vai do player vai ser entao do alvo até o ponto de colisao do raycast
                    _distance = Mathf.Lerp(_distance, hit.distance, Time.deltaTime * 10f);
                }
            }
            // O mesmo aqui!
            else if (Mathf.Abs(_distance - targetDistance) > epsilon)
            {
                // se nao a distancia volta a ser a definida pelo zoom
                _distance = Mathf.Lerp(_distance, targetDistance, Time.deltaTime * 10f);
            }

            // A posição do Target + um vetor deslocado para trás na direção da rotação atual
            return _navigationInputs.MainCamera.transform.rotation * Vector3.forward * -(_distance - 1f) + _navigationInputs.Target.position;
        }
    }
}