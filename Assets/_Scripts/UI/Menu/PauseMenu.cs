using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace _Scripts.UI.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuPause;
        [SerializeField] public GameObject pause;
        
        public void Pause()
        {
            Time.timeScale = 0f;
            pause.SetActive(false);
            menuPause.SetActive(true);
        }
        public void Resume()
        {
            Time.timeScale = 1f;
            pause.SetActive(true);
            menuPause.SetActive(false);
        }
        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}