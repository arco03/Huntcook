using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Test
{
    public class Restart : MonoBehaviour
    {
        public bool reiniciar = false;
        public string sceneName;
        void Update()
        {
            if (reiniciar)
            {
                // Reiniciar la escena sin cargarla nuevamente
                RestartScene();
                reiniciar = false;
            }
        }

        public void RestartScene()
        {
            // Obtener el nombre de la escena actual
            string currentSceneName = SceneManager.GetActiveScene().name;

            // Cargar la misma escena nuevamente de manera controlada
            SceneManager.LoadSceneAsync(currentSceneName);

            // Alternativamente, puedes usar SceneManager.LoadSceneAsync(currentSceneName) para carga asincrónica
        }
        public void Duplicar()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        
            // Cargar la nueva escena
            SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
            // string currentSceneName = SceneManager.GetActiveScene().name;
            // SceneManager.LoadScene(currentSceneName);
        }

        // Llamada desde un botón o cualquier otro evento
        public void BotonReiniciar()
        {
            reiniciar = true;
        }
    }
}