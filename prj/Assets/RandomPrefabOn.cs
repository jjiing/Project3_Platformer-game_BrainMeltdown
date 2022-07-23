using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabOn : MonoBehaviour
{
    bool isYellowOn;
    bool isPurpleOn;
    int tryCheck;


    
    public GameObject child1;
    public GameObject child2;
    public GameObject child3;
    void Start()
    {
        isYellowOn = false;
        isPurpleOn = false;
        tryCheck = 0;
        
        child1.SetActive(false);
        child2.SetActive(false);
        child3.SetActive(false);

    }


    void Update()
    {
        if (isYellowOn && isPurpleOn && tryCheck ==0)
            RandomOn();
;
    }
    private void RandomOn()
    {
        tryCheck++; // 딱 한번만 실행되도록
        int RandomNum = Random.Range(0, 3);
        if(RandomNum ==0) child1.SetActive(true);
        else if(RandomNum ==1) child2.SetActive(true);
        else if(RandomNum ==2) child3.SetActive(true);
        isYellowOn = false;
        isPurpleOn = false;

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isYellowOn = true;
        }
        if (collision.gameObject.layer == 9)
        {
            isPurpleOn = true;
        }
    }
}
