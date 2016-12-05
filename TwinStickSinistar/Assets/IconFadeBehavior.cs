using UnityEngine;
using System.Collections;

public class IconFadeBehavior : MonoBehaviour {

    public Transform playerIcon;
    private SpriteRenderer mySR;

    public float fullColorRange;
    public float minColorRange;

    void Start ()
    {
        playerIcon = transform.parent.parent.transform.Find("PlayerMM").transform;
        mySR = GetComponent<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update () {

        if (playerIcon != null)
        {
            float distToPlayer = Vector3.Distance(playerIcon.position, transform.position);
            if (distToPlayer <= fullColorRange)
            {
                mySR.color = Color.white;
            }
            else
            {
                mySR.color = new Color(1, 1, 1, fullColorRange * (1 - (distToPlayer / (minColorRange - fullColorRange))));
            }
        }
	
	}
}
