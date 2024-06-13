using System;
using UnityEngine;

namespace _Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        
        public Sound[] MusicSounds;
        public AudioSource musicSource;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            PlayMusic("Menu");
        }

        public void PlayMusic(string name)
        {
            Sound sound = Array.Find(MusicSounds, x => x.name == name);

            if (sound == null)
            {
                Debug.Log("Sound not Found");
            }
            else
            {
                musicSource.clip = sound.clip;
                musicSource.Play();
            }
        }
    }
}