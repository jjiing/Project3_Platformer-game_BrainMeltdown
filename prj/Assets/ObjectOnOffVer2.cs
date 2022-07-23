using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnOffVer2 : MonoBehaviour
{
    GameObject children0;
    GameObject children1;
    GameObject children2;
    GameObject children3;
    GameObject children4;
    GameObject children5;


    void OnEnable()
    {
        children0 = transform.GetChild(0).gameObject;
        children1 = transform.GetChild(1).gameObject;
        children2 = transform.GetChild(2).gameObject;
        children3 = transform.GetChild(3).gameObject;
        children4 = transform.GetChild(4).gameObject;
        children5 = transform.GetChild(5).gameObject;
        
        children0.SetActive(false);
        children1.SetActive(false);
        children2.SetActive(false);
        children3.SetActive(false);
        children4.SetActive(false);
        children5.SetActive(false);





        StartCoroutine(OnOffCo());
    }


    IEnumerator OnOffCo()
    {


        children0.SetActive(true);
        yield return new WaitForSeconds(3);

        children1.SetActive(true);
        yield return new WaitForSeconds(2);

        children0.SetActive(false);
        yield return new WaitForSeconds(1);

        children2.SetActive(true);
        yield return new WaitForSeconds(2);

        children1.SetActive(false);
        yield return new WaitForSeconds(1);

        children3.SetActive(true);
        yield return new WaitForSeconds(2);

        children2.SetActive(false);
        yield return new WaitForSeconds(1);

        children4.SetActive(true);
        yield return new WaitForSeconds(2);

        children3.SetActive(false);
        yield return new WaitForSeconds(1);

        children5.SetActive(true);
        yield return new WaitForSeconds(2);

        children4.SetActive(false);
        yield return new WaitForSeconds(3);

        children5.SetActive(false);









    }
}
