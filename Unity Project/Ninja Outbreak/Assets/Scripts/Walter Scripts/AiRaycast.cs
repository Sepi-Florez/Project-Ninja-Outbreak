using UnityEngine;

public class AiRaycast : MonoBehaviour
{
    public GameObject player;
    public float SpotAngle = 90;
    public int SpotRayCount, SpotRayLenght = 10;
	void Update ()
    {
        //float rot = -(((float)SpotAngle / SpotRayCount) * ((float)SpotRayCount /2));
        //float rot = -SpotAngle / 2;
        float rot = 0;
        for (int i = 1; i <= SpotRayCount; i++)
        {
            Debug.DrawRay(transform.position, Quaternion.AngleAxis(rot, transform.up) * transform.right * SpotRayLenght, Color.blue);
            rot += ((SpotAngle+(SpotAngle / SpotRayCount)) / SpotRayCount);
        }
	}
}