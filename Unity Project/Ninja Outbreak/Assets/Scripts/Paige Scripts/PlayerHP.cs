using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

    public int health = 2;
    public Image hp;
    public Sprite fullhp, halfhp, zerohp;

    void Start ()
    {
     
    }
	void Update ()
    {
        if (health == 0)
        {
            hp.GetComponent<UnityEngine.UI.Image>().sprite = zerohp;
            Death();
        }
        else if(health == 1)
        {
            hp.GetComponent<UnityEngine.UI.Image>().sprite = halfhp;
        }
        else if(health == 2)
        {
            hp.GetComponent<UnityEngine.UI.Image>().sprite = fullhp;
        }
	}
    void Hit()
    {
        health -= 1;
        //stealth for a second
    }
    void Death()
    {
        //death animation?
        //respawn at checkpoint
        //health = 2;
    }
}
