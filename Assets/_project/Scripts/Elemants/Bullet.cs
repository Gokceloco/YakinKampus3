using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Player _player;    
    private Transform _transform;

    private void Start()
    {
        _player = GameDirector.instance.player;
        _transform = transform;
    }

    private void Update()
    {
        _transform.position += _transform.forward * speed * Time.deltaTime;
        if ((_transform.position - _player.transform.position).magnitude > 50)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
