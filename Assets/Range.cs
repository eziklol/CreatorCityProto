using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject parent;
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "elka")
        {
            if (parent.GetComponent<sobiratellesa>().forest == null)
            {
                parent.GetComponent<sobiratellesa>().forest = collision.gameObject;
            }
            else
            {
                GameObject go = parent.GetComponent<sobiratellesa>().forest;
                float distance1 = Vector3.Distance(transform.position, go.transform.position);
                float distance2 = Vector3.Distance(transform.position, collision.gameObject.transform.position);
                if (distance2 < distance1)
                {
                    parent.GetComponent<sobiratellesa>().forest = collision.gameObject;
                }
            }
        }
    }


}
