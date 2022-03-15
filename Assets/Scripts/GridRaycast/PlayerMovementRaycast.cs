using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRaycast : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 2, 0);
    private GridSpawning GridSpawn;
    Ray rayX, rayminusX, rayZ, rayminusZ;
    private float range = 2f;
    public bool isMovingForward, isMovingBack, isMovingRight, isMovingLeft;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
       GridSpawn = GameObject.Find("GridSpawning").GetComponent<GridSpawning>();

       rayZ = new Ray(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z + 2f), Vector3.forward);
       rayminusZ = new Ray(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 2f), Vector3.back);
       rayX = new Ray(new Vector3(transform.position.x + 2f, transform.position.y - 1, transform.position.z), Vector3.right);
       rayminusX = new Ray(new Vector3(transform.position.x - 2f, transform.position.y - 1, transform.position.z), Vector3.left);
    }

    void playerBound()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Vector3 rayOrigin = transform.position;
            if (Physics.Raycast(rayZ, out hit, range))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                isMovingForward = true;
            }

        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            //Vector3 rayOrigin = transform.position;
            if (Physics.Raycast(rayminusZ, out hit, range))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
                isMovingBack = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Vector3 rayOrigin = transform.position;
            if (Physics.Raycast(rayminusX, out hit, range))
            {
                transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
                isMovingLeft = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Vector3 rayOrigin = transform.position
            if (Physics.Raycast(rayX, out hit, range))
            {
                transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                isMovingRight = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        playerBound();
    }
}
