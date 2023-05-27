using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    //Game Settings
    public float WorldSpeed = 0.2f;
    private float score;
    private int coins;

    //References
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public GameObject gameOverPanel;

    //Powerups
    public bool MagnetActive { get; private set; }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        score += WorldSpeed;
        scoreText.text = score.ToString("n0");
    }

    public void CollectMagnet()
    {
        MagnetActive = true;
    }

    public void CollectCoin()
    {
        coins++;
        coinsText.text = coins.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        Time.timeScale = 1;
    }
}
