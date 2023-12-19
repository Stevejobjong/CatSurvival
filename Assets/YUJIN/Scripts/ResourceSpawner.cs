using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource[] resources;
    [SerializeField] private Transform[] SpawnSpots;

    [SerializeField] private float spawnDuration; // 자원 리스폰 주기
    private float timer; // 시간 계산을 위한 타이머

    void Start()
    {
        timer = spawnDuration;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawneResource();
            timer = spawnDuration;
        }

    }
    public void SpawneResource()
    {
        GameObject rsClone = Instantiate(resources[Random.Range(0, resources.Length)].gameObject, SpawnSpots[Random.Range(0, resources.Length)]);
    }
}
