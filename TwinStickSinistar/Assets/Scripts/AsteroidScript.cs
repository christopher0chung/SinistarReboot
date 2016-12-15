using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour, IMappable {

    private GameObject myIcon;
    private GameObject myCrystal;
    private int health = 200;

    void Start()
    {
        SpawnIcon();
        myCrystal = (GameObject)Resources.Load("Crystal");
        gameObject.tag = "Asteroid";
    }

    public void SpawnIcon()
    {
        myIcon = (GameObject) Instantiate(Resources.Load("AsteroidMM"), Vector3.zero, Quaternion.Euler (90, 0, 0) , GameObject.Find("MiniMap").transform);
        myIcon.GetComponent<MiniMapIcon>().TrackMe(transform);
    }
    public void DeleteIcon()
    {
        Destroy(myIcon);
    }

    public void MakeACrystal (Vector3 to)
    {
        health--;
        //Debug.Log("hit");
        int maybe = Random.Range(0, 30);
        if (maybe == 0)
        {
            //Debug.Log("Make a crystal");
            Vector3 from = transform.position;
            GameObject theCrystal = (GameObject) Instantiate(myCrystal, to, Quaternion.identity);
            theCrystal.GetComponent<CrystalBehavior>().WhereToGo(from, to);
        }
        if (health <= 0)
        {
            for (int i = 0; i < 5; i++)
            {
                float ang = Random.Range(0, 359);
                Vector3 basicPos = new Vector3(Mathf.Cos(ang * Mathf.Deg2Rad), 0, Mathf.Sin(ang * Mathf.Deg2Rad));
                Vector3 from = transform.position + basicPos * 10;
                Vector3 dest = transform.position + basicPos * 20;

                GameObject theCrystal = (GameObject)Instantiate(Resources.Load("Crystal"), from, Quaternion.identity);
                theCrystal.GetComponent<CrystalBehavior>().WhereToGo(from, dest);
            }
            Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
            DeleteIcon();
            Destroy(this.gameObject);
        }
    }
}
