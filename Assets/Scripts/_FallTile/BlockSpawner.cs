// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;


namespace MookCode._FallTile
{
    public class BlockSpawner : MonoBehaviour {

        public Transform[] spawnPoints;
        public GameObject blockPrefab;
        public float timeToSpawn1 = 2f;
        public float timeToSpawn2 = 2f;
        public float timeToSpawn3 = 2f;
        public float wave2, wave3;
        int barrelsSpawned = 0;
        bool firstSetup = true;
        float currTime;
        private void Start() {
            currTime = Time.time;
            wave2 = currTime + 10f;
            wave3 = currTime + 20f;
        }
        private void Update() {
            // if game has started AND game hasn't ended, spawn blocks
            if (Data.hasGameStarted && !Data.hasGameEnded) {
                if (firstSetup) {
                    currTime = Time.time;
                    wave2 = currTime + 10f;
                    wave3 = currTime + 20f;
                }
                if (Time.time >= timeToSpawn1) {
                    SpawnBlocks();
                    barrelsSpawned++;
                    currTime = Time.time;
                    timeToSpawn1 = currTime + Random.Range(.5f, 1.5f);
                }
                if (Time.time >= wave2 && Time.time >= timeToSpawn2) {
                    SpawnBlocks();
                    barrelsSpawned++;
                    currTime = Time.time;
                    timeToSpawn2 = currTime + Random.Range(.2f, 1f);
                }
                if (Time.time >= wave3 && Time.time >= timeToSpawn3) {
                    SpawnBlocks();
                    barrelsSpawned++;
                    currTime = Time.time;
                    timeToSpawn3 = currTime + Random.Range(0, .5f);
                }
                firstSetup = false;
            }

        }
        private void SpawnBlocks() {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++) {
                if (randomIndex == i) {
                    Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                }
            }
        }
        public int getBarrelsSpawned() {
            return barrelsSpawned;
        }
    }
}
