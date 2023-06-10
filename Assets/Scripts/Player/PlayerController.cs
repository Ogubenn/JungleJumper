using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 3f; //Player baþlangýç hýzý
    Rigidbody rb;
    Vector3 direction = Vector3.forward;
    public float difficult = 0.03f; //zaman geçtikçe playerýn hýzý artmasý katsayýsý

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * speed * Time.deltaTime; //hareket deðeri
        speed += Time.deltaTime * difficult; //zorluk katsayýsýný speede ekliyoruz.
        transform.position += movement; //hareket deðerini sürekli pozisyona ekler
    }
}//class
