using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacter : Character
{
    [field: SerializeField] public override int Health { get; protected set; }
    [field: SerializeField] public override float MoveSpeed { get; protected set; }
    [field: SerializeField] public override float JumpForce { get; protected set; }

    private bool CanJump => jumpCooldown == 0f && rb.velocity.y == 0f;

    private float jumpCooldown = 0f;
    private float jumpWaitTime = 0.1f;

    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        jumpCooldown -= Time.deltaTime;
        jumpCooldown = Mathf.Clamp(jumpCooldown, 0f, jumpWaitTime);
    }

    public override void Move2D(float direction)
    {
        rb.velocity = new Vector3(0f, rb.velocity.y, direction * MoveSpeed) ;
    }

    public override void Jump()
    {
        if (!CanJump) return;
        jumpCooldown = jumpWaitTime;
        
        // Maybe add async task to improve jump, or make our own gravity
        rb.AddForce(Vector3.up * JumpForce);
    }


    public override void Heal(int amount)
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }
}