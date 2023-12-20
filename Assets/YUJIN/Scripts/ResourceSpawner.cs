using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource[] resources;
    [SerializeField] private Transform[] SpawnSpots;

    [SerializeField] private float spawnDuration; // 자원 리스폰 주기
    private float timer; // 시간 계산을 위한 타이머

    private void Awake()
    {
        Debug.Log("Resource생성?!?!?");
    }
    void Start()
    {
        Debug.Log("Resource생성?!?!?");
        timer = spawnDuration;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Debug.Log("Resource생성?!?!?");
            SpawneResource();
            timer = spawnDuration;
        }

    }
    public void SpawneResource()
    {
        GameObject rsClone = Instantiate(resources[Random.Range(0, resources.Length)].gameObject, SpawnSpots[Random.Range(0, SpawnSpots.Length)]);
    }
}
