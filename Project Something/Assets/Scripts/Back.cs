using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {

    public GameObject Back4moreUI;

	// Use this for initialization
	void Start () {
		
	}
	
	public void back()
    {
        Back4moreUI.SetActive(true);
        SceneManager.LoadScene("Arena");
        Time.timeScale = 1f;

    }
}

