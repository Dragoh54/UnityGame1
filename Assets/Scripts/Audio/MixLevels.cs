using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Audio
{
    public class MixLevels : MonoBehaviour
    {
        [Header("Audio")]
        public AudioMixer audioMixer;
        public float musicVolume;
        public float soundsVolume;
        
        [Header("UI")]
        public Slider sliderVolumeSound;
        public Slider sliderVolumeMusic;
        public Toggle toggleSound;
        public Toggle toggleMusic;

        private void Awake()
        {
            LoadMusic();
            LoadSound();
        }

        private void Start()
        {
            SlideMusic();
            SlideSound();
            
            CheckSoundToggle();
            CheckMusicToggle();
        }

        private void Update()
        {
            CheckSoundToggle();
            CheckMusicToggle();
        }

        public void SetSoundLvl(float soundLvl)
        {
            audioMixer.SetFloat("SoundsVolume", soundLvl);
            SaveSound(soundLvl);
            soundsVolume = soundLvl;
            CheckSoundToggle();
        }

        public void SetMusicLvl(float musicLvl)
        {
            audioMixer.SetFloat("MusicVolume", musicLvl);
            SaveMusic(musicLvl);
            musicVolume = musicLvl;
            CheckMusicToggle();
        }

        public void TurnOffMusic()
        {
            if (toggleMusic.isOn)
            {
                SetMusicLvl(0f);
            }
            else
            {
                SetMusicLvl(-40f);
            }
            SlideMusic();
        }
        
        public void TurnOffSound()
        {
            if (toggleSound.isOn)
            {
                SetSoundLvl(0f);
            }
            else
            {
                SetSoundLvl(-40f);
            }
            SlideSound();
        }

        private void SaveSound(float volume)
        {
            PlayerPrefs.SetFloat("VolumeSound", volume);
        }

        private void LoadSound()
        {
            soundsVolume = PlayerPrefs.GetFloat("VolumeSound", soundsVolume);
        }
        
        private void SaveMusic(float volume)
        {
            PlayerPrefs.SetFloat("MusicVolume", volume);
        }

        private void LoadMusic()
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", musicVolume);
        }
        
        private void SlideSound()
        {
            sliderVolumeSound.value = soundsVolume;
        }
        
        private void SlideMusic()
        {
            sliderVolumeMusic.value = musicVolume;
        }

        private void CheckMusicToggle()
        {
            if (musicVolume == -40f)
            {
                    toggleMusic.isOn = false;
            }
            else
            {
                toggleMusic.isOn = true;
            }
        }
        
        private void CheckSoundToggle()
        {
            if (soundsVolume == -40f)
            {
                toggleSound.isOn = false;
            }
            else
            {
                toggleSound.isOn = true;
            }
        }
    }
}