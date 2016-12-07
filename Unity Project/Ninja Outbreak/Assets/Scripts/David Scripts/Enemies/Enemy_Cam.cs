using UnityEngine;
using System.Collections;

public class Enemy_Cam : FieldOfView {
    bool stun;
    bool detect2;
    float stunDur;

    public Color[] states;


    void Start() {
        base.Start();
    }
    public void Detected(bool detect) {
        if (detect) {
            viewMeshFilter.GetComponent<Renderer>().material.color = states[1];
            if (!detect2) {
                GameObject.Find("Alarm").GetComponent<Alarm>().SpawnGuard(2);
                detect2 = true;
            }
        }
        else
            viewMeshFilter.GetComponent<Renderer>().material.color = states[0];
    }
    
}
