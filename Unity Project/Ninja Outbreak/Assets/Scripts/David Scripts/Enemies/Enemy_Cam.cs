using UnityEngine;
using System.Collections;

public class Enemy_Cam : FieldOfView {
    bool stun;
    float stunDur;
    public float time;
    public float reactTime;

    public Color[] states;


    void Start() {
        base.Start();
    }
    public void Detected(bool detect, Transform player) {
        if (detect) {
            viewMeshFilter.GetComponent<Renderer>().material.color = states[2];
            time += Time.deltaTime;
            if(time >= reactTime) {
                print("Detected player!");
                viewMeshFilter.GetComponent<Renderer>().material.color = states[1];
                transform.parent.GetChild(0).GetComponent<Enemy>().Engage(player);
            }
            
        }
        if (!detect) {
            viewMeshFilter.GetComponent<Renderer>().material.color = states[0];
            print("reset");
            time = 0;
        }
    }
    
}
