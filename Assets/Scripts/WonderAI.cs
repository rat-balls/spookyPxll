using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderAI : MonoBehaviour
{
    public float Speed = 3f;
    public float SpeedRotation = 100f;

    public bool isWandering = false;
    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;
    public bool isWalking = false;

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            //gameObjet.GetComponent<Animator>().Play("");
            transform.Rotate(transform.up * Time.deltaTime * SpeedRotation);

        }
        if (isRotatingLeft == true)
        {
            //gameObjet.GetComponent<Animator>().Play("");
            transform.Rotate(transform.up * Time.deltaTime * -SpeedRotation);

        }
        if (isWalking == true)
        {
            //gameObjet.GetComponent<Animator>().Play("");
            transform.position += transform.forward * Time.deltaTime * Speed;

        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotWait = Random.Range(1, 4);
        int rotLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 6);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotWait);
        if (rotLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotLorR == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        isWandering = false;
    }
}
