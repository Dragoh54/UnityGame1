using TMPro;
using UnityEngine;

namespace Floor
{
    public class FloorRespawn : MonoBehaviour
    {
        [Header("Game Objects")]
        public GameObject floor;
        public GameObject deadZone;
        private GameObject _fallingFloor;

        [Header("Rotating")]
        private bool _isRotate; 
    
        [Header("Floors")]
        public static int _floorCounter = 0;

        private void Awake()
        {
            _fallingFloor = Instantiate(floor, this.transform.position, Quaternion.identity);
            _fallingFloor.gameObject.layer = 6;

            _isRotate = true;

            _floorCounter = 0;
        }
        
        private void Update()
        {
            RotateFloor(_fallingFloor.transform);
            if (_fallingFloor.CompareTag("Placed_Floor") && !_isRotate)
            {
                Generate();
                _floorCounter += 1;
                _isRotate = true;
            }
        }

        private void Generate()
        {
            _fallingFloor = Instantiate(floor, this.transform.position, Quaternion.identity);
            transform.position = transform.position + Vector3.up;
        }

        private void RotateFloor(Transform obj)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isRotate = false;
            }
            else if (_isRotate)
            {
                obj.position = new Vector3
                {
                    x = Mathf.Sin(Time.time) + 1, 
                    y = 0.5f * Mathf.Sin(Time.time * 0.5f) + this.gameObject.transform.position.y,
                    z = obj.position.z
                };
            }
        }
    }
}
