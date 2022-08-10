using System.Collections;
using UnityEngine;
using MookCode.GlobalData;

namespace MookCode._FallTile {
    public class Block : MonoBehaviour {

        private void Start() {
            float timeSinceStart = Time.time - Data.timeSinceGameStart;
            GetComponent<Rigidbody2D>().gravityScale += timeSinceStart / 20f;
        }
        private void Update() {
            if (transform.position.y < -2.98f) {
                Destroy(gameObject);
            }
        }
    }
}