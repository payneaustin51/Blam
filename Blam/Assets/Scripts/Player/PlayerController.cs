using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacterInterface {

    [Header("General Movement")]
    public float Speed = 10.0f;
    public float JumpForce = 50.0f;
    public float GravityModifier = -50.0f;
    private Rigidbody Player_RB;
    private float LastPosition;

    [Header("Gun Settings")]
    public Gun EquippedGun;

    [Header("View Settings")]
    public Camera PlayerView;
    [Range(1, 10)]public int Sensitivity = 2;
    public float MinimumY = -60.0f;
    public float MaximumY = 60.0f;
    private float RotationY = 0.0f;
    

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Player_RB = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        PlayerMovement();
        CameraMovement();
    }

    //Player Movement (Moving forward/backwards and straffing)
    private void PlayerMovement() {
        //Input Velocity
        Player_RB.velocity = (transform.right * Input.GetAxis("Horizontal") * Speed) + (transform.forward * Input.GetAxis("Vertical") * Speed);

        //Jump Velocity
        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded(1.1f))
            Player_RB.velocity += Vector3.up * JumpForce;

        if ((LastPosition - transform.position.y) >= 0.0f)
            Player_RB.velocity += Vector3.up * GravityModifier;
        else
            Player_RB.velocity += Vector3.up * GravityModifier / 4.0f;

        LastPosition = this.transform.position.y;
    }

    private bool CheckGrounded(float distance) { return Physics.Raycast(this.transform.position, Vector3.down, distance); }

    //Camera Controls/Player Rotation
    private void CameraMovement() {
        float RotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Sensitivity;
        RotationY += Input.GetAxis("Mouse Y") * Sensitivity;
        RotationY = Mathf.Clamp(RotationY, MinimumY, MaximumY);

        PlayerView.transform.localEulerAngles = new Vector3(-RotationY, 0.0f, 0.0f);
        this.transform.localEulerAngles = new Vector3(0.0f, RotationX, 0.0f);
    }

    public void TakeDamage(int DamagePoints) {
        Debug.Log("asdf");
    }
}
