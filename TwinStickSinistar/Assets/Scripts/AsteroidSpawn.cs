using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {

    public GameObject spawnObj;
    public int howMany;
    public float xRange;
    public float zRange;

	// Use this for initialization
	void Start () {
	
        for (int i = 0; i < howMany + GameObject.Find("LevelNum").GetComponent<LevelNum>().levelNum; i++)
        {
            Instantiate(spawnObj, new Vector3(Random.Range(-xRange / 2, xRange / 2), 0, Random.Range(-zRange / 2, zRange / 2)), Quaternion.Euler(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359)), transform);
        }

	}

}
