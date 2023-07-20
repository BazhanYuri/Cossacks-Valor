using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private Rigidbody _rigidbody;


    public void Push(int force)
    {
        _rigidbody.velocity = transform.forward * force;
    }
}
