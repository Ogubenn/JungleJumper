using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject Ground;//pe�pe�e gelen 2 zemin olu�turuyoruz bu scripti en arkada kalan gamamanager g�revi g�ren ground oluyor.O hi� de�i�imyor.e�er �ndeki grounda bu scripti verirsek recursive gibi olur ve s�reli �al���r ve loopa girip unity crash verir.
    [SerializeField] GameObject BotCar1; //Kar��dan gelen rastgele araba;


    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GroundMake();
        }
    }

    public void GroundMake()
    {
        Vector3 yon = Vector3.forward * 18; // Hangi y�ne do�ru groundu olu�turaca��m�z, 18 ile �arpmam�n sebebi groundun boyunun 18 olmas� yoksa �st �ste biner.

        Ground = Instantiate(Ground, Ground.transform.position + yon, Ground.transform.rotation); //Instantiate ile ground olu�turuyoruz.

        if(Random.Range(0, 10) == 0) //0 gelirse
        {
            Debug.Log("BotCar1");
            Vector3 botCarSpawnPoint = new Vector3(-1.46f, 1, 2.65f);

            Instantiate(BotCar1, Ground.transform.position + botCarSpawnPoint, Quaternion.Euler(0f, 90f, 0f));
        }
    }

}//class
