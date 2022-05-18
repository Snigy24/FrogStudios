using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterPhysics : MonoBehaviour, IMovable
{
    [field: SerializeField, Range(1f, 10f)] 
    public float MoveSpeed { get; private set; } = 5f;

    [field: SerializeField, Range(1f, 10f)]
    public float JumpForce { get; private set; } = 5f;
    
    private float jumpCooldown = 0f;
    private float jumpWaitTime = 0.1f;
    
    [SerializeField] private GroundChecker groundChecker;
    public bool IsGrounded => groundChecker.IsGrounded;

    public bool CanJump => IsGrounded && jumpCooldown <= 0f;
    
    private Rigidbody rb;

    private GravityManager gravity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gravity = GravityManager.Instance;
    }

    private void Update()
    {
        jumpCooldown -= Time.deltaTime;
        jumpCooldown = Mathf.Clamp(jumpCooldown, 0f, jumpWaitTime);
    }

    private void FixedUpdate()
    {
        UpdatePhysics();
    }

    private void UpdatePhysics()
    {
        switch (rb.velocity.y)
        {
            case < 0:
                rb.velocity += Vector3.up * (gravity.FallMultiplier * Time.deltaTime);
                break;
            case > 0:
                rb.velocity += Vector3.up * (gravity.JumpMultiplier * Time.deltaTime);
                break;
        }
    }

    public void Move2D(float direction)
    {
        rb.MovePosition(rb.position + Vector3.forward * (direction * MoveSpeed * Time.deltaTime));
    }

    public void Jump()
    {
        if (!CanJump) return;
        jumpCooldown = jumpWaitTime;
        
        rb.AddForce(Vector3.up * (JumpForce * 100f));
    }
}
