using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private int RotateSpeed = 100;
    [SerializeField] private int jumpForce = 5;
    [SerializeField] private Rigidbody rb;
    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal")*RotateSpeed*Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(0, 0, vertical);
        transform.Rotate(0, horizontal, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Chest"))
        {
            Renderer rend = collision.gameObject.GetComponent<Renderer>();
            rend.material.color = Color.yellow;
        }
    }
}
