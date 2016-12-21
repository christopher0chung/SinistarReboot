using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinistarBehavior : MonoBehaviour, IBaddyBehavior, IMappable
{
    private Rigidbody myRB;

    public GameObject target;
    private float range;
    private float moveRange;
    private Vector3 dir;
    private Vector3 nextDest;

    public float fireRange;

    private GameObject myIcon;

    private IRadar myRadar;

    private float timer;
    public float timeSwitch;

    private GameObject death;

    private bool playOnce;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        gameObject.tag = "Mob";
        SpawnIcon();
        myRadar = GetComponent<IRadar>();
        death = GameObject.Find("Death");
        death.SetActive(false);
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
        timer += Time.fixedDeltaTime;
        if (timer > timeSwitch)
        {
            timer = 0;
            CalcHeading(target);
        }

        ApplyThruster();
        myRB.velocity = Vector3.zero;

        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= fireRange)
        {
            FireAtTgt();
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
                range = Vector3.Distance(transform.position, tgt.transform.position);
                moveRange = range + 100;
                dir = Vector3.Normalize(tgt.transform.position - transform.position);
                nextDest = transform.position + dir * moveRange;
                //Debug.Log(range + " " + moveRange);
            }
        }
    }

    // Set based on RadarMiner return
    public void ApplyThruster()
    {
        if (target != null)
        {
            Vector3 moveTo = Vector3.Lerp(transform.position, nextDest, .018f);
            myRB.MovePosition(moveTo);
        }
    }

    //Set based on RadarMiner return
    public void FireAtTgt()
    {
        target = null;
        Instantiate(Resources.Load("Bullet"), transform.position, Quaternion.identity);
        transform.position = new Vector3(Random.Range(-900, 900), 0, Random.Range(-900, 900));
    }

    public void CleanKill()
    {
        DeleteIcon();
        Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!playOnce)
            {
                GetComponent<AudioSource>().Play();
                playOnce = true;
            }
            Destroy(other.gameObject);
            death.SetActive(true); 
        }
    }
}