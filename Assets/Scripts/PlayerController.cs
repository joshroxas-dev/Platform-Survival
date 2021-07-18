using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_Rb;
    private GameObject m_Elevator;
    private float m_ElevatorOffsetY;
    private Vector3 m_CameraPosition;
    public Camera followCamera;
    public float speed = 10;

    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_ElevatorOffsetY = 0;

        m_CameraPosition = followCamera.transform.position - m_Rb.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float velocity = speed * Time.fixedDeltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 playerPosition = m_Rb.position;

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        move.Normalize();

        if (m_Elevator != null)
        {
            playerPosition.y = m_Elevator.transform.position.y + m_ElevatorOffsetY;
        }

        m_Rb.MovePosition(playerPosition + move * speed * velocity);

        
    }

    void LateUpdate()
    {
        followCamera.transform.position = m_Rb.position + m_CameraPosition;    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rb.AddForce(new Vector3(transform.position.x, 300, transform.position.z));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            m_Elevator = other.gameObject;
            m_ElevatorOffsetY = transform.position.y - m_Elevator.transform.position.y;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            m_Elevator = null;
            m_ElevatorOffsetY = 0;
        }
    }
}
