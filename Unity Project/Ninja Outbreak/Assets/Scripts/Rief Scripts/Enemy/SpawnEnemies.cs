using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour{

    public bool spawnOn = false;
    public GameObject theEnemy;
    public int spawnLimit = 4;
    public int maxSpawn =  7;
    public int minSpawn = -7;

    void Start () {
        
    }
	
	void Update () {
    }
    public void Spawn () {

        if (spawnOn == true) {
            for (int i = 0; i < spawnLimit; i++) {
                Vector3 xRange = new Vector3 (Random.Range (minSpawn, maxSpawn), transform.position.y, transform.position.z);
                Instantiate (theEnemy, xRange, Quaternion.identity);
                }
            }
        }
}
