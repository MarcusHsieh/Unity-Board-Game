// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.Gameboard.Tiles {
    public class TROPHY : TileEvents {
        public override void RunTileEvent() {
            Debug.Log("> TROPHY");
            // Trophy prompt
        }
        public override string GetName() {
            return "TROPHY";
        }
        // smth for if pOnTile>1, offset ppl on the tile
    }
}
