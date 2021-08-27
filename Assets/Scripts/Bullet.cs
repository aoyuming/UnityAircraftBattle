using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody)
        {
            _rigidbody.velocity = Vector3.forward * moveSpeed;
        }
    }

    // 第一帧调用
    void Start()
    {
    }

    // 没帧调用
    void Update()
    {
        
    }
}
