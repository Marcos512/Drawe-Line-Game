using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField]
    private string _aimTag;

    [SerializeField, Tooltip("Задержка перед остановкой цели")]
    private float _StopDelay;

    public bool AimFinished = false;

    private GameObject _aim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _aimTag)
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
