// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.NPlayers
{
    public class P0 : Players {
        
        public Vector2 Poffset; // move offset to Data

        public void Awake() {
            Poffset = new Vector2(-0.205f, 0.206f); // top left
        }

        public Vector2 getPoffset() {
            return Poffset;
        }
    }
}
