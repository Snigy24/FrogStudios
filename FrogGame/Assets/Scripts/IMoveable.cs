using UnityEngine;

public interface IMoveable
{
    public float MoveSpeed { get; }
    public float JumpForce { get; }
    
    public void Move2D(float direction);
    public void Jump();
}