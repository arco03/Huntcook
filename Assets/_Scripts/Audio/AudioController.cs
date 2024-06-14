using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Scripts.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {
            if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("sfxVolume"))
            {
                LoadVolume();
            }
            else
            {
                SetMusicVolume();
                SetSfxVolume();
            }
        }

        private void LoadVolume()
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
            SetMusicVolume();
            SetSfxVolume();
        }

        public void SetMusicVolume()
        {
            float volume = musicSlider.value;
            audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }
        public void SetSfxVolume()
        {
            float volume = sfxSlider.value;
            audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("sfxVolume", volume);
        }
    }
}