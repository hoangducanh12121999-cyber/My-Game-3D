using UnityEngine;
using UnityEngine.AI;
[AddComponentMenu("DucAnh/EnemyShootAI")]
public class EnemyShootAI : MonoBehaviour
{
    public enum StateEnemy
    {
        Patrol,
        Chaser,
        Attack
    }

    public float speedAgentWalking = 3.5f;
    public float speedAgentChaser = 5f;
    public float speedAgentAttack = 2f;
    public Transform[] wayPoints;
    public float ChaserRange = 20f;
    public float AttackRange = 10f;
    private NavMeshAgent agent;
    private int currentWayPointIndex = 0;
    StateEnemy stateEnemy;
    private Transform player;
    private bool isAttacking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateEnemy = StateEnemy.Patrol;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GoToNextWayPoint();

    }

    // Update is called once per frame
    void Update()
    {
        switch (stateEnemy)
        {
            case StateEnemy.Patrol:
                Patrol();
                break;
            case StateEnemy.Chaser:
                Chaser();
                break;
            case StateEnemy.Attack:
                Attack();
                break;
        }
    }

    void Patrol()
    {
        agent.speed = speedAgentWalking;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= ChaserRange && distanceToPlayer > AttackRange)
        {
            stateEnemy = StateEnemy.Chaser;
        }
        else if (distanceToPlayer <= AttackRange)
        {
            stateEnemy = StateEnemy.Attack;
        }
        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            GoToNextWayPoint();
        }
    }

    void Chaser()
    {
        agent.speed = speedAgentChaser;
        FaceToPlayer();
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > ChaserRange)
        {
            stateEnemy = StateEnemy.Patrol;
            GoToNextWayPoint();
        }
        else if (distanceToPlayer <= AttackRange)
        {
            stateEnemy = StateEnemy.Attack;
        }
        agent.destination = player.position;
    }

    void Attack()
    {
        agent.speed = speedAgentAttack;
        FaceToPlayer();
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > ChaserRange)
        {
            stateEnemy = StateEnemy.Patrol;
            GoToNextWayPoint();
        }
        else if (distanceToPlayer > AttackRange)
        {
            stateEnemy = StateEnemy.Chaser;
        }
        ShootAttack();
        Invoke("ResetAttack", 1f);
    }

    private void ShootAttack()
    {
        
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }

    private void GoToNextWayPoint()
    {
        if (wayPoints.Length == 0)
            return;
        agent.destination = wayPoints[currentWayPointIndex].position;
        currentWayPointIndex = (currentWayPointIndex + 1) % wayPoints.Length;
    }

    private void FaceToPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ChaserRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
