using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("Задержка перед остановкой цели")]
    private float _StopDelay;

    public bool AimFinished = false;

    private GameObject _aim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Cart>())
        {
            Invoke(nameof(Finish), _StopDelay);
            _aim = collision.gameObject;
        }
    }

    private void Finish()
    {
        AimFinished = true;
        _aim.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
