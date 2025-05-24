using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float range;

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
        if ((_transform.position - _player.transform.position).magnitude > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetHit(1);
            }
            gameObject.SetActive(false);
        }
    }
}
