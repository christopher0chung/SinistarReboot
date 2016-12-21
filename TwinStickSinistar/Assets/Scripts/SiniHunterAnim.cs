using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiniHunterAnim : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
