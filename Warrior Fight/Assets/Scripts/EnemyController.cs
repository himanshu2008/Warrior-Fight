using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    CHASE, ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemyAnim;
    private NavMeshAgent navAgent;
    private Transform playerTarget;
    public float moveSpeed = 3.5f;
    public float attackDistance = 1.3f;
    public float chase_Player_After_Attack_Distance = 1f;
    private float wait_Before_Attack_Time = 3f;
    private float attackTimer;
    private EnemyState enemyState;
    public GameObject attackPoint;
    private CharacterSoundFX soundFX;

    void Start()
    {
        enemyState = EnemyState.CHASE;
        attackTimer = wait_Before_Attack_Time;
        enemyAnim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    void Update()
    {
        if (enemyState == EnemyState.CHASE)
        {
            ChasePlayer();
        }
        if (enemyState == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = moveSpeed;
        if (navAgent.velocity.sqrMagnitude == 0)
        {
            enemyAnim.Walk(false);
        }
        else
        {
            enemyAnim.Walk(true);
        }
        if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            enemyState = EnemyState.ATTACK;
        }
    }

    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        enemyAnim.Walk(false);
        attackTimer += Time.deltaTime;
        if (attackTimer > wait_Before_Attack_Time)
        {
            if (Random.Range(0, 2) > 0)
            {
                enemyAnim.Attack_1();
                soundFX.Attack_1();
            }
            else
            {
                enemyAnim.Attack_2();
                soundFX.Attack_2();
            }
            attackTimer = 0f;
        }
        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chase_Player_After_Attack_Distance)
        {
            navAgent.isStopped = false;
            enemyState = EnemyState.CHASE;
        }
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void Deactivate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}