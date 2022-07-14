// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.Gameboard.Tiles {
    public class ADDCOINS : TileEvents {
        public override void RunTileEvent() {
            Debug.Log("> ADDCOINS");
            // +3 coins
        }
        public override string GetName() {
            return "ADDCOINS";
        }
        // smth for if pOnTile>1, offset ppl on the tile
    }
}
