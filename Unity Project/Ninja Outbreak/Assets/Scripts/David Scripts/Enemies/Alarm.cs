 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {
    public Transform player;
    public GameObject[] guards;

    public int spawnDistance;
    public void SpawnGuard(int count) {
       Vector3 spawnLoc = DecideSpawnLocations();
        int spawnCount = count;
        if (spawnCount != 0){
            if (spawnLoc != Vector3.zero) {
                GameObject guard = (GameObject)Instantiate(guards[0], spawnLoc, Quaternion.identity);
                guard.transform.LookAt(player);
                spawnDistance++;
                spawnCount--;
                if (spawnCount != 0)
                    SpawnGuard(spawnCount);
            }
            else {
                SpawnGuard(spawnCount);
            }
        }

    }
    Vector3 DecideSpawnLocations() {
        Vector3 spawnLoc = new Vector3();

        if (Physics.Raycast(player.position, player.forward, spawnDistance)) {
            if (Physics.Raycast(player.position, -player.forward, spawnDistance)) {

            }
            else {
                spawnLoc = new Vector3(-spawnDistance, player.position.y, player.position.z);
                
   

       
            }
        }
        else {
            spawnLoc = new Vector3(+spawnDistance, player.position.y, player.position.z);
            spawnDistance++;
        }

        return spawnLoc;
    }
}
