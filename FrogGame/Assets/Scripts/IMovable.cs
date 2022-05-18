using UnityEngine;

public interface IMovable
{
    public float MoveSpeed { get; }
    public float JumpForce { get; }
    public bool IsGrounded { get; }
    
    public void Move2D(float direction);
    public void Jump();
}