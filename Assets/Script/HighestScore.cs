using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighestScore : MonoBehaviour
{

    private PlayerScript player;

    public TextMeshProUGUI ScoreText;
    public float Score;

    public TextMeshProUGUI HighScoreText;

    public float Highscore;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(IncreaseCoinsOverTime());
        player = FindObjectOfType<PlayerScript>();
        if (PlayerPrefs.HasKey("Highscore"))
        {
            Highscore = PlayerPrefs.GetFloat("Highscore");
        }
        else
        {
            Highscore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreText.text = Highscore.ToString();
        ScoreText.text = Score.ToString();

        if (player == null)
        {
            SaveHighScore();
        }

    }
    public void SaveHighScore()
    {
        if (Score > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", Score);
        }
    }
    //public void ChangeCoins(int amount)
    //{
    //    Score += amount;
    //    if (Score <= 0)
    //    {
    //        Score = 0;
    //    }
    //}

    //private IEnumerator IncreaseCoinsOverTime()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(2f); // Chờ 2 giây
    //        ChangeCoins(50); // Tăng 50 điểm
    //    }
    //}
}
