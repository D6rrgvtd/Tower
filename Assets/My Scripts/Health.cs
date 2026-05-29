using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   [SerializeField] public int Hp;

    public void TakeDamage(int amout)
    {
        Hp -= amout;
        Debug.Log(gameObject.name + "‚ÌHP"+Hp);
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
