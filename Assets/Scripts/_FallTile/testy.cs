// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace MookCode.FallTesty
{
    public class testy : MonoBehaviour {
        void Start() {
        
        }

        void Update(){
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
    }
}
