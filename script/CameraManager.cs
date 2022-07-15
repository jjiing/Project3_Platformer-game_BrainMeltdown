using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target_y;
    public GameObject target_p;



    private float moveSpeed; //카메라 속도


    private Vector3 targetPos_y;
    private Vector3 targetPos_p;
    private Vector3 targetPos; //대상 위치


    //카메라 바운드 설정
    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound;

    private float halfWidth;
    private float halfHeight;

    private Camera theCamera;



    void Start()
    {
        moveSpeed = 1f;

        //카메라 바운드 지정
        theCamera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        Vector3 startPos = (target_y.transform.position + target_p.transform.position)/ 2;
        this.transform.position = new Vector3(startPos.x, startPos.y+2 , transform.position.z);


    }


    void Update()
    {
        //카메라 이동

        targetPos_y = target_y.transform.position;
        targetPos_p = target_p.transform.position;
        targetPos = (targetPos_y + targetPos_p) / 2;

        if (target_y.gameObject != null && target_p.gameObject != null)
        {
            targetPos.Set(targetPos.x, targetPos.y + 2, transform.position.z);
            this.transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }


        //카메라 바운드 설정
        float clampedX = Mathf.Clamp(transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
