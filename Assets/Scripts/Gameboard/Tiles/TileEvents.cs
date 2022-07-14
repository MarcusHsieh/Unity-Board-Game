// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.Gameboard.Tiles
{
    public abstract class TileEvents : MonoBehaviour {

        public int pOnTile = 0;
        public abstract void RunTileEvent();
        public abstract string GetName();

        public void pOnTileCheck() {

        }
    }
}
