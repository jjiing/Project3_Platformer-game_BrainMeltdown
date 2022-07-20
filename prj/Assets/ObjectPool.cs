using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject landingEffectPrefab;
    Queue<GameObject> Pool = new Queue<GameObject>();

    private void Start()
    {
        CreatePrefab(6);
    }

    void CreatePrefab(int num =1)
    {
        for(int i=0;i<num;i++)
        {
            GameObject landingEffect = Instantiate(landingEffectPrefab, transform);
            landingEffect.SetActive(false);
            Pool.Enqueue(landingEffect);
        }
    }
    public GameObject UsePrefab()
    {
        if(Pool.Count<=0) CreatePrefab(5);
           
        GameObject landingEffect = Pool.Dequeue();
        landingEffect.SetActive(true);
        return landingEffect;
    }

    public void GetBackPrefab(GameObject landingEffect)
    {
        landingEffect.SetActive(false);
        Pool.Enqueue(landingEffect);
    }
}
