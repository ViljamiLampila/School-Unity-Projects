using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerConrtoller : MonoBehaviour
{
    private Rigidbody playerRb;
    
    public float jumpForce;

    public float gravityModifier;

    public bool isOnGround = true;

    public bool gameOver = true;

    public GameObject player;
    
    public ParticleSystem explosionParticle;

    public ParticleSystem dirtParticles;

    public AudioClip jumpSound;

    public AudioClip crashSound;

    private AudioSource playerAudio;
    
    private Animator playerAnims;
    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnims = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnims.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.5f);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            gameOver = false;
            playerAnims.SetBool("Death_b", true);
            playerAnims.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound, 0.5f);
        }
    }
}
