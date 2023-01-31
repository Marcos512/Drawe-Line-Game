using UnityEngine;

class LoseTrigger : MonoBehaviour
{
    [SerializeField]
    private string _aimTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _aimTag)
            GameStatus.OnLoseTrigger = true;
    }

}

