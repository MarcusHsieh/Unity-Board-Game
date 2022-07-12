// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.NPlayers
{
    public class P1 : Players {
        
        public Vector2 Poffset;

        public void Awake() {
            Poffset = new Vector2(0.195f, 0.206f); // top right
        }

        public Vector2 getPoffset() {
            return Poffset;
        }
    }
}
