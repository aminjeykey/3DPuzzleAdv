using UnityEngine;
using UnityEngine.SceneManagement;

// The class responsible for handling the game state
public class GameManager : MonoBehaviour
{
    private int sceneIndex = 0;
    private static GameState gameState;
    private static PlayerState playerState = PlayerState.InProgress;
    private static GameManager _Instance;
    public static GameManager Instance
    {
        get 
        {
            return _Instance;
        } 
    }

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // enum for tracking which state the game is in
    public enum GameState 
    {
        InMenu,
        InGame,
        Paused
    }

    // enum for tracking which state the player is in
    public enum PlayerState
    {
        Qualified,
        InProgress,
        Finished
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void RestartGame()
    {
        LoadSceneByIndex(sceneIndex);
    }

    // loads next level
    public void LoadNextLevel()
    {
        if (sceneIndex >= 2)
        {
            sceneIndex = -1;
        }
        sceneIndex++;
        LoadSceneByIndex(sceneIndex);
        playerState = PlayerState.InProgress;
    }

    // calls LoadNextLevel() if player is qualified for exit
    public void FinishedLevel()
    {
        if (playerState == PlayerState.Qualified)
        {
            playerState = PlayerState.Finished;
            LoadNextLevel();
        }
    }

    // quits the game
    public void ExitGame()
    {
        Application.Quit();
    }

    // setter for playerstate
    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
    }
}
