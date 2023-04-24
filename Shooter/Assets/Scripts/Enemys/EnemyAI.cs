using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatIsGroung, whatIsPlayer;

    // патруль
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // атака
    public float timeBetweenAttaks;
    bool alreadyAttacked;

    // состояния
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Paroling();
        if (!playerInSightRange && playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();


    }

    private void Paroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanseToWalkPoint = transform.position - walkPoint;

        if(distanseToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(randomX, transform.position.y, randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 10f, whatIsGroung))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position); // убеждаемся, что враг не движется

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            AttackSequence();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttaks);
        }
    }
    protected void AttackSequence()
    {
        // уникальное для каждого
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}