using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject Ground;//peþpeþe gelen 2 zemin oluþturuyoruz bu scripti en arkada kalan gamamanager görevi gören ground oluyor.O hiç deðiþimyor.eðer öndeki grounda bu scripti verirsek recursive gibi olur ve süreli çalýþýr ve loopa girip unity crash verir.
    [Header("Arabalar")]
    [SerializeField] GameObject BotCar0; //Karþýdan gelen rastgele araba;
    [SerializeField] GameObject BotCar1; //Karþýdan gelen rastgele araba;
    [SerializeField] GameObject BotCar2; //Karþýdan gelen rastgele araba;
    [SerializeField] GameObject BotCar3; //Karþýdan gelen rastgele araba;
    [SerializeField] GameObject BotCar4; //Karþýdan gelen rastgele araba;
    //[SerializeField] GameObject BotCar5; //Karþýdan gelen rastgele araba;




    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GroundMake();
        }
    }

    public void GroundMake()
    {
        int random = Random.Range(0, 10);
        Vector3 yon = Vector3.forward * 18; // Hangi yöne doðru groundu oluþturacaðýmýz, 18 ile çarpmamýn sebebi groundun boyunun 18 olmasý yoksa üst üste biner.
        Vector3 botCarSpawnPoint = new Vector3(-1.46f, 0.5f, 2.65f); //BotCar doðma pozisyonlarý

        Ground = Instantiate(Ground, Ground.transform.position + yon, Ground.transform.rotation); //Instantiate ile ground oluþturuyoruz.

        if(random == 0) //0 gelirse
        {
            Instantiate(BotCar0, Ground.transform.position + botCarSpawnPoint, Quaternion.Euler(0f, 90f, 0f));
        }
        else if(random == 1)
        {
            Instantiate(BotCar1, Ground.transform.position + botCarSpawnPoint, Quaternion.Euler(0f, 90f, 0f));
        }
        else if (random == 2)
        {
            Instantiate(BotCar2, Ground.transform.position + botCarSpawnPoint, Quaternion.Euler(0f, 90f, 0f));
        }
        else if (random == 3)
        {
            Instantiate(BotCar3, Ground.transform.position + botCarSpawnPoint, Quaternion.Euler(0f, 90f, 0f));
        }
        else if (random == 4)
        {
            Instantiate(BotCar4, Ground.transform.position + botCarSpawnPoint, Quaternion.Euler(0f, 90f, 0f));
        }
        /*else if (random == 5)
        {
            Instantiate(BotCar5, Ground.transform.position + botCarSpawnPoint, Quaternion.Euler(0f, 90f, 0f));
        }*/
    }

}//class
