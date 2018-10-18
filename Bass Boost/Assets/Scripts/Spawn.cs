using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] enemyTypes;
    public Transform Center;
    private GameObject enemyToSpawn;
    private Transform spawn;
    private Transform[] children;

    // Use this for initialization
    void Start () {
		children = GetComponentsInChildren<Transform>();
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
        int index = Random.Range(0, enemyTypes.Length);
        enemyToSpawn = enemyTypes[index];
        index = Random.Range(0, gameObject.transform.childCount);
        spawn = children[index];
        GameObject newEnemy = Instantiate(enemyToSpawn, spawn.position, Quaternion.identity);
        newEnemy.GetComponentInChildren<Enemy>().target = Center;
    }
}
