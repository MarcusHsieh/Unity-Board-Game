// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
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

        private void Start() {
            /*placementsPosArr[0] = new Vector2(-445, -240);
            placementsPosArr[1] = new Vector2(-445, -80);
            placementsPosArr[2] = new Vector2(-445, 80);
            placementsPosArr[3] = new Vector2(-445, 240);*/
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
                Data.barrelsDodged[total] = FindObjectOfType<BlockSpawner>().getBarrelsSpawned();
            }
        }
        public void setupResultsWindow() {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 3; j++) {
                    if (i == pPlacementsArr[j]) {
                        pName = "P" + i.ToString();
                        GameObject.Find(pName).GetComponent<RectTransform>().localPosition = placementsPosArr[j];
                        //GameObject.Find(pName).GetComponentInChildren
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
            GameObject.Find(pName).GetComponent<RectTransform>().localPosition = placementsPosArr[3];
        }

        public void openResultsCanvas() {
            GetComponentInParent<CanvasGroup>().alpha = 1;
        }
        public void closeResultsCanvas() {
            GetComponentInParent<CanvasGroup>().alpha = 0;
        }

    }
}
