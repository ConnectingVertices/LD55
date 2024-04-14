using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public Rigidbody rb;
    public bool GameOver = false;
    Transform trans;
    public GameObject movingSound;
    void Start() 
    {
        trans = this.transform;
        movingSound.SetActive(false);
    
    }
    void Update()
    {
        if (GameOver)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if(moveDirection.magnitude > 0.25)
        {
            if (movingSound != null)
            {
                movingSound.SetActive(true);
            }
        }
        else if (movingSound != null)
        {
            movingSound.SetActive(false);
        }

        Vector3 velocity = moveDirection * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
}
