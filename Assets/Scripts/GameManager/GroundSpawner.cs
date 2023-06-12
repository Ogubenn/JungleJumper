using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject Ground;//peþpeþe gelen 2 zemin oluþturuyoruz bu scripti en arkada kalan gamamanager görevi gören ground oluyor.O hiç deðiþimyor.eðer öndeki grounda bu scripti verirsek recursive gibi olur ve süreli çalýþýr ve loopa girip unity crash verir.
    [SerializeField] GameObject BotCar1; //Karþýdan gelen rastgele araba;


    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GroundMake();
        }
    }

    public void GroundMake()
    {
        Vector3 yon = Vector3.forward * 18; // Hangi yöne doðru groundu oluþturacaðýmýz, 18 ile çarpmamýn sebebi groundun boyunun 18 olmasý yoksa üst üste biner.

        Ground = Instantiate(Ground, Ground.transform.position + yon, Ground.transform.rotation); //Instantiate ile ground oluþturuyoruz.

        if(Random.Range(0, 10) == 0) //0 gelirse
        {
            Debug.Log("BotCar1");
            Vector3 botCarSpawnPoint = new Vector3(-1.46f, 1, 2.65f);

            Instantiate(BotCar1, Ground.transform.position + botCarSpawnPoint, Quaternion.Euler(0f, 90f, 0f));
        }
    }

}//class
