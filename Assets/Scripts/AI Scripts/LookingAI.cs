using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAI : MonoBehaviour
{
    public GameObject player;
    public GameObject pixelle;
    public float maxlimit;
    private float Distance_;

    public bool chasing = false;

    void Start()
    {
        StartCoroutine(waiter());
    }

    void Update()
    {
  
        Distance_ = Vector3.Distance(player.transform.position, pixelle.transform.position);
        
        transform.LookAt(player.transform);
        this.GetComponent<WonderAI>().enabled = false;
        StartCoroutine(waiter());
        if (Distance_ <= gameObject.GetComponent<Raycasting>().maxSightDistance)
        {
            chasing = true;
            Debug.Log("chasing");
        }
        else
        {
            this.GetComponent<WonderAI>().enabled = true;
            Debug.Log("wander");
            this.GetComponent<LookingAI>().enabled = false;

        }
 
    }
    IEnumerator waiter() {
        yield return new WaitForSeconds(3);
    }

}
