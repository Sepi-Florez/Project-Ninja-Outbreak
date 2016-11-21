using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterMoveInversed : MonoBehaviour
{
    [Tooltip("Add the player's CharacterController in here.")]
    public CharacterController controller;
    private Collider Floor;
    private Vector2 moveVector, lastVector;
    [HideInInspector]
    public float verticalVelocity, speed;
    [HideInInspector]
    public bool isClimbing, isClinging, hasClung;
    public float minSpeed = 4,  maxSpeed = 10, secToMaxSpeed, maxSlideSpeed , jumpforce = 12.5f, gravity = 25;
    public float rayCastLenghtX = 1f,rayCastLenghtY =2.5f;

    void Update()
    {
       RaycastHit hit, up;
        int layerMask = 1 << 8;
        if (Physics.Raycast(transform.position - new Vector3(0,controller.height/2,0), transform.up * rayCastLenghtY, out up, rayCastLenghtY, ~layerMask) && (up.transform.tag == "Floor"))// && !controller.isGrounded
        {
                Floor = up.collider;
                Floor.isTrigger = true;
        }
        else if (Floor != null){Floor.isTrigger = false;}
        if ((Physics.Raycast(transform.position, transform.right, out hit, rayCastLenghtX)) || (Physics.Raycast(transform.position, -transform.right, out hit, rayCastLenghtX)))
        {
            if (hit.transform.tag == "Climbable")
            {
                isClimbing = true;
                verticalVelocity = Input.GetAxis("Vertical") * ((minSpeed + maxSpeed)/2);
                moveVector.x = -Input.GetAxis("Horizontal") * ((minSpeed + maxSpeed)/2);
            }
        }
        else if(isClimbing == true){ isClimbing = false;}

        if (isClimbing == false)
        {
            if (controller.isGrounded)
            {
                hasClung = false;
                moveVector = Vector2.zero;
                moveVector.x = -Input.GetAxis("Horizontal");
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
            if (verticalVelocity < -maxSlideSpeed && Input.GetAxis("Horizontal") == hit.normal.x)
            {
                verticalVelocity = -maxSlideSpeed;
                isClinging = true;
            }
            if (Input.GetButton("Jump"))
            {
                if (Input.GetAxis("Horizontal") == -hit.normal.x)
                {
                    moveVector = hit.normal * speed * Time.deltaTime;
                    verticalVelocity = jumpforce;
                }
                else if (Input.GetAxis("Horizontal") == hit.normal.x && hasClung == false)
                {
                    hasClung = true;
                    verticalVelocity = jumpforce;
                }
            }
            Debug.DrawRay(hit.point, hit.normal, Color.white, 0.35f);
        }
        if(hit.transform.tag == "Floor")
        {
            if (Input.GetButton("Down"))
            {
                hit.collider.isTrigger = true;
            }
        }
    }
}