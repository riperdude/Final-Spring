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

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        int doorKeyAmount = GameObject.FindGameObjectsWithTag("Key").Length;
        _keyAmount = doorKeyAmount;
        keyText.text = "Keys to go: " + _keyAmount.ToString();
    }

    // Update is called once per frame
    public void UpdateKeyAmount(int amount)
    {
        _keyAmount += amount;
        keyText.text = "Keys to go: " + _keyAmount.ToString();

        if(_keyAmount <= 0)
        {
            SceneManager.LoadScene("You Won");
        }
    }
}
