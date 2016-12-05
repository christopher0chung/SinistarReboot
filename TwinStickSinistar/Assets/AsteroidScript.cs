using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour, IMappable {

    public GameObject myIcon;

    void Start()
    {
        SpawnIcon();
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
}
