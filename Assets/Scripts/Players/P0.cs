// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Gameboard.Tiles;
using MookCode.GlobalData;


namespace MookCode.NPlayers
{
    public class P0 : Players {
        private Vector2 nextTile; // currently (0,0)

        public override void Move() {
            Debug.Log(gameObject.name + " moving");

            // Get next tile pos
            nextTile = Data.tileArr[(getCurrTile() + 1) % 27].transform.position;
            Debug.Log("Tile "+nextTile);
            
            // Move one tile forward
            // Vector2.SmoothDamp (?)
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, nextTile, Data.speed * Time.deltaTime);

            // Update currTile
            incCurrTile();
            if (getEndTile() == getCurrTile()) {
                setOnEndTile(true);
            }
            // Check if onEndTile, if yes then onEndTile = true
            //setEndTile(getDiceRoll(), getCurrTile());
        }


        public override void UseItem() {
            throw new System.NotImplementedException();
        }
        public override void MoveOffset() {
            throw new System.NotImplementedException();
        }

        private void Awake() {
            setCurrCoins(100);
            Debug.Log("Set coins to 100");
        }
    }
}
