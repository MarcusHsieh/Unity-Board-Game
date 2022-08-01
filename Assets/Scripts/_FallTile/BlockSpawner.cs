// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode
{
    public class BlockSpawner : MonoBehaviour {

        public Transform[] spawnPoints;
        public GameObject blockPrefab;
        public float timeBetweenWaves = 4f;
        public float timeToSpawn = 2f;
        float currTime;
        private void Update() {
            if (Time.time >= timeToSpawn) {
                SpawnBlocks();
                currTime = Time.time;
                timeToSpawn = currTime += timeBetweenWaves;
            }
        }
        private void SpawnBlocks() {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++) {
                if (randomIndex != i) {
                    Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                }
            }
        }
    }
}
