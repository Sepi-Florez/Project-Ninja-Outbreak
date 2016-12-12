using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    int health;
    public enum MovState { Run, Idle, Turn, Walk}
    public MovState states = (MovState)1;
    bool stunned = false;

    public float speed;
    public Vector3[] movements = new Vector3[2];

    void Update () {



		if(stunned) {
            
        }
        else {
            Movement();
        }
	}
    public void Movement() {
        switch (states) {
            case (MovState)0:
                transform.Translate(movements[0] * speed * Time.deltaTime);
                break;
            case (MovState)1:
                //Don't move play idle
                break;
            case (MovState)2:
                //Play Turn Animation
                break;
            case (MovState)3:
                transform.Translate(movements[1] * speed * Time.deltaTime);
                break;
        }
    }
    public void Health() {

    }
}
