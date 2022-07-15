using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float rotateSpeed;
    private void Start()
    {
        rotateSpeed = 50f;
    }

    private void Update()
    {
        transform.Rotate(0,0, rotateSpeed* Time.deltaTime);
    }
}
