// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.Gameboard.Tiles
{
    public abstract class TileEvents : MonoBehaviour {

        public int pOnTile = 0;
        public virtual IEnumerator RunTileEvent() {
            Debug.Log("Base RunTileEvent()");
            yield return null;
        }
        //public abstract void RunTileEvent();
        public abstract string GetName();

        public abstract void ChangeSprite();

        public void pOnTileCheck() {

        }
    }
}
