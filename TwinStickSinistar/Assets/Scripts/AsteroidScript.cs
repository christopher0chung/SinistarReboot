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
    }

    void onEnable()
    {
        SpawnIcon();
    }

    void onDisable()
    {
        DeleteIcon();
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
        Debug.Log("hit");
        int maybe = Random.Range(0, 30);
        if (maybe == 0)
        {
            Debug.Log("Make a crystal");
            Vector3 from = transform.position;
            GameObject theCrystal = (GameObject) Instantiate(myCrystal, to, Quaternion.identity);
            theCrystal.GetComponent<CrystalBehavior>().WhereToGo(from, to);
        }
        if (health <= 0)
        {
            Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
