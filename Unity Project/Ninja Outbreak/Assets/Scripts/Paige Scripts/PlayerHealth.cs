using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public enum Status { alive, dead};
    public Status currentStatus;
    public Sprite hp1;
    public Sprite fullhp;
    public Sprite halfhp;
    public Sprite nullhp;
	void Start () {
        currentStatus = Status.alive;
	}
	void Update () {
        if(health == 0) {
            //hp1.GetComponent = hpnull;
            currentStatus = Status.dead;
            Respawn();
        }
        //else if(player is hit){ Hit(); } 
        if (health == 1)
        {
            //change sprite hp1 to hphalf
        }
        if (health == 2)
        {
            //change sprite hp1 to hpfull
        }
    }
    void Hit()
    {
        health = health - 1;
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
