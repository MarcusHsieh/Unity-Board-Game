// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;


namespace MookCode.Gameboard.Tiles {
    public class ADDCOINS : TileEvents {
        public override IEnumerator RunTileEvent() {
            Debug.Log("> ADDCOINS");
            // +3 coins
            // can add a value in Data later if want to have multiplier
            Data.playersArr[Data.currPlayer].incCurrCoins(3);
            yield return new WaitForSeconds(1);
        }
        public override string GetName() {
            return "ADDCOINS";
        }

        // smth for if pOnTile>1, offset ppl on the tile
    }
}
