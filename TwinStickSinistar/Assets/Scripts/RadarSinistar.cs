using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarSinistar : MonoBehaviour, IRadar
{
    private IBaddyBehavior myMA;
    private GameObject Player;
    public float radarRange;
    public Collider[] pingReturn;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("LookAround", 1, 2);
        myMA = GetComponent<IBaddyBehavior>();
    }

    public void LookAround()
    {
        myMA = GetComponent<IBaddyBehavior>();

        pingReturn = Physics.OverlapSphere(transform.position, radarRange);
        for (int i = 0; i < pingReturn.Length; i++)
        {
            if (pingReturn[i].gameObject.tag == "Player")
                Player = pingReturn[i].transform.gameObject;
        }
        if (Player != null)
        {
            SetOOC(Player);
            Player = null;
        }
        else
        {
            SetOOC(null);
        }
    }

    public void SetOOC(GameObject OOC)
    {
        myMA.SetTgt(OOC);
    }
}
