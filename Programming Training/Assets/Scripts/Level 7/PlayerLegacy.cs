using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegacy : MonoBehaviour
{
    private Animation anim;
    private CharacterController characterController;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    [SerializeField] float moveSpeed  = 6f;
    [SerializeField] float jumpSpeed = 3f;
    bool canMove = true;
    public float gravity = 10.0f;
    public HealthBar healthBar;
    Vector3 velocity;

    void Start()
    {
        anim = GetComponent<Animation>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction  = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude >= 0.1f && canMove)
        {
            if(characterController.isGrounded)
            {
                anim.Play("Walking");
            }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
            
        }
        if(direction.magnitude == 0 && canMove)
        {
            anim.Stop("Walking");
            anim.Play("Breathing Idle");
        }
        if (characterController.isGrounded && Input.GetButton("Jump") && canMove) 
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
            anim.Play("Jump");
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.gameObject.tag == "Damager")
        {
            healthBar.maxHp -= 20;
            if(healthBar.maxHp <=0)
            {
                canMove = false;
                anim.Play("Dying Backwards");
            }
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Healer")
        {
            healthBar.maxHp += 20;
            Destroy(other.gameObject);
        }
    }
}
