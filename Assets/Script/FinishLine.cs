using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has reached the finish line!");
            CameraInstance.instance.ChangeCameraFocus();
            ScoreManager.instance.isPlaying = false;
            HighestScoreManager.instance.HighestScoreUpdate();
            StartCoroutine(AfterDead());
        }
    }

    public IEnumerator AfterDead(){
        yield return new WaitForSeconds(2f);
        //Show Win game screen
        Debug.Log("You have won the game!");
    }
}
