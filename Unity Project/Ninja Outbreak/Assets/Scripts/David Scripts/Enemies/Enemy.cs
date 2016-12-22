﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Animator anim;
    public Animator anim2;

    public Transform enemy;

    bool mov = false;
    bool run = false;

    int health;
    public enum MovState { Run, Idle, Turn, Walk}
    public MovState states = (MovState)1;
    bool stunned = false;
    bool left = false;

    public float speed;
    public Vector3[] movements = new Vector3[2];

    void Start () {
        anim = transform.GetComponent<Animator>();
        StartCoroutine(Patrol(3, 2));
    }

    void Update () {
        
        if (mov) {
            if (run) {
                Moving(true);
            }
            else {
                Moving(false);
            }
           
        }
	}
    public void Movement(MovState newState) {
        mov = false;
        run = false;
        switch (newState) {
            case (MovState)0:
                anim.SetTrigger("Running");
                anim.ResetTrigger("Idle");
                mov = true;
                run = true;
                
                
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
                mov = true;
                anim.SetTrigger("Walking");
                anim.ResetTrigger("Idle");
                
                break;
        }
    }
    // Is called when hit
    void Moving(bool run) {
        if (run) {
            enemy.Translate(movements[1] * speed * Time.deltaTime);
        }
        else {
            enemy.Translate(movements[0] * speed * Time.deltaTime);
        }
    }
    public void Health() {

        health--;
        if (health == 0 ){
            Death();
        }
    }
    public void Death() {
        // play death animation
    }
    IEnumerator Patrol (float PatrolTime, float TurnTime) {
        Movement((MovState)0);
        yield return new WaitForSeconds(PatrolTime);
        Movement((MovState)1);
        yield return new WaitForSeconds(TurnTime);
        Movement((MovState)2);
        yield return new WaitForSeconds(1);
        StartCoroutine(Patrol(PatrolTime, TurnTime));
    }
}
