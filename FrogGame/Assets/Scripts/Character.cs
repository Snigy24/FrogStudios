using System;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public abstract class Character : MonoBehaviour, IHealth
{
    public abstract int Health { get; protected set; }

    protected IMovable charPhysics;

    protected virtual void Awake()
    {
        charPhysics = GetComponent<IMovable>();
    }

    public abstract void Heal(int amount);

    public abstract void TakeDamage(int amount);
}

