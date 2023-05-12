using System;
using UnityEngine;

namespace Floor
{
    public class FloorRespawn : FloorGeneratingMethods
    {
        [Header("Game Objects")]
        public GameObject floor;
        private GameObject _fallingFloor;
        private ParticleSystem _particle;

        [Header("Rotating")]
        private bool _isFall;

        private void Awake()
        {
            _fallingFloor = Instantiate(floor, this.transform.position, Quaternion.identity);
            _particle = _fallingFloor.GetComponentInChildren<ParticleSystem>();

            _fallingFloor.gameObject.layer = 6;

            _isFall = true;
        }

        private void Update()
        {
            _isFall = IsStartFall(_isFall, _particle);
            if (_isFall)
            {
                RotateFloor(_fallingFloor.transform);
            }
        }

        private void LateUpdate()
        {
            if (_fallingFloor.CompareTag("Placed_Floor") && !_isFall)
            {
                Generate(floor);
                _isFall = true;
            }
        }

        private void Generate(GameObject floor)
        {
            _fallingFloor = GenerateFloor(floor);
            _particle = GenerateParticle(_fallingFloor);
        }
    }
}
