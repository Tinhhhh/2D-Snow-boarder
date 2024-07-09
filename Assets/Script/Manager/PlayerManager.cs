using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private TMP_Text extralifeDisplay;
    [SerializeField] private GameObject pauseButton;
    public static PlayerManager instance;
    private ScoreManager scoreManager;
    private HighestScoreManager highestScoreManager;
    //private UIManager uiManager;
    public bool isAlive = true;

    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        scoreManager = ScoreManager.instance;
        highestScoreManager = HighestScoreManager.instance;
        //uiManager = UIManager.Instance;
        this.player = GameObject.Find("Player");
        this.player.SetActive(true);
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void SetAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

}
