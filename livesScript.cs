using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesScript : MonoBehaviour
{
    public int curlives;
    public int maxlives;
    public Slider livesBar;
    // Start is called before the first frame update
    void Start()
    {
        curlives = maxlives;
        livesBar.maxValue = maxlives;
        livesBar.value = curlives;
    }

    // Update is called once per frame
    void Update()
    {
        livesBar.transform.parent.rotation = Camera.main.transform.rotation;
        /*if(Input.GetMouseButtonDown(0) )
        {
            TakeDamage(5);
            Debug.Log(curlives);
        }*/
    }

    public void TakeDamage(int damage)
    {
        curlives -= damage;
        livesBar.value = curlives;
        if (curlives < 0)
        {
            Destroy(gameObject);
        }
    }
}
