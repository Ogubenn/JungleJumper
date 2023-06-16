using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Player")]
    [SerializeField] float speed = 3f; //Player ba�lang�� h�z�
    Vector3 direction = Vector3.forward; //player�n hareketinin y�n�
    public float difficult = 0.03f; //zaman ge�tik�e player�n h�z� artmas� katsay�s�
    public bool jump = false; //Z�plama boolu
    public bool slide = false; //slide boolu

    [Header("GameManager")]
    //public GroundSpawner groundSpawner; // Ground Make e ula�mak i�in ground spawner scripti
    public float leftBoundary = -3f; //Player�n sola max ne kadar gidebilece�i default -1.5f    //San�r�m art�k boundrayler gereksiz
    public float rightBoundary = 3f; //Player�n sa�a max ne kadar gidebilece�i default 1.6f //San�r�m art�k boundrayler gereksiz
    public float leftRightSpeed = 4f; //Sa�a sola gitme h�z� default 5
    public Animator anim;
    private int desiredLane = 1; //�erit say�s� 0 = left , 1 = mmiddle 2 = right
    public float laneDistance = 4; //�eritler aras� mesafe
    private int leftRightLerp = 10; //Sa�a ve sola ���nlanmalarda lerp�n ne kadar olmas� gerekti�i

    [Header("Coin")]
    public  int score = 0; //coin score
    public int xScore = 5;//coin al�nd���nda scorun ka� artmas� gereken de�i�keni
    [SerializeField] AudioSource coinSounds; //Coin sesi
    [SerializeField] TextMeshProUGUI coinTextScore;

    #endregion


    private void Awake()
    {
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
            desiredLane--;
            if(desiredLane == -1)
            {
                desiredLane = 0;
            }
            /*if (this.gameObject.transform.position.x > leftBoundary)
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * 1);*/ //San�r�m art�k boundrayler gereksiz
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
            /*if (this.gameObject.transform.position.x < rightBoundary)
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);*/ //San�r�m art�k boundrayler gereksiz
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, leftRightLerp * Time.deltaTime);

    }

    #region Take a coin
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            TakeCoin();
            Destroy(other.gameObject);
        }
    }

    #endregion

    #region TakeCoin
    public void TakeCoin()
    {
            coinSounds.Play();
            score += xScore;
            Debug.Log(score);
            coinTextScore.text = score.ToString();
    }

    #endregion
}//class
