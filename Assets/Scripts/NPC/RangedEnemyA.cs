using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyA : MonoBehaviour
{
    public float idleMoveSpeed = 2f;
    public float chaseSpeed = 5f;
    public float rotationSpeed = 5f;
    public float attackRange = 20f;
    public float attackDelay = 5f;
    public Transform player;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private Vector3 randomDestination;
    private bool isAttacking = false;


    private NavMeshAgent agent;
    private Animator animator;
    private SkinnedMeshRenderer[] meshRenderers;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }
    void Start()
    {
        InvokeRepeating("IdleMove", 0f, 2f);
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange && !isAttacking)
            {
                isAttacking = true;
                InvokeRepeating("Attack", 0f, attackDelay);
            }
            else if (distanceToPlayer > attackRange)
            {
                isAttacking = false;
                CancelInvoke("Attack");
            }

            if (isAttacking)
            {
                // 플레이어를 바라보기
                Vector3 directionToPlayer = player.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    void IdleMove()
    {
        // 랜덤한 목적지 설정
        randomDestination = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));

        // idle 상태에서 랜덤한 목적지로 이동
        StartCoroutine(MoveToDestination(randomDestination, idleMoveSpeed));
    }

    void Attack()
    {
        // 총알 발사 로직 구현
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    IEnumerator MoveToDestination(Vector3 destination, float speed)
    {
        while (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }
}
