using UnityEngine;

public class StarCollect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _effect;

    [SerializeField]
    private GameObject _sprite;

    [SerializeField]
    private string _aimTag;

    [SerializeField]
    private AudioSource _audio;

    private bool _activ = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _aimTag && !_activ)
        {
            _effect.Play();
            _sprite.SetActive(false);
            _activ = true;
            Game.StarsCollect++;
            _audio.Play();
            Destroy(gameObject, 5);
        }
    }
}
