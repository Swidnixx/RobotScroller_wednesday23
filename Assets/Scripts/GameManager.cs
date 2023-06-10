using System;
using TMPro;
using UnityEngine;
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
    public TextMeshProUGUI magnetTimerText;
    public GameObject powerupsPanelUI;

    //Powerups
    public bool MagnetActive { get; private set; }
    public float magnetDuration = 10;
    float timerMagnet;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        powerupsPanelUI.SetActive(false);
    }

    private void Update()
    {
        if(MagnetActive)
        {
            timerMagnet -= Time.deltaTime;
            magnetTimerText.text = timerMagnet.ToString("n0");
        }
    }

    private void FixedUpdate()
    {
        score += WorldSpeed;
        scoreText.text = score.ToString("n0");
    }

    #region Pickups
    public bool BatteryActive { get; private set; }
    public void CollectBattery()
    {
        CancelInvoke(nameof(BatteryOff));
        if (!BatteryActive)
            WorldSpeed += 0.05f;

        BatteryActive = true;
        Invoke(nameof(BatteryOff), 10);
    }
    void BatteryOff()
    {
        WorldSpeed -= 0.05f;
        BatteryActive = false;
    }

    public void CollectMagnet()
    {
        powerupsPanelUI.SetActive(true);
        timerMagnet = magnetDuration;
        CancelInvoke(nameof(MagnetOff));
        MagnetActive = true;

        Invoke(nameof(MagnetOff), magnetDuration);
    }
    void MagnetOff()
    {
        MagnetActive = false;
        timerMagnet = 0;
        powerupsPanelUI.SetActive(false);
    }
    public void CollectCoin()
    {
        coins++;
        coinsText.text = coins.ToString();
    }
    #endregion

    #region GameFlow
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
    #endregion
}
