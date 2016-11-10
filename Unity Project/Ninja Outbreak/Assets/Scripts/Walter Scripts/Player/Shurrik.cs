using System.Collections;
using UnityEngine;
public class Shurrik : MonoBehaviour
{
    public Transform shurk;
    public CameraBounds cameraBounds;
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            shurk.position = Vector3.Lerp(shurk.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset)), 10 *Time.deltaTime);
        }
    }
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}