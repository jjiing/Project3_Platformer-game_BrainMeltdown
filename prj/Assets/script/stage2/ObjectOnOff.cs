using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnOff : MonoBehaviour
{
    
    GameObject[] children = new GameObject[2];
    

    public float time1 = 2f;
    public float time2 = 1f;

    private void Start()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
            children[i].SetActive(false);
        }





        StartCoroutine(OnOffCo());
    }
    

    
    void Update()
    {
        
    }
    IEnumerator OnOffCo()
    {
        while (true)
        {
            
            children[0].SetActive(true);
            yield return new WaitForSeconds(time1);

            children[1].SetActive(false);
            yield return new WaitForSeconds(time2);

            children[1].SetActive(true);
            yield return new WaitForSeconds(time1);

            children[0].SetActive(false);
            yield return new WaitForSeconds(time2);






        }
    }
    

   
    
}
