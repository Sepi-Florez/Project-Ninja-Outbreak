using UnityEngine;

public class CharacterMoveV2 : MonoBehaviour
{
    private Vector3 moveVector;
    private Vector3 lastVector;
    private float verticalVelocity;
    public CharacterController controller;
    public float speed = 2.5f , maxSpeed = 8 , jumpforce = 8, gravity = 25;

    void Update()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            verticalVelocity = -1;
            if (Input.GetButtonDown("Jump")){ verticalVelocity = jumpforce; }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            moveVector = lastVector;
        }
        moveVector.y = 0;
        moveVector.Normalize();
        moveVector *= speed;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
        lastVector = moveVector;
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f && hit.normal.y > -1f)
        {
            if (Input.GetButton("Jump"))
            {
                moveVector.y = jumpforce;
            }
            Debug.DrawRay(hit.point, hit.normal, Color.blue, 0.35f);
        }
    }
}