using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public InputActionReference horizontalLook;
    public InputActionReference verticalLook;
    public float lookSpeed = 0.5f;
    public Transform cameraTransform;
    float pitch;
    float yaw;
    private Vector3 moveVec;
    private Rigidbody rb;
    private float moveSpeed = 10f;

    private GameObject droidPartA;
    private GameObject droidPartB;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       horizontalLook.action.performed += HandleHorizontalLookChange;
       verticalLook.action.performed += HandleVerticalLookChange;
       rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void HandleHorizontalLookChange(InputAction.CallbackContext obj)
    {
        yaw += obj.ReadValue<float>();
        transform.localRotation = Quaternion.AngleAxis(yaw * lookSpeed, Vector3.up);
    }

    void HandleVerticalLookChange(InputAction.CallbackContext obj)
    {
        pitch -= obj.ReadValue<float>();
        cameraTransform.localRotation = Quaternion.AngleAxis(pitch * lookSpeed, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMovement()
    {
         rb.velocity = moveVec * moveSpeed;
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        moveVec = transform.forward * inputVec.y + transform.right*inputVec.x;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "DroidPart")
        {
            Debug.Log(other.gameObject.tag);
        }
    }

}
