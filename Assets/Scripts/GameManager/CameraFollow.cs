using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Kamera")]
    public Transform target; // Arabanýn transform bileþeni
    public float distance = 1f; // Kamera ile araba arasýndaki mesafe
    public float height = 5f; // Kamera yüksekliði
    public float smoothSpeed = 0.5f; // Kamera hareketinin yumuþaklýðý

    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0f, height, -distance); // KAmera ile araba arasýndaki baþlangýç mesafesini hesaplar
    }

    private void LateUpdate()
    {
        // Arabayý takip etmek için hedef pozisyonu belirler

        Vector3 targetPosition = target.position + offset;

        // Kamerayý hedef pozisyona doðru hareket ettirir

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target); // Arabayý hedef alýr

        //Kamerayý ayný açýda tutmak için

        Vector3 euler = transform.rotation.eulerAngles;
        euler.z = 0f;
        euler.y = 0f;
        euler.x = 0f;
        transform.rotation = Quaternion.Euler(euler);
    }
}
