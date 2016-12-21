using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScreenMove : MonoBehaviour {

    float angZ;
    float angY;
    float xPos;
    float yPos;

    float timer;

	void Update () {

        timer += Time.deltaTime;

        xPos = 7 * Mathf.Sin(timer * .3f);
        yPos = 2 * (Mathf.Cos(timer * .3f));
        angZ = 45 * Mathf.Sin(timer * .3f);
        angY = 40 * Mathf.Sin(timer * .3f);

        transform.position = new Vector3(xPos, yPos, 0);
        transform.rotation = Quaternion.Euler(0, angY, angZ);

	}
}
