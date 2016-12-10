using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SinistarCounter : MonoBehaviour {

    private int _counter;
    public int counter
    {
        get
        {
            return _counter;
        }
        set
        {
            if (value != _counter)
            {
                counterText.text = "Sinistar has collected: " + value.ToString();
                _counter = value;
            }
        }
    }
    public Text counterText;
}
