using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float jumpHeight = 4, timeToJumpApex = .4f;
    float moveSpeed = 6;
    float accelerationTimeAirborne = .2f, accelerationTimeGrounded = .1f;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

    //Controller2D controller;
    public CharacterController controller;

	void Start()
    {
        //controller = GetComponent<Controller2D> ();
        controller = GetComponent<CharacterController>();

        gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);

	}

	void Update()
    {
        //if (controller.collisions.above || controller.collisions.below) {
        if (controller.isGrounded)
        {
			velocity.y = 0;
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.isGrounded) ?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;

		controller.Move (velocity * Time.deltaTime);

	}
}
