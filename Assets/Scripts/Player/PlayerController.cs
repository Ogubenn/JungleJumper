using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float speed = 3f; //Player baþlangýç hýzý
    Vector3 direction = Vector3.forward; //playerýn hareketinin yönü
    public float difficult = 0.03f; //zaman geçtikçe playerýn hýzý artmasý katsayýsý
    public bool jump = false; //Zýplama boolu
    public bool slide = false; //slide boolu

    [Header("GameManager")]
    //public GroundSpawner groundSpawner; // Ground Make e ulaþmak için ground spawner scripti
    public float leftBoundary = -3f; //Playerýn sola max ne kadar gidebileceði default -1.5f
    public float rightBoundary = 3f; //Playerýn saða max ne kadar gidebileceði default 1.6f
    public float leftRightSpeed = 4f; //Saða sola gitme hýzý default 5
    public Animator anim;
    private int score = 0; //coin score
    public int xScore = 5;//coin alýndýðýnda scorun kaç artmasý gereken deðiþkeni
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
        Vector3 movement = direction * speed * Time.deltaTime; //hareket deðeri
        speed += Time.deltaTime * difficult; //zorluk katsayýsýný speede ekliyoruz.
        transform.position += movement; //hareket deðerini sürekli pozisyona ekler

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
