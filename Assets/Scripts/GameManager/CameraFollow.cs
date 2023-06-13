using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position; //Kamera ile player aras�ndaki mesafeyi offsete e�itledik
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset; //kamera pozisyonunu player�n + offset e e�itleyip bunu her framede yap�p mesafeyi ayn� tutuyoruz.
    }
}
