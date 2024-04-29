using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Key : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("PLayer"))
        {
            if(this.gameObject.tag == "Key")
            {
                //Destroy(this.gameObject);
                GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateKeyAmount(-1);
                this.gameObject.SetActive(false);
            }
            //add grayscale to standing target later
            if(this.gameObject.tag == "Target")
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateKeyAmount(-1);
                this.gameObject.SetActive(false);
            }
        }
    }
}
