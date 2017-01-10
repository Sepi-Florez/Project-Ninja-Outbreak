using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BulletTime : MonoBehaviour
{
    public Camera mainCam;
	void Update ()
    {
        if (Input.GetButtonDown("Fire3"))
        {

            if(Time.timeScale == 1.0)
            {
                Time.timeScale = 0.05f;
            }
            else
            {
                Time.timeScale = 1.0f;
                //Time.fixedDeltaTime = 0.2f * Time.timeScale;
            }
        }
	}
}
