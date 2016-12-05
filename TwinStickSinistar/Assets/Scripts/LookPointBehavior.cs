using UnityEngine;
using System.Collections;

public class LookPointBehavior : MonoBehaviour {

    private Vector3 lookPtOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.root.position + lookPtOffset;
	}

    public void LookPtVal (Vector3 myOffset)
    {
        lookPtOffset = myOffset;
    }
}
