using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] enemyTypes;
    private System.Random rand;
    private GameObject enemyToSpawn;
    private Transform spawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            SpawnEnemy();
        }
		
	}

    private void SpawnEnemy()
    {
        int index = rand.Next(0, enemyTypes.Length);
        enemyToSpawn = enemyTypes[index];
        Instantiate(enemyToSpawn, spawn.position, Quaternion.identity);
    }
}
