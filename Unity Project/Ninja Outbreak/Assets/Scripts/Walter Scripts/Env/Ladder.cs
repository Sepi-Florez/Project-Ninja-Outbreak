using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{
    public bool canClimb;
    public GameObject player;
    void OnCollision(Collision hit)
    {
        Debug.Log(this.gameObject.name + " collided with " + hit.gameObject.name);
        if (hit.gameObject.tag == "Player")
        {
            canClimb = true;
            player = hit.gameObject;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        print("hit");
        if (collision.gameObject.tag == "Player")
        {
            canClimb = true;
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canClimb = !canClimb;
            player = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canClimb = !canClimb;
        }
    }
    void Update()
    {
        if (canClimb == true && Input.GetButton("Fire1"))
        {
            //player.transform.Translate(new Vector3(0, 15, 0) * Time.deltaTime);
            player.transform.position += new Vector3(0, 15, 0) * Time.deltaTime;
        }
    }
}
