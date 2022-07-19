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

        public override void RunTileEvent() {
            Debug.Log("> TROPHY");
            // Trophy prompt
            StartCoroutine("TrophyEvent");
        }
        public override string GetName() {
            return "TROPHY";
        }
        public IEnumerator TrophyEvent() {
            GameObject.Find("Trophy Canvas").GetComponent<TrophyPrompt>().openTrophyPrompt();
            while (Data.hasTrophyInput == false) {
                
                yield return null; 
            }
            GameObject.Find("Trophy Canvas").GetComponent<TrophyPrompt>().closeTrophyPrompt();
            Data.hasTrophyInput = true;
            // move trophy tile
        }
        

        // smth for if pOnTile>1, offset ppl on the tile
    }
}
