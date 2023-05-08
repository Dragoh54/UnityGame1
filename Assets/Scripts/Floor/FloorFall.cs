using UnityEngine;
using UnityEngine.Audio;

namespace Floor
{
    public class FloorFall : MonoBehaviour
    {
        [Header("Ground detection")] 
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask gameOver;

        [Header("Gravity")] 
        private Rigidbody _rb;

        [Header("Audio")] 
        private AudioSource _audioSource;
        public AudioClip audioClip;

        void Awake()
        {
            _rb = this.gameObject.GetComponent<Rigidbody>();
            _audioSource = this.GetComponent<AudioSource>();

            _rb.isKinematic = true;
            _rb.detectCollisions = true;
            
        }

        private void Update()
        {
            Fall();
        }

        private void Fall()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded(this.gameObject, groundLayer))
            {
                _rb.isKinematic = false;
                _rb.detectCollisions = true;
            }
        }

        public bool IsGrounded(GameObject floor, LayerMask mask)
        {
            BoxCollider boxCollider = floor.GetComponent<BoxCollider>();
            return Physics.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,
                Vector3.down, Quaternion.identity, 0.1f, mask);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 7 && this.gameObject.layer == 3)
            {
                gameObject.tag = "Lose";
                gameObject.name = "Lose";
            }
            else
            {
                gameObject.tag = "Placed_Floor";
                gameObject.name = "Placed_Floor";
                _audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
