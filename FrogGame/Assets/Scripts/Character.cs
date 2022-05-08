using UnityEngine;

public abstract class Character : MonoBehaviour, IMoveable, IHealth
{
    public abstract int Health { get; protected set; }
    public abstract float MoveSpeed { get; protected set; }
    public abstract float JumpForce { get; protected set; }


    public abstract void Move2D(float direction);

    public abstract void Jump();

    public abstract void Heal(int amount);

    public abstract void TakeDamage(int amount);
}

