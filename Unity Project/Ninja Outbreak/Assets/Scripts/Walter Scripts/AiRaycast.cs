using UnityEngine;
public class AiRaycast : MonoBehaviour
{
    public GameObject player;
    [Range(0, 360)]
    public float SpotAngle = 90;
    [Range(2, 360)]
    public int SpotRayCount = 2;
    [Range(0, 10)]
    public int SpotRayLenght = 10;

	void Update ()
    {
        float rot = 0;
        for (int i = 0; i <= SpotRayCount-1; i++)
        {
            rot = (i * (SpotAngle / (SpotRayCount-1)));
            Debug.DrawRay(transform.position, Quaternion.AngleAxis(rot, -transform.forward) * transform.up * SpotRayLenght, Color.blue);
        }
    }
}