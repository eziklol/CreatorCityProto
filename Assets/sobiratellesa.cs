using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sobiratellesa : MonoBehaviour
{
    [SerializeField] GameObject home;
    public GameObject forest;
    [SerializeField] GameObject target;
    [SerializeField] GameObject derevo;
    [SerializeField] GameObject thisDerevo;
    float distance;
    float Currdistance;
    private NavMeshAgent agent;

    void Start()    
    {
        // forest = GameObject.FindGameObjectsWithTag("elka");
        agent = GetComponent<NavMeshAgent>();
        
    }

    //GameObject FindForest()
    //{
    //    Currdistance = 1000f;
    //    foreach (GameObject go in forest)
    //    {
    //        float distance = Vector3.Distance(transform.position, go.transform.position);
    //        if (Currdistance > distance)
    //        {
    //            thisDerevo = go;
    //            Currdistance = distance;
    //        }
    //    }



    //    return thisDerevo;
    //}
    void Update()
    {
        if (target == null) { StartCoroutine(ForestFind()); }
        else { agent.SetDestination(target.transform.position); }
    }

    private IEnumerator ForestFind()
    {
        derevo = forest; /*FindForest();*/

        if (derevo != null) { target = derevo; }
        else { target = home;  }        
        yield return new WaitForSeconds(5f);



    }
}
