using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{

	public GameObject[] Prefabs; // Yol parçalarýnýn farklý prefabslarýný içeren bir dizi.Farklý varyasyonlar
	private Transform Player; 

	private List<GameObject> ActivePrefabs; //Atadýðýmýz bütün tile larý listede tutar.


	public float BackArea = 200.0f; //Tile oyuncunun gerisinde kaç birim olduðunu belirtir.alan.Alan geçilince tile silinir ve yeni tile ürer.
	public int PrefabsOnScreen = 4; //Ekrandaki max tile 
	public int LastPrefab = 0; //Son üretilen yol parçasýnýn prefabs dizisindeki index deðerini tutar.
	public float SpawnPrefab = -100.0f; //Tileýn üretileceði z koordinatý
	public float PrefabLength = 99.0f; //týle uzunluðu


	private void Start()
	{
		ActivePrefabs = new List<GameObject>();
		Player = GameObject.FindGameObjectWithTag("Player").transform;

		for (int i = 0; i < PrefabsOnScreen; i++)
		{
			if (i < 4)
				Spawn(0);
			else
				Spawn();
		}
	}


	private void Update()
	{
		if (Player.position.z - BackArea > (SpawnPrefab - PrefabsOnScreen * PrefabLength))
		{
			Spawn();
			DeletePrefab();
		}
	}

    #region Spawn Methot
    private void Spawn(int prefabIndex = -1)
	{
		GameObject myPrefab;
		if (prefabIndex == -1)

			myPrefab = Instantiate(Prefabs[RandomPrefabs()] as GameObject);
		else
			myPrefab = Instantiate(Prefabs[prefabIndex] as GameObject);

		myPrefab.transform.SetParent(transform);
		myPrefab.transform.position = Vector3.forward * SpawnPrefab;
		SpawnPrefab += PrefabLength;
		ActivePrefabs.Add(myPrefab);
	}

    #endregion


    #region Delete Methot
    private void DeletePrefab()
	{
		Destroy(ActivePrefabs[0]);
		ActivePrefabs.RemoveAt(0);
	}

    #endregion

    #region Random Methot
    private int RandomPrefabs()
	{
		if (Prefabs.Length <= 1)
			return 0;
		int randomIndex = LastPrefab;
		while (randomIndex == LastPrefab)
		{
			randomIndex = Random.Range(0, Prefabs.Length);
		}

		LastPrefab = randomIndex;
		return randomIndex;
	}

    #endregion
}