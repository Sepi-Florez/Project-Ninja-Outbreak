using UnityEngine;
using System.Collections.Generic;

/*[System.Serializable]
public class NodeSystem : Waypoints
{
    public WaypointPath waypointPath;
    public LineRenderer lineRenderer;
    void createShape()
    {
        lineRenderer.SetVertexCount(waypointPath.points.Length);
        for (int i = 0; i <= waypointPath.points.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(waypointPath.points[i].x, waypointPath.points[i].y, 0));
        }
    }
}*/
[System.Serializable]
public class WaypointPath
{
    public string name;
    public Vector2[] points;
}

public class Waypoints : MonoBehaviour
{
    public WaypointPath[] waypoints;
}

public class CutSystem : MonoBehaviour
{
    public List<Vector3> hitPoints = new List<Vector3>();
    public List<List<Vector3>> checkLists = new List<List<Vector3>>();

    public int nextPoint, pointCount;
    private bool slashMode;
    public float timer, timerMax, mouseZVal;
    public GameObject trail;

    private WaypointPath waypointPath;
    public WaypointPath[] waypoints;
    public LineRenderer lineRenderer;

    /*void createShape()
    {
        lineRenderer.SetVertexCount(waypoints.Length);
        for (int i = 0; i <= waypoints.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(waypointPath.points[i].x, waypointPath.points[i].y, 0));
        }
    }*/

    void Update()
    {
        if (slashMode == true)
        {
            InSlashMode();
        }
        if (Input.GetButton("Activate") && slashMode == false)
        {
            InSlashMode();
        }
    }
   void InSlashMode ()
    {
        slashMode = true;
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseposition = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseZVal));
            trail.transform.position = mouseposition;

            if (Vector3.Distance(mouseposition, hitPoints[nextPoint]) <= 0.5f)
            {
                if (nextPoint == pointCount) { Succeeded(); }
                else { nextPoint++; }
            }
        }
        // if (Time.time >= endTime) //als de timer is ge-exceed zul je ALTIJD falen
        if (timer >= timerMax * Time.timeScale)
        {
            Failed();
            print("TimerExceeded");
            timer = 0;
        }
    }
    void Succeeded()
    {
        //Slowmo zo je andere kan selecten Or Quit als je niet select

        //has selected
        ///////////////
        //hasn't selected
        slashMode = false;
        timer = 0;
        print("Succeeded");
        return;
        // !!Quit slowmo
        //////////////
    }
    void Failed()
    {
        //Respawn();
        slashMode = false;
        timer = 0;
        print("Failed");
        return;
        //!!Quit slowmo
    }
}