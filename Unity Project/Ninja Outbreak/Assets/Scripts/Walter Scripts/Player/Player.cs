using UnityEngine;

public class Player : MonoBehaviour
{
	public float jumpHeight = 4, jumpSpeed = .4f;
    public float speed = 6, wallSlideSpeed =1;
    public float accelerateTimeAir = .2f, accelerateTimeGround = .1f;
    public Vector2 wallJumpClimb, wallJumpOff;

    [Space(10)]
    public int wallJumpsMax;
    int wallJumps;

    float gravity, jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

     CharacterController controller;

	void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = -(2 * jumpHeight) / Mathf.Pow (jumpSpeed, 2);
		jumpVelocity = Mathf.Abs(gravity) * jumpSpeed;
	}

	void Update()
    {
        //if (controller.collisions.above || controller.collisions.below) {
        if (controller.isGrounded)
        {
			velocity.y = 0;
            wallJumps = 0;
		}
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            //print("Jump");
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = input.x * speed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.isGrounded) ? accelerateTimeGround : accelerateTimeAir);
		velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
	}

    public void Hit(RaycastHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f && hit.normal.y > -1f)
        {
            if (velocity.y < -wallSlideSpeed && Input.GetAxis("Vertical") > -1){velocity.y = -wallSlideSpeed;}

            if (Input.GetButtonDown("Jump"))
            {
                if (Input.GetAxis("Horizontal") == -hit.normal.x)
                {
                    if (wallJumps <= wallJumpsMax - 1)
                    {
                        //print("1");
                        wallJumps++;
                        velocity.x = hit.normal.x * wallJumpClimb.x;
                        velocity.y = wallJumpClimb.y;
                    }
                }
                else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Horizontal") == hit.normal.x)
                {
                    //print("2");
                    velocity.x = hit.normal.x * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else
                {
                    //print("3");
                    velocity.x = hit.normal.x * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
            }
            Debug.DrawRay(hit.point, hit.normal, Color.red, 0.35f);
        }
    }
}