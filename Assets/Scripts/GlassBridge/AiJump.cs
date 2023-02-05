using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiJump : MonoBehaviour
{
    public Vector3 dir;
    public float Movespeed = 3.5f;
    public float Jumpforce = 7.0f;
    public float Fallmultiplier = 2.0f;
    private Rigidbody rb = null;
    private bool onGround = true;

    public bool side = false;
    public bool diagnol;
    public bool left, right;
    public Animator animator;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!onGround)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if (side)
        {
            dir.x = -10;

        }
        else
        {
            dir.x = 10;
        }
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * Fallmultiplier * Time.deltaTime;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    public void LeftButton()
    {
      
        if (left)
        {
            if (onGround)
            {
                onGround = false;
                rb.AddForce(Vector3.up * Jumpforce, ForceMode.VelocityChange);
                rb.AddForce(Vector3.forward * Movespeed, ForceMode.VelocityChange);
                left = true;
                right = false;
            }
        }
        if(right)
        {
            if (onGround)
            {
                onGround = false;
                rb.AddForce(Vector3.up * Jumpforce, ForceMode.VelocityChange);
                rb.AddForce(dir.x, dir.y, dir.z * Jumpforce, ForceMode.VelocityChange);
                side = !side;
                left = true;
                right = false;
            }
            
        }
        animator.SetBool("Jump", true);
    }

    public void RightButton()
    {
        if (right)
        {
            if (onGround)
            {
                onGround = false;
                rb.AddForce(Vector3.up * Jumpforce, ForceMode.VelocityChange);
                rb.AddForce(Vector3.forward * Movespeed, ForceMode.VelocityChange);
                left = false;
                right = true;
            }
        }
        if(left)
        {
            if (onGround)
            {
                onGround = false;
                rb.AddForce(Vector3.up * Jumpforce, ForceMode.VelocityChange);
                rb.AddForce(dir.x, dir.y, dir.z * Jumpforce, ForceMode.VelocityChange);
                side = !side;
                left = false;
                right = true;
            }
        }
        animator.SetBool("Jump", true);
    }
}
