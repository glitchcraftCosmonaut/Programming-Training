using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 pointB;
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;
    [SerializeField] protected private float moveSpeed;
    protected private Transform target;//The Target is our player
    [SerializeField] protected private float distance;
    [SerializeField] float jumpForce = 3f;
    public bool isGrounded;
    Vector3 jump;
    public float gravity = -9.81f;
    Vector3 velocity;
    
   

   
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        wayPointTarget = wayPoint01;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        
    }


    void OnCollisionStay() 
    {
        isGrounded = true;
    }

    private void Update() 
    {
        if(Vector2.Distance(transform.position, target.position) > distance)
            {
                transform.LookAt(wayPointTarget);
                //When we reached at the waypoint01, we have to mvoe to the waypoint 02
                if(Vector3.Distance(transform.position, wayPoint01.position) < 0.01f)
                {
                    // transform.Translate(Vector3.forward * moveSpeed);
                    wayPointTarget = wayPoint02;
                }

                if(Vector3.Distance(transform.position, wayPoint02.position) < 0.01f)
                {
                    wayPointTarget = wayPoint01;
                }

                transform.position = Vector3.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);
            }
        
        if(Vector3.Distance(transform.position, target.position) < distance && isGrounded)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            transform.LookAt(target);
            
        }
    }
}
