using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigidbody;
    private float velocityZ = 16f;
    private float velocityX = 10f;
    private float velocityY = 10f;
    private float movableRange = 3.4f;
       
    // Start is called before the first frame update
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputVelocityX = 0;
        float inputVelocityY = 0;
        this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);
        if (Input.GetKey(KeyCode.LeftArrow) && -movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && movableRange > this.transform.position.x)
        {
            inputVelocityX = this.velocityX;
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y <= 0.5f)
        {
            inputVelocityY = this.velocityY;
            this.myAnimator.SetBool("Jump", true);
        }
        else
        {
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, velocityZ);
    }
}
