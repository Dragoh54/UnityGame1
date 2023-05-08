using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu
{
    public class SoundsSettings : MonoBehaviour
    {
        [Header("UI")] 
        public Toggle toggleSound;
        public Slider sliderVolumeSound;

        [Header("Game objects")]
        public new AudioMixer audio;

        [Header("VolumeSound")] public float volume;

        private void Awake()
        {
            Load();
        }

        private void Start()
        {
            ValueSound();
        }

        public void SlideSound()
        {
            volume = sliderVolumeSound.value;
            Save();
            ValueSound();
        }

        public void ToggleSound()
        {
            if (toggleSound.isOn)
            {
                volume = 0f;
            }
            else
            {
                volume = -40f;
            }

            Save();
            ValueSound();
        }

        private void ValueSound()
        {
            print(volume);
            audio.SetFloat("SoundsVolume", volume);
            sliderVolumeSound.value = volume;
            if (volume == -40f)
            {
                toggleSound.isOn = false;
            }
            else
            {
                toggleSound.isOn = true;
            }
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("VolumeSound", volume);
        }

        private void Load()
        {
            volume = PlayerPrefs.GetFloat("VolumeSound", volume);
        }
    }
}