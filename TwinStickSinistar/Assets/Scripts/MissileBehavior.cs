using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour, IBaddyBehavior, IMappable {

    private Rigidbody myRB;

    public GameObject target;
    private Vector3 heading;
    private float lookDir;

    public float speedBase;

    private Vector3 momentumApplied;
    private Vector3 momentumContributed;

    private GameObject myIcon;

    private IRadar myRadar;

    public float maxFlightTime;
    private float timer;


    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        gameObject.tag = "Mob";
        SpawnIcon();
        myRadar = GetComponent<IRadar>();
    }

    public void SpawnIcon()
    {
        myIcon = (GameObject)Instantiate(Resources.Load("MobMM"), Vector3.zero, Quaternion.Euler(90, 0, 0), GameObject.Find("MiniMap").transform);
        myIcon.GetComponent<MiniMapIcon>().TrackMe(transform);
    }
    public void DeleteIcon()
    {
        Destroy(myIcon);
    }

    void FixedUpdate()
    {
        CalcHeading(target);

        ApplyThruster();
        myRB.velocity = Vector3.zero;
        momentumApplied = Vector3.Lerp(momentumApplied, momentumContributed, .03f);
        myRB.MovePosition(transform.position + momentumApplied);

        timer += Time.fixedDeltaTime;
        if (timer >= maxFlightTime)
        {
            CleanKill();
        }
    }

    // Called by RadarMiner
    public void SetTgt(GameObject tgt)
    {
        //Debug.Log("Tgt set");
        target = tgt;
    }

    // Called based on RadarMiner return
    public void CalcHeading(GameObject tgt)
    {
        if (tgt != null)
        {
            if (tgt.gameObject.tag == "Player")
            {
                Vector3 bearing = Vector3.Normalize(tgt.transform.position - transform.position);
                heading = bearing;
            }

            Vector3 delta = tgt.transform.position - transform.position;
            lookDir = Mathf.Atan2(-delta.z, delta.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, lookDir, 0);
        }
    }

    // Set based on RadarMiner return
    public void ApplyThruster()
    {
        if (target != null)
        {
            momentumContributed = heading * (speedBase);
        }
    }

    //Set based on RadarMiner return
    public void FireAtTgt()
    {
        return;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

            other.gameObject.GetComponent<PlayerHealth>().LoseCrystal("all");
            CleanKill();
        }
    }

    public void CleanKill()
    {
        DeleteIcon();
        Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
