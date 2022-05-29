using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public float rangeToTarget;
    public float timeBetweenShots = 0.5f;
    private float shotCounter;

    public Transform gun;
    public Transform firePoint;
    public float rotateSpeed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToTarget)
        {
            gun.LookAt(PlayerController.instance.transform.position + new Vector3(0f, 0f, 0f));
            //Vector3 newDirection = Vector3.RotateTowards(gun.forward, PlayerController.instance.transform.position - transform.position, rotateSpeed * 2 * Time.deltaTime, 0f);
            //gun.rotation = Quaternion.LookRotation(newDirection);

            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }
        else
        {
            shotCounter = timeBetweenShots;
            gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.Euler(0f, gun.rotation.eulerAngles.y + 10f, 0f), rotateSpeed * Time.deltaTime);
        }
    }
}
