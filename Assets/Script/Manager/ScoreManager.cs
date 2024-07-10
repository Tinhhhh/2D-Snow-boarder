using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TMP_Text scoreDisplay;
    private PlayerManager playerManager;
    public int score;
    public bool isPlaying = true;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        else
        {
            score = 0;
        }

    }

    void Update()
    {
        if (playerManager.IsAlive())
        {
            scoreDisplay.text = score.ToString();
        }
    }

    private void Start()
    {
        // Bắt đầu Coroutine để tăng điểm mỗi 2 giây
        StartCoroutine(IncreaseCoinsOverTime());
        playerManager = PlayerManager.instance;
    }

    public void ChangeCoins(int amount)
    {
        if (isPlaying)
        {
            score = Getscore() + amount;
            if (score <= 0)
            {
                score = 0;
            }
        }
    }

    public int Getscore()
    {
        return score;
    }

    private IEnumerator IncreaseCoinsOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Chờ 2 giây
            if (playerManager.IsAlive())
            {
                ChangeCoins(50); // Tăng 50 điểm
            }
        }

    }

}
