using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerY : MonoBehaviour
{
    public float RotaionSpeed = 45f;

    private float _horizontalInput;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 2, 0) * RotaionSpeed * Time.deltaTime);
    }
}