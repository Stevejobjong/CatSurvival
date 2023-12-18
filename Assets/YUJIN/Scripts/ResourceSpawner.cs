using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource[] resources;
    [SerializeField] private Transform[] SpawnSpots;

    [SerializeField] private float spawnDuration; // �ڿ� ������ �ֱ�
    private float timer; // �ð� ����� ���� Ÿ�̸�

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
