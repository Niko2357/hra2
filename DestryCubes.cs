using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryCubes : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

            foreach (GameObject cube in cubes)
            {
                Destroy(cube);
            }
        }
    }
}
