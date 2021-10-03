using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] bool jumpWithTranslate;
    [SerializeField] bool jumpWithRigidbody;
    public float runSpeed = 10f;
    public float walkSpeed = 5f;
    public float turnSpeed = 50f;
    float horizontalMovement;
    float verticalMovement;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

     void OnCollisionStay(){
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpWithTranslate) 
        {
            this.transform.Translate(Vector3.up * jumpSpeed);
            isGrounded = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpWithRigidbody){

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void Movement()
    {
        Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        Vector2 inputDir = input.normalized;
        bool running = Input.GetKey (KeyCode.LeftShift);
        Move (input, running);
    }
    void Move(Vector2 inputDir, bool running) 
    {

        float targetSpeed = ((running) ? runSpeed : walkSpeed); //ternary op if running true then runspeed else walkspeed
        float realSpeed = targetSpeed * Time.deltaTime;


        Vector3 directionToMove = new Vector3 (inputDir.x, 0, inputDir.y) * realSpeed;

        transform.Translate (directionToMove);
    }

}
