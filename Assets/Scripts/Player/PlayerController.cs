using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float speed = 3f; //Player ba�lang�� h�z�
    Vector3 direction = Vector3.forward; //player�n hareketinin y�n�
    public float difficult = 0.03f; //zaman ge�tik�e player�n h�z� artmas� katsay�s�
    public bool jump = false; //Z�plama boolu
    public bool slide = false; //slide boolu

    [Header("GameManager")]
    //public GroundSpawner groundSpawner; // Ground Make e ula�mak i�in ground spawner scripti
    public float leftBoundary = -3f; //Player�n sola max ne kadar gidebilece�i default -1.5f
    public float rightBoundary = 3f; //Player�n sa�a max ne kadar gidebilece�i default 1.6f
    public float leftRightSpeed = 4f; //Sa�a sola gitme h�z� default 5
    public Animator anim;
    private int score = 0; //coin score
    public int xScore = 5;//coin al�nd���nda scorun ka� artmas� gereken de�i�keni
    //Rigidbody rb;



    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
        else
            jump = false;


        if (Input.GetKeyDown(KeyCode.DownArrow))
            slide = true;
        else
            slide = false;

        if (jump == true)
        {
            anim.SetBool("isJump", jump);
            transform.Translate(0, 0f, 0.1f);
        }
        else if(jump == false)
        {
            anim.SetBool("isJump", jump);
        }


        if (slide == true)
        {
            anim.SetBool("isSlide", slide);
            transform.Translate(0, 0f, 0.1f);
        }
        else if (slide == false)
        {
            anim.SetBool("isSlide", slide);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * speed * Time.deltaTime; //hareket de�eri
        speed += Time.deltaTime * difficult; //zorluk katsay�s�n� speede ekliyoruz.
        transform.position += movement; //hareket de�erini s�rekli pozisyona ekler

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftBoundary)
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * 1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightBoundary)
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
        }
    }

    #region groundExit
    /*
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
    */
    #endregion

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            score += xScore;
            Debug.Log(score);
            Destroy(other.gameObject);
        }
    }
}//class
