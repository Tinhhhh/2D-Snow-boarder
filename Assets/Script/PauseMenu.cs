using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool PauseGame = false;
    public GameObject PauseMenuUI;
    public GameObject PlayerPosition;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SaveGame()
    {
        Vector3 playerPosition = PlayerPosition.transform.position;
        PlayerPrefs.SetFloat("PlayerX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerZ", playerPosition.z);
        PlayerPrefs.SetFloat("PlayerRotation", transform.rotation.eulerAngles.z);
        Debug.Log("Saved");
        PlayerPrefs.Save();
    }
    public void LoadPosition()
    {
        //if (PlayerPrefs.HasKey("PlayerX"))
        //{
        //    float x = PlayerPrefs.GetFloat("PlayerX");
        //    float y = PlayerPrefs.GetFloat("PlayerY");
        //    float z = PlayerPrefs.GetFloat("PlayerZ");
        //    float rotation = PlayerPrefs.GetFloat("PlayerRotation");

        //    transform.position = new Vector3(x, y, z);
        //    transform.rotation = Quaternion.Euler(0, 0, rotation);
        //}
    }
}
