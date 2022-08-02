// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode._FallTile
{
    public class FallTile_GM : MonoBehaviour {
        private bool hasStartedGame = false;

        private void Start() {
            Time.timeScale = 0f; // instead of this enable/disable the spawner
            Time.fixedDeltaTime = 0f;
            FindObjectOfType<FallTile_UIM>().openStartCanvas();
            while (hasStartedGame == false) {
                if (Input.GetKeyDown(KeyCode.Return)) {
                    Time.timeScale = 1f;
                    Time.fixedDeltaTime = 1f;
                    FindObjectOfType<FallTile_UIM>().closeStartCanvas();
                    hasStartedGame = true;
                }
            }
        }
        public void EndGame() {
            StartCoroutine(ShowResults());
        }
        IEnumerator ShowResults() {
            yield return new WaitForSeconds(10);
        }

    }
}
