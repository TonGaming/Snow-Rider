using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 12f;
    [SerializeField] ParticleSystem BoostEffect;
    [SerializeField] ParticleSystem BrakeEffect;
    [SerializeField] float fastSpeed = 20f;
    [SerializeField] float slowSpeed = 7f;
    [SerializeField] float defaultSpeed = 10f;
    [SerializeField] float XJump2D = 0f;
    [SerializeField] float YJump2D = 1f;
    [SerializeField] float JumpForce = 2f;
    [SerializeField] AudioSource SnowStep;
    bool isGrounded = false;
    Rigidbody2D rb2d;
    SurfaceEffector2D se2d;
    Vector2 jump;
    //Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
        jump = new Vector2(XJump2D, YJump2D);
    }

    // Update is called once per frame
    void Update()
    {
        AddJump();
        SpeedPLayer();
        RotatePlayer();
    }

    void AddJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            // Hồi còn ngây dại
            rb2d.AddForce(jump * JumpForce, ForceMode2D.Impulse);
            
            
            isGrounded = false;
            // Phương pháp tối ưu
            //if (jumpButton.isPressed)
            //{
            //    playerRB2D.velocity += new Vector2(0f, jumpForce);
            //}
            //isGrounded = false;
        }
    }
    // OnCollisionStay2D sets isGrounded to true if player is touching the Surface Effector 2D
    void OnCollisionEnter2D(Collision2D other)
    {
        SnowStep.Play();
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))

        {
            BoostEffect.Play();
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))

        {
            BrakeEffect.Play();
            rb2d.AddTorque(-torqueAmount);
        }

    }

    void SpeedPLayer()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))

        {
            se2d.speed = fastSpeed;
            BoostEffect.Play();
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            se2d.speed = slowSpeed;
            BrakeEffect.Play();
        }
        else
        {
            se2d.speed = defaultSpeed;
        }
    }
}
