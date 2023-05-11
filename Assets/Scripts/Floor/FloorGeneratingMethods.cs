using System.Runtime.InteropServices;
using UnityEngine;

namespace Floor
{
    public class FloorGeneratingMethods : MonoBehaviour
    {
        [Header("Move up")] 
        public float up;
        
        protected GameObject GenerateFloor(GameObject floor)
        {
            transform.position = transform.position + Vector3.up * up;
            return Instantiate(floor, this.transform.position, Quaternion.identity);
        }

        protected ParticleSystem GenerateParticle(GameObject _fallingFloor)
        {
            return _fallingFloor.GetComponentInChildren<ParticleSystem>();
        }

        protected void RotateFloor(Transform obj)
        {
            obj.position = new Vector3
            {
                    x = Mathf.Sin(Time.time) + 1, 
                    y = 0.5f * Mathf.Sin(Time.time * 0.5f) + this.gameObject.transform.position.y,
                    z = obj.position.z
            };
        }

        protected bool IsStartFall(bool _isRotate, ParticleSystem _particle)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _particle.Stop();
                _isRotate = false;
            }

            return _isRotate;
        }
    }
}