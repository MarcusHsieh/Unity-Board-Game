// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode._FallTile
{
    public class FallTile_UIM : MonoBehaviour {
        public void openStartCanvas() {
            GameObject.Find("Start Canvas").GetComponent<CanvasGroup>().alpha = 1;
        }
        public void closeStartCanvas() {
            GameObject.Find("Start Canvas").GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}
