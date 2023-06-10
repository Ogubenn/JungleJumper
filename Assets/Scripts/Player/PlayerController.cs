using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float speed = 3f; //Player baþlangýç hýzý
    Rigidbody rb;
    Vector3 direction = Vector3.forward; //playerýn hareketinin yönü
    public float difficult = 0.03f; //zaman geçtikçe playerýn hýzý artmasý katsayýsý

    [Header("GameManager")]
    public GroundSpawner groundSpawner; // Ground Make e ulaþmak için ground spawner scripti

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

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(Desttroy(collision.gameObject));
            groundSpawner.GroundMake(); // ife her girdiðinde arkadan 1 ground destroy öne 1 ground make yapýcak.
        }
    }

    IEnumerator Desttroy(GameObject groundparam)
    {
        yield return new WaitForSeconds(0.2f);
        groundparam.AddComponent<Rigidbody>(); //0.2 sn bekleyip rigidbody ekliyoruzki gravitye maruz kalýp düþme animasyonu oluþsun.

        yield return new WaitForSeconds(0.4f);
        Destroy(groundparam); // 0.4 sn bekleyip destroyluyoruz.
    }
}//class
