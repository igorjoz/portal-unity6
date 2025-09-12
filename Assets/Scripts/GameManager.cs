using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    int timeToEnd;

    bool isGamePaused = false;

    bool isGameEnd = false;
    bool isWin = false;

    public void EndGame()
    {
        CancelInvoke("Stopper");

        if (isWin)
        {
            Debug.Log("You won!");
        }
        else
        {
            Debug.Log("You lost");
        }
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + "s");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;

            isGameEnd = true;
        }

        if (isGameEnd)
        {
            EndGame();
        }
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 10;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    void Update()
    {
        PauseCheck();
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game paused");
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game resumed");
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}
