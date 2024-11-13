using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> selectableObjects = new List<GameObject>();
    int score;
    public TMP_Text scoreText;
    public TMP_Text text;
    public Vector3 teleport;

    
    // Start is called before the first frame update
    void Start()
    {
       LoadSelectableObjects();
       teleport = new Vector3(5, 5, -5);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 15f, 1 << 6))
        {
            text.text = hit.collider.gameObject.name;
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.transform.position = teleport;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(hit.collider.gameObject);
                score += 10;
                scoreText.text = "Score:" + score;
            }
        }
        else if (Physics.Raycast(ray, out hit, 15f, 1<< 7))
        {
            text.text = hit.collider.gameObject.name;
        }

        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }
        if(score == 30)
        {
            SceneManager.LoadScene(0);
            Cursor.lockState= CursorLockMode.None;
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
