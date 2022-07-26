using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectiveObstacle : MonoBehaviour, IRotate, IProjective
{
    public float rotateSpeed;
    float shootSpeed;

    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        shootSpeed = 0.05f;
    }
   

    
    void Update()
    {
        AutoRotate();
        Projective();
    }
    
    public void AutoRotate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    public void Projective()
    {
        rigid.AddForce(new Vector2(-1, -0.4f) * shootSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
