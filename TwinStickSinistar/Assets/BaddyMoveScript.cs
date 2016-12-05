using UnityEngine;
using System.Collections;

public class BaddyMoveScript : MonoBehaviour {

    public float ang;
    public float dist;

    private float timer;
    public float moveTime;

    private Vector3 nextPos;

	// Use this for initialization
	void Start () {

        nextPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            timer = 0;
            nextPos = PickADir();
        }

        transform.position = Vector3.Lerp(transform.position, nextPos, .05f);
	
	}

    Vector3 PickADir ()
    {
        ang = Random.Range(-180, 180);
        dist = Random.Range(10, 20);
        Vector3 myNextPos = transform.position + new Vector3(dist * Mathf.Cos(ang), 0, dist * Mathf.Sin(ang));

        return myNextPos;
    }
}
