using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> selectableObjects = new List<GameObject>();
    GameObject currentTarget;
    GameObject oldTarget;
    public int score;
    float time;
    float maxTime = 30f;
    public TMP_Text targetText;
    public Slider slider;
    public TMP_Text scoreText;
    public bool reloading;
    public TMP_Text shooting;
    livesScript livescript;

    // Start is called before the first frame update
    void Start()
    {
        LoadSelectableObjects();
        SelectNewTarget();
        slider.maxValue = maxTime;
        reloading = false;
        livescript = FindAnyObjectByType<livesScript>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        slider.value = time;
        if(time <= 0)
        {
            SelectNewTarget();
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 15f, 1<<6))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject == currentTarget)
                {
                    float PointsAwarded = time;
                    score += Mathf.FloorToInt(PointsAwarded);
                    
                    Debug.Log("Trefil si cíl, skóre je: " + score);
                    scoreText.text = "Score: " + score;
                    SelectNewTarget();
                }
            }
        }*/
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //while (reloading == false)
            //{
                if (Physics.Raycast(ray, out hit, 15f, 1 << 6))
                {
                    GameObject clickedObject = hit.collider.gameObject;

                    if (clickedObject.CompareTag("Enemy"))
                    {
                        float PointsAwarded = time;
                        score += 10;

                        Debug.Log("Trefil si enemaka, skóre je: " + score);
                        scoreText.text = "Score: " + score;
                        reloading = true;
                        livescript.TakeDamage(5);
                        shooting.text = "Reloading";
                        slider.value = maxTime;
                        if (slider.value == 0)
                        {
                            reloading = false;
                            shooting.text = "Shoot";
                        }
                    }
                }
            //}
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

    void SelectNewTarget()
    {

        if (selectableObjects.Count >= 1)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, selectableObjects.Count);
            } while (selectableObjects[randomIndex] == oldTarget);

            currentTarget = selectableObjects[randomIndex];
            oldTarget = currentTarget;
            time = maxTime;
            targetText.text = "Target is: " + currentTarget.name;
            Debug.Log("Target is: " + currentTarget.name);
        }
        else
        {
            Debug.Log("List musí mít alespoò 2 elementy");
        }        
    }
}
