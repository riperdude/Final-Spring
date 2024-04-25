using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Target : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Twig"))
        {
            if(this.gameObject.tag == "Floating target")
            {
                //Destroy(this.gameObject);
                GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateTargetAmount(-1);
                this.gameObject.SetActive(false);
            }
            //add grayscale to standing target later
            if(this.gameObject.tag == "Target")
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateTargetAmount(-1);
                this.gameObject.SetActive(false);
            }
        }
    }
}
