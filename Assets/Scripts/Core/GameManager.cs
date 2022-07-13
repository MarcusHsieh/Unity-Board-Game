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

            for (int i = 0; i < 5; i++) {
                Data.playersArr[Data.currPlayer].Move();
                var a = Data.tileArr[0].GetComponents(typeof(Component))
                    [Data.playersArr[Data.currPlayer].getCurrTile()] as TileEvents;
                a.RunTileEvent(); // runs whatever event the tile has
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
            // if passing trophy or start tile OR on end tile run the event
            /*if (FindObjectOfType<TileInfo>().getEventName().Equals("TROPHY") || FindObjectOfType<TileInfo>().getEventName().Equals("START") || onEndTile == true) {
                // check after every move()                     
                //FindObjectOfType<TileEvents>().RunTileEvent( Data.tileArr[ currTile ].getEventName() ); 
            }*/
            
        }
    }
}
