using _Scripts.UI.Ingredient;
using _Scripts.UI.Recipe;
using _Scripts.UI.State;
using _Scripts.UI.Timer;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Manager
{
    // public class GameManager : MonoBehaviour
    // {
    //     public enum GameState
    //     {
    //         Game,
    //         Win,
    //         GameOver
    //     }
    //     
    //     public GameState CurrentState { get; private set; }
    //     [SerializeField] private StateController stateController;
    //     [SerializeField] private TimerController timerController;
    //     [SerializeField] private RecipeController recipeController;
    //     [SerializeField] private IngredientController ingredientListController;
    //
    //
    //     private void OnEnable()
    //     {
    //         TimeManager.OnTimeOver += HandleGameOver;
    //         DishManager.OnDishComplete += HandleWin;
    //     }
    //
    //     private void Start()
    //     {
    //         InitializeControllers();
    //         ChangeState(GameState.Game);
    //         Time.timeScale = 1;
    //     }
    //     private void InitializeControllers()
    //     {
    //         if (timerController != null)
    //         {
    //             timerController.Initialize();
    //         }
    //         if (recipeController != null)
    //         {
    //             recipeController.Initialize();
    //         }
    //         if (ingredientListController != null)
    //         {
    //             ingredientListController.Initialize();
    //         }
    //     }
    //     private void HandleGameOver()
    //     {
    //         ChangeState(GameState.GameOver);
    //         stateController.TimeOut();
    //     }
    //
    //     private void HandleWin()
    //     {
    //         ChangeState(GameState.Win);
    //         stateController.Win();
    //     }
    //
    //     private void ChangeState(GameState newState)
    //     {
    //         CurrentState = newState;
    //         Debug.Log($"Game State change to: {newState}");
    //     }
    //     
    //     public void ChangeScene(string nameScene)
    //     {
    //         Scene duplicatedScene = SceneManager.CreateScene("DuplicatedScene");
    //     }
    //
    //     public void ReloadScene()
    //     {
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //     }
    //     
    //     public void Quit()
    //     {
    //         Application.Quit();
    //         Debug.Log("Quit Game");
    //     }
    //     
    //     private void OnDisable()
    //     {
    //         TimeManager.OnTimeOver -= HandleGameOver;
    //         DishManager.OnDishComplete -= HandleWin;
    //     }
    // }


}
