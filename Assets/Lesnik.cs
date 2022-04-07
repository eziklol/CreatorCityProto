using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesnik : MonoBehaviour
{
    [SerializeField] private GameObject lesorubi;
    [SerializeField] private int maxHumans;
    private Vector3 spawn;
    void Start()
    {
        //spawn = this.gameObject.transform.position;
        StartCoroutine(CoroutineSpawner());
        
    }

    
    void Update()
    {
        
    }

    private IEnumerator CoroutineSpawner()
    {
        yield return new WaitForSeconds(5f);
        for (int humans=0; humans<maxHumans; humans++)
        {
            GameObject inst_obj = Instantiate(lesorubi, this.gameObject.transform.position, Quaternion.identity) as GameObject;

            yield return new WaitForSeconds(5f);
        }
    }
}
