using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public bool isStarted;
    public int score = 0;
    public int highScore;
    public int savedScore;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text highScoreText, highScoreBanner;

    [SerializeField] float scoreIncreasePerSecond = 50f;
    [SerializeField] GameObject levelStart, levelRestart;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] ParticleSystem firework1, firework2, firework3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        backgroundMusic.Play();
        isStarted = true;
        levelStart.SetActive(false);
    }

    public void GameOver()
    {
        backgroundMusic.Stop();
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        isStarted = false;
        levelRestart.SetActive(true);
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        StopAllCoroutines();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ScoreIncrease()
    {
        score += Mathf.RoundToInt(scoreIncreasePerSecond * Time.deltaTime);
        currentScoreText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            highScoreBanner.text = "!! NEW  HIGH  SCORE !!";
            PlayerPrefs.SetInt("HighScore", score);

        }

    }

}
