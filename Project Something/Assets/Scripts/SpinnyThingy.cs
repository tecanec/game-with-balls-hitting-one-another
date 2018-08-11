using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyThingy : MonoBehaviour {
    public HingeJoint2D Motor;
    public AnimationCurve SpinSpeedOverTime;
    public MeshRenderer Light;
    public int LightMaterialId;
    public Material MaterialPrototype;
    public Color Blank;
    public Color Accelerating;

    GameMasta masta;

    float startTime;

    Material material;

	// Use this for initialization
	void Start () {
        masta = GameMasta.TheMasta;
        startTime = masta.CountDown;

        material = new Material(MaterialPrototype);
        Light.materials[LightMaterialId] = material;
    }
	
	// Update is called once per frame
	void Update () {
        JointMotor2D motorToChange = Motor.motor;
        motorToChange.motorSpeed = SpinSpeedOverTime.Evaluate((startTime - masta.CountDown) / startTime) * 200;
        material.color = Color.Lerp(Blank, Accelerating, (motorToChange.motorSpeed - Motor.motor.motorSpeed) / Time.deltaTime);
        Debug.Log(motorToChange.motorSpeed);
        Motor.motor = motorToChange;
        Debug.Log(Motor.motor.motorSpeed);
    }
}
