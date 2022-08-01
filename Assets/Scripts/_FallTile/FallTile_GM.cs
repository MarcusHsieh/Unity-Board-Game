// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode._FallTile
{
    public class FallTile_GM : MonoBehaviour {
        float defaultTimeScale = Time.timeScale;
        float defaultFixedDefaultTime = Time.fixedDeltaTime;
        public float slowness = 10f;
        public void EndGame() {
            StartCoroutine(ShowResults());
        }
        IEnumerator ShowResults() {
            yield return new WaitForSeconds(10);
        }
        public IEnumerator PlayerDeath() {
            Time.timeScale = 1f / slowness;
            Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
            yield return new WaitForSeconds(3);
            Time.timeScale = defaultTimeScale;
            Time.fixedDeltaTime = defaultFixedDefaultTime;
        }
    }
}
