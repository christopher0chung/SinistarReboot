using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (gameObject.name == "Right")
            other.transform.position += Vector3.left * 1995f;
        if (gameObject.name == "Left")
            other.transform.position += Vector3.right * 1995f;
        if (gameObject.name == "Top")
            other.transform.position += Vector3.back * 1995f;
        if (gameObject.name == "Bottom")
            other.transform.position += Vector3.forward * 1995f;
    }
}
