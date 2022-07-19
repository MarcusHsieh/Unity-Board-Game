// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;



namespace MookCode.Gameboard.Tiles {
    public class START : TileEvents {
        public override IEnumerator RunTileEvent() {
            Debug.Log("> START");
            // +8 coins WHEN PASS, don't need to land
            Data.playersArr[Data.currPlayer].incCurrCoins(8);
            yield return new WaitForSeconds(1);
        }
        public override string GetName() {
            return "START";
        }

        public override void ChangeSprite() {
            GetComponentInChildren<SpriteRenderer>().sprite = FindObjectOfType<Data>().tileSpiteArr[0];
            GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255);
            //GetComponentInChildren<Transform>().localPosition = new Vector2(0,.08f);
            GetComponentInChildren<Transform>().localScale = new Vector2(1, 1);
        }
        // smth for if pOnTile>1, offset ppl on the tile
    }
}
