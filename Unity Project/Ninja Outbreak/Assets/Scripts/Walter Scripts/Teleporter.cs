using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform exit;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.transform.position = exit.transform.position;
        }
    }
}