using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float speed = 3f; //Player ba�lang�� h�z�
    Rigidbody rb;
    Vector3 direction = Vector3.forward; //player�n hareketinin y�n�
    public float difficult = 0.03f; //zaman ge�tik�e player�n h�z� artmas� katsay�s�

    [Header("GameManager")]
    public GroundSpawner groundSpawner; // Ground Make e ula�mak i�in ground spawner scripti

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

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(Desttroy(collision.gameObject));
            groundSpawner.GroundMake(); // ife her girdi�inde arkadan 1 ground destroy �ne 1 ground make yap�cak.
        }
    }

    IEnumerator Desttroy(GameObject groundparam)
    {
        yield return new WaitForSeconds(0.2f);
        groundparam.AddComponent<Rigidbody>(); //0.2 sn bekleyip rigidbody ekliyoruzki gravitye maruz kal�p d��me animasyonu olu�sun.

        yield return new WaitForSeconds(0.4f);
        Destroy(groundparam); // 0.4 sn bekleyip destroyluyoruz.
    }
}//class
