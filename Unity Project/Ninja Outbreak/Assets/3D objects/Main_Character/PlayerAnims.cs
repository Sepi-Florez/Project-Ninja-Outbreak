using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        if(Input.GetAxis("Horizontal") > .1f) { transform.localScale = new Vector3(1,1,1);}
        else if (Input.GetAxis("Horizontal") < -.1f) { transform.localScale = new Vector3(1, 1, -1); }

        if (Input.GetAxis("Horizontal") > .1f || Input.GetAxis("Horizontal") < -.1f) { anim.SetBool("Moving", true); }
        else { anim.SetBool("Moving", false); }

        if (Input.GetButton("Crouch")) { anim.SetBool("Crouch", true); }
        else { anim.SetBool("Crouch", false); }

        if (Input.GetButton("Jump")) { anim.SetBool("InAir", true); }
        else { anim.SetBool("InAir", false); }
    }
}