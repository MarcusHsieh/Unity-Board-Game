// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;


namespace MookCode.Dice
{
    public class DiceScript : MonoBehaviour {
        private bool hasRolled = false;
        public void Start() {
            gameObject.GetComponent<Animator>().Play("Dice_Roll");
        }

        public void deactivateDice() {
            // disable dice from scene
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        public IEnumerator RollDice() {
            Debug.Log("Rolling dice...");
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
            while (hasRolled == false) {
                if (Input.GetKeyDown(KeyCode.Space)){
                    hasRolled = true;
                    gameObject.GetComponent<Animator>().enabled = false;
                    Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite.name);
                    Data.diceRoll = int.Parse(gameObject.GetComponent<SpriteRenderer>().sprite.name.Substring(11));
                    Data.diceRoll += 1;
                    Debug.Log("ROLL > "+Data.diceRoll);
                }
                yield return null;
            }
            hasRolled = false;
            yield break;
            
        }
    }
}
