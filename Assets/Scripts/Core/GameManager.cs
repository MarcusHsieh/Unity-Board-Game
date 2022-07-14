// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;
using MookCode.Dice;


namespace MookCode.Core
{
    public class GameManager : MonoBehaviour {

         [SerializeField]
        private P0 pZero;
         [SerializeField]
        private P1 pOne;
         [SerializeField]
        private P2 pTwo;
         [SerializeField]
        private P3 pThree;


        [SerializeField]
        private int currCoins;
         [SerializeField]
        private int currTile;
         [SerializeField]
        private bool onEndTile; // for GM locally


        void Start() {

            // need to add smth for game as a whole and main menu?
            StartCoroutine(inRound());

            /*
            FindObjectOfType<P0>().Move();
            Debug.Log(Data.tileArr[0].getEventName());
            Debug.Log(Data.tileArr[1].getPos());
            Debug.Log(GameObject.Find("0").transform.position);*/
        }

        private void Update() {

        }

         IEnumerator inRound() {
            Debug.Log("In round...");
            while (Data.isEndRound == false) {
                // I think I need to use coroutines here after moving in case of a tile event
                // maybe put in each tile event

                // Ask whether move or use item
                // *[item]
                // [move] - have for each player? Think I have to
                // 1. x = rollDice();
                // wait for other coroutine
                yield return StartCoroutine(GameObject.Find("Dice").GetComponent<DiceScript>().RollDice());
                // 2. For loop for x times
                //     Move();
                //     runTileEvent();
                Data.playersArr[Data.currPlayer].setEndTile(Data.diceRoll,Data.playersArr[Data.currPlayer].getCurrTile());
                for (int i = 0; i < Data.diceRoll; i++) {
                    Data.playersArr[Data.currPlayer].Move(); // Move current 
                    runTileEvent();
                    yield return null;
                }
                Data.currPlayer++;
                yield return new WaitForSeconds(2);
                GameObject.Find("Dice").GetComponent<DiceScript>().deactivateDice();
                yield return new WaitForSeconds(1);

                // run minigame sequence
                if (Data.currPlayer == 4) {
                    Debug.Log("Running minigame");
                    //yield return StartCoroutine( minigame coroutine );
                    Data.isEndRound = true;
                }
                yield return null;
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
