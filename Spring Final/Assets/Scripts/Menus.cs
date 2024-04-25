
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public string levelOne;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnPlayButtonPressed()
    {
        if(levelOne == "Level One")
        {
            SceneManager.LoadScene(levelOne);
        }
        else
        {
            Debug.Log("You stupid chis");
        }
    }
}
