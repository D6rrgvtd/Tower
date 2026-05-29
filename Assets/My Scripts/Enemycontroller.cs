using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public float Speed;
    [SerializeField] public int damage;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Tower"))
        {

            Health health = other.gameObject.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }


        }
    }
}
