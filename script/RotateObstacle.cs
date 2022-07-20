using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour, IMovePingpong, IRotate
{
    public float rotateSpeed;

    public float distance = 3.8f;
    Vector3 pos;
    SpriteRenderer spriteRenderer;
    public float moveSpeed = 5;

    void Start()
    {
        pos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        AutoRotate();
        MovePingPong();
    }
    public void AutoRotate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    public void MovePingPong()
    {
        float pingpongValue = Mathf.PingPong(moveSpeed *Time.time, distance);
        transform.position = new Vector3(pos.x + pingpongValue, pos.y, pos.z);


    }
}
