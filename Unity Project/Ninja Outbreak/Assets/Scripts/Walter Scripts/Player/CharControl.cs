using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour
{
    public float jumpHeight = 5, jumpSpeed = .5f;
    public float minWalkSpeed = 4, maxWalkSpeed = 8;
    float gravity, jumpVelocity;
    Vector3 moveVector;

    void Update()
    {
        //suvat
        gravity = -(2 * jumpHeight) / Mathf.Pow(jumpSpeed, 2); //gravity = - jumpheight x 2 / jumpspeed to the power of 2
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        moveVector.y -= gravity;
        transform.Translate(moveVector * Time.deltaTime);
    }

    void Jump()
    {
        jumpVelocity = Mathf.Abs(gravity) * jumpSpeed;
        moveVector.y = jumpVelocity;
    }
}