using UnityEngine;
using System.Collections;

public class IconFadeBehavior : MonoBehaviour {

    public Transform playerIcon;
    private SpriteRenderer mySR;

    private Color myColor;

    public float fullColorRange;
    public float minColorRange;

    void Start ()
    {
        playerIcon = transform.parent.parent.transform.Find("PlayerMM").transform;
        mySR = GetComponent<SpriteRenderer>();
        myColor = mySR.color;
    }

	// Update is called once per frame
	void Update () {

        if (playerIcon != null)
        {
            float distToPlayer = Vector3.Distance(playerIcon.position, transform.position);
            if (distToPlayer <= fullColorRange)
            {
                mySR.color = myColor;
            }
            else
            {
                mySR.color = new Color(myColor.r, myColor.g, myColor.b, fullColorRange * (1 - (distToPlayer / (minColorRange - fullColorRange))));
            }
        }
	
	}
}
