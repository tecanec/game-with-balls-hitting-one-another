using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {

    public GameObject BackUI;

	// Use this for initialization
	void Start () {
		
	}
	
	public void back()
    {
        BackUI.SetActive(true);
        SceneManager.LoadScene("Arena");
        Time.timeScale = 1f;

    }
}

