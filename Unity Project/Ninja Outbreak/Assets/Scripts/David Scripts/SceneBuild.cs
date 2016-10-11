using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SceneBuild : MonoBehaviour {

    public GameObject playerPref;
    public Object playerIns;

    public List<Vector3> checkPoints = new List<Vector3>();

    void Start () {
        int checkPoint = GameObject.Find("GameManager").GetComponent<GameManager>().save.checkPoint;
        GameObject checkPointObj = GameObject.Find("Checkpoints");
        print(checkPointObj);
        for (int a = 0; a < checkPointObj.transform.childCount; a++) {
            checkPoints.Add(checkPointObj.transform.GetChild(a).transform.position);
        }
        playerIns = Instantiate(playerPref, checkPoints[checkPoint], Quaternion.identity);
    }
}
