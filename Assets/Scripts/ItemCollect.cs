using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _effect;

    [SerializeField]
    private GameObject _sprite;

    [SerializeField]
    private AudioSource _audio;

    private bool _activ = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.GetComponent<Cart>() || collision.GetComponent<CargoTrigger>()) && !_activ)
        {
            _effect.Play();
            _sprite.SetActive(false);
            _activ = true;
            Game.ItemsCollect++;
            _audio.Play();
            Destroy(gameObject, 5);
        }
    }
}
