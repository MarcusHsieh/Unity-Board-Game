// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;


namespace MookCode.Core
{
    public class GameManager : MonoBehaviour {

         [SerializeField]
        private P0 pZero;
         [SerializeField]
        private P1 pOne;
        

         [SerializeField]
        private int currCoins;
         [SerializeField]
        private int currTile;
         [SerializeField]
        private bool onEndTile; // for GM locally


        void Start() {

            inGame();
            /*
            FindObjectOfType<P0>().Move();
            Debug.Log(Data.tileArr[0].getEventName());
            Debug.Log(Data.tileArr[1].getPos());
            Debug.Log(GameObject.Find("0").transform.position);*/
        }

        private void Update() {
            tempUpdateCurrPlayer(Data.currPlayer);
        }

        public void inGame() {
            // Ask whether move or use item
            // *[item]
            // [move] - have for each player? Think I have to
            // 1. x = rollDice();
            // 2. For loop for x times
            //     Move();
            //     runTileEvent();
            // change for loop to the dice roll later
            for (int i = 0; i < 5; i++) {
                Data.playersArr[Data.currPlayer].Move(); // Move current 
                
                runTileEvent();
                

            }
                Data.currPlayer++;

        }

        public void tempUpdateCurrPlayer(int currPlayer) {
            if (currPlayer == 0) {
                currCoins = pZero.getCurrCoins();
                currTile = pZero.getCurrTile();
                onEndTile = pZero.getOnEndTile();
            }
            else if (currPlayer == 1) {
                currCoins = pOne.getCurrCoins();
                currTile = pOne.getCurrTile();
                onEndTile = pOne.getOnEndTile();
            }
        }

        public void runTileEvent() {
            // **not sure it this will pause everything until it finishes, then continue running code
            
            Data.tileComponents = Data.tileArr[Data.playersArr[Data.currPlayer].getCurrTile()]
                .GetComponents(typeof(Component)); // grab components in current tile
            if (Data.tileComponents.Length > 1) { // if component list has more than just transform
                var tileRunner = Data.tileArr[Data.playersArr[Data.currPlayer].getCurrTile()]
                    .GetComponents(typeof(Component))[1] as TileEvents;
                if (tileRunner.GetName().Equals("START") || tileRunner.GetName().Equals("TROPHY")
                    || Data.playersArr[Data.currPlayer].getOnEndTile() == true) { // if start, trophy, or end tile
                    // can change [1] to [Data.tileComponents.Length-1] if trying to add more components later
                    tileRunner.RunTileEvent(); // runs whatever event the tile has
                }
            }


        }
    }
}
