using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarMiner : MonoBehaviour, IRadar {

    private IBaddyBehavior myMA;
    private GameObject NearestCrystal;
    private GameObject NearestAsteroid;
    public float radarRange;
    public Collider[] pingReturn;
    public float rangeAst;
    public float rangeCry;

    // Use this for initialization
    void Start () {
        InvokeRepeating("LookAround", 0, 2);
        myMA = GetComponent<IBaddyBehavior>();
	}

    public void LookAround ()
    {
        rangeAst = 200;
        rangeCry = 200;
        pingReturn = Physics.OverlapSphere(transform.position, radarRange);
        for (int i = 0; i < pingReturn.Length; i++)
        {
            if (pingReturn[i].transform.gameObject.tag == "Crystal")
            {
                if (Vector3.Distance(pingReturn[i].transform.position, transform.position) < rangeCry)
                {
                    rangeCry = Vector3.Distance(pingReturn[i].transform.position, transform.position);
                    NearestCrystal = pingReturn[i].transform.gameObject;
                }
            }
            if (pingReturn[i].transform.gameObject.tag == "Asteroid")
            {
                //Debug.Log("Found Asteroid");

                if (Vector3.Distance(pingReturn[i].transform.position, transform.position) < rangeAst)
                {
                    rangeAst = Vector3.Distance(pingReturn[i].transform.position, transform.position);
                    NearestAsteroid = pingReturn[i].transform.gameObject;
                }
            }
        }
        if (NearestCrystal != null)
        {
            SetOOC(NearestCrystal);
        }
        else
        {
            SetOOC(NearestAsteroid);
        }
    }

    public void SetOOC (GameObject OOC)
    {
        myMA.SetTgt(OOC);
    }
}
