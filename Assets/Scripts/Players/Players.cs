// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode.NPlayers
{
    public abstract class Players : MonoBehaviour {
         [SerializeField]
        private int currCoins;
         [SerializeField]
        private int currTile;
         [SerializeField]
        private bool onEndTile;

        private void Awake() {
            currCoins = 10;
            currTile = 0;
            onEndTile = true;

        }

        public int getCurrCoins() {
            return currCoins;
        }

        public int getCurrTile() {
            return currTile;
        }
        public bool getOnEndTile() {
            return onEndTile;
        }


        public void Move() {
            Debug.Log(gameObject.name + " moving");
            // Move one tile forward
            // Update currTile
            // Check if onEndTile, if yes then onEndTile = true
            
            
        }

        public void UseItem() {
            Debug.Log("Use item");
            // Open player's item menu
            // will implement later
        }
    }
}
