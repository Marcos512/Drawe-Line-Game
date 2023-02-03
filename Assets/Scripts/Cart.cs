using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField]
    private Vector2 forceVector;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
       _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddRelativeForce(forceVector);
    }
}
