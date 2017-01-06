using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Animator anim;
    public Animator anim2;

    public Transform enemy;

    public bool patrol = false;
    bool mov = false;
    bool run = false;

    int health;
    public enum MovState { Run, Idle, Turn, Walk, Death}
    public MovState states = (MovState)1;
    bool stunned = false;

    public float speed;
    public Vector3[] movements = new Vector3[2];

    RaycastHit shootHit;
    public int shootingRange;

    void Start () {
        anim = transform.GetComponent<Animator>();
        if(patrol)
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
            case (MovState)4:
                anim.SetTrigger("Death");
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
        if (health == 0 || stunned == true ){
            Death();
        }
    }
    public void Death() {
        StopAllCoroutines();
        Movement((MovState)0);
    }

    public void Engage(Transform player) {
        StopAllCoroutines();
        

        if (Physics.Raycast(transform.position, player.position, shootingRange)) {
            if(shootHit.transform.tag == "Player") {

            }
        }


    }
    IEnumerator Patrol (float PatrolTime, float TurnTime) {
        Movement((MovState)3);
        yield return new WaitForSeconds(PatrolTime);
        Movement((MovState)1);
        yield return new WaitForSeconds(TurnTime);
        Movement((MovState)2);
        yield return new WaitForSeconds(1);
        StartCoroutine(Patrol(PatrolTime, TurnTime));
    }
}
