using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCarController : MonoBehaviour
{
    public float botSpeed = 2f; //bot hareket h�z�
    Vector3 botDirection = Vector3.forward * -1; //bot hareket y�n�

    private void FixedUpdate()
    {
        Vector3 botMovement = botDirection * botSpeed * Time.deltaTime; //botlar�n hareket de�eri
        transform.position += botMovement; //botun hareket de�erini s�rekli pozisyona ekler.
    }

}//class
