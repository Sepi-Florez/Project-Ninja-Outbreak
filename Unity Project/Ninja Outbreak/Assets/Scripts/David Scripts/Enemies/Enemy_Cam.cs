using UnityEngine;
using System.Collections;

public class Enemy_Cam : FieldOfView {
    bool stun;
    float stunDur;

    public Color[] states;


    void Start() {
        base.Start();
    }
    public void Detected(bool detect, Transform player) {
        if (detect) {
            print("Detected player!");
            viewMeshFilter.GetComponent<Renderer>().material.color = states[1];
            transform.parent.GetChild(0).GetComponent<Enemy>().Engage(player);
        }
        else
            viewMeshFilter.GetComponent<Renderer>().material.color = states[0];
    }
    
}
