using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource[] resources;
    [SerializeField] private Transform[] SpawnSpots;

    [SerializeField] private float spawnDuration; // 자원 생성 간격
    private float timer; // 타이머

    void Start()
    {
        timer = spawnDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {  
            SpawnResource();
            timer = spawnDuration;
        }
    }

    private void SpawnResource()
    {
        List<int> availableIndexes = new List<int>();
        for (int i = 0; i < SpawnSpots.Length; i++)
        {
            if (SpawnSpots[i].childCount == 0) // 해당 스폰 위치에 자식이 없는 경우
            {
                availableIndexes.Add(i);
            }
        }

        if (availableIndexes.Count > 0)
        {
            Debug.Log("리소스 생성");
            int randomIndex = availableIndexes[Random.Range(0, availableIndexes.Count)];
            Transform spawnSpot = SpawnSpots[randomIndex];

            Resource resourceToSpawn = resources[Random.Range(0, resources.Length)];
            Instantiate(resourceToSpawn.gameObject, spawnSpot.position, spawnSpot.rotation, spawnSpot);
        }
        else
        {
            Debug.Log("자리없뜸");
        }
    }
}