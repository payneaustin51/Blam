using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ITakeDamage {

    [Header("General Movement")]
    [SerializeField] private float Speed = 10.0f;
    [SerializeField] private float JumpForce = 50.0f;
    [SerializeField] private float GravityModifier = 1.0f;
    private Vector3 Movement = Vector3.zero;
    private CharacterController CController;

    [Header("View Settings")]
    [SerializeField] [Range(1, 10)] private int Sensitivity = 2;
    [SerializeField] private float MinimumY = -60.0f;
    [SerializeField] private float MaximumY = 60.0f;
    private float RotationY = 0.0f;
    private Camera PlayerView;

    [Header("Player Attributes")]
    [SerializeField] private float Health = 100.0f;
    private PlayerShoot PShoot;

    void Awake() {
        Cursor.lockState = CursorLockMode.Locked;

        CController = this.GetComponent<CharacterController>();
        PShoot = this.GetComponent<PlayerShoot>();
        PlayerView = FindObjectOfType<Camera>();

    }

    void Update() {
        ShootGun();
    }

    void FixedUpdate() {
        PlayerMovement();
        CameraMovement();
    }

    //Player Movement (Forwards/Backwards/Strafing/Jumping)
    private void PlayerMovement() {
        if(Input.GetKeyDown(KeyCode.Space) && CheckGrounded(1.1f)) {
            Movement.y = JumpForce;
        }
        Movement.y -= -(Physics.gravity.y) * Time.deltaTime * GravityModifier;
        Movement = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical")) + (transform.up * Movement.y);

        CController.Move(Movement * Speed * Time.deltaTime);
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

    //Shooting Call
    private void ShootGun() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            PShoot.Shoot(PlayerView.transform.position, PlayerView.transform.forward);
        }
    }

    //Taking Damage (Interface method)
    public void TakeDamage(int DamagePoints) {
        Health -= DamagePoints;
        if(Health < 0.0f) {
            Destroy(this.gameObject);
        }
    }
}
