using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource[] resources;
    [SerializeField] private Transform[] SpawnSpots;

    [SerializeField] private float spawnDuration; // �ڿ� ���� ����
    private float timer; // Ÿ�̸�

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
            if (SpawnSpots[i].childCount == 0) // �ش� ���� ��ġ�� �ڽ��� ���� ���
            {
                availableIndexes.Add(i);
            }
        }

        if (availableIndexes.Count > 0)
        {
            Debug.Log("���ҽ� ����");
            int randomIndex = availableIndexes[Random.Range(0, availableIndexes.Count)];
            Transform spawnSpot = SpawnSpots[randomIndex];

            Resource resourceToSpawn = resources[Random.Range(0, resources.Length)];
            Instantiate(resourceToSpawn.gameObject, spawnSpot.position, spawnSpot.rotation, spawnSpot);
        }
        else
        {
            Debug.Log("�ڸ�����");
        }
    }
}