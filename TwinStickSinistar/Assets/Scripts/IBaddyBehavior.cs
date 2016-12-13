using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaddyBehavior {

    // Called by radar
    void SetTgt(GameObject tgt);

    // Called in behavior
    void CalcHeading(GameObject tgt);
    void ApplyThruster();
    void FireAtTgt();
}
