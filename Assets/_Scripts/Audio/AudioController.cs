using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Scripts.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider musicSlider;

        private void Start()
        {
            if (PlayerPrefs.HasKey("musicVolume"))
            {
                LoadVolume();
            }
            else
            {
                SetMusicVolume();
            }
        }

        private void LoadVolume()
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            SetMusicVolume();
        }

        public void SetMusicVolume()
        {
            float volume = musicSlider.value;
            audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }
    }
}