using UnityEngine;

namespace CameraScripts
{
    public class CameraMovement : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private Transform target;
        [SerializeField] private float speed;
        [SerializeField] private string targetTag;

        private void Awake()
        {
            if (this.target == null)
            {
                target = GameObject.FindGameObjectWithTag(targetTag).transform;
            }

            var position = target.position;
            this.transform.position = new Vector3()
            {
                x = position.x,
                y = position.y - 2f,
                z = position.z - 6f
            };
        }

        private void Update()
        {
            if (this.target)
            {
                var position = target.position;
                Vector3 temp = new Vector3()
                {
                    x = position.x,
                    y = position.y - 3f,
                    z = position.z - 6f
                };
                Vector3 pos = Vector3.Lerp(this.transform.position, temp, speed * Time.deltaTime);
                this.transform.position = pos;
            }
        }
    }
}
