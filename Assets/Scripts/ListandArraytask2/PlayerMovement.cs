using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 2, 0);
    private GridSpawn GridSpawn;
    // Start is called before the first frame update
    void Start()
    {
       GridSpawn = GameObject.Find("GridSpawner").GetComponent<GridSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && transform.position.z < GridSpawn.height * 2)
        {
            //transform.Translate(Vector3.forward + offset);
            transform.Translate(new Vector3 (0,0,2));
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > GridSpawn.height * 2)
        {
            //transform.Translate(Vector3.left + offset);
            transform.Translate(new Vector3(-2, 0, 0));

        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.z > GridSpawn.height * 2)
        {
            //transform.Translate(Vector3.back + offset);
            transform.Translate(new Vector3(0, 0, -2));

        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.z < GridSpawn.height * 2)
        {
            //transform.Translate(Vector3.right + offset);
            transform.Translate(new Vector3(2, 0, 0));

        }

    }
}
