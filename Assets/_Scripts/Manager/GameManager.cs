using System;
using UnityEngine;

namespace _Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            Game,
            Win,
            GameOver
        }
        public GameState CurrentState { get; private set; }

        private void OnEnable()
        {
            TimeManager.OnTimeOver += HandleGameOver;
            DishManager.OnDishComplete += HandleWin;
        }
        private void Start()
        {
            ChangeState(GameState.Game);
        }
        
        private void HandleGameOver()
        {
            ChangeState(GameState.GameOver);
        }

        private void HandleWin()
        {
            ChangeState(GameState.Win);
            Debug.Log($"ganaste{CurrentState}");
        }
        
        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
            Debug.Log($"Game State change to: {newState}");
        }
        
        private void OnDisable()
        {
            TimeManager.OnTimeOver -= HandleGameOver;
            DishManager.OnDishComplete -= HandleWin;
        }
        
    }
}
