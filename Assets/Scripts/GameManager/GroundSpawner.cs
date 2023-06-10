using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject Ground;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GroundMake();
        }
    }

    void GroundMake()
    {
        Vector3 yon = Vector3.forward;
        Ground = Instantiate(Ground, Ground.transform.position + yon, Ground.transform.rotation);
    }

}//class
