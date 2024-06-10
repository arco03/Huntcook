using System;
using System.Collections;
using System.Runtime.CompilerServices;
using _Scripts.Player;
using MoreMountains.Tools;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace _Scripts.Tutorial
{
    public class Tutorial : MonoBehaviour
    {
        public GameObject panel;
        public GameObject letter;
        public GameObject instructor;
        public GameObject ghostInstructor;
        public GameObject play;
        public Character character;
        public Player.Player player;
        public detectorChef detectorChef;
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;
        private float _x, _z;
        
        public void Start()
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
        }

        public void Update()
        {
            _x = Input.GetAxisRaw(horizontal);
            _z = Input.GetAxisRaw(vertical);
            if (_x !=0 || _z !=0)
            {
                Time.timeScale = 1f;
                panel.SetActive(false);
            }

            if (detectorChef.detector)
            {
                Time.timeScale = 0f;
                letter.SetActive(true);
                if (player.tutorial)
                {
                    Time.timeScale = 1f;
                    letter.SetActive(false);
                    instructor.SetActive(true);
               

                }
            }

            if (detectorChef.detectorPlate)
            {
                instructor.SetActive(false);
            }
            if (detectorChef.detectorGhost)
            {
                ghostInstructor.SetActive(true);
                Time.timeScale = 0f;
                
                
            }

            if (character.isAttacking)
            {
                ghostInstructor.SetActive(false);
                Time.timeScale = 1f;
                play.SetActive(true);
                Invoke("Play",2f);
            }

        }
        public void Play()
        {
            SceneManager.LoadScene("Level 1");
        }

    }
}