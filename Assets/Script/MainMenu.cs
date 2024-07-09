using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        PlayerPrefs.SetInt("StartNewGame", 1);
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            PlayerPrefs.SetInt("StartNewGame", 0);
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Không có dữ liệu lưu");
        }
    }

    //private IEnumerator SetPlayerPosition(Vector3 position)
    //{
    //    yield return new WaitForEndOfFrame();
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");
    //    if (player != null)
    //    {
    //        player.transform.position = position;
    //    }
    //}
    public void QuitGame()
    {
        Application.Quit();
    }
}
