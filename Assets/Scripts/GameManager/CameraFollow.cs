using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position; //Kamera ile player arasýndaki mesafeyi offsete eþitledik
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset; //kamera pozisyonunu playerýn + offset e eþitleyip bunu her framede yapýp mesafeyi ayný tutuyoruz.
    }
}
