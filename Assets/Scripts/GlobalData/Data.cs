// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;

namespace MookCode.GlobalData
{
    public class Data : MonoBehaviour {

        public Sprite[] tileSpiteArr = new Sprite[4];

        public static bool isEndGame = false;
        public static bool isEndRound = false;

        // inc speed seems to fix not moving enough
        public static int speed = 500; 
        public static float smoothTime = 0.5f;
        public static float maxSpeed = Mathf.Infinity;

        // reset these to wtv you want at beginning of func
        public static int tempNum = 0;
        public static int tempInde = 0;
        public static Players tempP;


        public static Players[] playersArr = new Players[4];
        // may have playerList in other scripts, need to change to playerArr
        public static Vector2[] pOffsetArr = new Vector2[4];
        public static int currPlayer = 0;

        public static GameObject[] tileArr = new GameObject[28];
        public static Component[] tileComponents = new Component[3];

        // Dice
        public static int diceRoll = 0;
        public static bool hasRunEvent = false;

        // UI
        public static bool hasTrophyInput = false;

        private void Awake() {
            //setTileArr();
            //tileArr[0].GetComponent<ADDCOINS>().RunTileEvent();
            
            //Debug.Log(tileComponents.Length); // get # of components in GameObject
            /*foreach (Component component in tileComponents) {
                Debug.Log(component.ToString());
            }*/
 
            
            //Debug.Log(FindObjectOfType<P0>().getCurrTile());
            //setPlayersArr();
            //2031
            //sortPlayersArr();
            //players[0].getCurrCoins();
            //players[0].Move();
            //players[0].
            // Poffset in data


            

            

        }

    }
}
