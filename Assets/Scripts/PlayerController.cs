using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_Rb;
    private GameObject m_Elevator;
    private GameObject m_PowerUp;
    private float m_ElevatorOffsetY;
    private Vector3 m_CameraPosition;
    public Camera followCamera;
    public float speed = 3;

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

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (move == Vector3.zero)
        {
            return;
        }
        //rotate the player
        Quaternion targetRotation = Quaternion.LookRotation(move);

        if (m_Elevator != null)
        {
            playerPosition.y = m_Elevator.transform.position.y + m_ElevatorOffsetY;
        }

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

        m_Rb.MovePosition(playerPosition + move * speed * velocity);
        m_Rb.MoveRotation(targetRotation);

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

        if (other.CompareTag("powerUp"))
        {
            Debug.Log("you got the powerup");
            speed++;
            m_PowerUp = other.gameObject;
            Destroy(m_PowerUp);
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
