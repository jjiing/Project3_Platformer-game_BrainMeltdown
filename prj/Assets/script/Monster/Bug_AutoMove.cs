using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_AutoMove : MonoBehaviour, IMovePingpong
{
    public float distance=3.8f;

    Vector3 pos;
    SpriteRenderer spriteRenderer;

    

    void Start()
    {

        pos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
     

    }

    void Update()
    {
        MovePingPong();
    }

    public void MovePingPong()
    {
        float pingpongValue = Mathf.PingPong(Time.time, distance);
        transform.position = new Vector3(pos.x + pingpongValue, pos.y, pos.z);

        if (pingpongValue > distance-0.01f) spriteRenderer.flipX = false;
        else if (pingpongValue < 0.01f) spriteRenderer.flipX = true;
    }


   



}
