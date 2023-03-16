using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public float apertureAngle;
    public float maxSightDistance;
    public int iterations;
    public bool agro = false;
    void Update()
    {
        float angleStep = apertureAngle / iterations;
        Vector3 startingPoint = transform.position;

        RaycastHit hit;
        for (int i = 0; i <= iterations; i++)
        {
            float angle = (-apertureAngle * 0.5f) + (i * angleStep);
            Vector3 sightVector = Quaternion.AngleAxis(angle, transform.up) * transform.forward;
            Debug.DrawRay(startingPoint, sightVector * maxSightDistance, Color.red);

            if (Physics.Raycast(startingPoint, sightVector, out hit, maxSightDistance))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "Player")
                {
                    this.GetComponent<LookingAI>().enabled = true;
                }
            }
        }
        
    }
}
