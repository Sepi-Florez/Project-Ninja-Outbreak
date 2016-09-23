using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {
    //moet op de AlertGuard
    public bool spawnOn = false; //false laten.
    public GameObject theEnemy; //enemy die gespawned moet worden.
    public int spawnLimit = 4; //limiet van hoeveel er gespawned kunnen worden.
    public Vector3 spawnNum; //aanpassen als je de distance van de spawnpoint wil aanpassen (ALLEEN DE X-AS).
    public bool maxSpawn; //laten zoals het is.
    public bool minSpawn; //laten zoals het is.

    void Start () {

    }

    void Update () {
    }
    public void SpawnActive () {
        maxSpawn = true;
        if (spawnOn == true) {
            StartCoroutine (Spawning ());
        }
    }


    IEnumerator Spawning () {
        Vector3 maxSpawnLoc = new Vector3 (transform.position.x, transform.position.y, transform.position.z) + spawnNum;
        Vector3 minSpawnLoc = new Vector3 (transform.position.x, transform.position.y, transform.position.z) - spawnNum;
        for (int i = 0; i < spawnLimit; i++) {
            if (maxSpawn == true) {
                GameObject enemySpawn = Instantiate (theEnemy, maxSpawnLoc, Quaternion.identity) as GameObject;
                enemySpawn.transform.LookAt (gameObject.transform);
                yield return new WaitForSeconds (1);
                maxSpawn = false;
                minSpawn = true;
            }
            else {
                if (minSpawn == true) {
                    GameObject enemySpawn = Instantiate (theEnemy, minSpawnLoc, Quaternion.identity) as GameObject;
                    enemySpawn.transform.LookAt (gameObject.transform);
                    yield return new WaitForSeconds (1);
                    maxSpawn = true;
                    minSpawn = false;
                }
            }
        }
    }
}
