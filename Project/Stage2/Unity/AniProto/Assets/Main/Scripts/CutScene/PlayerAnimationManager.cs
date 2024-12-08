using UnityEngine;

namespace Main.Scripts.CutScene
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] private float normalSpeed;
        [SerializeField] private float pushingSpeed;
        
        private Animator _animator;
        private float _currentSpeed;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _currentSpeed = normalSpeed;
        }

        private void FixedUpdate()
        {
            // using transform was not a good idea, but since the player object is moving slowly, it should be okay
            transform.position += transform.forward * (_currentSpeed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Crate"))
            {
                _animator.SetBool("pushing", true);
                _animator.SetBool("idle", false);
                _animator.SetBool("walking", false);
                _currentSpeed = pushingSpeed;
            }
        }
        
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Crate"))
            {
                _animator.SetBool("pushing", true);
                _animator.SetBool("idle", false);
                _animator.SetBool("walking", false);
                _currentSpeed = pushingSpeed;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Crate"))
            {
                _animator.SetBool("pushing", false);
                _animator.SetBool("idle", true);
                _animator.SetBool("walking", false);
                _currentSpeed = 0;
            }
        }
    }
}
