using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> selectableObjects = new List<GameObject>();
    int score;
    float time;
    public TMP_Text scoreText;
    



    // Start is called before the first frame update
    void Start()
    {
        LoadSelectableObjects();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 15f, 1<<6))
            {
                GameObject clickedObject = hit.collider.gameObject;

            
                    float PointsAwarded = time;
                    score += Mathf.FloorToInt(PointsAwarded);
                    
                    Debug.Log("Trefil si cíl, skóre je: " + score);
                    scoreText.text = "Score: " + score;
                    
                
            }
        }
        
    }

    

    void LoadSelectableObjects()
    {
        GameObject[] objectInScene = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objectInScene) 
        {
            if (obj.layer == 6)
            {
                selectableObjects.Add(obj);
                Debug.Log("selectable Object: " + obj.name);
            }
        }
    }
}
