using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Test
{
    public class Timer : MonoBehaviour
    {
        public float timer = 0f;
        public TextMeshProUGUI textoTimer;
        
        
        void Update()
        {
            timer -= Time.deltaTime;
            textoTimer.text = "" + timer.ToString("f0");
        
            if(timer <= 0f)
            {
                SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            }
        }
    }
}