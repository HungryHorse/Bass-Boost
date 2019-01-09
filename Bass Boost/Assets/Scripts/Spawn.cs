using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] enemyTypes;
    public Transform[] targets;
    public Transform Center;
    public float spawnTime;

    private float spawnCooldown = 0;
    private GameObject enemyToSpawn;
    private Transform spawn;
    private Transform[] children;

    // Use this for initialization
    void Start () {
		children = GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    SpawnEnemy();
        //}
		
        if(spawnCooldown < 0)
        {
            SpawnEnemy();
            spawnCooldown = spawnTime;
        }
        else
        {
            spawnCooldown -= Time.deltaTime;
        }
	}

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyTypes.Length);
        int targetIndex = Random.Range(0, targets.Length);
        enemyToSpawn = enemyTypes[index];
        index = Random.Range(1, gameObject.transform.childCount);
        spawn = children[index];
        GameObject newEnemy = Instantiate(enemyToSpawn, spawn.position, Quaternion.identity);
        newEnemy.GetComponentInChildren<Enemy>().targets = targets;
        newEnemy.GetComponentInChildren<Enemy>().targetIndex = targetIndex;
    }
}
