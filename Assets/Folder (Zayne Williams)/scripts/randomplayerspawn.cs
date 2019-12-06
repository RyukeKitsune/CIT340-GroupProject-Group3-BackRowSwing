using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomplayerspawn : MonoBehaviour
{
    public Transform spawnpoint;
    public Transform weapon;
    public GameObject CrossbowHunter;
    public GameObject Crossbow;
    public GameObject GunHunter;
    public GameObject Gun;
    bool playerSpawned = false; 
    // Start is called before the first frame update
    void Start()
    {
        if (playerSpawned == false)
            Spawn();
    }
    void Spawn()
    {
        GameObject spawnPrefab;
        GameObject weaponChose;
        int spawnRange = Random.Range(0, 2);
        if (spawnRange == 0)
        {
            spawnPrefab = CrossbowHunter;
            weaponChose = Crossbow;
        }
        else
        {
            spawnPrefab = GunHunter;
            weaponChose = Gun;
        }
        Instantiate(spawnPrefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
        Instantiate(weaponChose, weapon.transform.position, weapon.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
