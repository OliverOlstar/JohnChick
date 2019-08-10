using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 5f;
   
    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rayDistance = 0.2f;

    [SerializeField] private Rigidbody _rb;

    private bool OnGround = true;

    //audio variables
    private AudioSource playsound;
    public AudioClip jump;


    private void Start()
    {
        playsound = GetComponent<AudioSource>();
    }
    void Update()
    {
        OnGroundCheck();
        Jump();
        Move();
    }

    void OnGroundCheck()
    {
        OnGround = (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Vector3.down, rayDistance));
    }

    void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveInput = moveInput.normalized * moveSpeed * Time.deltaTime;

        if (_rb.velocity.magnitude < maxSpeed)
            _rb.AddForce(moveInput, ForceMode.VelocityChange);
    }

    void Jump()
    {
        if (OnGround && Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector3.up * jumpForce);
            playEffect();
        }
    }

    private void playEffect()
    {
        playsound.clip = jump;
        playsound.volume = 0.35f;
        playsound.Play();
    }

}
