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
    public GameObject magnetTimerPanel;
    public GameObject batteryTimerPanel;
    public TextMeshProUGUI batteryTimerText;

    //Powerups
    public bool BatteryActive { get; private set; }
    public bool MagnetActive { get; private set; }
    public float magnetDuration = 10;
    float timerMagnet;
    float timerBattery;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        magnetTimerPanel.SetActive(false);
        batteryTimerPanel.SetActive(false);
    }

    private void Update()
    {
        if(MagnetActive)
        {
            timerMagnet -= Time.deltaTime;
            magnetTimerText.text = timerMagnet.ToString("n2");
        }

        if(BatteryActive)
        {
            timerBattery -= Time.deltaTime;
            batteryTimerText.text = timerBattery.ToString("n2");
        }
    }

    private void FixedUpdate()
    {
        score += WorldSpeed;
        scoreText.text = score.ToString("n0");
    }

    #region Pickups
    public float batteryDuration = 10;
    public void CollectBattery()
    {
        batteryTimerPanel.SetActive(true);
        timerBattery = batteryDuration;

        CancelInvoke(nameof(BatteryOff));
        if (!BatteryActive)
            WorldSpeed += 0.05f;

        BatteryActive = true;
        Invoke(nameof(BatteryOff), batteryDuration);
    }
    void BatteryOff()
    {
        WorldSpeed -= 0.05f;
        BatteryActive = false;
        batteryTimerPanel.SetActive(false);
    }

    public void CollectMagnet()
    {
        magnetTimerPanel.SetActive(true);
        timerMagnet = magnetDuration;
        CancelInvoke(nameof(MagnetOff));
        MagnetActive = true;

        Invoke(nameof(MagnetOff), magnetDuration);
    }
    void MagnetOff()
    {
        MagnetActive = false;
        timerMagnet = 0;
        magnetTimerPanel.SetActive(false);
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
