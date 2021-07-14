using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_Rb;
    public float speed = 10;

    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float velocity = speed * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        move.Normalize();

        m_Rb.MovePosition(m_Rb.position + move * speed * velocity);
    }
}
