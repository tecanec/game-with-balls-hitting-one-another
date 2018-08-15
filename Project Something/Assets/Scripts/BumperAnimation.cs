using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperAnimation : MonoBehaviour {
    public Transform ApplyTo;
    public float Intensity;
    public float Duration;
    public float MaxDuration;
    public float Frequency;

    float time;
    Vector3 initialSize;

	// Use this for initialization
	void Start () {
        initialSize = ApplyTo.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (time > 0)
        {
            ApplyTo.localScale = initialSize * (1 + (Mathf.Sin(time * Frequency) * Intensity * time));
            time -= Time.deltaTime;
        }
        else ApplyTo.localScale = initialSize;
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        time += collision.relativeVelocity.magnitude * Duration;
        if (time > MaxDuration) time = MaxDuration;
    }
}
