using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{
    public GameObject player; 
    public void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");
            player.transform.position = new Vector3(x, y, z);
            Debug.Log("Player position loaded.");
        }
        else
        {
            Debug.Log("No saved position found.");
        }
    }
}
