using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selectarena : MonoBehaviour
{
    public GameObject SelectArenaUI;

    public void GoToScene(string destination)
    {
        SceneManager.LoadScene(destination);
    }

    public void GoToScene(int destination)
    {
        SceneManager.LoadScene(destination);
    }
}