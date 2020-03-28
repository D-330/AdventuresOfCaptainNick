using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	public int health = 100;
	public int stamina = 100;
	
    public float playerSpeed;
    public float sprintSpeed = 4f;
    public float walkSpeed = 2f;
    public float mouseSensitivity = 2f;
    public float jumpHeight = 3f;
    private bool isMoving = false;
    private bool isSprinting =false;
    private float yRot;
 
    // private Animator anim;
    private Rigidbody rigidBody;
 
    // Use this for initialization
    void Start () {
 
        playerSpeed = walkSpeed;
    //    anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
 
    }
 
    // Update is called once per frame
    void FixedUpdate () {
 
        yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);
 
        isMoving = false;
 
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
            rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
            isMoving = true;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed;
            isMoving = true;
        }
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jumpHeight);
        }
 
        if (Input.GetAxisRaw("Sprint") > 0f)
        {
            playerSpeed = sprintSpeed;
            isSprinting = true;
        }else if (Input.GetAxisRaw("Sprint") < 1f)
        {
            playerSpeed = walkSpeed;
            isSprinting = false;
        }
 
        //anim.SetBool("isMoving", isMoving);
        //anim.SetBool("isSprinting", isSprinting);
 
    }
}