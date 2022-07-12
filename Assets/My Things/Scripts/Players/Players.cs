// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Gameboard.Tiles;
using MookCode.GlobalData;


namespace MookCode.NPlayers
{
    public abstract class Players : MonoBehaviour {
         [SerializeField]
        private int currCoins;
         [SerializeField]
        private int currTile;
         [SerializeField]
        private bool onEndTile;
         [SerializeField]
        private int endTile;

        private void Awake() {
            currCoins = 10;
            currTile = 0;
            onEndTile = true;
            endTile = 0;

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

        public void setCurrCoins(int n) { // for testing
            currCoins = n;
        }

        public void setEndTile(/*int diceRoll, */int currTile) {
            endTile = (/*DiceRollFunc + */currTile) % 27;
        }

        public void incCurrTile() {
            currTile++;
        }





        public abstract void Move(); 
        // each Move() in P0, P1, P2, P3
        public abstract void UseItem();
        //Debug.Log("Use item");
        // Open player's item menu
        // will implement later
        public abstract void setEndTile();
    }
}
