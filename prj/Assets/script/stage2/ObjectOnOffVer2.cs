using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnOffVer2 : MonoBehaviour
{
    GameObject[] children= new GameObject[6];


    void OnEnable()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
            children[i].SetActive(false);
        }
 
        


        StartCoroutine(OnOffCo());
    }


    IEnumerator OnOffCo()
    {


        children[0].SetActive(true);
        yield return new WaitForSeconds(3);

        children[1].SetActive(true);
        yield return new WaitForSeconds(2);

        children[0].SetActive(false);
        yield return new WaitForSeconds(1);

        children[2].SetActive(true);
        yield return new WaitForSeconds(2);

        children[1].SetActive(false);
        yield return new WaitForSeconds(1);

        children[3].SetActive(true);
        yield return new WaitForSeconds(2);

        children[2].SetActive(false);
        yield return new WaitForSeconds(1);

        children[4].SetActive(true);
        yield return new WaitForSeconds(2);

        children[3].SetActive(false);
        yield return new WaitForSeconds(1);

        children[5].SetActive(true);
        yield return new WaitForSeconds(2);

        children[4].SetActive(false);
        yield return new WaitForSeconds(3);

        children[5].SetActive(false);









    }
}
