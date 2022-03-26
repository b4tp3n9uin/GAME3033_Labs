using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public int numberOfZombiesToSpawn;
    public GameObject[] ZombiePrefab;
    public SpawnerVolume[] spawnerVolumes;
    
    GameObject followGameObject;
    // Start is called before the first frame update
    void Start()
    {
        followGameObject = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        GameObject zombieToSpawn =
            ZombiePrefab[Random.Range(0, ZombiePrefab.Length)];
        SpawnerVolume spawnerVolume =
            spawnerVolumes[Random.Range(0, spawnerVolumes.Length)];

        //if (!followGameObject) return;

        // object pooling can be referenced.
        GameObject zombie = Instantiate(zombieToSpawn, spawnerVolume.GetPositionInBounds(), spawnerVolume.transform.rotation);

        //zombie.GetComponent<ZombieComponent>().Initialize(followGameObject);
    }
}
