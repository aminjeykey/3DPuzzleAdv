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
        _Instance = this;
        DontDestroyOnLoad(this.gameObject);
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

    // loads next level
    public void LoadNextLevel()
    {
        if (sceneIndex >= 2)
        {
            sceneIndex = -1;
        }
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex);
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
