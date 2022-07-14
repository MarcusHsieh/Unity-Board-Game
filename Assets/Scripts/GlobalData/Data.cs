// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;

namespace MookCode.GlobalData
{
    public class Data : MonoBehaviour {

        public static bool isEndGame = false;
        public static bool isEndRound = false;

        // inc speed seems to fix not moving enough
        public static int speed = 500; 
        public static float smoothTime = 0.5f;
        public static float maxSpeed = Mathf.Infinity;
        private int tempNum = 0;

        public static Players[] playersArr = new Players[4];
        // may have playerList in other scripts, need to change to playerArr
        public static Vector2[] pOffsetArr = new Vector2[4];
        public static int currPlayer = 0;

        public static GameObject[] tileArr = new GameObject[28];
        public static Component[] tileComponents = new Component[3];

        public static int diceRoll = 0;

        private void Awake() {
            setTileArr();
            //tileArr[0].GetComponent<ADDCOINS>().RunTileEvent();
            
            //Debug.Log(tileComponents.Length); // get # of components in GameObject
            /*foreach (Component component in tileComponents) {
                Debug.Log(component.ToString());
            }*/
 
            tempNum = 0;
            //Debug.Log(FindObjectOfType<P0>().getCurrTile());
            var players = FindObjectsOfType<Players>();
            foreach (var player in players) { // make array of the players
                //Debug.Log(">> "+player);
                playersArr[tempNum] = player;
                tempNum++;
            }

            //players[0].getCurrCoins();
            //players[0].Move();
            //players[0].
            // Poffset in data


            pOffsetArr[0] = new Vector2(-0.205f, 0.206f);
            pOffsetArr[1] = new Vector2(0.195f, 0.206f);
            pOffsetArr[2] = new Vector2(-0.205f, -0.09f);
            pOffsetArr[3] = new Vector2(0.195f, 0.09f);

            

        }
        // check for # of components
        // Destroy component when need to change tile 
        // Also later need to add a sprite or some indicator for each tile type (Visually)
        private void setTileArr() {
            string temp = "";
            tileArr[0] = GameObject.Find("00");
            tileArr[0].AddComponent<START>();
            for (int i = 2; i < 27; i += 2) {
                temp = i.ToString().PadLeft(2, '0');
                tileArr[i] = GameObject.Find(temp);
                tileArr[i].AddComponent<ADDCOINS>();
            }
            for (int i = 1; i < 27; i += 2) {
                temp = i.ToString().PadLeft(2, '0');
                tileArr[i] = GameObject.Find(temp);
                tileArr[i].AddComponent<MINCOINS>();
            }
            
        }

        //Players[] playerList = Players[0, 1, 2, 3];
    }
}
