using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Scripts.CutScene
{
    public class CutSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;

        private Rigidbody[] _enemyRigidbodies;
        private Animator _enemyAnimator;
        private AudioSource _enemyAudio;

        private bool _flag;

        private bool _crateFlag;

        private void Start()
        {
            _enemyRigidbodies = enemy.GetComponentsInChildren<Rigidbody>();
            _enemyAnimator = enemy.GetComponent<Animator>();
            _enemyAudio = enemy.GetComponent<AudioSource>();
            ToggleEnemyRagdoll(false);
        }

        /*private void Update() // I used for input management
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _flag = !_flag;
                _crateFlag = false;
                ToggleEnemyRagdoll(_flag);
            }
        }*/

        private void ToggleEnemyRagdoll(bool value)
        {
            _enemyAnimator.enabled = !value;
            foreach (var rb in _enemyRigidbodies)
            {
                rb.isKinematic = !value;
            }

            if (value)
            {
                _enemyAudio.Play();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_crateFlag)
            {
                if (other.gameObject.CompareTag("Crate"))
                {
                    ToggleEnemyRagdoll(true);
                }
            }
        }

        public void GoBack()
        {
            SceneManager.LoadScene("Main/Scenes/MainMenu");
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
