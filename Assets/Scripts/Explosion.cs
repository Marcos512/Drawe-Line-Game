using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float Force;

    [SerializeField]
    private float Radius;

    [SerializeField]
    private LayerMask _layerMask;

    public void Explode()
    {
        Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(transform.position, Radius);

        foreach(var collider in overlappedColliders)
        {
            Rigidbody2D rigidbody = collider.attachedRigidbody;
            if (rigidbody)
            {
                var vector = (rigidbody.position - (Vector2)transform.position).normalized;
                var distForce = Radius - Vector2.Distance(rigidbody.position, transform.position);

                rigidbody.AddForce(vector*Force*distForce);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
