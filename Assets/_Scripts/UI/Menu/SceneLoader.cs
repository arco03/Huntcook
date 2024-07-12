using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.UI.Menu
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;
        
        [SerializeField] private float time;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
        IEnumerator MakeTheLoad(string level)
        {
            yield return new WaitForSeconds(time);

            AsyncOperation operation = SceneManager.LoadSceneAsync(level);
            while (!operation!.isDone)
            {
                yield return null;
            }
        }
        
        public void LoadLevel(string sceneName, string loadScene)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(loadScene);
            StartCoroutine(MakeTheLoad(sceneName));
        }
    }
}