using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Kamera")]
    public Transform target; // Araban�n transform bile�eni
    public float distance = 1f; // Kamera ile araba aras�ndaki mesafe
    public float height = 5f; // Kamera y�ksekli�i
    public float smoothSpeed = 0.5f; // Kamera hareketinin yumu�akl���

    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0f, height, -distance); // KAmera ile araba aras�ndaki ba�lang�� mesafesini hesaplar
    }

    private void LateUpdate()
    {
        // Arabay� takip etmek i�in hedef pozisyonu belirler

        Vector3 targetPosition = target.position + offset;

        // Kameray� hedef pozisyona do�ru hareket ettirir

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target); // Arabay� hedef al�r

        //Kameray� ayn� a��da tutmak i�in

        Vector3 euler = transform.rotation.eulerAngles;
        euler.z = 0f;
        euler.y = 0f;
        euler.x = 0f;
        transform.rotation = Quaternion.Euler(euler);
    }
}
