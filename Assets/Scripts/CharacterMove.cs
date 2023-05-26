using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterMove : MonoBehaviour
{
    [SerializeField] public bool AI { get; set; }

    [Header("Dependencies")]
    [SerializeField] public CharacterController characterController;
    
    [Header("Movement Settings")]
    public float MoveSpeed = 8f;
    public float TurnSensitivity = 5f;
    public float MaxTurnSpeed = 100f;

    [Header("Debug")]
    private float   _horizontal;
    private float   _vertical;
    private Vector3 _velocity;

    private void Awake()
    {
        characterController.enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (characterController == null || !characterController.enabled)
            return;

        if (AI)
        {
            Vector3 distance = PlayerSpawner.PlayerInstance.transform.position - transform.position;
            Vector3 direction = distance.normalized;

            _horizontal = direction.x;
            _vertical = direction.z;
        }
        else
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(_horizontal, 0, _vertical);
        direction = Vector3.ClampMagnitude(direction, 1f);
        direction = transform.TransformDirection(direction);
        direction *= MoveSpeed;

        characterController.SimpleMove(direction);
    }
}
