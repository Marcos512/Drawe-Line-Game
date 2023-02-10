using System.Collections;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("Задержка перед остановкой цели")]
    private float _StopDelay;

    public bool AimFinished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Cart cart))
        {
            StartCoroutine(StopDelay(_StopDelay, cart));
        }
    }

    private IEnumerator StopDelay(float delay, Cart cart)
    {   cart.FreezPosition();
        yield return new WaitForSeconds(delay);
        AimFinished = true;
        
    }
}
