using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUITButtom : MonoBehaviour
{

    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }
}