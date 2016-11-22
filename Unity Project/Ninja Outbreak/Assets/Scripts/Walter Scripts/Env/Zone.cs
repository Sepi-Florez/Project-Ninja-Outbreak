using UnityEngine;
using System.Collections;

public class Zone : MonoBehaviour
{
    public float yOffset = 0.5f, zOffset = 2f, peekDistance = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Cam Pos").GetComponent<CameraBounds>().ChangeVals(yOffset, zOffset, peekDistance);
        }
    }
}
