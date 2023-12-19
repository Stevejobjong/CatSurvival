using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnManger : MonoBehaviour
{
    public GameObject[] NPCPrefabs;
    public GameObject[] NPCCount;
    public Transform spawnPoint;
    private int currentNPCCount = 0;
    private int maxNPCCount = 3;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float maxSpawnDelay = 3f;

    private void Update()
    {
        //GameObject[] NPCCount = GameObject.FindGameObjectsWithTag("NPC");
        //currentNPCCount = NPCCount.Length;

        if (currentNPCCount < maxNPCCount)
        {
            spawnDelay += Time.deltaTime;
            if (spawnDelay >= maxSpawnDelay)
            {
                //NPCSpawn();
                Debug.Log("NPCSpawn");
                currentNPCCount++;
                spawnDelay = 0;
            }
        }
        
    }

    void NPCSpawn()
    {
        //float randomX = transform.position.x + Random.Range(-spawnRadius, spawnRadius);
        //float randomZ = transform.position.z + Random.Range(-spawnRadius, spawnRadius);

        int randomNPC = Random.Range(0, NPCPrefabs.Length);

        Instantiate(NPCPrefabs[randomNPC], spawnPoint.position, spawnPoint.rotation);
    }
}
