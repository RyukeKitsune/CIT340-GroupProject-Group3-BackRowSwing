using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine.Utility;
using Cinemachine;

public class CameraTransition : MonoBehaviour
{
    public CinemachineVirtualCamera cameraList;
    public CinemachineBrain mainCameraBrain;

    private ICinemachineCamera currentCamera;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            currentCamera = mainCameraBrain.ActiveVirtualCamera;
            if (currentCamera != cameraList)
            {
                currentCamera.VirtualCameraGameObject.SetActive(false);
                cameraList.VirtualCameraGameObject.SetActive(true);
            }
        }
    }
}
