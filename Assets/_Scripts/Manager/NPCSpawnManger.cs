using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnManger : MonoBehaviour
{
    public GameObject[] NPCPrefabs;
    private GameObject[] NPCCount;
    //public Transform spawnPoint;
    private int currentNPCCount = 0;
    public int maxNPCCount = 3;
    private float spawnRadius = 50f;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float maxSpawnDelay = 3f;

    private void Update()
    {
        NPCCount = GameObject.FindGameObjectsWithTag("NPC");
        currentNPCCount = NPCCount.Length;

        if (currentNPCCount < maxNPCCount)
        {
            spawnDelay += Time.deltaTime;
            if (spawnDelay >= maxSpawnDelay)
            {
                NPCSpawn();
                Debug.Log("NPCSpawn");
                currentNPCCount++;
                spawnDelay = 0;
            }
        }
        
    }

    void NPCSpawn()
    {
        float randomX = transform.position.x + Random.Range(-spawnRadius, spawnRadius);
        float randomZ = transform.position.z + Random.Range(-spawnRadius, spawnRadius);
        Vector3 spawnPoint = new Vector3(randomX, 10, randomZ);
        int randomNPC = Random.Range(0, NPCPrefabs.Length);

        Instantiate(NPCPrefabs[randomNPC], spawnPoint, Quaternion.identity);
        //Instantiate(NPCPrefabs[randomNPC], spawnPoint.position, spawnPoint.rotation);
    }
}
