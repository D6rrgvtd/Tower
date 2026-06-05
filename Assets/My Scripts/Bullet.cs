using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 8f;
    [SerializeField] public int damage;

    void Update()
    {

        if (target == null)
        {
            FindNewTarget();
        }
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

     transform.position = Vector2.MoveTowards(transform.position,target.position
         ,speed *  Time.deltaTime );
    }
    void FindNewTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(
                transform.position,
                enemy.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

    }
}
