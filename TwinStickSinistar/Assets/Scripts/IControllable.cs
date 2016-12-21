using UnityEngine;
using System.Collections;

public interface IControllable {

    void LeftStick(float upDown, float leftRight);
    void RightStick(float upDown, float leftRight);
    void RightTrigger(bool pressedReleased);
}
