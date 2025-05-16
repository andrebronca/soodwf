using ArvoreComponentesCenaPrincipal;
using CenaPrincipal;
using UnityEngine;

namespace NavegacaoGlobalCenaPrincipal
{
    public enum Navigation
    {
        Orbital,
        Drone
    }

    public class NavigationManager : MonoBehaviour
    {
        [Header("GENERAL")]
        [SerializeField] private InputManager _navigationInputs;
        [SerializeField] private Navigation _navigation;

        [Header("MODES")]
        [SerializeField] public NavigationFirstPerson _droneNavigation;
        [SerializeField] private NavigationThirdPerson _orbitalNavigation;
        [SerializeField] private NavigationMinimap _satelliteNavigation;
        [SerializeField] private NavigationRail _railNavigation;

        private bool _isUIActive = false;

        private void Start()
        {
            _droneNavigation?.Initialize(_navigationInputs);
            _orbitalNavigation?.Initialize(_navigationInputs);
            _satelliteNavigation?.Initialize(_navigationInputs);
            _railNavigation?.Initialize(_navigationInputs);

            TreeManager treeManager = FindObjectOfType<TreeManager>();

            if (treeManager != null)
            {
                treeManager.IsZoomClicked += delegate
                {
                    _navigation = Navigation.Orbital;
                    Fly();
                };
                treeManager.InputField.onSelect.AddListener(_ => _droneNavigation.OnDisable());
                treeManager.InputField.onDeselect.AddListener(_ => _droneNavigation.StartDroneMode());
            }

            Fly();
        }

        private void Update()
        {
            if (_navigation == Navigation.Orbital && !InputUtilities.IsPointerOverUIElement())
            {
                _orbitalNavigation?.ZoomOrbitalMode();
            }
            _satelliteNavigation?.UpdateNavigationSatellite();
            _railNavigation?.UpdateRailNavigation();

            if (_navigation == Navigation.Drone)
            {
                _droneNavigation?.UpdateDroneMode();
            }

            if (_navigationInputs.Target == null)
            {
                _navigation = Navigation.Drone;
                Fly();
            }

            if (InputUtilities.IsPointerOverUIElement() && !_isUIActive)
            {
                _droneNavigation.OnDisable();
                _isUIActive = true;
            }
            else if (!InputUtilities.IsPointerOverUIElement() && _isUIActive)
            {
                _droneNavigation.StartDroneMode();
                _isUIActive = false;
            }

        }

        private void LateUpdate()
        {
            if (_navigation == Navigation.Orbital)
                _orbitalNavigation?.HandleOrbitalUpdates();
        }

        #region CONFIGURAÇÕES

        // Configura os comportamentos e interações específicos para os modos Drone e Orbital, ativando ou desativando funções conforme o caso.
        private void Fly()
        {
            switch (_navigation)
            {
                case Navigation.Drone:
                    _droneNavigation.StartDroneMode();
                    _satelliteNavigation.OnMinimapClick += _satelliteNavigation.StartCoroutineMinimap;
                    _railNavigation?.Initialize(_navigationInputs);
                    _railNavigation.SliderRailNavigation.interactable = true;
                    break;
                case Navigation.Orbital:
                    _satelliteNavigation.OnMinimapClick -= _satelliteNavigation.StartCoroutineMinimap;
                    _droneNavigation.OnDisable();
                    _orbitalNavigation.StartOrbitalMode();
                    _railNavigation.SliderRailNavigation.interactable = false;
                    break;
            }
        }

        // Alterna entre os modos Orbital e Drone e reconfigura o sistema de navegação chamando Fly().
        public void SwitchNavigation()
        {
            _navigation = (_navigation == Navigation.Orbital) ? Navigation.Drone : Navigation.Orbital;
            Fly();
        }
        #endregion
    }
}