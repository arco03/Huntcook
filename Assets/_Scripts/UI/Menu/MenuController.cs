﻿using _Scripts.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.UI.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject optionPanel;
        [SerializeField] private GameObject creditPanel;
        [SerializeField] private GameObject controlsPanel;
        private void Awake()
        {
            menuPanel.SetActive(true);
            optionPanel.SetActive(false);
            creditPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }

        public void Play(string nameScene)
        {
            SceneManager.LoadScene(nameScene);
        }

        public void Options()
        {
            AudioManager.instance.PlaySfx("Button");
            menuPanel.SetActive(false);
            optionPanel.SetActive(true);
            creditPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }
        
        public void Controls()
        {
            AudioManager.instance.PlaySfx("Button");
            
            menuPanel.SetActive(false);
            optionPanel.SetActive(false);
            creditPanel.SetActive(false);
            controlsPanel.SetActive(true);
        }

        public void Credits()
        {
            AudioManager.instance.PlaySfx("Button");
            menuPanel.SetActive(false);
            optionPanel.SetActive(false);
            creditPanel.SetActive(true);
            controlsPanel.SetActive(false);
        }

        public void Back()
        {
            AudioManager.instance.PlaySfx("Button");
            menuPanel.SetActive(true);
            optionPanel.SetActive(false);
            creditPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }

        public void Quit()
        {
            AudioManager.instance.PlaySfx("Button");
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }
}