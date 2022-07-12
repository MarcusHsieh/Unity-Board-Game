// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;


namespace MookCode.Gameboard.Tiles {
    public class TileInfo : TileEvents {
        private Vector2 pos;
        private int pOnTile; // for visuals so players aren't stacked if more than one on a tile
        private string eventName;

        public TileInfo(Vector2 pos, string eventName) {
            this.pos = pos;
            pOnTile = 0;
            this.eventName = eventName;
        }

        public Vector2 getPos() {
            return pos;
        }

        public int getpOnTile() {
            return pOnTile;
        }

        public string getEventName() {
            
            return eventName;
        }



    }
}
