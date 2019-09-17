using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnRate = 1;
    private float timeLeftBeforeSpawn;
    private SpawnPoint[] spawnPoints;
    public GameObject[] ennemis;
	// Use this for initialization
	void Start () {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        timeLeftBeforeSpawn = 1 / spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpawn();
	}

    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if(timeLeftBeforeSpawn < 0)
        {
            SpawnCube();
            timeLeftBeforeSpawn = 1 / spawnRate;
        }
    }

    private void SpawnCube()
    {
        int countSpwanPoint = spawnPoints.Length;
        int randomPointIndex = Random.Range(0, countSpwanPoint);
        SpawnPoint RandomSpawnPointSelected = spawnPoints[randomPointIndex];
        int randomEnnemiIndex = Random.Range(0,ennemis.Length);
        GameObject newEnnemi = Instantiate(ennemis[randomEnnemiIndex], RandomSpawnPointSelected.GetPosition(), RandomSpawnPointSelected.transform.rotation);
    }
}
