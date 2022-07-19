// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Core;
using MookCode.GlobalData;


namespace MookCode.UI
{
    public class TrophyPrompt : MonoBehaviour {
        // scuffed animation for now :)
        public void openTrophyPrompt() {
            GetComponent<CanvasGroup>().alpha = .2f;
            GetComponent<CanvasGroup>().alpha = .4f;
            GetComponent<CanvasGroup>().alpha = .6f;
            GetComponent<CanvasGroup>().alpha = .8f;
            GetComponent<CanvasGroup>().alpha = 1;
        }
        public void closeTrophyPrompt() {
            GetComponent<CanvasGroup>().alpha = .8f;
            GetComponent<CanvasGroup>().alpha = .6f;
            GetComponent<CanvasGroup>().alpha = .4f;
            GetComponent<CanvasGroup>().alpha = .2f;
            GetComponent<CanvasGroup>().alpha = 0;
        }

        public void buyTrophy() {
            Data.playersArr[Data.currPlayer].incCurrTrophies(1);
            Data.playersArr[Data.currPlayer].decCurrCoins(10);
            Debug.Log("+1 Trophy \\ -10 coins");
            Data.hasTrophyInput = true;
        }
        public void passTrophy() {
            Debug.Log("Pass trophy");
            Data.hasTrophyInput = true;
        }
    }
}
