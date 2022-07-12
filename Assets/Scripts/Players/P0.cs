// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Gameboard.Tiles;
using MookCode.GlobalData;


namespace MookCode.NPlayers
{
    public class P0 : Players {
        private Vector2 nextTile;

        public override void Move() {
            Debug.Log(gameObject.name + " moving");

            // Get next tile pos
            //nextTile = TileInfo.tileArr[(getCurrTile() + 1) % 27].getPos();
            
            // Move one tile forward
            // Vector2.SmoothDamp (?)
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, nextTile, Data.speed * Time.deltaTime);

            // Update currTile
            incCurrTile();

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
            Debug.Log(gameObject.transform.position);
        }
    }
}
