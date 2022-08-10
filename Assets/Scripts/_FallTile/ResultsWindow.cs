// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MookCode.GlobalData;


namespace MookCode._FallTile
{
    public class ResultsWindow : MonoBehaviour {
        Vector2[] placementsPosArr = new Vector2[4];
        public int[] pPlacementsArr = new int[3];
        int temp = 0;
        int total = 6;
        int lastP;
        int tempP;
        string pName;
        bool hasFoundLastP = false;
        bool notLastP = false;
        string[] playerData;

        private void Start() {
            placementsPosArr[0] = new Vector2(-190, -240);
            placementsPosArr[1] = new Vector2(-190, -80);
            placementsPosArr[2] = new Vector2(-190, 80);
            placementsPosArr[3] = new Vector2(-190, 240);
            for (int i = 0; i < pPlacementsArr.Length; i++) {
                pPlacementsArr[i] = -1;
            }
        }

        public void nextDeath(string p) {
            tempP = int.Parse(p.Substring(6));
            pPlacementsArr[temp] = tempP;
            Data.barrelsDodged[tempP] = FindObjectOfType<BlockSpawner>().getBarrelsSpawned();
            temp++;
            total -= tempP; 
            // since 0 + 1 + 2 + 3 = 6, after nextDeath() runs 3 times,
            // we'll be able to find the last number (one unknown)
            if (temp == 3) {
                Data.barrelsDodged[total] = FindObjectOfType<BlockSpawner>().getBarrelsSpawned() + 1;
            }
        }
        public void setupResultsWindow() {
            foreach (int p in pPlacementsArr) {
                Debug.Log(p + "<<<");
            }
            for (int i = 0; i < 4; i++) { // # of placementPos, 0 = top, 3 = bot
                for (int j = 0; j < 3; j++) { // # of pPlacements, 0 = bot, 2 = second to top
                    if (i == pPlacementsArr[j]) { // looking for player i's ranking
                        pName = "P" + i.ToString();
                        //Debug.Log(i + "pNamed");
                        setText(i,j);
                        GameObject.Find(pName).GetComponent<RectTransform>().localPosition = placementsPosArr[j];
                        notLastP = true;
                    }
                }
                if (!hasFoundLastP && !notLastP) {
                    lastP = i;
                    hasFoundLastP = true;
                }
                notLastP = false;
            }
            pName = "P" + lastP.ToString();
            setText(lastP, 3);
            GameObject.Find(pName).GetComponent<RectTransform>().localPosition = placementsPosArr[3];
            updateCoinStats();
        }
        void setText(int p,int n) { // player number, placement number backwards
            string[] players = Data.playersArrSave.Split('|');
            string[] colNames = { "Barrel", "Trophies", "Coins" };
            playerData = players[p].Split('\\');
            Debug.Log("Text set");
            for (int k = 0; k < colNames.Length; k++) {
                foreach (TMP_Text val in GameObject.Find(colNames[k]).GetComponentsInChildren<TMP_Text>()) {
                    if (val.name.Equals($"{3-n}")) {
                        if (k == 0) { // barrels dodged
                            val.text = $"{Data.barrelsDodged[p]}";
                            Debug.Log("Set barrels");
                        }
                        else if (k == 1) { // Trophies
                            val.text = $"{playerData[1]}";
                        }
                        else if (k == 2) { // Coins
                            val.text = $"{playerData[0]}";
                        }

                    }
                }
            }
        }
        void updateCoinStats() {
            bool last = false;
            string[] players = Data.playersArrSave.Split('|');
            string newPlayerSave = "";
            int finalNum = 0;
            int currP = 0;
            for (int i = 0; i < 3; i++) {
                finalNum += pPlacementsArr[i];
            }
            pPlacementsArr[3] = 6 - finalNum; // (first place)      0 + 1 + 2 + 3 = 6 
            for (int i = 0; i < players.Length; i++) {
                for (int j = 0; j < 4; j++) {
                    if (pPlacementsArr[j] == i) {
                        currP = j;
                        break;
                    }
                }
                playerData = players[i].Split('\\'); // coins\\trophies\\currTile
                string coins = (int.Parse(playerData[0]) + Data.coinWinnings[3-currP]).ToString();
                newPlayerSave += coins;
                newPlayerSave += "\\";
                for (int j = 1; j < playerData.Length; j++) {
                    newPlayerSave += playerData[j];
                    if (i == players.Length - 1 && j == playerData.Length - 1) {
                        last = true;
                    }
                    if (j == playerData.Length - 1 && !last) {
                        newPlayerSave += "|";
                    }
                    else if (!last){
                        newPlayerSave += "\\";
                    }
                }
            }
            Data.playersArrSave = newPlayerSave;
        }
        

        public void openResultsCanvas() {
            GetComponentInParent<CanvasGroup>().alpha = 1;
        }
        public void closeResultsCanvas() {
            GetComponentInParent<CanvasGroup>().alpha = 0;
        }

    }
}
