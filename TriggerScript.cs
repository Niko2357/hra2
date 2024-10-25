using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    GameObject vrtule;
    bool tocit = false;
    public GameObject svetlo;
    // Start is called before the first frame update
    void Start()
    {
        svetlo = GameObject.FindGameObjectWithTag("svet");
        svetlo.SetActive(false);
        vrtule = GameObject.FindGameObjectWithTag("vrtule");
    }

    // Update is called once per frame
    void Update()
    {
        if (tocit)
        {
            vrtule.transform.Rotate(0f, 0f, 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            tocit = true;
            svetlo.SetActive(true);
        }
    }
}
