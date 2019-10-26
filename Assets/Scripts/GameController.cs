using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    Vector3 cubePosition;
    GameObject activeCube;
    public int gridX = 16, gridY = 9;
    int airplaneX, airplaneY;
    GameObject[,] grid;
    bool airplaneActive;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[gridX, gridY];

        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                cubePosition = new Vector3(x * 2, y * 2, 0);
                grid[x,y] = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                grid[x, y].GetComponent<CubeController>().myX = x;
                grid[x, y].GetComponent<CubeController>().myY = y;

            }
        }

        // airplane starts in upper left
        airplaneX = 0;
        airplaneY = 8;
        grid[airplaneX, airplaneY].GetComponent<Renderer>().material.color = Color.red;
        airplaneActive = false;
    }

    public void ProcessClick(GameObject clickedCube, int x, int y)
    {
        if (x == airplaneX && y == airplaneY)
        {
            if (airplaneActive)
            {
                airplaneActive = false;
                clickedCube.transform.localScale /= 1.5f;
            }
            else
            {
                airplaneActive = true;
                clickedCube.transform.localScale *= 1.5f;
            }
        }

        else
        {
            if (airplaneActive)
            {
                // remove plane from old spot
                grid[airplaneX, airplaneY].GetComponent<Renderer>().material.color = Color.white;
                grid[airplaneX, airplaneY].transform.localScale /= 1.5f;


                // move plane to new spot
                airplaneX = x;
                airplaneY = y;
                grid[x, y].GetComponent<Renderer>().material.color = Color.red;
                grid[x, y].transform.localScale *= 1.5f;
            }
        }
    }
// Update is called once per frame
    void Update()
    {

    }
}