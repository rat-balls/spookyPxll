using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] Points;

    [SerializeField] private float moveSpeed;

    private Vector3 lastpos;

    public Light flashlight;
    public Light flashlightHalo;
    public MeshRenderer playerMesh;
    public Camera playerCam;

    private bool Cinematic = true;
    private int pointsIndex;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
        lastpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }
            Vector3 direction = transform.position - lastpos;
            transform.forward = Vector3.Lerp(transform.forward, direction, 0.1f);
        } else if(Cinematic == true){
            playerCam.enabled = !playerCam.enabled;
            flashlight.enabled = !flashlight.enabled;
            flashlightHalo.enabled = !flashlightHalo.enabled;
            playerMesh.enabled = playerMesh.enabled;
            Cinematic = false;
        }
        lastpos = transform.position;
    }
}
