using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text goldKeysText;
    public TMP_Text redKeysText;
    public TMP_Text greenKeysText;
    public TMP_Text CrystalText;

    public GameObject gamePanel;
    public GameObject infoPanel;
    public TMP_Text InfoPanelText;
    public TMP_Text GamePanelText;


    public static GameManager instance;
    AudioSource audioSource;

    [SerializeField]
    int timeToEnd;

    bool isGamePaused = false;

    bool isGameEnd = false;
    bool isWin = false;

    int diamonds;

    public int goldKeys;
    public int greenKeys;
    public int redKeys;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip pickupClip;

    public void AddDiamond()
    {
        diamonds++;
        CrystalText.text = diamonds.ToString();
    }
    

    public void AddTime(int timeToAdd)
    {
        timeToEnd += timeToAdd;
        if(timeToEnd < 0) timeToEnd = 0;
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        infoPanel.SetActive(true);

        if (isWin)
        {
            PlayClip(winClip);
            Debug.Log("You won!");
            InfoPanelText.text = "Win!";
        }
        else
        {
            PlayClip(loseClip);
            Debug.Log("You lost");
            InfoPanelText.text = "Loser c:";
        }
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + "s");
        timeText.text = timeToEnd.ToString();

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

        timeText.text = timeToEnd.ToString();
        infoPanel.SetActive(false);
        gamePanel.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 2, 1);
    }

    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Gold:
                goldKeys++;
                goldKeysText.text = goldKeys.ToString();
                break;
            case KeyColor.Green:
                greenKeys++;
                greenKeysText.text = greenKeys.ToString();
                break;
            case KeyColor.Red:
                redKeys++;
                redKeysText.text = redKeys.ToString();
                break;
        }
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
        PlayClip(pauseClip);
        Debug.Log("Game paused");
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        PlayClip(resumeClip);
        Debug.Log("Game resumed");
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void FreezeTime(int time)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", time, 1);
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayPickupClip()
    {
        PlayClip(pickupClip);
    }

    public void WinGame()
    {
        isWin = true;
        isGameEnd = true;
    }
}
