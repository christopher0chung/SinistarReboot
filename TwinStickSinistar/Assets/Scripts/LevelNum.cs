using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelNum : MonoBehaviour {

    public int levelNum;

    private bool notTheFirstTime;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += LevelLoadFunc;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);  
        }
    }

    void LevelLoadFunc(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0 && notTheFirstTime)
        {
            Destroy(this.gameObject);
        }
        if (scene.buildIndex == 1)
        {
            GameObject.Find("LevelNumber").GetComponent<Text>().text = "Level Number: " + (levelNum + 1);
        }
        notTheFirstTime = true;
    }
}
