using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selectarena : MonoBehaviour
{

    public GameObject SelectArenaUI;

    void SelecedArena1()
    {
        SelectArenaUI.SetActive(true);
        SceneManager.LoadScene("Main Floor");

    }

    void SelecedArena2()
    {
        SelectArenaUI.SetActive(true);
        SceneManager.LoadScene("Bumper Spot");

    }

    void SelecedArena3()
    {
        SelectArenaUI.SetActive(true);
        SceneManager.LoadScene("The Mixer");

    }

    void SelecedArena4()
    {
        SelectArenaUI.SetActive(true);
        SceneManager.LoadScene("Training Zone ");

    }
}