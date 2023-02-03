using UnityEngine;

public class CargoTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameStatus.OnLoseTrigger = true;
    }
}
