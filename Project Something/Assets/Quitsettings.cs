using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quitsettings : MonoBehaviour {

    public GameObject backUI;

    // Update is called once per frame
    void Update ()
    {
        Debug.Log(" ");
	}

    void Back ()
    {
        backUI.SetActive(true);
        SceneManager.LoadScene("Arena");
    }
}
