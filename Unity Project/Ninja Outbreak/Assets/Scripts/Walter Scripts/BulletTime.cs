using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BulletTime : MonoBehaviour
{
    public Camera mainCam;
	void Update ()
    {
        if (Input.GetButtonDown("Fire2"))
        {

            if(Time.timeScale == 1.0)
            {
                Time.timeScale = 0.05f;
                mainCam.GetComponent<BloomOptimized>().enabled = true;
            }
            else
            {
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.2f * Time.timeScale;
                mainCam.GetComponent<BloomOptimized>().enabled = false;
            }
        }
	}
}
