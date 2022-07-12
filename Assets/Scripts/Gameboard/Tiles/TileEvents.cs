// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.Gameboard.Tiles
{
    public abstract class TileEvents : MonoBehaviour {

        public int pOnTile = 0;
        public abstract void RunTileEvent();

        /*public void RunTileEvent(string eventName) {
            if (eventName.Equals("START")) {
                Debug.Log(eventName);
                // +8 coins WHEN PASS, don't need to land
            }
            else if (eventName.Equals("ADDCOINS")) {
                Debug.Log(eventName);
                // +3 coins
            }
            else if (eventName.Equals("MINCOINS")) {
                Debug.Log(eventName);
                // -3 coins
            }
            else if (eventName.Equals("TROPHY")) {
                Debug.Log(eventName);
                // Trophy prompt
            }
        }*/
    }
}
