using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterMoveV2 : MonoBehaviour
{
    [Tooltip("Add the player's CharacterController in here.")]
    public CharacterController controller;
    private Vector2 moveVector, lastVector;
    private float verticalVelocity, speed;
    private bool isClimbing, hasClung, woop;
    public float minSpeed = 4,  maxSpeed = 16, secToMaxSpeed, maxSlideSpeed , jumpforce = 8, gravity = 25;

    void Update()
    {
        /*RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.right, out hit))
        {
            WallCheck(hit.collider);
        }*/

        if (isClimbing == false)
        {
            moveVector = Vector2.zero;
            moveVector.x = Input.GetAxis("Horizontal");

            if (controller.isGrounded)
            {
                hasClung = false;
                if (Input.GetButton("Jump")) { verticalVelocity = jumpforce; }
                if (Input.GetAxis("Horizontal") != 0)
                {
                    speed += maxSpeed / secToMaxSpeed * Time.deltaTime;
                    if (speed > maxSpeed) { speed = maxSpeed; }
                }
                else { speed = minSpeed; }
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
                moveVector = lastVector;
                if (Input.GetButton("Down"))
                {
                    verticalVelocity -= gravity * 2 * Time.deltaTime;
                }
            }
        moveVector.y = 0;
        moveVector.Normalize();
        moveVector *= speed;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
        lastVector = moveVector;
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f && hit.normal.y > -1f)
        {
            //if (Input.GetButtonDown("Jump")){
            if (verticalVelocity < -maxSlideSpeed && Input.GetAxis("Horizontal") == -hit.normal.x)
            {
                verticalVelocity = -maxSlideSpeed;
            }

            if (Input.GetButtonUp("Jump"))
            {
                if (Input.GetAxis("Horizontal") == hit.normal.x)
                {
                    moveVector = hit.normal * (speed * 2) * Time.deltaTime;
                    verticalVelocity = jumpforce;
                }
                else if (Input.GetAxis("Horizontal") == -hit.normal.x && hasClung == false)
                {
                    hasClung = true;
                    verticalVelocity = jumpforce;
                }
            }
            Debug.DrawRay(hit.point, hit.normal, Color.red, 0.35f);
        }
    }
}