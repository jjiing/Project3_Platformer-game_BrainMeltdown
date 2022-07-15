using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_AutoMove : MonoBehaviour, IMovePingpong
{
    Vector3 pos;
    SpriteRenderer spriteRenderer;

    //public GameObject player_P;
    //public GameObject player_y;
    //Player_purple player_p_script;
    //Player_yellow player_y_script;
    //bool isDown_p;
    //bool isDown_y;

    void Start()
    {
        pos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //player_p_script = player_P.GetComponent<Player_purple>();
        //player_y_script = player_y.GetComponent<Player_yellow>();


    }

    void Update()
    {
        MovePingPong();
    }

    public void MovePingPong()
    {
        float pingpongValue = Mathf.PingPong(Time.time, 3.8f);
        transform.position = new Vector3(pos.x + pingpongValue, pos.y, pos.z);

        if (pingpongValue > 3.79f) spriteRenderer.flipX = false;
        else if (pingpongValue < 0.01f) spriteRenderer.flipX = true;
    }


    //public void Attackable()
    //{
    //        Destroy(gameObject);

    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isDown_p = player_p_script.isDown;
    //    isDown_y = player_y_script.isDown;

    //    if ((collision.gameObject == player_P && isDown_p) ||
    //            (collision.gameObject ==player_y && isDown_y))
    //    {
    //        Attackable();
    //    }
    //}



}
