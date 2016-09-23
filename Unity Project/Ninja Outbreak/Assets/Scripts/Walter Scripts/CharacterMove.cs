using UnityEngine;
public class CharacterMove : MonoBehaviour
{
    public float walkSpeed = 5f, runSpeed = 20f, jumpSpeed = 12f, gravity = 30f, increase = 2f, cInFront = 9f;
    private float speed;
    private Vector3 moveDirection = Vector3.zero, camOrigin = new Vector3(0, 5, -15);
    public Transform camPos;

    void Update()
    {
        CameraBehaviour();
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Horizontal") != 0f)
            {
                speed = Mathf.MoveTowards(speed, runSpeed, increase);
            }
            else if (speed >= walkSpeed + 1)
            {
                speed -= 1;
            }

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void ClimbOnWall()
    {

    }
    public void CameraBehaviour()
    {
        if (Input.GetButton("Right") || Input.GetButton("Left"))
        {
            if (Input.GetButton("Right"))
            {
                camPos.position = new Vector3(Mathf.Lerp(camPos.position.x, transform.position.x + cInFront, 0.05f), camOrigin.y, camOrigin.z);
            }
            if (Input.GetButton("Left"))
            {
                camPos.position = new Vector3(Mathf.Lerp(camPos.position.x, transform.position.x - cInFront, 0.05f), camOrigin.y, camOrigin.z);
            }
        }
        else if (Mathf.FloorToInt(camPos.position.x) != 0 || Mathf.CeilToInt(camPos.position.x) != 0)
        {
            camPos.localPosition = new Vector3(Mathf.Lerp(camPos.position.x, transform.position.x, 0.025f), camOrigin.y, camOrigin.z);
        }
    }
}