using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    int timeToEnd;

    bool isGamePaused = false;

    bool isGameEnd = false;
    bool isWin = false;

    int diamonds;

    public int goldKeys;
    public int greenKeys;
    public int redKeys;

    AudioSource audioSource;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip pickupClip;

    public void PlayPickupClip()
    {
        PlayClip(pickupClip);
    }

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
    }

    public void AddDiamond()
    {
        diamonds++;
    }
    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Gold:
                goldKeys++;
                break;
            case KeyColor.Green:
                greenKeys++;
                break;
            case KeyColor.Red:
                redKeys++;
                break;
        }
    }

    public void AddTime(int timeToAdd)
    {
        timeToEnd += timeToAdd;
        if(timeToEnd < 0) timeToEnd = 0;
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");

        if (isWin)
        {
            Debug.Log("You won!");
            PlayClip(winClip);
        }
        else
        {
            Debug.Log("You lost");
            PlayClip(loseClip);
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
        audioSource = GetComponent<AudioSource>();
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
        PlayClip(pauseClip);
    }

    public void ResumeGame()
    {
        Debug.Log("Game resumed");
        Time.timeScale = 1f;
        isGamePaused = false;
        PlayClip(resumeClip);
    }

    public void FreezeTime(int time)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", time, 1);
    }
}
