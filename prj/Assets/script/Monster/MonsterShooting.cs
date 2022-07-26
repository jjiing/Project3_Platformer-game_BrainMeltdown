using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : MonoBehaviour
{

    GameObject projective;

    void Start()
    {
        projective = transform.GetChild(0).gameObject;
        StartCoroutine(ShootCo());
    }

   
    void Update()
    {
       
            
    }
    IEnumerator ShootCo()
    {
        
        while (true)
        {
            Shooting();
            yield return new WaitForSeconds(3f);
        }
    }

    void Shooting()
    {
  
        projective.SetActive(true);
        projective.transform.localPosition = new Vector3(-2.05f, 0.25f, 0);

      
    }
}
