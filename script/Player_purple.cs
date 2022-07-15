using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_purple : Player
{

    void Start()
    {
        base.Start();
        
        gameObject.transform.position = currentSavePointPos + new Vector3(-1, 0.5f, 0);

        dieEffectSR.color = colorDic["purple"];
    }
    
    void Update()
    {
        //재정의
        Move();
        Jump();
        Sit();

        //상속
        StateUpDown();
        MoveAnim(); 
    }

   

    protected override void Move()
    {
        //이동
        float moveX = Input.GetAxisRaw("Horizontal2");
        rigid2d.velocity = new Vector2(moveX * speed, rigid2d.velocity.y);
        //x축 이동은 x*speed로 y축 이동은 기존의 속력값(현재는 중력)


        //anim 좌우방향설정
        if (moveX < 0) spriteRenderer.flipX = false;
        else if (moveX > 0) spriteRenderer.flipX = true;


        //상태 설정
        if (moveX != 0) isRun = true;
        else isRun = false;

    }
    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isGrounded = false;
            rigid2d.velocity = Vector2.up * jumpForce;

        }



    }
    protected override void Sit()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isSit = true;
            collider.enabled = false;
            childCollider.enabled = true;

        }
        else
        {
            isSit = false;
            collider.enabled = true;
            childCollider.enabled = false;
        }
    }
}
