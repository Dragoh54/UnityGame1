using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu
{
    public class MusicSettings : MonoBehaviour
    {
        [Header("UI")] 
        public Toggle toggleMusic;
        public Slider sliderVolumeMusic;

        [Header("Game objects")]
        public new AudioMixer audio;

        [Header("VolumeMusic")] public float volume;

        private void Awake()
        {
            Load();
        }

        private void Start()
        {
            ValueMusic();
        }

        public void SliderMusic()
        {
            volume = sliderVolumeMusic.value;
            Save();
            ValueMusic();
        }

        public void ToggleMusic()
        { 
            if (toggleMusic.isOn)
            {
                volume = 0f;
            }
            else
            {
                volume = -40f;
            }
            Save();
            ValueMusic();
        }

        private void ValueMusic()
        {
            audio.SetFloat("MusicVolume", volume);
            sliderVolumeMusic.value = volume;
            if (volume == -40f)
            {
                toggleMusic.isOn = false;
            }
            else
            {
                toggleMusic.isOn = true;
            }
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("VolumeMusic", volume);
        }

        private void Load()
        {
            volume = PlayerPrefs.GetFloat("VolumeMusic", volume);
        }
    }
}