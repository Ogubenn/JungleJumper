using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject Ground;//pe�pe�e gelen 2 zemin olu�turuyoruz bu scripti en arkada kalan gamamanager g�revi g�ren ground oluyor.O hi� de�i�imyor.e�er �ndeki grounda bu scripti verirsek recursive gibi olur ve s�reli �al���r ve loopa girip unity crash verir.

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GroundMake();
        }
    }

    void GroundMake()
    {
        Vector3 yon = Vector3.forward;

        Ground = Instantiate(Ground, Ground.transform.position + yon*18, Ground.transform.rotation);
    }

}//class
