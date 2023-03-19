using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Player player;
    public PlayerTail playertail;
    public LevelGenerator level;

    public GameObject CanvasLoss;
    public GameObject CanvasWin;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void PlayerDefeat()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        player.StopMovement();
        Points = 4;
        player.enabled = false;
        Debug.Log("Game over!");
        CanvasLoss.SetActive(true);
    }
    public void OnPlayerReachedFinish(int i)
    {
        if (CurrentState != State.Playing) return;
        player.StopMovement();
        Points = i;
        player.enabled = false;
        LevelIndex++;
        Debug.Log("You won!");
        CanvasWin.SetActive(true);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt("LevelIndexKey", 0);
        private set
        {
            PlayerPrefs.SetInt("LevelIndexKey", value);
            PlayerPrefs.Save();
        }
    }

    public int Points
    {
        get => PlayerPrefs.GetInt("Points", 4);
        set
        {
            PlayerPrefs.SetInt("Points", value);
            PlayerPrefs.Save();
        }
    }

    private const string NumPoints = "Points";
    private const string LevelIndexKey = "LevelIndex";

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
