// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MookCode.GlobalData;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;
using MookCode.Dice;
using MookCode.UI;



namespace MookCode.Core
{
    public class GameManager : MonoBehaviour {
        private static bool gm_Initialized = false;
        private int toDiceRoll = 0;

        
        private void Awake() {
            
        }
        void Start() {
            if (gm_Initialized) {
                // grab save data and set everything from that
                loadTileArr();
                setPlayersArr();
                sortPlayersArr();
                loadPlayerArr();
                
            }
            if (!gm_Initialized) {
                setTileArr();
                setPlayersArr();
                sortPlayersArr();
                setpOffsetArr();
                // set to rand later 
                // check TrophyPrompt buyTrophy()
                setTrophyTile(3);
                gm_Initialized = true;
            }
            // in inGame(), just have inRound run once, so after scene change it'll run once
            StartCoroutine(inGame());

        }

        private void Update() {
            //StartCoroutine(inGame());
            
        }
        IEnumerator inGame() {
            while (Data.isEndGame == false) {
                yield return StartCoroutine(inRound());
                Data.isEndRound = false;
                for (int i = 0; i < Data.playersArr.Length; i++) {
                    Data.playersArr[i].setOnEndTile(false);
                }
                Debug.Log("Next round...");
                if (Data.roundNum == 10) {
                    Debug.Log("end game...");
                    Data.isEndGame = true;
                }
            }
            // scene change to end screen?
        }

        IEnumerator inRound() {
            Debug.Log("In round..."+Data.roundNum);
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
                saveTileArr();
                savePlayerArr();
                // run minigame sequence
                if (Data.currPlayer == 4) {
                    Debug.Log("Running minigame");
                    //yield return StartCoroutine( minigame coroutine ); or change scene
                    SceneManager.LoadScene(1);
                    Data.currPlayer = 0;
                    Data.isEndRound = true;
                    Data.roundNum++;
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
                // add more later...
            }
            //Data.hasRunEvent = true;

        }
        public void setTrophyTile(int n) {
            int someTileInd = -1;
            for (int i = 0; i < Data.tileArr.Length; i++) {
                if (Data.tileArr[i].GetComponent<TROPHY>() != null) {
                    //Debug.Log(i + " has trophy!");
                    someTileInd = i;
                }
            }
            //Data.tileComponents = Data.tileArr[n].GetComponents(typeof(Component));
            var someTile = Data.tileArr[n].GetComponents(typeof(Component))[1] as TileEvents;
            Destroy(someTile);
            // replace old tile if exists
            if (someTileInd != -1) {
                Destroy(Data.tileArr[someTileInd].GetComponent<TROPHY>());
                if (someTileInd % 2 == 0) {
                    Data.tileArr[someTileInd].AddComponent<ADDCOINS>();
                    Data.tileArr[someTileInd].GetComponent<ADDCOINS>().ChangeSprite();
                }
                else if (someTileInd % 2 == 1) {
                    Data.tileArr[someTileInd].AddComponent<MINCOINS>();
                    Data.tileArr[someTileInd].GetComponent<MINCOINS>().ChangeSprite();
                }
                // add more later...
            }
            Data.tileArr[n].AddComponent<TROPHY>();
            Data.tileArr[n].GetComponent<TROPHY>().ChangeSprite();
        }
        // 1
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
        // 2
        private void savePlayerArr() {
            Data.playersArrSave = "";
            // split each player with |
            // split each value with \
            //  > coins\trophies\currTile
            //   > Later add items LAST - so last few elements of array are always items 
            foreach (Players p in Data.playersArr) {
                Data.playersArrSave += p.getCurrCoins();
                Data.playersArrSave += "\\";
                Data.playersArrSave += p.getCurrTrophies();
                Data.playersArrSave += "\\";
                Data.playersArrSave += p.getCurrTile();
                Data.playersArrSave += "\\";
                Data.playersArrSave += "item0,item1,item2";
                if (p.getPlayerNum() != 3) {
                    Data.playersArrSave += "|";
                }
                // add more later...
            }
        }
        // 3
        private void loadPlayerArr() {
            // MoveTowards curr tile
            int n = 0;
            string[] players = Data.playersArrSave.Split('|');
            string[] tempPlayer;
            foreach (Players p in Data.playersArr) {
                tempPlayer = players[n].Split('\\');
                p.playerLoader(int.Parse(tempPlayer[0]), int.Parse(tempPlayer[1]), int.Parse(tempPlayer[2]), tempPlayer[3]);
                p.gameObject.transform.position = Data.tileArr[p.getCurrTile()].transform.position;
                n++;
            }
        }
        private void sortPlayersArr() {
            Data.tempInde = 0;
            for (int i = 0; i < Data.playersArr.Length - 1; i++) {
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
        
        // 1
        private void setTileArr() {
            string temp = "";
            Data.tileArr[0] = GameObject.Find("00");
            Data.tileArr[0].AddComponent<START>();
            Data.tileArr[0].GetComponent<START>().ChangeSprite();
            for (int i = 2; i < 28; i += 2) {
                temp = i.ToString().PadLeft(2, '0');
                Data.tileArr[i] = GameObject.Find(temp);
                Data.tileArr[i].AddComponent<ADDCOINS>();
                Data.tileArr[i].GetComponent<ADDCOINS>().ChangeSprite();
            }
            for (int i = 1; i < 28; i += 2) {
                temp = i.ToString().PadLeft(2, '0');
                Data.tileArr[i] = GameObject.Find(temp);
                Data.tileArr[i].AddComponent<MINCOINS>();
                Data.tileArr[i].GetComponent<MINCOINS>().ChangeSprite();
            }
            // add more later...
        }
        // 2
        private void saveTileArr() {
            // save into a string

            Data.tileArrSave = ""; 
            // don't need one for Start since it'll always be at the beginning
            foreach (GameObject tile in Data.tileArr) {
                var someTile = tile.GetComponents(typeof(Component))[1] as TileEvents;
                if (someTile.GetName().Equals("TROPHY")) {
                    Data.tileArrSave += "T";
                }
                else if (someTile.GetName().Equals("ADDCOINS")) {
                    Data.tileArrSave += "A";
                }
                else if (someTile.GetName().Equals("MINCOINS")) {
                    Data.tileArrSave += "M";
                }
                // add more later...
            }
        }
        // 3
        private void loadTileArr() {
            int n = 1; // start at 1 bc START autosets
            string temp = "";
            Data.tileArr[0] = GameObject.Find("00");
            Data.tileArr[0].AddComponent<START>();
            Data.tileArr[0].GetComponent<START>().ChangeSprite();
            foreach (char c in Data.tileArrSave) {
                temp = n.ToString().PadLeft(2, '0');
                if (c.Equals('T')) {
                    Data.tileArr[n] = GameObject.Find(temp);
                    Data.tileArr[n].AddComponent<TROPHY>();
                    Data.tileArr[n].GetComponent<TROPHY>().ChangeSprite();
                }
                else if (c.Equals('A')) {
                    Data.tileArr[n] = GameObject.Find(temp);
                    Data.tileArr[n].AddComponent<ADDCOINS>();
                    Data.tileArr[n].GetComponent<ADDCOINS>().ChangeSprite();
                }
                else if (c.Equals('M')) {
                    Data.tileArr[n] = GameObject.Find(temp);
                    Data.tileArr[n].AddComponent<MINCOINS>();
                    Data.tileArr[n].GetComponent<MINCOINS>().ChangeSprite();
                }
                // add more later...
                n++;
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
