using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField]
    private Vector2 _forceVector;

    [SerializeField]
    private Rigidbody2D _cartRigidbody2D;

    [SerializeField]
    private bool _onGraund = true;

    private void FixedUpdate()
    {
        if (_onGraund)
            _cartRigidbody2D.AddRelativeForce(_forceVector);
        //  _cartRigidbody2D.AddForce(_forceVector);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _onGraund = true;
        Debug.Log("stay");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onGraund = true;
        Debug.Log("On");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _onGraund = false;
        Debug.Log("Off");
    }

    public void FreezPosition()
    {
        _cartRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
