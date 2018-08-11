using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAlignment : MonoBehaviour {
    public Vector2 Alignment;
    public Vector2 Offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rect rect = GameMasta.TheMasta.gameZone;
        transform.position = Offset + rect.position + (rect.size * Alignment);
	}
}
