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

    private PlayerHand hand;

    float pitch;
    float yaw;
    private Vector3 moveVec;
    private Rigidbody rb;
    private float moveSpeed = 4.0f;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       horizontalLook.action.performed += HandleHorizontalLookChange;
       verticalLook.action.performed += HandleVerticalLookChange;
       rb = this.gameObject.GetComponent<Rigidbody>();
       hand = gameObject.GetComponentInChildren<PlayerHand>();
       levelManager = GameObject.Find("Level").GetComponent<LevelManager>();
    }

    void HandleHorizontalLookChange(InputAction.CallbackContext obj)
    {
        yaw += obj.ReadValue<float>();
        transform.localRotation = Quaternion.AngleAxis(yaw * lookSpeed, Vector3.up);
    }

    void HandleVerticalLookChange(InputAction.CallbackContext obj)
    {
        pitch -= obj.ReadValue<float>();
        pitch = Mathf.Clamp(pitch, -45f, 45f);
        cameraTransform.localRotation = Quaternion.AngleAxis(pitch * lookSpeed, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMovement()
    {
        transform.position += moveVec * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        moveVec = transform.forward * inputVec.y + transform.right*inputVec.x;
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.PlayPlayerStepAudio();
    }

    // space bar pressed
    public void OnGrab(InputValue input)
    {
        hand.Grab();
    }

    // ']' pressed
    public void OnChangeDroid(InputValue input)
    {
        levelManager.ChangeDroid();
    }

    // 'm' pressed
    public void OnMute(InputValue input)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.ToggleMute();
    }

}
