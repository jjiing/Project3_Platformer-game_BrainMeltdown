using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnOff : MonoBehaviour
{
    
    GameObject children0;
    GameObject children1;

    public float time1 = 2f;
    public float time2 = 1f;

    private void Start()
    {
        children0 = transform.GetChild(0).gameObject;
        children1 = transform.GetChild(1).gameObject;
        children0.SetActive(false);
        children1.SetActive(false);





        StartCoroutine(OnOffCo());
    }
    

    
    void Update()
    {
        
    }
    IEnumerator OnOffCo()
    {
        while (true)
        {
            
            children0.SetActive(true);
            yield return new WaitForSeconds(time1);

            children1.SetActive(false);
            yield return new WaitForSeconds(time2);

            children1.SetActive(true);
            yield return new WaitForSeconds(time1);

            children0.SetActive(false);
            yield return new WaitForSeconds(time2);






        }
    }
    

   
    
}
