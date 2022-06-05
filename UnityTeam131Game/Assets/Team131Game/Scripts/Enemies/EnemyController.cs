using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody rb;
    private bool chasing;
    public float chaseDistance = 10f, distanceToLose = 15f, distanceToStop = 2f;

    private Vector3 targetPoint, startPoint;

    public NavMeshAgent agent;
    public float keepChasingTime = 5f;
    private float chaseCounter;

    private bool wasShot;

    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < chaseDistance)
            {
                chasing = true;
            }

            if (chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;

                if (chaseCounter <= 0)
                {
                    agent.destination = startPoint;
                }
            }

        }
        else
        {
            //transform.LookAt(targetPoint);
            //rb.velocity = transform.forward * moveSpeed;
            if (Vector3.Distance(transform.position, targetPoint) > distanceToStop)
            {
                agent.destination = targetPoint;
            }
            else
            {
                agent.destination = transform.position;
            }

            if (Vector3.Distance(transform.position, targetPoint) > distanceToLose)
            {
                if (!wasShot)
                {
                    chasing = false;

                    chaseCounter = keepChasingTime;
                }
            }
            else
            {
                wasShot = false;
            }
        }

    }

    public void GetShot()
    {
        wasShot = true;
        chasing = true;

    }

}
