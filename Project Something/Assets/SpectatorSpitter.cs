using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorSpitter : MonoBehaviour {
    public GameObject SpectatorPrefab;
    public float TimeBetween;
    public float MoveSpeed;

    Transform[] people;
    int nextTeleport = 0;
    float countdown;

	// Use this for initialization
	void Start () {
        SpawnSpectator(0);
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Transform item in people)
        {
            item.Translate((transform.rotation * Vector3.up) * MoveSpeed * Time.deltaTime, Space.World);
        }

        countdown -= Time.deltaTime;
        if (countdown < 0)
        {
            if (people[nextTeleport].localPosition.y >= 1)
            {
                people[nextTeleport].localPosition = Vector3.down;
                nextTeleport += 1;
                nextTeleport %= people.Length;
            }
            else
                SpawnSpectator();
            countdown = TimeBetween;
        }
	}

    Transform SpawnSpectator(int id = -1)
    {
        GameObject newOne = Instantiate(SpectatorPrefab);
        Transform trans = newOne.transform;
        trans.parent = transform;
        trans.localPosition = Vector3.left * 0.01f;
        people[(id == -1) ? people.Length : id] = trans;
        return trans;
    }
}
