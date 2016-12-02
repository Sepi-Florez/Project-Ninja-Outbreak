using UnityEngine;
using System.Collections;

public class Enemy_Cam : FieldOfView {
    bool stun;
    float stunDur;

    public Color[] states;


    void Start() {
        base.Start();
    }
    public void Detected(bool detect) {
        if (detect) {
            viewMeshFilter.GetComponent<Renderer>().material.color = states[1];
            GameObject.Find("Alarm").GetComponent<Alarm>().SpawnGuard();
        }
        else
            viewMeshFilter.GetComponent<Renderer>().material.color = states[0];
    }
    
}
