// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MookCode.GlobalData;

namespace MookCode.FallTesty
{
    public class testy : MonoBehaviour {
        // disable this during actual game
        // sets values to playersArrSave so no error during results window
        void Start() {
            Data.playersArrSave = 
                "83\\13\\0|" +
                "64\\26\\0|" +
                "35\\46\\0|" +
                "1\\1\\0";
        }
    }
}
