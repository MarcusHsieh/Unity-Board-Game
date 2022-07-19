// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;
using MookCode.UI;
using MookCode.Core;


namespace MookCode.Gameboard.Tiles {
    public class TROPHY : TileEvents {
        
        // replace sprite?

        public override IEnumerator RunTileEvent() {
            Debug.Log("> TROPHY");
            // Trophy prompt
            //yield return StartCoroutine(TrophyEvent());
            GameObject.Find("Trophy Canvas").GetComponent<TrophyPrompt>().openTrophyPrompt();
            //ield return new WaitUntil(() => Data.hasTrophyInput);
            while (!Data.hasTrophyInput) {
                Debug.Log("Waiting...");
                yield return null;
            }
            GameObject.Find("Trophy Canvas").GetComponent<TrophyPrompt>().closeTrophyPrompt();
            Debug.Log("Here somehow?");
            Data.hasTrophyInput = false;
        }
        public override string GetName() {
            return "TROPHY";
        }
        public IEnumerator TrophyEvent() {
            GameObject.Find("Trophy Canvas").GetComponent<TrophyPrompt>().openTrophyPrompt();
            //ield return new WaitUntil(() => Data.hasTrophyInput);
            while (!Data.hasTrophyInput) {
                Debug.Log("Waiting...");
                yield return null;
            }
            GameObject.Find("Trophy Canvas").GetComponent<TrophyPrompt>().closeTrophyPrompt();
            Debug.Log("Here somehow?");
            Data.hasTrophyInput = false;
            // move trophy tile
        }
        

        // smth for if pOnTile>1, offset ppl on the tile
    }
}
