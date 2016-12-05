using UnityEngine;
using System.Collections;

public class ShipMovementControls : MonoBehaviour {

    public float boosterForce;
    public float turnTorque;

    private Rigidbody myRB;

    public delegate void controlOutput();
    public controlOutput myOutput;

    void InputParser (Left leftStick, Right rightStick)
    {
        if (leftStick == Left.up && rightStick == Right.up)
        {
            Debug.Log("in parser: " + leftStick + " " + rightStick);

            myOutput = boostFwd;
        }
        else if (leftStick == Left.down && rightStick == Right.down)
        {
            myOutput = boostAft;
        }
        else if (leftStick == Left.left && rightStick == Right.left)
        {
            myOutput = boostPort;
        }
        else if (leftStick == Left.right && rightStick == Right.right)
        {
            myOutput = boostStbd;
        }
        else if (leftStick == Left.down && rightStick == Right.up)
        {
            myOutput = rotateCCW;
        }
        else if (leftStick == Left.up && rightStick == Right.down)
        {
            myOutput = rotateCW;
        }
        else if (leftStick == Left.up && rightStick == Right.none)
        {
            myOutput = leftStickFwd;
        }
        else if (leftStick == Left.none && rightStick == Right.up)
        {
            myOutput = rightStickFwd;
        }
        else
        {
            myOutput = neutral;
        }
    }

    void Start ()
    {
        myRB = GetComponent<Rigidbody>();
        myOutput = neutral;
    }
	
	void Update () {

        Left myLeftInput;
        Right myRightInput;

        if (Input.GetKey(KeyCode.W))
            myLeftInput = Left.up;
        else if (Input.GetKey(KeyCode.A))
            myLeftInput = Left.left;
        else if (Input.GetKey(KeyCode.S))
            myLeftInput = Left.down;
        else if (Input.GetKey(KeyCode.D))
            myLeftInput = Left.right;
        else
            myLeftInput = Left.none;

        if (Input.GetKey(KeyCode.I))
            myRightInput = Right.up;
        else if (Input.GetKey(KeyCode.J))
            myRightInput = Right.left;
        else if (Input.GetKey(KeyCode.K))
            myRightInput = Right.down;
        else if (Input.GetKey(KeyCode.L))
            myRightInput = Right.right;
        else
            myRightInput = Right.none;

        InputParser(myLeftInput, myRightInput);

    }

    void FixedUpdate ()
    {
        myOutput();
    }

    public void boostFwd()
    {
        Debug.Log("in boostFwd");

        myRB.AddForce(transform.forward * boosterForce, ForceMode.Force);
    }

    public void boostAft()
    {
        myRB.AddForce(transform.forward * -boosterForce, ForceMode.Force);
    }

    public void boostPort()
    {
        myRB.AddForce(transform.right * -boosterForce, ForceMode.Force);
    }

    public void boostStbd()
    {
        myRB.AddForce(transform.right * boosterForce, ForceMode.Force);
    }

    public void rotateCCW()
    {
        myRB.AddTorque(transform.up * -turnTorque, ForceMode.Force);
    }

    public void rotateCW()
    {
        myRB.AddTorque(transform.up * turnTorque, ForceMode.Force);
    }

    public void leftStickFwd()
    {
        myRB.AddForce(transform.forward * boosterForce / 2, ForceMode.Force);
        myRB.AddTorque(transform.up * turnTorque / 2, ForceMode.Force);
    }

    public void rightStickFwd()
    {
        myRB.AddForce(transform.forward * boosterForce / 2, ForceMode.Force);
        myRB.AddTorque(transform.up * -turnTorque / 2, ForceMode.Force);
    }

    public void neutral()
    {

    }
}

public enum Left { up, down, left, right, none };
public enum Right { up, down, left, right, none };

