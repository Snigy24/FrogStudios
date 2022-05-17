using System;
using UnityEngine;

[RequireComponent(typeof(IMoveable))]
public abstract class Character : MonoBehaviour, IHealth
{
    public abstract int Health { get; protected set; }

    protected IMoveable charPhysics;

    protected void Awake()
    {
        charPhysics = GetComponent<IMoveable>();
    }

    public abstract void Heal(int amount);

    public abstract void TakeDamage(int amount);
}

