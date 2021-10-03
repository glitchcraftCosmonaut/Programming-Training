using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public HealthBar healthBar;

    public ParticleSystem sparkle;
    

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    { 
        // maxHp = hp;
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.gameObject.tag == "Damager")
        {
            // hp -= 20;
            healthBar.maxHp -= 20;
            if(healthBar.maxHp <=0)
            {
                gameObject.SetActive(false);
            }
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Healer")
        {
            // hp -= 20;
            healthBar.maxHp += 20;
            sparkle.Play();
            Destroy(other.gameObject);
        }
    }

    
}
