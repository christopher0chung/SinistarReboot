using UnityEngine;
using System.Collections;

public class SelfCleanUpTimed : MonoBehaviour {

    public float timeToCleanUp;
    private float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer >= timeToCleanUp)
            Destroy(this.gameObject);
	
	}
}
