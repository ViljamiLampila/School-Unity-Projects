using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    
    private Rigidbody playerRB;
    
    private float speed = 10.0f;
    
    public float jumpForce;

    public float zRange = -1.5f;

    public float zRangeplus = 15.0f;

    public float GravModifier;

    private float HorizontalInput;

    private float VerticalInput;

    public bool OnGround = false;
    // Start is called before the first frame update
    void Start()
    {
        //gets the players rigidbody and gravitymodifier at the start of the game.
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= GravModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //calls the MovePlayer void to check if inputs are pressed.
        MovePlayer();
        //calls the PlayerConstraints void every frame.
        PlayerConstraints();
        
    }

    void MovePlayer()
    {
        //getting inputs for movement.
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        
        //player controls for vertical and horizontal movement.
        transform.Translate(Vector3.forward * speed *  VerticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed *  HorizontalInput * Time.deltaTime);
        //jump command when space pressed.
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // if player in air Onground false.
            OnGround = false;
        }

        
    }

    void PlayerConstraints()
    {
        //restricts player movement out of bounds
        if (playerRB.position.z < zRange)
        {
            transform.position  = new Vector3(transform.position.x,transform.position.y, zRange);
        }

        if (playerRB.position.z > zRangeplus)
        {
            transform.position  = new Vector3(transform.position.x,transform.position.y, zRangeplus);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //detects if player touches the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
          OnGround = true;
        }
    }
    
}
