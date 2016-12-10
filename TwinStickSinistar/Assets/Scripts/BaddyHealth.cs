using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddyHealth : MonoBehaviour {

    public int health;
    private int maxHealth;

    void Start()
    {
        maxHealth = health;
    }

    public void Hit ()
    {
        health--;

        if (health <= 0)
        {
            if (GameObject.Find("SinistarCounter").GetComponent<SinistarCounter>().counter >= 1)
            {
                GameObject.Find("SinistarCounter").GetComponent<SinistarCounter>().counter--;
                GameObject myCrystal = (GameObject)Instantiate(Resources.Load("Crystal"), transform.position, Quaternion.identity);
                myCrystal.GetComponent<CrystalBehavior>().WhereToGo(transform.position, transform.position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)));
            }
            Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
            transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
            health = maxHealth;
        }
        
    }

}
