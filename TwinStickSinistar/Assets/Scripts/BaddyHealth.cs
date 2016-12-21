using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddyHealth : MonoBehaviour {

    public int health;
    private int maxHealth;
    private int armor;

    void Start()
    {
        maxHealth = health;
        armor = 4;
    }

    public void Armor ()
    {
        armor--;
    }

    public void Hit ()
    {
        if (gameObject.name != "Sinistar")
        {
            health--;
        }
        else
        {
            //Debug.Log(gameObject.name);

            if (armor <= 0)
                health--;
        }

        if (health <= 0)
        {
            if (gameObject.name == "MissilePrefab(Clone)")
            {
                Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
                GetComponent<MissileBehavior>().CleanKill();
            }
            else if (gameObject.name == "BaddyMiner(Clone)")
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
            else if (gameObject.name == "Armor")
            {
                transform.root.GetComponent<BaddyHealth>().Armor();
                Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else if (gameObject.name == "Sinistar")
            {
                Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
                GetComponent<SinistarBehavior>().CleanKill();
            }
            else
            {
                Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
                transform.position = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
                health = maxHealth;
            }


        }
        
    }

}
