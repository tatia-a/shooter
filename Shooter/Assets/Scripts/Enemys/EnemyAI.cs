using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    [SerializeField] public LayerMask whatIsGroung, whatIsPlayer;

    // �������
    private Vector3 walkPoint; // ��������� �����
    private bool walkPointSet; // true - ���� ��������� ����� �����������
    [SerializeField] private float walkPointRange;

    // �����
    [SerializeField] private float timeBetweenAttaks;
    private bool alreadyAttacked;

    // ���������
    [SerializeField] private float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;

    // ��������
    [SerializeField] private Animator animator;

    // ��������� ��� ��������� �����
    [SerializeField] private AttackZone attackZone;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        SearchWalkPoint();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Paroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();


    }

    private void Paroling()
    {
        if (!walkPointSet)
        {
            animator.SetTrigger("isIdle");
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            animator.SetTrigger("isRun");
            agent.SetDestination(walkPoint);
        }
        Vector3 distanseToWalkPoint = transform.position - walkPoint;

        if (distanseToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.y + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 10f, whatIsGroung))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position); // ����������, ��� ���� �� ��������

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            AttackSequence();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttaks);
        }
    }
    protected void AttackSequence()
    {
        animator.SetTrigger("isAttack");

        // ������� ���� � ������ 75
        var chance = UnityEngine.Random.RandomRange(0f, 100f) > 25;

        if (attackZone.PlayerInZone && chance)
            player.GetComponent<PlayerHealth>().TakeDamage(5f);

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}