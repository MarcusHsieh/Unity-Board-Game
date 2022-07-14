// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.Gameboard.Tiles {
    public class START : TileEvents {
        public override void RunTileEvent() {
            Debug.Log("> START");
            // +8 coins WHEN PASS, don't need to land
            // needs to be generic for Data.currPlayer
        }
        public override string GetName() {
            return "START";
        }
        // smth for if pOnTile>1, offset ppl on the tile
    }
}
