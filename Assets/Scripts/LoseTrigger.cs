using UnityEngine;

class LoseTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Cart>())
            GameStatus.OnLoseTrigger = true;
    }
}

