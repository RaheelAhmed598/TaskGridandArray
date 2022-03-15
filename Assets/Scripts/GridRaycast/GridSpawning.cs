using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpawning : MonoBehaviour
{
    [SerializeField] private int height = 5;
    [SerializeField] private int width = 5;
    [SerializeField] public GameObject cubePrefab;
    private GameObject[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        List<string> birds = new List<string>();
        birds.Add("pigeon");
        birds.Add("sparrow");
        birds.Add("Eagle");

       
        grid = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                // you could also add a padding /space between the cubes here
                grid[x, z] = Instantiate(cubePrefab, new Vector3(x * 2, 0, z * 2), Quaternion.identity);
                grid[x, z].GetComponentInChildren<TextMesh>().text = birds[Random.Range(0, birds.Count)];
                

            }
        }
    }

}





















    // Update is called once per frame
    //void Update()
    //{
    //    RaycastHit hit;
    //    // If you have more than one camera, assign the right one through inspector to some variable and use that
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        Vector3 hitPos = hit.point;
    //        Vector3 gridPos = new Vector2(Mathf.Round(hitPos.x), Mathf.Round(hitPos.z));
    //        if (Input.GetMouseButtonDown(0)) // lmb pressed
    //        {
    //            pressedLmbLast = true;
    //            mouseDownCubePosition = gridPos;
    //            Debug.Log("Clicked on Cube: " + gridPos + BirdNames);
    //            //Destroy(grid[(int)gridPos.x, (int)gridPos.y]);
    //        }
    //        else if (Input.GetMouseButtonUp(0) && pressedLmbLast) // lmp released
    //        {
    //            pressedLmbLast = false;
    //            mouseUpCubePosition = gridPos;
    //            Debug.Log("Released on Cube: " + gridPos + BirdNames);

    //            List<GameObject> roadCubes = new List<GameObject>();
    //            // We want the difference, so only the positive value
    //            int xDiff = Mathf.Abs((int)mouseDownCubePosition.x - (int)mouseUpCubePosition.x);
    //            int zDiff = Mathf.Abs((int)mouseDownCubePosition.y - (int)mouseUpCubePosition.y); // remember this is z

    //            // We know how many blocks, but not where to start. Find the smaller of the two values:
    //            int xStart = mouseDownCubePosition.x < mouseUpCubePosition.x ?
    //                (int)mouseDownCubePosition.x : (int)mouseUpCubePosition.x;
    //            int zStart = mouseDownCubePosition.y < mouseUpCubePosition.y ?
    //                (int)mouseDownCubePosition.y : (int)mouseUpCubePosition.y;

    //            // Iterate over all cubes in the defined range to get cubes on our path
    //            // Note: dont use nested loops, or you get the entire area, not its outline/path
    //            for (int x = xStart; x < (xStart + xDiff); x++)
    //            {
    //                roadCubes.Add(grid[x, zStart]);
    //            }
    //            for (int z = zStart; z < (zStart + zDiff); z++)
    //            {
    //                roadCubes.Add(grid[xStart, z]);
    //            }

    //            Debug.Log("Road consists of " + roadCubes.Count + " cubes.");

    //            // All cubes that make up our road are now saved in roadCubes
    //            // Do what you want with them, for example delete them or change their color:
    //            foreach (GameObject cube in roadCubes)
    //            {
    //                cube.GetComponent<Renderer>().material.color = Color.black;
    //            }
    //        }
    //    }
    //}

