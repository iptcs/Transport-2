using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    Vector3 cubePosition;
    public static GameObject airplane;
    public static GameObject activePlane;
    public int gridLength = 16, gridHeight = 9;
    public static bool airplaneSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 16; i++)
        //{
        //cubePosition = new Vector3(i*2, 0, 0);
        //Instantiate(cubePrefab, cubePosition, Quaternion.identity);
        //}
        for (int y = 0; y < gridHeight; y += 2)
        {
            for (int x = 0; x < gridLength; x += 2)
            {
                SpawnCube(x, y);
                if (airplaneSpawned == false)
                    { airplaneSpawned = true; }
            }
        }
    }
    void SpawnCube(int Xaxis, int Yaxis)
    {
        cubePosition = new Vector3(Xaxis, Yaxis, 0);
        Instantiate(cubePrefab, cubePosition, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
