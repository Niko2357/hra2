using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    Ray ray;

    RaycastHit hit;

    public LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 10f, mask))
            {
                Debug.Log("Trefil si " + hit.collider.name);
            }
        }
    }
}
