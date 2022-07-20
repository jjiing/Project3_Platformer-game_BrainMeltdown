using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour, IRotate
{
    public float rotateSpeed;
    private void Start()
    {

    }

    private void Update()
    {
        AutoRotate();
    }
    public void AutoRotate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
