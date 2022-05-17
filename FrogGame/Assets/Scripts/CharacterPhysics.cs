using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterPhysics : MonoBehaviour, IMoveable
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    public bool IsGrounded { get; protected set; }
    
    private Rigidbody rb;
    
    private float gravityFallMultiplier = 2.5f;
    private float gravityJumpMultiplier = 2f;
    
    private bool CanJump => jumpCooldown == 0f && rb.velocity.y == 0f && !IsGrounded;

    private float jumpCooldown = 0f;
    private float jumpWaitTime = 0.1f;
    
    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        jumpCooldown = Mathf.Clamp(jumpCooldown, 0f, jumpWaitTime);
        
        UpdatePhysics();
    }
    
    private void UpdatePhysics()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * (Physics.gravity.y * (gravityFallMultiplier) * Time.deltaTime);
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector3.up * (Physics.gravity.y * (gravityJumpMultiplier) * Time.deltaTime);
        }
    }

    public void Move2D(float direction)
    {
        rb.velocity = new Vector3(0f, rb.velocity.y, direction * MoveSpeed);
    }

    public void Jump()
    {
        if (!CanJump) return;
        jumpCooldown = jumpWaitTime;
        
        rb.AddForce(Vector3.up * JumpForce);
    }
}
