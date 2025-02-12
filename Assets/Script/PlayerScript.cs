using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void EnablePlayerAfterDelay(GameObject player, float delay)
    {
        StartCoroutine(EnableAfterDelay(player, delay));
    }

    private IEnumerator EnableAfterDelay(GameObject player, float delay)
    {
        yield return new WaitForSeconds(delay);
        player.SetActive(true);
    }
}
