using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ContinueButton;

    void Awake()
    {
        this.ContinueButton = GameObject.Find("LoadButton");

        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            // Co du lieu
            this.ContinueButton.SetActive(true);
        }
        else
        {
            // Khong co du lieu
            this.ContinueButton.SetActive(false);
        }
    }

    public void PlayButton()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("PlayerX");
        PlayerPrefs.DeleteKey("PlayerY");
        PlayerPrefs.DeleteKey("PlayerZ");
        PlayerPrefs.SetInt("StartNewGame", 1);
        SceneManager.LoadSceneAsync(1);

    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            PlayerPrefs.SetInt("StartNewGame", 0);
            Debug.Log("Có dữ liệu lưu");
            PlayerPrefs.SetInt("continue", 0);
            SceneManager.LoadScene(1);
            PauseMenu.instance.Resume();
        }
        else
        {
            Debug.Log("Không có dữ liệu lưu");
        }
    }

    public void RenewHighScore()
    {
        PlayerPrefs.SetInt("HighestScore", 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
