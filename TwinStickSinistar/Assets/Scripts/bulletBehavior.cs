using UnityEngine;
using System.Collections;

public class bulletBehavior : MonoBehaviour {

    public float bulletSpeed;
    public Vector3 inheritedMomentum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * bulletSpeed + inheritedMomentum;	
	}

    public void InheritMomentum (Vector3 momentum)
    {
        inheritedMomentum = momentum;
    }
}
