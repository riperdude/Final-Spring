using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Key : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.tag == "Key")
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateKeyAmount(-1);
                this.gameObject.SetActive(false);
            }
        }
    }
}
