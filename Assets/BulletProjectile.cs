using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int damage;
    private Rigidbody2D _rigidbody2D;
    private Transform _target;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        Vector2 direction = (_target.position - transform.position).normalized;
        _rigidbody2D.velocity = direction * speed;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player" || other.collider.tag == "Default")
        {

            if (other.collider.tag == "Default")
            {
                Destroy(gameObject);
            }
            other.collider.GetComponent<PlayerConfig>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
