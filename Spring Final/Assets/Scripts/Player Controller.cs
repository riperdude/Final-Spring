using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float mouseSensitivity = 1f;
    public GameObject Twig;
    public Transform firePoint;
    public Transform theCamera;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    private bool canPlayerJump;
    private Vector3 moveInput;
    private CharacterController _characterController;
    private Ammo _ammo;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _ammo = GetComponent<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        float yVeclocity = moveInput.y;
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw ("Mouse Y")) * mouseSensitivity;

        //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 forwardDirection = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalDirection = transform.right * Input.GetAxis("Horizontal");

        moveInput =(forwardDirection + horizontalDirection). normalized;
        moveInput *= moveSpeed;

        moveInput.y = yVeclocity;
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        if(_characterController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        canPlayerJump = Physics.OverlapSphere(groundCheckpoint.position, 0.50f, whatIsGround).Length > 0;

        if(Input.GetKeyDown(KeyCode.Space) && canPlayerJump)
        {
            moveInput.y = jumpForce;
        }

        _characterController.Move(moveInput * Time.deltaTime);

        //camcontroles 

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        theCamera.rotation = Quaternion.Euler(theCamera.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        //shooting
        if(Input.GetMouseButtonDown(0) && _ammo.GetAmmoAmount() > 0)
        {
            RaycastHit hit;

            if(Physics.Raycast(theCamera.position,theCamera.forward, out hit, 50f))
            {
                if(Vector3.Distance(theCamera.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
            }
                else
                {
                    firePoint.LookAt(theCamera.position + (theCamera.forward * 30f));
                }

                Instantiate(Bullet, firePoint.position, firePoint.rotation);
                _ammo.RemoveAmmo();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Sticks"))
        {
            _ammo.AddAmmo();
            other.gameObject.SetActive(false);
        }
    }
}
