// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Gameboard.Tiles;
using MookCode.NPlayers;

namespace MookCode.GlobalData
{
    public class Data : MonoBehaviour {

        
        public static Players[] playersList = new Players[4];
        public static int currPlayer = 0;
        public static TileInfo[] tileArr = new TileInfo[28];
        private void Start() {


            Debug.Log(FindObjectOfType<P0>().getCurrTile());
            var players = FindObjectsOfType<Players>();
            foreach (var player in players) {
                Debug.Log(player);
            }
            players[0].Move();
            //players[0].
            // Poffset in data

            //playersList[0] = P0;
            
            tileArr[0] = new TileInfo(GameObject.Find("0").transform.position, "START");
            tileArr[1] = new TileInfo(GameObject.Find("1").transform.position, "ADDCOINS");
            tileArr[2] = new TileInfo(GameObject.Find("2").transform.position, "MINCOINS");
            tileArr[3] = new TileInfo(GameObject.Find("3").transform.position, "ADDCOINS");
            tileArr[4] = new TileInfo(GameObject.Find("4").transform.position, "MINCOINS");
            tileArr[5] = new TileInfo(GameObject.Find("5").transform.position, "TROPHY");
            tileArr[6] = new TileInfo(GameObject.Find("6").transform.position, "MINCOINS");
            tileArr[7] = new TileInfo(GameObject.Find("7").transform.position, "MINCOINS");
            tileArr[8] = new TileInfo(GameObject.Find("8").transform.position, "ADDCOINS");
            tileArr[9] = new TileInfo(GameObject.Find("9").transform.position, "ADDCOINS");
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
            tileArr[27] = new TileInfo(GameObject.Find("27").transform.position, "ADDCOINS");
        }

        //Players[] playerList = Players[0, 1, 2, 3];
    }
}
