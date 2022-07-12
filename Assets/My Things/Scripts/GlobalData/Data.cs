// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;

namespace MookCode.GlobalData
{
    public class Data : MonoBehaviour {

        public static int speed = 25;
        public static float smoothTime = 0.5f;
        public static float maxSpeed = Mathf.Infinity;
        private int tempNum = 0;
        public static Players[] playersArr = new Players[4];
        // may have playerList in other scripts, need to change to playerArr
        public static Vector2[] pOffsetArr = new Vector2[4];
        public static int currPlayer = 0;
        //public static TileInfo[] tileArr = new TileInfo[28];
        
        
        private void Start() {

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

            /*tileArr[0] = new TileInfo(GameObject.Find("00").transform.position, "START");
            tileArr[1] = new TileInfo(GameObject.Find("01").transform.position, "ADDCOINS");
            tileArr[2] = new TileInfo(GameObject.Find("02").transform.position, "MINCOINS");
            tileArr[3] = new TileInfo(GameObject.Find("03").transform.position, "ADDCOINS");
            tileArr[4] = new TileInfo(GameObject.Find("04").transform.position, "MINCOINS");
            tileArr[5] = new TileInfo(GameObject.Find("05").transform.position, "TROPHY");
            tileArr[6] = new TileInfo(GameObject.Find("06").transform.position, "MINCOINS");
            tileArr[7] = new TileInfo(GameObject.Find("07").transform.position, "MINCOINS");
            tileArr[8] = new TileInfo(GameObject.Find("08").transform.position, "ADDCOINS");
            tileArr[9] = new TileInfo(GameObject.Find("09").transform.position, "ADDCOINS");
            tileArr[10] = new TileInfo(GameObject.Find("10").transform.position, "ADDCOINS");
            tileArr[11] = new TileInfo(GameObject.Find("11").transform.position, "ADDCOINS");
            tileArr[12] = new TileInfo(GameObject.Find("12").transform.position, "ADDCOINS");
            tileArr[13] = new TileInfo(GameObject.Find("13").transform.position, "ADDCOINS");
            tileArr[14] = new TileInfo(GameObject.Find("14").transform.position, "MINCOINS");
            tileArr[15] = new TileInfo(GameObject.Find("15").transform.position, "ADDCOINS");
            tileArr[16] = new TileInfo(GameObject.Find("16").transform.position, "ADDCOINS");
            tileArr[17] = new TileInfo(GameObject.Find("17").transform.position, "MINCOINS");
            tileArr[18] = new TileInfo(GameObject.Find("18").transform.position, "ADDCOINS");
            tileArr[19] = new TileInfo(GameObject.Find("19").transform.position, "ADDCOINS");
            tileArr[20] = new TileInfo(GameObject.Find("20").transform.position, "ADDCOINS");
            tileArr[21] = new TileInfo(GameObject.Find("21").transform.position, "MINCOINS");
            tileArr[22] = new TileInfo(GameObject.Find("22").transform.position, "ADDCOINS");
            tileArr[23] = new TileInfo(GameObject.Find("23").transform.position, "MINCOINS");
            tileArr[24] = new TileInfo(GameObject.Find("24").transform.position, "ADDCOINS");
            tileArr[25] = new TileInfo(GameObject.Find("25").transform.position, "ADDCOINS");
            tileArr[26] = new TileInfo(GameObject.Find("26").transform.position, "ADDCOINS");
            tileArr[27] = new TileInfo(GameObject.Find("27").transform.position, "ADDCOINS");*/
        }
        private void Update() {
            
        }

        //Players[] playerList = Players[0, 1, 2, 3];
    }
}
