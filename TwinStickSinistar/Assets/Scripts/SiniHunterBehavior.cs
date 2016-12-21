using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiniHunterBehavior : MonoBehaviour {

    private GameObject sinistar;
    private Rigidbody myRB;

    public float speed;

	// Use this for initialization
	void Start () {
        sinistar = GameObject.Find("Sinistar");
        myRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (sinistar != null)
        {
            myRB.MovePosition((Vector3.Normalize(sinistar.transform.position - transform.position) * speed) + transform.position);
        }
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Mob")
        {
            for (int i = 0; i < 20; i++)
            {
                other.GetComponent<BaddyHealth>().Hit();
            }
        }
        Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
