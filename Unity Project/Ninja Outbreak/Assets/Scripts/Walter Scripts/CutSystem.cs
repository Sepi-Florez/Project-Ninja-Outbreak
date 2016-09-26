using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class WaypointPath
{
    public string name;
    public Vector3[] positions;
}
public class Waypoints : MonoBehaviour
{
    public WaypointPath[] waypoints;
}

public class CutSystem : MonoBehaviour
{
    private int mouseObjective, randomWaypoint;
    private float timer;
    public float timerMax, mouseZVal;
    private bool inSlashMode;
    public GameObject trail;
    private WaypointPath waypointPath;
    public WaypointPath[] waypoints;
    public LineRenderer lineRenderer;

    void Start()
    {
        RandomShape();
    }
    void Update()
    {
        if ((inSlashMode == true) || (Input.GetButton("Activate") && inSlashMode == false))
        {
            SlashMode();
        }
    }
   void SlashMode ()
    {
        inSlashMode = true;
        timer += Time.deltaTime;

        //als je Lmuisknop indrukt komt er trail achter muis
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseposition = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseZVal));
            trail.transform.position = mouseposition;

            //als distance van muis tot mouseObjective minder dan 0.5 is dan telt hij een punt op bij mouseObjective
            if (Vector3.Distance(mouseposition, waypoints[randomWaypoint].positions[mouseObjective]) <= 0.5f)
            {
                if (mouseObjective == waypoints.Length - 1 || mouseObjective >= waypoints.Length - 1) { Succeeded(); }
                else { mouseObjective++; }
            }
        }

        if (timer >= timerMax * Time.timeScale)//als de timer is ge-exceed zul je ALTIJD falen
        {
            Failed();
            print("TimerExceeded");
            timer = 0;
        }
    }
    void RandomShape() //word ook gecalled als het script (of functie) eerste keer word gecalled
    {
        if (waypoints.Length > 0)
        {
            lineRenderer.SetVertexCount(waypoints.Length - 1);
            randomWaypoint = Random.Range(0, waypoints.Length - 1);
            lineRenderer.SetPositions(waypoints[randomWaypoint].positions);
        }
    }
    void Succeeded()
    {
        //Slowmo zo je andere kan selecten Or Quit als je niet select

        //has selected
        //RandomShape();
        ///////////////
        //hasn't selected
        RandomShape();
        inSlashMode = false;
        timer = 0;
        print("Succeeded");
        return;
        // !!Quit slowmo
        //////////////
    }
    void Failed()
    {
        //Respawn();
        RandomShape();
        inSlashMode = false;
        timer = 0;
        print("Failed");
        return;
        //!!Quit slowmo
    }
}