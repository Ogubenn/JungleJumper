using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject Ground;//pe�pe�e gelen 2 zemin olu�turuyoruz bu scripti en arkada kalan gamamanager g�revi g�ren ground oluyor.O hi� de�i�imyor.e�er �ndeki grounda bu scripti verirsek recursive gibi olur ve s�reli �al���r ve loopa girip unity crash verir.
    [Header("Arabalar")]
    [SerializeField] GameObject BotCar0; //Kar��dan gelen rastgele araba;
    [SerializeField] GameObject BotCar1; //Kar��dan gelen rastgele araba;
    [SerializeField] GameObject BotCar2; //Kar��dan gelen rastgele araba;
    [SerializeField] GameObject BotCar3; //Kar��dan gelen rastgele araba;
    [SerializeField] GameObject BotCar4; //Kar��dan gelen rastgele araba;
    //[SerializeField] GameObject BotCar5; //Kar��dan gelen rastgele araba;




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
        Vector3 yon = Vector3.forward * 18; // Hangi y�ne do�ru groundu olu�turaca��m�z, 18 ile �arpmam�n sebebi groundun boyunun 18 olmas� yoksa �st �ste biner.
        Vector3 botCarSpawnPoint = new Vector3(-1.46f, 0.5f, 2.65f); //BotCar do�ma pozisyonlar�

        Ground = Instantiate(Ground, Ground.transform.position + yon, Ground.transform.rotation); //Instantiate ile ground olu�turuyoruz.

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
