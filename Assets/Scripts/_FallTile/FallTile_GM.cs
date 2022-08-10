// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MookCode.GlobalData;

namespace MookCode._FallTile
{
    public class FallTile_GM : MonoBehaviour {
        bool isEndGame = false;
        bool hasClosedResultsWindow = false;

        private void Start() {
            StartCoroutine(StartCanvas());
            Debug.Log("Starting Barrel Barrage");
        }
        private void Update() {
            if (!Data.hasGameEnded) {
                checkIfEndGame();
            }
        }
        IEnumerator StartCanvas() {
            FindObjectOfType<FallTile_UIM>().openStartCanvas(); 
            while (Data.hasGameStarted == false) {
                if (Input.GetKeyDown(KeyCode.Return)) {
                    Data.hasGameStarted = true;
                    FindObjectOfType<FallTile_UIM>().closeStartCanvas();
                }
                yield return null;
            }
            yield break;
        }
        void checkIfEndGame() {
            for (int i = 0; i < 3; i++) {
                if (FindObjectOfType<ResultsWindow>().pPlacementsArr[i] != -1) {
                    isEndGame = true;
                }
                else {
                    isEndGame = false;
                    break;
                }
            }
            if (isEndGame) {
                Data.hasGameEnded = true;
                EndGame();
            }
        }
        void EndGame() {
            StartCoroutine(ShowResults());
        }
        IEnumerator ShowResults() {
            FindObjectOfType<ResultsWindow>().setupResultsWindow();
            FindObjectOfType<ResultsWindow>().openResultsCanvas();
            while (!hasClosedResultsWindow) {
                if (Input.GetKey(KeyCode.Return)) {
                    hasClosedResultsWindow = true;
                    FindObjectOfType<ResultsWindow>().closeResultsCanvas();
                    SceneManager.LoadScene(0);
                }
                yield return null;
            }
            yield break;
        }


        private GameObject[] FindGameObjectsInLayer(int layer) {
            GameObject[] barrelsArr = FindObjectsOfType(typeof(GameObject)) as GameObject[];
            List<GameObject> barrelsList = new List<GameObject>();
            for (int i = 0; i < barrelsArr.Length; i++) {
                if (barrelsArr[i].layer == layer) {
                    barrelsList.Add(barrelsArr[i]);
                }
            }
            if (barrelsList.Count == 0) {
                return null; // if no gameobjects in layer
            }
            return barrelsList.ToArray();
        }

    }
}
