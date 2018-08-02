using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyThingy : MonoBehaviour {
    public HingeJoint2D Motor;
    public AnimationCurve SpinSpeedOverTime;
    public SpriteRenderer Light;
    public Color Blank;
    public Color Accelerating;

    GameMasta masta;

    float startTime;

	// Use this for initialization
	void Start () {
        masta = GameMasta.TheMasta;
        startTime = masta.CountDown;
    }
	
	// Update is called once per frame
	void Update () {
        JointMotor2D motorToChange = Motor.motor;
        motorToChange.motorSpeed = SpinSpeedOverTime.Evaluate((startTime - masta.CountDown) / startTime) * 200;
        Light.color = Color.Lerp(Blank, Accelerating, (motorToChange.motorSpeed - Motor.motor.motorSpeed) / Time.deltaTime);
        Motor.motor = motorToChange;
	}
}
