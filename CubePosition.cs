using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubePosition : MonoBehaviour
{
    public Vector3 position;
    public GameObject cube;
    int score;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {

        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cube.transform.position += new Vector3(1, 0, 0);
            score += 10;
            scoreText.text = "Score:" + score;
        }
      
    }
}
