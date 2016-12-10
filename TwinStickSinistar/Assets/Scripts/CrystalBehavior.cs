using UnityEngine;
using System.Collections;

public class CrystalBehavior : MonoBehaviour {

    public float moveScalar;

    void Start()
    {
        gameObject.tag = "Crystal";
    }

	void Update () {
        transform.rotation = Quaternion.Euler(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
	}

    public void WhereToGo(Vector3 from, Vector3 to)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.Normalize(to - from) * moveScalar, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Ship")
        {
            other.GetComponent<ShipControlTwinStick>().crystalCount++;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Mob")
        {
            GameObject.Find("SinistarCounter").GetComponent<SinistarCounter>().counter++;
            Destroy(this.gameObject);
        }
    }
}
