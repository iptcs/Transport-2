using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.airplaneSpawned == false)
        {
            GameController.airplane = gameObject;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnMouseDown()
    {
        if (GameController.airplane == gameObject && GameController.activePlane != gameObject)
        {
            GameController.activePlane = gameObject;
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (GameController.airplane == gameObject && GameController.activePlane == gameObject)
        {
            GameController.activePlane = null;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (GameController.airplane != gameObject && GameController.activePlane != null)
        {
            GameController.activePlane.GetComponent<Renderer>().material.color = Color.white;
            GameController.airplane = gameObject;
            GameController.activePlane = gameObject;
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
