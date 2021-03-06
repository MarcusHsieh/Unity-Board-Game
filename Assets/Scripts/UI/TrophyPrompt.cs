// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.Core;
using MookCode.GlobalData;
using UnityEngine.UI;


namespace MookCode.UI
{
    public class TrophyPrompt : MonoBehaviour {
        
        public void openTrophyPrompt() {
            Debug.Log("OpeningTrophyPrompt");
            GetComponent<CanvasGroup>().alpha = 1;
            if (Data.playersArr[Data.currPlayer].getCurrCoins() > 10) {
                GameObject.Find("BuyTrophy").GetComponent<Button>().interactable = true;
            }
            GameObject.Find("PassTrophy").GetComponent<Button>().interactable = true;
        }
        public void closeTrophyPrompt() {
            Debug.Log("ClosingTrophyPrompt");
            GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("BuyTrophy").GetComponent<Button>().interactable = false;
            GameObject.Find("PassTrophy").GetComponent<Button>().interactable = false;
        }

        public void buyTrophy() {
            Debug.Log("Buying trophy!");
            Data.playersArr[Data.currPlayer].incCurrTrophies(1);
            Data.playersArr[Data.currPlayer].decCurrCoins(10);
            Debug.Log("+1 Trophy \\ -10 coins");
            Data.hasTrophyInput = true;
            closeTrophyPrompt();
            int randNum = Random.Range(1, 27);
            while (randNum == Data.playersArr[Data.currPlayer].getCurrTile()
                && randNum == Data.playersArr[0].getCurrTile()
                && randNum == Data.playersArr[1].getCurrTile()
                && randNum == Data.playersArr[2].getCurrTile()
                && randNum == Data.playersArr[3].getCurrTile()
                && randNum == 0) {
                randNum = Random.Range(1, 27);
            }
            FindObjectOfType<GameManager>().setTrophyTile(randNum);
        }
        public void passTrophy() {
            Debug.Log("Pass trophy");
            Data.hasTrophyInput = true;
            closeTrophyPrompt();
        }
    }
}
