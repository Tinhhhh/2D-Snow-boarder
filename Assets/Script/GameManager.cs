using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PauseMenu playerController;
    public GameObject player;
    public Vector3 startPosition;


    void Start()
    {
        if (PlayerPrefs.GetInt("StartNewGame", 1) == 1)
        {
            StartNewGame();
        }
        else if (PlayerPrefs.HasKey("PlayerX"))
        {
            LoadPlayerPosition();
        }
        PlayerPrefs.DeleteKey("StartNewGame");
    }

    void StartNewGame()
    {
        if (player != null)
        {
            player.transform.position = startPosition;
            player.transform.rotation = Quaternion.identity;
        }
    }

    void LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        float z = PlayerPrefs.GetFloat("PlayerZ");
        float rotation = PlayerPrefs.GetFloat("PlayerRotation");

        if (player != null)
        {
            player.transform.position = new Vector3(x, y, z);
            player.transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }
}
