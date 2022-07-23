using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockFadeManage : MonoBehaviour
{
    SpriteRenderer sr;

    public float time = 4f;
    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeInOutCo());
    }
    IEnumerator FadeInOutCo()
    {
        StartCoroutine(FadeInCo());
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeOutCo());

    }
    IEnumerator FadeInCo()
    {
        Color c = sr.color;
        c.a = 0; 
        sr.color = c;

        while(c.a<1f)
        {
            c.a +=Time.deltaTime/1f;
            sr.color = c;
            yield return null;
        }
    }
    IEnumerator FadeOutCo()
    {
        Color c = sr.color;
       

        while (c.a > 0)
        {
            c.a -= Time.deltaTime / 1f;
            sr.color = c;
            yield return null;
        }
    }
}
