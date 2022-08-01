using System.Collections;
using UnityEngine;

namespace MookCode._FallTile {
    public class Block : MonoBehaviour {

        private void Start() {
            GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 20f;
            // change to since GameStart or smth
        }
        private void Update() {
            if (transform.position.y < -2.98f) {
                Destroy(gameObject);
            }
        }
    }
}