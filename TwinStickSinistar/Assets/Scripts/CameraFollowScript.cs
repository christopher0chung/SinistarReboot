using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    public Transform tgt;
    private float offSet;

	// Use this for initialization
	void Start () {

        offSet = transform.position.y - tgt.position.y; 

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = Vector3.Lerp(transform.position, new Vector3(tgt.position.x, tgt.position.y + offSet, tgt.position.z), .08f);

	}
}
