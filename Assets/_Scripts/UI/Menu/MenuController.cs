using _Scripts.Audio;
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
        [SerializeField] private AudioManager audioManager;
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
            audioManager.PlaySfx("Button");
            menuPanel.SetActive(false);
            optionPanel.SetActive(true);
            creditPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }
        
        public void Controls()
        {
            
            audioManager.PlaySfx("Button");
            menuPanel.SetActive(false);
            optionPanel.SetActive(false);
            creditPanel.SetActive(false);
            controlsPanel.SetActive(true);
        }

        public void Credits()
        {
            audioManager.PlaySfx("Button");

            menuPanel.SetActive(false);
            optionPanel.SetActive(false);
            creditPanel.SetActive(true);
            controlsPanel.SetActive(false);
        }

        public void Back()
        {
            audioManager.PlaySfx("Button");

            menuPanel.SetActive(true);
            optionPanel.SetActive(false);
            creditPanel.SetActive(false);
            controlsPanel.SetActive(false);
        }

        public void Quit()
        {
            audioManager.PlaySfx("Button");

            Application.Quit();
            Debug.Log("Quit Game");
        }
    }
}