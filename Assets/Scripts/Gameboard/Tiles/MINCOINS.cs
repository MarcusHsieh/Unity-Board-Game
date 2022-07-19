// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.Gameboard.Tiles {
    public class MINCOINS : TileEvents {
        public override IEnumerator RunTileEvent() {
            Debug.Log("> MINCOINS");
            // -3 coins
            yield return new WaitForSeconds(1);
        }
        public override string GetName() {
            return "MINCOINS";
        }
        // smth for if pOnTile>1, offset ppl on the tile
    }
}
