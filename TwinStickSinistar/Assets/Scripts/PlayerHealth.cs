using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    private Text countText;
    private int count;
    public int crystalCount
    {
        get
        {
            return count;
        }
        set
        {
            if (value != count)
            {
                countText.text = "Crystal Count: " + value;
                count = value;
                Collect.Play();
            }
        }
    }
    private AudioSource Collect;


    void Start () {
        countText = GameObject.Find("CrystalCount").GetComponent<Text>();
        Collect = GetComponent<AudioSource>();
    }


    public void LoseCrystal (string howMany) {
        int theNumber;
		if (howMany == "one")
        {
            theNumber = 1;
        }
        else if (howMany == "all")
        {
            theNumber = crystalCount;
        }
        else
        {
            theNumber = 0;
        }

        for (int i = 0; i < theNumber; i++)
        {
            float ang = Random.Range(0, 359);
            Vector3 basicPos = new Vector3(Mathf.Cos(ang * Mathf.Deg2Rad), 0, Mathf.Sin(ang * Mathf.Deg2Rad));
            Vector3 from = transform.position + basicPos * 10;
            Vector3 to = transform.position + basicPos * 20;

            GameObject theCrystal = (GameObject)Instantiate(Resources.Load("Crystal"), from, Quaternion.identity);
            theCrystal.GetComponent<CrystalBehavior>().WhereToGo(from, to);
        }
        crystalCount -= theNumber;

    }
}
