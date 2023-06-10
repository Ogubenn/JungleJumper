using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 3f; //Player ba�lang�� h�z�
    Rigidbody rb;
    Vector3 direction = Vector3.forward;
    public float difficult = 0.03f; //zaman ge�tik�e player�n h�z� artmas� katsay�s�

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * speed * Time.deltaTime; //hareket de�eri
        speed += Time.deltaTime * difficult; //zorluk katsay�s�n� speede ekliyoruz.
        transform.position += movement; //hareket de�erini s�rekli pozisyona ekler
    }
}//class
