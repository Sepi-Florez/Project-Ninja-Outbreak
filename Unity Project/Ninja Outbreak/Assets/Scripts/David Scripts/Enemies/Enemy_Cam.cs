using UnityEngine;
using System.Collections;

public class Enemy_Cam : FieldOfView {
    bool stun;
    float stunDur;


    void Start() {
        base.Start();
        Detected();
    }
    void Detected() {

        viewMeshFilter.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.5F);

    }

}
