// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;

namespace MookCode.GlobalData
{
    public class Data : MonoBehaviour {

        public static int speed = 100;
        public static float smoothTime = 0.5f;
        public static float maxSpeed = Mathf.Infinity;
        private int tempNum = 0;
        public static Players[] playersArr = new Players[4];
        // may have playerList in other scripts, need to change to playerArr
        public static Vector2[] pOffsetArr = new Vector2[4];
        public static int currPlayer = 0;

        public static GameObject[] tileArr = new GameObject[28];
        public static Component[] tileComponents = new Component[3];
        
        private void Start() {
            setTileArr();
            //tileArr[0].GetComponent<ADDCOINS>().RunTileEvent();
            tileComponents = tileArr[0].GetComponents(typeof(Component));
            Debug.Log(tileComponents.Length); // get # of components in GameObject
            /*foreach (Component component in tileComponents) {
                Debug.Log(component.ToString());
            }*/
            /*
            var a = tileArr[0].GetComponents(typeof(Component))[1] as TileEvents;
            a.RunTileEvent(); // runs whatever event the tile has
            */
            tempNum = 0;
            Debug.Log(FindObjectOfType<P0>().getCurrTile());
            var players = FindObjectsOfType<Players>();
            foreach (var player in players) { // make array of the players
                //Debug.Log(">> "+player);
                playersArr[tempNum] = player;
                tempNum++;
            }

            //players[0].getCurrCoins();
            players[0].Move();
            //players[0].
            // Poffset in data

            //playersList[0] = P0;

            pOffsetArr[0] = new Vector2(-0.205f, 0.206f);
            pOffsetArr[1] = new Vector2(0.195f, 0.206f);
            // need to update pOffset for p2 and p3
            //pOffsetArr[2] = new Vector2(0.195f, 0.206f);
            //pOffsetArr[3] = new Vector2(0.195f, 0.206f);

            

        }
        // check for # of components
        private void setTileArr() {
            
            tileArr[0] = GameObject.Find("00");
            tileArr[0].AddComponent<ADDCOINS>();
            
        }

        //Players[] playerList = Players[0, 1, 2, 3];
    }
}
