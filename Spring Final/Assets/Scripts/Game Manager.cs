using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI keyText;
    public string youWonScene;
    public string youLostScene;

    private int _keyAmount;
    private int _honeyAmount;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        int doorKeyAmount = GameObject.FindGameObjectsWithTag("Key").Length;
        int honeyEndAmount = GameObject.FindGameObjectsWithTag("Honey").Length;
        _keyAmount = doorKeyAmount;
        _honeyAmount = honeyEndAmount;
        keyText.text = "Keys to go: " + _keyAmount.ToString();
    }

    // Update is called once per frame
    public void UpdateKeyAmount(int amount)
    {
        _keyAmount += amount;
        keyText.text = "Keys to go: " + _keyAmount.ToString();

        if(_keyAmount <= 0)
        {
            int doorAmount = GameObject.FindGameObjectsWithTag("Door").Length;

            for(int i = 0; i < doorAmount; i++)
            {
                Destroy(GameObject.FindGameObjectWithTag("Door"));
                Debug.Log("I destroyed door number " + i);
            }
        }
        
        _honeyAmount += amount;

        if(_honeyAmount <= 0)
        {
            SceneManager.LoadScene("End Menu");
        }
    }
}
