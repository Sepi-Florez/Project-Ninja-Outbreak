using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public enum Status { alive, dead};
    public Status currentStatus;
    //assign sprites to int health
	void Start () {
        currentStatus = Status.alive;
	}
	void Update () {
        if(health == 0) {
            currentStatus = Status.dead;
            Respawn();
        }
        //else if(player = hit){ Hit(); }
	}
    void Hit()
    {
        //stealth 
    }
    //redirect from Checkpoints script
    void Respawn()
    {   
        if(currentStatus == Status.dead)
        {
            //respawn player at current checkpoint
        }
        currentStatus = Status.alive;
        health = 2;
    }
}
