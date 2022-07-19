// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;


namespace MookCode.Gameboard.Tiles {
    public class MINCOINS : TileEvents {
        public override IEnumerator RunTileEvent() {
            Debug.Log("> MINCOINS");
            // -3 coins
            Data.playersArr[Data.currPlayer].decCurrCoins(3);
            yield return new WaitForSeconds(1);
        }
        public override string GetName() {
            return "MINCOINS";
        }

        public override void ChangeSprite() {
            GetComponentInChildren<SpriteRenderer>().sprite = FindObjectOfType<Data>().tileSpiteArr[3];
            GetComponentInChildren<SpriteRenderer>().color = new Color(255, 167, 167);
            //GetComponentInChildren<Transform>().localPosition = new Vector2(0, .1f);
            GetComponentInChildren<Transform>().localScale = new Vector2(.5f, .5f);
        }
        // smth for if pOnTile>1, offset ppl on the tile
    }
}
