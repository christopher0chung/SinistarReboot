using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarMissile : MonoBehaviour {

    private IBaddyBehavior myMA;
    private GameObject Player;
    public float radarRange;
    public Collider[] pingReturn;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("LookAround", 0, 2);
        myMA = GetComponent<IBaddyBehavior>();
    }

    public void LookAround()
    {

        pingReturn = Physics.OverlapSphere(transform.position, radarRange);
        for (int i = 0; i < pingReturn.Length; i++)
        {
            if (pingReturn[i].gameObject.tag == "Player")
                Player = pingReturn[i].transform.gameObject;
        }
        if (Player != null)
        {
            SetOOC(Player);
        }
    }

    public void SetOOC(GameObject OOC)
    {
        myMA.SetTgt(OOC);
    }
}
