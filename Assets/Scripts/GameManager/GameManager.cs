using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public CameraFollow cameraFollow;

    private void Start()
    {
        cameraFollow.target = playerController.transform;
    }

}//class
