using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterMoveV3 : MonoBehaviour
{
    [Tooltip("Add the player's CharacterController in here.")]
    public CharacterController controller;
    private Vector2 moveVector, lastVector;
    private float verticalVelocity, speed;
    private bool isClimbing, hasClung, woop;
    public float minSpeed = 4,  maxSpeed = 10, secToMaxSpeed, maxSlideSpeed , jumpforce = 12.5f, gravity = 25;
    public float rayCastLenghtX = .5f;

    void Update()
    {
       RaycastHit hit;
        Debug.DrawRay(transform.position, transform.right * rayCastLenghtX, Color.blue);
        Debug.DrawRay(transform.position, -transform.right * rayCastLenghtX, Color.green);
        if ((Physics.Raycast(transform.position, transform.right, out hit, rayCastLenghtX)) || (Physics.Raycast(transform.position, -transform.right, out hit, rayCastLenghtX)))
        {

        }

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

            if (Input.GetButton("Jump"))
            {
                if (Input.GetAxis("Horizontal") == hit.normal.x)
                {
                    moveVector = hit.normal * speed * Time.deltaTime;
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