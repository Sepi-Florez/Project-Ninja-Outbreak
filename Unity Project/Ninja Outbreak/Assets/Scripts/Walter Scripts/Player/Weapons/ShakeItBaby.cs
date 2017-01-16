using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeItBaby : MonoBehaviour
{
	void Update ()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShakeIt());
        }*/
	}
    IEnumerator ShakeIt()
    {
        transform.localPosition = NoiseGen.Shake2D(1, 0.98f, 2, 0.2f, 20, 0.5f, 2, Time.time);
        yield return new WaitForSeconds(0.1f);
        transform.localPosition = NoiseGen.Shake2D(0, 0.98f, 2, 0.2f, 20, 0.5f, 2, Time.time);
    }
}
