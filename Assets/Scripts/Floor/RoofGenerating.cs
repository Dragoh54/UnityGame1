using System;
using GameOver;
using Unity.VisualScripting;
using UnityEngine;

namespace Floor
{
    public class RoofGenerating : FloorGeneratingMethods
    {
        [Header("GameObject")] 
        public GameObject roof;
        private GameObject _roof;

        [Header("Rotating")] 
        private bool _isFall;

        [Header("Is Placed")] 
        public static bool IsPlaced;

        private void Start()
        {
            if (this.enabled)
            {
                _roof = GenerateFloor(roof);
            }
            _isFall = true;
            IsPlaced = false;
        }

        private void Update()
        {
            _isFall = IsStartFall(_isFall, _roof.GetComponentInChildren<ParticleSystem>());
            if (_isFall)
            {
                RotateFloor(_roof.transform);
            }
            
            Finish();
        }

        private void Finish()
        {
            if (_roof.GameObject().CompareTag("Placed_Floor"))
            {
                IsPlaced = true;
            }
        }
    }
}