// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MookCode.GlobalData;

namespace MookCode.UI
{
    public class PStatWindow : MonoBehaviour {
         [SerializeField]
        TMP_Text P0_Win;
         [SerializeField]
        TMP_Text P1_Win;
         [SerializeField]
        TMP_Text P2_Win;
         [SerializeField]
        TMP_Text P3_Win;
         [SerializeField]
        GameObject turnInd;
        Vector2[] turnPosArr = new Vector2[4];
        private void Start() {
            //82.30001
            turnPosArr[0] = new Vector2(-334, 42.4f);
            turnPosArr[1] = new Vector2(-334, -40.3f);
            turnPosArr[2] = new Vector2(-334, -121.8f);
            turnPosArr[3] = new Vector2(-334, -203.3f);
        }
        public void updateStats() {
            // p1
            // need to add # placing
            P0_Win.GetComponent<TMP_Text>().text= $"P1@{Data.playersArr[0].getCurrCoins()} coins@{Data.playersArr[0].getCurrTrophies()} trophies";
            P0_Win.GetComponent<TMP_Text>().text = P0_Win.GetComponent<TMP_Text>().text.Replace("@", System.Environment.NewLine);
            P1_Win.GetComponent<TMP_Text>().text = $"P2@{Data.playersArr[1].getCurrCoins()} coins@{Data.playersArr[1].getCurrTrophies()} trophies";
            P1_Win.GetComponent<TMP_Text>().text = P1_Win.GetComponent<TMP_Text>().text.Replace("@", System.Environment.NewLine);
            P2_Win.GetComponent<TMP_Text>().text = $"P3@{Data.playersArr[2].getCurrCoins()} coins@{Data.playersArr[2].getCurrTrophies()} trophies";
            P2_Win.GetComponent<TMP_Text>().text = P2_Win.GetComponent<TMP_Text>().text.Replace("@", System.Environment.NewLine);
            P3_Win.GetComponent<TMP_Text>().text = $"P4@{Data.playersArr[3].getCurrCoins()} coins@{Data.playersArr[3].getCurrTrophies()} trophies";
            P3_Win.GetComponent<TMP_Text>().text = P3_Win.GetComponent<TMP_Text>().text.Replace("@", System.Environment.NewLine);
        }
        public void updateTurn() {
            for (int i = 0; i < 4; i++) {
                if (Data.currPlayer == i) {
                    turnInd.transform.localPosition = turnPosArr[i];
                }
            }
        }
        public void updatePlacements() {
            // Not implemented yet (#1 #2 #3 #4)
        }

    }
}
