using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Rigidbody _rb;
    private Player _player;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameDirector.instance.player;
    }

    private void Update()
    {
        var dir = (_player.transform.position - transform.position).normalized;
        _rb.linearVelocity = dir * speed;
        transform.LookAt(transform.position + dir);
    }
}
