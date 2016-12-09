using UnityEngine;
using System.Collections;

public class bulletBehavior : MonoBehaviour {

    public float bulletSpeed;
    public Vector3 inheritedMomentum;
    public GameObject explosion;

    public float explosionForce;
    public float explosionRadius;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.name != "Ship")
        {
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (other.gameObject.name == "Asteroid(Clone)")
        {
            other.GetComponent<AsteroidScript>().MakeACrystal(transform.position);
            other.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
        Destroy(this.gameObject);
        }
    }
}
