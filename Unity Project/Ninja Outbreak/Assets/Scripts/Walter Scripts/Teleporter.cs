using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform portal;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.transform.position = portal.transform.position;
        }
    }
}