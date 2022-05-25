using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed, gravityMod, jumpPower;
    public CharacterController chController;

    private bool canJump;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    public GameObject bullet;
    public Transform firePoint;

    //public GameObject impactEffect;
    //public float range = 100f;

    public Animator anim;
    public Animator weaponanim;
    

    public Transform cameraTrans;
    private Vector3 moveInput;

    public float mouseSens;
    public bool invertX, invertY;

    public Weapon activeWeapon;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UIController.instance.ammoText.text = "AMMO: " + activeWeapon.currentAmmo;
    }


    void Update()
    {
        //movement

        if (!PlayerController.instance.gameObject.activeInHierarchy) return;

        float yStore = moveInput.y;

        Vector3 verticalMove = transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 horizontalMove = transform.right * Input.GetAxisRaw("Horizontal");

        moveInput = horizontalMove + verticalMove;

        // forward ve right speedlerin çarpýlmamasý için
        moveInput.Normalize();

        moveInput = moveInput * moveSpeed;

        moveInput.y = yStore;
        moveInput.y += Physics.gravity.y * gravityMod * Time.deltaTime;

        if (chController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityMod * Time.deltaTime;
        }

        canJump = Physics.OverlapSphere(groundCheckPoint.position, 0.25f, whatIsGround).Length > 0;

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            moveInput.y = jumpPower;
        }

        chController.Move(moveInput * Time.deltaTime);

        //camera
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSens;

        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        cameraTrans.rotation = Quaternion.Euler(cameraTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));


        //SHOOTING

        // for single shots
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            if (Physics.Raycast(cameraTrans.position, cameraTrans.forward, out hit, 50f))
            {
                if (Vector3.Distance(cameraTrans.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(cameraTrans.position + (cameraTrans.forward * 30f));
            }

            //Instantiate(bullet, firePoint.position, firePoint.rotation);
            FireShot();


            /*Instantiate(bullet, firePoint.position, firePoint.rotation);
            RaycastHit hit;
            if (Physics.Raycast(cameraTrans.position, cameraTrans.forward, out hit, range))
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                firePoint.LookAt(hit.point);
            }
            else
            {
                // mermi bir yere çarpmazsa
                firePoint.LookAt(cameraTrans.position + (cameraTrans.forward * range));
            }
        }*/
        }

        // for auto shots
        if (Input.GetMouseButton(0) && activeWeapon.canAutoFire)
        {
            if (activeWeapon.fireCounter <= 0)
            {
                FireShot();
            }
        }

        // magnitude = oyuncunun ne kadar mesafe kat ettiði
        anim.SetFloat("moveSpeed", moveInput.magnitude);
        anim.SetBool("onGround", canJump);

    }
    public void FireShot()
    {
        if (activeWeapon.currentAmmo > 0)
        {
            activeWeapon.currentAmmo--;


            Instantiate(activeWeapon.bullet, firePoint.position, firePoint.rotation);

            activeWeapon.fireCounter = activeWeapon.fireRate;

            UIController.instance.ammoText.text = "AMMO: " + activeWeapon.currentAmmo;

            weaponanim.SetTrigger("isShooting");
        }

        
    }
}
