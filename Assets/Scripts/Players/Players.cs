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
        private int currTrophies;
         [SerializeField]
        private int currTile;
         [SerializeField]
        private bool onEndTile;
         [SerializeField]
        private int endTile;
         [SerializeField]
        private int playerNum;
         [SerializeField]
        private int placementNum;

        private void Awake() {
            currCoins = 10;
            currTile = 0;
            onEndTile = false;
            endTile = 0;

        }

        public int getCurrCoins() {
            return currCoins;
        }
        public int getCurrTrophies() {
            return currTrophies;
        }
        public int getCurrTile() {
            return currTile;
        }
        public bool getOnEndTile() {
            return onEndTile;
        }
        public int getEndTile() {
            return endTile;
        }
        public int getPlacementNum() {
            return placementNum;
        }
        public void setCurrCoins(int n) { // for testing
            currCoins = n;
        }

        public void setEndTile(int diceRoll, int currTile) {
            endTile = (diceRoll + currTile) % 27;
        }
        public void setOnEndTile(bool b) {
            onEndTile = b;
        }
        public void setPlacementNum(int n) {
            placementNum = n;
        }

        public void incCurrTile() {
            currTile++;
        }
        public void incCurrCoins(int n) {
            for (int i = 0; i < n; i++) {
                currCoins++;
            }
        }
        public void decCurrCoins(int n) {
            for (int i = 0; i < n; i++) {
                currCoins--;
            }
        }
        public void incCurrTrophies(int n) {
            for (int i = 0; i < n; i++) {
                currTrophies++;
            }
        }
        public void decCurrTrophies(int n) {
            for (int i = 0; i < n; i++) {
                currTrophies--;
            }
        }
        public int getPlayerNum() {
            return playerNum;
        }
        public void setPlayerNum(int n) {
            playerNum = n;
        }





        public abstract void Move(); 
        // each Move() in P0, P1, P2, P3
        public abstract void UseItem();
        //Debug.Log("Use item");
        // Open player's item menu
        // will implement later
        public abstract void MoveOffset();
    
    }
}
