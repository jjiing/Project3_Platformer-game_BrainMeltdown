using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_CollisionMove : MonoBehaviour, IMoveCollision
{
    public float moveSpeed;
    public int changeDir;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid2d;

    private void Start()
    {
        moveSpeed = 2f;
        changeDir = -1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveUntilCollison();
    }

    public void MoveUntilCollison()
    {
        transform.Translate(new Vector3(moveSpeed *changeDir * Time.deltaTime, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag =="Obstacle")
        {
            changeDir *= -1;
            ChangeFlipX();
        }
        if(collision.gameObject.tag =="Player")
        {
            rigid2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY
                | RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void ChangeFlipX()
    {
        if (spriteRenderer.flipX) spriteRenderer.flipX = false;
        else spriteRenderer.flipX = true;
    }
    
}
