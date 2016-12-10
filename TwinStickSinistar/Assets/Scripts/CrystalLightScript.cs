using UnityEngine;
using System.Collections;

public class CrystalLightScript : MonoBehaviour {

    private Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }
	void Update () {
        myLight.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
	}
}
