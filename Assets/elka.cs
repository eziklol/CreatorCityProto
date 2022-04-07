using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elka : MonoBehaviour
{
    [SerializeField] GameObject forest;
    [SerializeField] GameObject drova;
    [SerializeField] GameObject newelka;
    public float hp;

    private float newSpawn;

    void Start()
    {
        hp = Random.Range(4f, 7f);    
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
           GameObject inst_obj = Instantiate(drova, this.gameObject.transform.position, Quaternion.identity) as GameObject;
            //StartCoroutine(CoroutineSpliter());
            Destroy(gameObject); 
        }
    }
    //private IEnumerator CoroutineSpliter()
    //{
    //    newSpawn = Random.Range(10f, 40f);
    //    yield return new WaitForSeconds(newSpawn);
    //    GameObject inst_obj = Instantiate(drova, this.gameObject.transform.position, Quaternion.identity) as GameObject;

    //}

}
