using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_CollisionMove : MonoBehaviour, IMoveCollision
{

    int changeDir;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        changeDir = -1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveUntilCollison();
    }

    public void MoveUntilCollison()
    {
        transform.Translate(new Vector3(changeDir *Time.deltaTime, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Obstacle")
        {
            changeDir *= -1;
            ChangeFlipX();
        }
    }
    void ChangeFlipX()
    {
        if (spriteRenderer.flipX) spriteRenderer.flipX = false;
        else spriteRenderer.flipX = true;
    }
}
