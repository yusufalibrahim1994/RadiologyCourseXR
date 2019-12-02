using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //SerializeFields
    [SerializeField] Transform startCube;
    [SerializeField] Transform endCube;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "start")
        {
            print("it touched");
            gameObject.transform.position = endCube.transform.position + new Vector3(0, -16.2f, 30);
            return;
        }

        if (col.tag == "end")
        {
            gameObject.transform.position = startCube.transform.position + new Vector3(0, -16.2f, -30);
            return;
        }
    }
}
