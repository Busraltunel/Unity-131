using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, gravityMod, jumpPower;
    public CharacterController chController;

    private bool canJump;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    public Animator anim;

    public Transform cameraTrans;
    private Vector3 moveInput;

    public float mouseSens;
    public bool invertX, invertY;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //movement

        //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float yStore = moveInput.y;

        Vector3 verticalMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalMove = transform.right * Input.GetAxis("Horizontal");

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

        // magnitude = oyuncunun ne kadar mesafe kat ettiði
        anim.SetFloat("moveSpeed", moveInput.magnitude);
        anim.SetBool("onGround", canJump);

    }
}
