using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControlManager : MonoBehaviour {

    GameObject player;
    GameObject boss;
    public GameObject myText;
    public Text myNext;

    public bool SSAlive;

    public SinistarBehavior mySB;
    public GameObject[] myA = new GameObject[5];



    private float timer;
    private bool enableSwitch;

    public int levelNum;

    private bool soundOncePerLevel;
    private bool soundOncePerLevel2;

    void Start ()
    {
        player = GameObject.Find("Ship");
        boss = GameObject.Find("Sinistar");
        myText.SetActive(false);
        Invoke("DisableSinistar", .1f);
        for (int i = 0; i < myA.Length; i++)
        {
            myA[i].SetActive(false);
        }
        myNext.color = new Color(0, 0, 0, 0);
        timer = 5.99f;
    }

	void FixedUpdate () {

        if (player == null)
        {
            myText.SetActive(true);

            if(Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }

        if(GameObject.Find("SinistarCounter").GetComponent<SinistarCounter>().counter >= 50 && !enableSwitch)
        {
            SSAlive = true;
            GameObject.Find("LookPoint").GetComponent<LookPointBehavior>().offset += 50;
            mySB.enabled = true;
            enableSwitch = true;
            for (int i = 0; i < myA.Length; i++)
            {
                myA[i].SetActive(true);
            }
            if (!soundOncePerLevel2)
            {
                transform.GetChild(0).GetComponent<AudioSource>().Play();
                soundOncePerLevel2 = true;
            }
        }

        if (boss == null)
        {
            myNext.color = new Color(1, 0, 0, 1);
            timer -= Time.deltaTime;
            myNext.text = "Next Level \n" + ((int)timer).ToString();

            if (timer <= 0)
            {
                GameObject.Find("LevelNum").GetComponent<LevelNum>().levelNum++;
                SceneManager.LoadScene(1);
            }
            if (!soundOncePerLevel)
            {
                GetComponent<AudioSource>().Play();
                soundOncePerLevel = true;
            }
        }

    }

    void DisableSinistar ()
    {
        mySB.enabled = false;
    }
}
