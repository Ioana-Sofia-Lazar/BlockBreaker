using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 63;
    [SerializeField] int pointsPerLevelWon = 200;
    [SerializeField] int pointsPerLifeNotUsed = 500;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled = false;
    [SerializeField] GameObject[] hearts; 

    [SerializeField] int currentScore = 0;
    [SerializeField] int livesLeft = 3;

    SceneLoader sceneLoader;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(String tag)
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void HandleLevelWon()
    {
        AddExtraPointsToScore(pointsPerLevelWon);
        if (sceneLoader.IsNextSceneWinScreen())
        {
            AddExtraPointsToScore(pointsPerLifeNotUsed * livesLeft);
        }

        sceneLoader.LoadNextScene();
    }

    public void HandleLevelLost()
    {
        livesLeft--;
        UpdateHearts();
        if (livesLeft == 0)
        {
            ResetGameSession();
        }
        else
        {
            ResetScene();
        }
    }

    private void AddExtraPointsToScore(int points)
    {
        currentScore += points;
        scoreText.text = currentScore.ToString();
    }

    private void ResetScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < livesLeft)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }         
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene("Game Over");
    }

}
