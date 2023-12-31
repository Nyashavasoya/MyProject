using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(movementSpeed * HorizontalInput, rb.velocity.y, jumpSpeed * VerticalInput);

        if (Input.GetButtonDown("Jump") && is_grounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }
    }
      

    bool is_grounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground); 
    }
}
