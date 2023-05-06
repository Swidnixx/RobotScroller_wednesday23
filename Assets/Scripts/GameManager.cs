using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void FixedUpdate()
    {
        score += WorldSpeed;
        scoreText.text = score.ToString("n0");
    }

    public void CollectCoin()
    {
        coins++;
    }
}
