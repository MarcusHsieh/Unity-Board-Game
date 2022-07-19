// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Core;
using MookCode.GlobalData;


namespace MookCode.UI
{
    public class TrophyPrompt : MonoBehaviour {
        
        public void openTrophyPrompt() {
            Debug.Log("OpeningTrophyPrompt");
            GetComponent<CanvasGroup>().alpha = 1;
        }
        public void closeTrophyPrompt() {
            Debug.Log("ClosingTrophyPrompt");
            GetComponent<CanvasGroup>().alpha = 0;
        }

        public void buyTrophy() {
            Data.playersArr[Data.currPlayer].incCurrTrophies(1);
            Data.playersArr[Data.currPlayer].decCurrCoins(10);
            Debug.Log("+1 Trophy \\ -10 coins");
            Data.hasTrophyInput = true;
            closeTrophyPrompt();
        }
        public void passTrophy() {
            Debug.Log("Pass trophy");
            Data.hasTrophyInput = true;
            closeTrophyPrompt();
        }
    }
}
