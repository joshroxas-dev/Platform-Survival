using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 5.0f;
    private float m_TravelDistance = 0;
    private float m_MaxTravelDistance = 15.0f;
    private Coroutine m_ReverseCoroutine;
    private Rigidbody m_Rb;

    IEnumerator Start()
    {
        m_Rb = GetComponent<Rigidbody>(); 
        enabled = false;
        yield return new WaitForSeconds(3.0f);
        enabled = true;
    }
    void FixedUpdate()
    {
        if (m_TravelDistance >= m_MaxTravelDistance)
        {
            if (m_ReverseCoroutine == null)
            {
                m_ReverseCoroutine = StartCoroutine(nameof(ReverseElevator));
            }
        }
        else
        {
            float velocity = speed * Time.fixedDeltaTime;
            m_TravelDistance = m_TravelDistance + Mathf.Abs(velocity);

            Vector3 elevatorPosition = m_Rb.position;
            elevatorPosition.y += velocity;

            m_Rb.MovePosition(elevatorPosition);
        }

    }

    IEnumerator ReverseElevator()
    {
        yield return new WaitForSeconds(3.0f);
        //wait 3 seconds to execute the below code.
        m_TravelDistance = 0;
        speed = -speed;
        m_ReverseCoroutine = null;
    }

  
}
