using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rockRb;

    [SerializeField]
    private string _aimTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_aimTag))
        {
            _rockRb.simulated = true;
        }
    }

}
