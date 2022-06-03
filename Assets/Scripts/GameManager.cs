using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int timeToEnd;
    public int points = 0;
    public int redKey = 0;
    public int goldKey = 0;
    public int greenKey = 0;

    AudioSource audioSource;  
    public AudioClip pauseGameClip;
    public AudioClip resumeGameClip;
    public AudioClip loseClip;
    public AudioClip winClip;
    
    MusicManager musicManager;
    bool isLessTimeOn = false;

    public GameObject pickupPanel;
    public GameObject snowflakeImage;
    public Text clockText;
    public Text coinText;
    public Text keyRedText;
    public Text keyGoldText;
    public Text keyGreenText;

    void ResetUI()
    {
        pickupPanel.SetActive(true);
        snowflakeImage.SetActive(false);
        clockText.text = "0";
        coinText.text = "0";
        keyRedText.text = "0";
        keyGoldText.text = "0";
        keyGreenText.text = "0";
    }

    void Start()
    {
        if (gameManager== null)
        {
            gameManager = this;
        }

        if(timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 2, 1);

        ResetUI();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PlayClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PauseGame()
    {
        musicManager.OnGamePaused();
        PlayClip(pauseGameClip);
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        musicManager.OnGameResumed();
        PlayClip(resumeGameClip);
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void LessTimeOn()
    {
        musicManager.Pitch(1.5f);
    }

    public void LessTimeOff()
    {
        musicManager.Pitch(1f);
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");

        if(timeToEnd <= 20 && !isLessTimeOn)
        {
            isLessTimeOn = true;
            LessTimeOn();
        }

        if (timeToEnd > 20 && isLessTimeOn)
        {
            isLessTimeOn = false;
            LessTimeOff();
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
            EndGame();
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        musicManager.OnGamePaused();
        if (win)
        {
            PlayClip(winClip);
            Debug.Log("You win! Reload?");
        }
        else
        {
            PlayClip(loseClip);
            Debug.Log("You lose! Reload?");
        }
    }

    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddTime(int time)
    {
        timeToEnd+=time;
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);
    }

    public void AddKey(KeyColor keyColor)
    {
        switch(keyColor)
        {
            case KeyColor.Red:
                redKey++;
                break;
            case KeyColor.Green:
                greenKey++;
                break;
            case KeyColor.Gold:
                goldKey++;
                break;
        }
    }
}