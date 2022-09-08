using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    [SerializeField]
    private float backgroundVelocity;

    private void Update() {
        moveBackground();
    }

    private void moveBackground() {
        Vector2 desloc = new Vector2(Time.time*backgroundVelocity, 0);
        GetComponent<Renderer>().material.mainTextureOffset = desloc;
    }
}
