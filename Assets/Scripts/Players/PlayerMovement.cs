// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using MookCode.GlobalData;
using MookCode._FallTile;

namespace MookCode.NPlayers
{
    public class PlayerMovement : MonoBehaviour {
        public PlayerController controller;
        public float runSpeed = 40f;
        string pHorizontal;
        string pJump;
        string pSlap;
        float horizontalMove = 0f;
        bool pHasDied = false;
        bool jump = false;
        bool slap = false;
        void Start() {
            if (gameObject.name.Equals("Player0")) {
                pHorizontal = "0Horizontal";
                pJump = "0Jump";
                pSlap = "0Slap";
            }
            else if (gameObject.name.Equals("Player1")) {
                pHorizontal = "1Horizontal";
                pJump = "1Jump";
                pSlap = "1Slap";
            }
            else if (gameObject.name.Equals("Player2")) {
                pHorizontal = "2Horizontal";
                pJump = "2Jump";
                pSlap = "2Slap";
            }
            else if (gameObject.name.Equals("Player3")) {
                pHorizontal = "3Horizontal";
                pJump = "3Jump";
                pSlap = "3Slap";
            }

        }

        void Update(){
            horizontalMove = Input.GetAxisRaw(pHorizontal) * runSpeed;
            if (Input.GetButtonDown(pJump)) {
                jump = true;
            }

            if (Input.GetButtonDown(pSlap)) {
                slap = true;
            }
        }
        public void pDeath() {
            pHasDied = true;
            FindObjectOfType<ResultsWindow>().nextDeath(gameObject.name);
        }

        private void FixedUpdate() {
            if (Data.hasGameStarted && !pHasDied) {
                controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
                jump = false;
                slap = false;
            }
        }
    }
}
