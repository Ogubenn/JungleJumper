using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCarController : MonoBehaviour
{
    public float botSpeed = 2f; //bot hareket hýzý
    Vector3 botDirection = Vector3.forward * -1; //bot hareket yönü

    private void FixedUpdate()
    {
        Vector3 botMovement = botDirection * botSpeed * Time.deltaTime; //botlarýn hareket deðeri
        transform.position += botMovement; //botun hareket deðerini sürekli pozisyona ekler.
    }

}//class
