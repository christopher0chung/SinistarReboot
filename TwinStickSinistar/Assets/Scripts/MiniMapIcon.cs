using UnityEngine;
using System.Collections;

public class MiniMapIcon : MonoBehaviour {

    public Transform whatITrack;

    public void TrackMe (Transform theTransform)
    {
        whatITrack = theTransform;
    }
	
	// Update is called once per frame
	void Update () {

        if (whatITrack != null)
        {
            transform.localPosition = new Vector3(whatITrack.position.x / 100, whatITrack.position.z / 100, 0);
        }
        else
        {
            Destroy(this.gameObject);
        }

	
	}
}
