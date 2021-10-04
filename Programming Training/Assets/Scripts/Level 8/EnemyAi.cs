using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;
    public HealthBar healthBar;

    private Rigidbody rb;
    private ComboAttack comboAttack;
    Animator animator;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    bool alreadyAttacked;
    [SerializeField] bool useAttack;

    //jumping
    [SerializeField] float jumpForce = 3f;
    public bool isGrounded;
    Vector3 jump;
    public float gravity = 2f;
    Vector3 enemyVelocity;
    [SerializeField] bool isJumping;
    [SerializeField] bool useJump;
    

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        comboAttack = GetComponent<ComboAttack>();
        animator = GetComponent<Animator>();
    }
    void OnCollisionStay() 
    {
        if(!isGrounded)
        {
            if (agent.enabled)
            {
                agent.updatePosition = true;
                agent.updateRotation = true;
                agent.isStopped = false;
            }
            rb.isKinematic = true;
            rb.useGravity = false;
            isGrounded = true;
        }
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if (playerInAttackRange && playerInSightRange) Jump();
    }
    
    private void Patroling()
    {
        animator.SetBool("isWalking", true);
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetBool("isWalking", true);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked &&  useAttack == true)
        {
            comboAttack.Attack();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack),0);
        }
    }
    private void Jump()
    {

        if(isGrounded && !isJumping && useJump)
        {
            jump = new Vector3(0.0f, 2.0f, 0.0f);
            isGrounded = false;
            if(agent.enabled)
            {
                agent.updatePosition = false;
                agent.updateRotation = false;
                agent.isStopped = true;
            }
            
            rb.isKinematic = false;
            rb.useGravity = true;
            isJumping = true;
            float jumping = jumpForce * gravity;
            rb.AddForce(jump * jumping, ForceMode.Impulse);
            animator.SetFloat("jumping", jumping);
            Invoke(nameof(StopJump), 1.7f);
        }
    
    }
    private void StopJump()
    {
        isJumping = false;
        float jumping = 0;
        animator.SetFloat("jumping", jumping);

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.gameObject.tag == "EnemyDamager")
        {
            healthBar.maxHp -= 20;
            if(healthBar.maxHp <=0)
            {
                Destroy(gameObject);
                animator.Play("Dying Backwards");
            }
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
