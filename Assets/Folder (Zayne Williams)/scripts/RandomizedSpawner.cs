using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedSpawner : MonoBehaviour
{
    
    public GameObject enemySpawn1;
    public GameObject enemySpawn2;
    public GameObject enemySpawn3;

    public GameObject undeadspawn1;
    public GameObject undeadspawn2;
    public GameObject wispspawn1;
    public GameObject wispspawn2;
    public GameObject reaperspawn1;

    public Transform target;
    public float range = 15;
    public float spawnSpeed = 6;
    int spawnEnemy;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        Invoke("Spawn", spawnSpeed);
        StartCoroutine(IncreaseDifficulty());

    }
    void Spawn()
    {
        GameObject spawnPrefab;
        int spawnRange = Random.Range(0, 10);
        if (spawnRange == 1 || spawnRange == 2 || spawnRange == 3 || spawnRange == 4)
            spawnPrefab = enemySpawn1;
        else if (spawnRange == 8 || spawnRange == 7 || spawnRange == 6 || spawnRange == 5 || spawnRange == 9)
            spawnPrefab = enemySpawn2;
        else
            spawnPrefab = enemySpawn3;
        if (spawnPrefab == enemySpawn1 && spawnRange == 1 || spawnRange == 2)
        {
            Instantiate(spawnPrefab, undeadspawn1.transform.position, undeadspawn1.transform.rotation);
        }
        if (spawnPrefab == enemySpawn1 && spawnRange == 3 || spawnRange == 4)
        {
            Instantiate(spawnPrefab, undeadspawn2.transform.position, undeadspawn2.transform.rotation);
        }
        if (spawnPrefab == enemySpawn2 && spawnRange == 5 || spawnRange == 6 || spawnRange == 7)
        {
            Instantiate(spawnPrefab, wispspawn1.transform.position, wispspawn1.transform.rotation);
        }
        if (spawnPrefab == enemySpawn2 && spawnRange == 8 || spawnRange == 9)
        {
            Instantiate(spawnPrefab, wispspawn2.transform.position, wispspawn2.transform.rotation);
        }
        if (spawnPrefab == enemySpawn3)
        {
            Instantiate(spawnPrefab, reaperspawn1.transform.position, reaperspawn1.transform.rotation);
        }
        Invoke("Spawn", spawnSpeed);
       // Debug.Log(spawnRange);
    }
    IEnumerator IncreaseDifficulty()
    {
        for (int i = 0; i < 5; ++i)
        {
            yield return new WaitForSeconds(5);
            spawnSpeed -= .15f;
        }
    }
    // Update is called once per frame
    
}
