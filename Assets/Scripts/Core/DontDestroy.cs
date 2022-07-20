// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace MookCode
{
    public class DontDestroy : MonoBehaviour {
        private void Start() {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
            foreach (GameObject obj in objs) {
                DontDestroyOnLoad(obj);
            }
        }
    }
}
