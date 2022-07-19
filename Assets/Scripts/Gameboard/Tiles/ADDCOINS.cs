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
        public override void ChangeSprite() {
            /*var sprRend = GetComponentsInChildren<SpriteRenderer>();
            foreach (var sr in sprRend) {
                sr.sprite = FindObjectOfType<Data>().tileSpiteArr[2];
                sr.color = new Color(157, 253, 162);
            }
            var tra = GetComponentsInChildren<Transform>();
            foreach (var t in tra) {
                //t.localPosition = new Vector3(0, .1f);
                t.localScale = new Vector3(.5f, .5f);
            }
            */
            GetComponentInChildren<SpriteRenderer>().sprite = FindObjectOfType<Data>().tileSpiteArr[2];
            GetComponentInChildren<SpriteRenderer>().color = new Color(157, 253, 162);
            //GetComponentInChildren<Transform>().position = new Vector2(0, .1f);
            GetComponentInChildren<Transform>().localScale = new Vector2(.5f, .5f);
        }

        // smth for if pOnTile>1, offset ppl on the tile
    }
}
