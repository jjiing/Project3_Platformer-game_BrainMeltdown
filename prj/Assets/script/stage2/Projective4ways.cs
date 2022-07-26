using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projective4ways : MonoBehaviour
{
    public float rotateSpeed;
    public int wayNum;
    float shootSpeed;

    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        wayNum = 0;
        shootSpeed = 12f;
    }

    void Update()
    {

        if(wayNum ==1) ProjectiveRight();
        else if(wayNum ==2) ProjectiveLeft();
        else if(wayNum ==3) ProjectiveDown();  
        else if(wayNum ==4) ProjectiveUp();

    }

    public void ProjectiveRight()
    {
        transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        transform.position += Vector3.right*Time.deltaTime*shootSpeed;
    }
    public void ProjectiveLeft()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        transform.position += Vector3.left * Time.deltaTime * shootSpeed;
    }
    public void ProjectiveDown()
    {
        transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        transform.position += Vector3.down * Time.deltaTime * shootSpeed;
    }
    public void ProjectiveUp()
    {
        transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        transform.position += Vector3.up * Time.deltaTime * shootSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY
                | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
