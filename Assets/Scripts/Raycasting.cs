using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);
        }
        
    }
}
