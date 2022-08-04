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
        public int[] pPlacementsArr = new int[100];
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
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 3; j++) {
                    if (i == pPlacementsArr[j]) {
                        pName = "P" + i.ToString();
                        Debug.Log(i + "pNamed");
                        setText(i,j);
                        GameObject.Find(pName).GetComponent<RectTransform>().localPosition = placementsPosArr[j];
                        //GameObject.Find(pName).GetComponentInChildren<TMP_Text>().text = $"{4-j}.{Data.barrelsDodged[i].ToString().PadLeft(25)}{playerData[0].PadLeft(11)}{playerData[1].PadLeft(12)}";
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
            setText(lastP, 4);
            GameObject.Find(pName).GetComponent<RectTransform>().localPosition = placementsPosArr[3];
            //GameObject.Find(pName).GetComponentInChildren<TMP_Text>().text = $"{1}.{(Data.barrelsDodged[lastP]+1).ToString().PadLeft(25)}{playerData[0].PadLeft(11)}{playerData[1].PadLeft(12)}";
        }
        void setText(int p,int n) { // player number, placement number backwards
            string[] players = Data.playersArrSave.Split('|');
            string[] colNames = { "Barrel", "Trophies", "Coins" };
            playerData = players[p].Split('\\');
            Debug.Log("Text set");
            for (int k = 0; k < colNames.Length; k++) {
                foreach (TMP_Text val in GameObject.Find(colNames[k]).GetComponentsInChildren<TMP_Text>()) {
                    if (val.name == $"{4-n}") {
                        if (k == 0) {
                            val.text = $"{Data.barrelsDodged[p]}";
                            Debug.Log("Set barrels");
                        }
                        else if (k == 1) {
                            val.text = $"{playerData[0]}";
                        }
                        else if (k == 2) {
                            val.text = $"{playerData[1]}";
                        }

                    }
                }
            }
        }

        public void openResultsCanvas() {
            GetComponentInParent<CanvasGroup>().alpha = 1;
        }
        public void closeResultsCanvas() {
            GetComponentInParent<CanvasGroup>().alpha = 0;
        }

    }
}
