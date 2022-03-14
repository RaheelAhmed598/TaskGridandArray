using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
    [SerializeField] private int height = 10;
    [SerializeField] private int width = 10;
    [SerializeField] private GameObject cubePrefab;
    private GameObject[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                // you could also add a padding /space between the cubes here
                grid[x, z] = Instantiate(cubePrefab, new Vector3(x*2, 0, z*2), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
