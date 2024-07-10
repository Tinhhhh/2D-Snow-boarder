using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInstance : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera vcam;

    public static CameraInstance instance;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        vcam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    public void ChangeCameraFocus(){
        vcam.Follow = GameObject.FindGameObjectWithTag("FinishGame").transform;
    }
}
