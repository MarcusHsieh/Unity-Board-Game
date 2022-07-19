// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;
using MookCode.Dice;
using MookCode.UI;


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

        private int toDiceRoll = 0;
        private void Awake() {
            
        }
        void Start() {
            setTileArr();
            setPlayersArr();
            sortPlayersArr();
            setpOffsetArr();
            

            setTrophyTile(3);
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
            Debug.Log(Data.currPlayer + "'s turn");

            while (Data.isEndRound == false) {
                FindObjectOfType<PStatWindow>().updateTurn();
                FindObjectOfType<PStatWindow>().updateStats();
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

                yield return StartCoroutine(RunMoveSeq());
                //Debug.Log("Past RunMoveSeq()");

                Data.currPlayer++;
                GameObject.Find("Dice").GetComponent<DiceScript>().deactivateDice();
                yield return new WaitForSeconds(1);

                // run minigame sequence
                if (Data.currPlayer == 4) {
                    Debug.Log("Running minigame");
                    //yield return StartCoroutine( minigame coroutine ); or change scene
                    Data.isEndRound = true;
                }
                yield return null;
            }
            
        }
        IEnumerator RunMoveSeq() {
            while (toDiceRoll < Data.diceRoll) {
                Data.playersArr[Data.currPlayer].Move();
                yield return StartCoroutine(runTileEvent());
                FindObjectOfType<PStatWindow>().updateStats();
                toDiceRoll++;
            }
            toDiceRoll = 0;
        }
        IEnumerator runTileEvent() {
            // **not sure it this will pause everything until it finishes, then continue running code
            
            Data.tileComponents = Data.tileArr[Data.playersArr[Data.currPlayer].getCurrTile()]
                .GetComponents(typeof(Component)); // grab components in current tile
            if (Data.tileComponents.Length > 1) { // if component list has more than just transform
                var tileRunner = Data.tileArr[Data.playersArr[Data.currPlayer].getCurrTile()]
                    .GetComponents(typeof(Component))[1] as TileEvents;
                if (tileRunner.GetName().Equals("START") || tileRunner.GetName().Equals("TROPHY")
                    || Data.playersArr[Data.currPlayer].getOnEndTile() == true) { // if start, trophy, or end tile
                    // can change [1] to [Data.tileComponents.Length-1] if trying to add more components later
                    Debug.Log(tileRunner.GetName() + " should be running now");
                    yield return StartCoroutine(tileRunner.RunTileEvent()); // runs whatever event the tile has
                }
            }
            //Data.hasRunEvent = true;
            
        }
        public void setTrophyTile(int n) {
            Data.tileComponents = Data.tileArr[n].GetComponents(typeof(Component));
            var someTile = Data.tileArr[n].GetComponents(typeof(Component))[1] as TileEvents;
            Destroy(someTile);
            Data.tileArr[n].AddComponent<TROPHY>();
        }
        private void setPlayersArr() {
            // NOT IN RIGHT ORDER
            Data.tempNum = 0;
            var players = FindObjectsOfType<Players>();
            foreach (var player in players) { // make array of the players
                //Debug.Log(">> "+player);
                Data.playersArr[Data.tempNum] = player;
                Data.tempNum++;
            }
        }
        private void sortPlayersArr() {
            Data.tempInde = 0;
            for (int i = 0; i < Data.playersArr.Length - 1; i++) {
                Debug.Log("aaa");
                Data.tempInde = i;
                for (int j = i + 1; j < Data.playersArr.Length; j++) {
                    Debug.Log(Data.playersArr[j].getPlayerNum() + "<" + Data.playersArr[Data.tempInde].getPlayerNum());
                    if (Data.playersArr[j].getPlayerNum() < Data.playersArr[Data.tempInde].getPlayerNum()) {
                        Data.tempInde = j;
                        Debug.Log(" > " + Data.playersArr[j].getPlayerNum());
                    }
                }
                Debug.Log(Data.playersArr[i].getPlayerNum());
                Data.tempP = Data.playersArr[i];
                Data.playersArr[i] = Data.playersArr[Data.tempInde];
                Data.playersArr[Data.tempInde] = Data.tempP;
            }
            Debug.Log("Sorted pA!");
        }

        // check for # of components
        // Destroy component when need to change tile 
        // Also later need to add a sprite or some indicator for each tile type (Visually)
        private void setTileArr() {
            string temp = "";
            Data.tileArr[0] = GameObject.Find("00");
            Data.tileArr[0].AddComponent<START>();
            for (int i = 2; i < 27; i += 2) {
                temp = i.ToString().PadLeft(2, '0');
                Data.tileArr[i] = GameObject.Find(temp);
                Data.tileArr[i].AddComponent<ADDCOINS>();
            }
            for (int i = 1; i < 27; i += 2) {
                temp = i.ToString().PadLeft(2, '0');
                Data.tileArr[i] = GameObject.Find(temp);
                Data.tileArr[i].AddComponent<MINCOINS>();
            }
        }
        private void setpOffsetArr() {
            Data.pOffsetArr[0] = new Vector2(-0.205f, 0.206f);
            Data.pOffsetArr[1] = new Vector2(0.195f, 0.206f);
            Data.pOffsetArr[2] = new Vector2(-0.205f, -0.09f);
            Data.pOffsetArr[3] = new Vector2(0.195f, 0.09f);
        }
    }
}
