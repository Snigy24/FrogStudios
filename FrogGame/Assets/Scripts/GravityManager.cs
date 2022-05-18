using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private static GravityManager instance;

    public static GravityManager Instance => instance;
    
    [Header("Gravity Settings")]

    [Tooltip("Gravity forces applied to movable objects")]
    [SerializeField] 
    private Vector3 gravity = new Vector3(0f, -9.81f, 0f);
    
    [Tooltip("How fast objects fall")]
    [SerializeField]
    [Range(1f, 10f)]
    private float gravityFallMultiplier = 3f;
    public float FallMultiplier => gravityFallMultiplier * Physics.gravity.y;
    
    [Tooltip("How quick objects go up while jumping, higher values means slower")]
    [SerializeField]
    [Range(1f, 10f)]
    private float gravityJumpMultiplier = 2f;
    public float JumpMultiplier => gravityJumpMultiplier * Physics.gravity.y;
    
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else instance = this;

        Physics.gravity = gravity;
        
    }

}
