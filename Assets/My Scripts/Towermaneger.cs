using UnityEngine;

public class Towermaneger : MonoBehaviour
{
    //[SerializeField] float Hp;
    public GameObject bulletPrefab;
    public float ShootingInterval;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ShootingInterval)
        {
            timer = 0;
            Shooting();
        }

    }

    void  Shooting()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0) return;

        GameObject nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

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
            GameObject bullet = Instantiate(
                bulletPrefab,
                transform.position,
                Quaternion.identity);

            bullet.GetComponent<Bullet>().target =
                nearestEnemy.transform;
        }
    }
}


