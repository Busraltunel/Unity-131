using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterEnemy : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody rb;
    private bool chasing;
    public float chaseDistance = 10f, distanceToLose = 15f, distanceToStop = 2f;

    private Vector3 targetPoint, startPoint;

    public NavMeshAgent agent;
    public float keepChasingTime = 5f;
    private float chaseCounter;

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate, waitBetweenShots = 2f, timeToShoot = 1f;
    private float fireCount, shotWaitCounter, shootTimeCounter;

    public Animator anim;

    void Start()
    {
        startPoint = transform.position;

        shootTimeCounter = timeToShoot;
        shotWaitCounter = waitBetweenShots;
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

                shootTimeCounter = timeToShoot;
                shotWaitCounter = waitBetweenShots;
            }

            if (chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;

                if (chaseCounter <= 0)
                {
                    agent.destination = startPoint;
                }
            }


            if(agent.remainingDistance < .25f) 
            {
                anim.SetBool("isMoving", false);
            }
            else 
            {
                anim.SetBool("isMoving", true);
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
                chasing = false;
                chaseCounter = keepChasingTime;
            }

            if (shotWaitCounter > 0)
            {
                shotWaitCounter -= Time.deltaTime;

                if (shotWaitCounter <= 0)
                {
                    shootTimeCounter = timeToShoot;
                }

                anim.SetBool("isMoving", true);
            }
            else
            {
                shootTimeCounter -= Time.deltaTime;
                if (shootTimeCounter > 0)
                {
                    fireCount -= Time.deltaTime;

                    if (fireCount <= 0)
                    {
                        fireCount = fireRate;

                        // enemy player objesinin dýþýndaki bir açýda ateþ etmeyecek ve player objesinin biraz üstüne ateþ edecek
                        firePoint.LookAt(PlayerController.instance.transform.position + new Vector3(0f, 0.5f, 0f));
                        // playerýn açýlarýný kontrol etme (enemy 1,1 pozisyonunda olduðunu varsayalým playerýmýz da 3,2 pozisyonunda olsun. enemynin playera ulaþmasý için (3-1),(2-1) konumunda gitmesi lazým)
                        Vector3 targetDir = PlayerController.instance.transform.position - transform.position;
                        float angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

                        if (Mathf.Abs(angle) < 30f)
                        {
                            // yeni mermi kopyalarý
                            Instantiate(bullet, firePoint.position, firePoint.rotation);
                            anim.SetTrigger("fireShot");
                        }
                        else
                        {
                            shotWaitCounter = waitBetweenShots;

                            
                        }

                    }
                    agent.destination = transform.position;
                }
                else
                {
                    shotWaitCounter = waitBetweenShots;
                }


                anim.SetBool("isMoving", false);
            }
        }
    }
}

