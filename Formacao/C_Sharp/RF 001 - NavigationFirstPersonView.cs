using CenaPrincipal;
using UnityEngine;

namespace NavegacaoGlobalCenaPrincipal
{

    [RequireComponent(typeof(NavigationManager))]
    public class NavigationFirstPerson : MonoBehaviour
    {
        [SerializeField] private float _sensibilityDroneMode = 5f;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _zoomSpeedDrone = 5f;
        private InputManager _navigationInputs;
        private Rigidbody _rb;

        public void OnDisable()
        {
            if (_navigationInputs != null)
            {
                _navigationInputs.OnInputTranslation -= ControllerMovement;
                _navigationInputs.OnZoomTranslation -= ZoomDroneMode;
            }
        }

        // Configura o componente com as entradas de navegação fornecidas.
        public void Initialize(InputManager navigationInputs)
        {
            _navigationInputs = navigationInputs;
        }

        // Registra callbacks para movimentação e zoom e ativa o Rigidbody para o modo drone.
        public void StartDroneMode()
        {
            _navigationInputs.OnInputTranslation += ControllerMovement;
            _navigationInputs.OnZoomTranslation += ZoomDroneMode;

            // A transição de câmeras desativa o mainCamera do Player, é necessária essa validação
            if (_navigationInputs.Player != null)
            {
                _rb = _navigationInputs.Player.GetComponent<Rigidbody>();
                _rb.isKinematic = false;
            }
        }

        // Atualiza a rotação do jogador em modo drone com base na sensibilidade definida.
        public void UpdateDroneMode()
        {
            _navigationInputs.RotatePlayerFirstPerson(_sensibilityDroneMode);
        }

        // Ajusta a interpolação e chama a função de movimentação ou para o movimento conforme a direção fornecida.
        private void ControllerMovement(Vector3 movementDirection)
        {
            if (movementDirection != Vector3.zero)
            {
                _rb.interpolation = RigidbodyInterpolation.Interpolate;
                Move(movementDirection);
            }
            else
            {
                _rb.interpolation = RigidbodyInterpolation.None;
                StopMovement();
            }
        }

        // Normaliza a direção, aplica um multiplicador de velocidade se Shift estiver pressionado e define a velocidade do Rigidbody.
        private void Move(Vector3 direction)
        {
            float speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;
            direction.Normalize();
            if (!_rb.isKinematic)
                _rb.velocity = direction * (_speed * speedMultiplier);
        }

        // Zera a velocidade do Rigidbody para interromper o movimento.
        private void StopMovement()
        {
            if (!_rb.isKinematic)
                _rb.velocity = Vector3.zero;
        }

        // Normaliza a direção de zoom e aplica uma força de impulso no Rigidbody para realizar o zoom.
        private void ZoomDroneMode(Vector3 zoomDirection)
        {
            zoomDirection.Normalize();
            _rb.AddForce(zoomDirection * _zoomSpeedDrone, ForceMode.Impulse);
        }
    }
}