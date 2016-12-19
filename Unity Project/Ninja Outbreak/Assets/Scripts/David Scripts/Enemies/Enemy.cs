using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Animator anim;
    public Animator anim2;

    public Transform enemy;


    int health;
    public enum MovState { Run, Idle, Turn, Walk}
    public MovState states = (MovState)1;
    bool stunned = false;
    bool left = false;

    public float speed;
    public Vector3[] movements = new Vector3[2];

    void Start () {
        anim = transform.GetComponent<Animator>();
    }

    void Update () {

		if(stunned) {

        }
        else {
            if (Input.GetButton("Jump")) {


                Movement();
            }
        }
	}
    public void Movement() {

        switch (states) {
            case (MovState)0:
                anim.SetTrigger("Running");
                anim.ResetTrigger("Idle");
                enemy.Translate(movements[0] * speed * Time.deltaTime);

                break;
            case (MovState)1:
                // play idle
                anim.SetTrigger("Idle");

                break;
            case (MovState)2:
                    anim2.SetTrigger("Turn");
                    states = (MovState)2;
                break;
            case (MovState)3:
                anim.SetTrigger("Walking");
                anim.ResetTrigger("Idle");
                enemy.Translate(movements[1] * speed * Time.deltaTime);
                break;
        }
    }
    // Is called when hit
    public void Health() {

        health--;
        if (health == 0 ){
            Death();
        }
    }
    public void Death() {
        // play death animation
    }
}
