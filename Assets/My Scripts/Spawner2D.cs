using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnData
    {
        public GameObject prefab;    
        [Range(0, 100)]
        public float weight;         
    }

    [Header("スポーンさせるプレハブと確率のリスト")]
　　　　public SpawnData[] spawnList;
    [Header("間隔")]
    public float spawnInterval = 2.0f;

    private float timer = 0.0f;


    
    void Update()
    {
        timer += Time.deltaTime;

        if ( timer >= spawnInterval )
        {
            SpawnEnemy();
            timer = 0.0f;
        }
    }

    void SpawnEnemy()
    {
        if (spawnList == null || spawnList.Length == 0) return;

        
        float totalWeight = 0f;
        foreach (var data in spawnList)
        {
            totalWeight += data.weight;
        }


       
        float randomValue = Random.Range(0f, totalWeight);

        // 3. ランダムな数値がどのプレハブの範囲にあるかを判定
        float currentWeightSum = 0f;
        foreach (var data in spawnList)
        {
            currentWeightSum += data.weight;

            if (randomValue <= currentWeightSum)
            {
                // 選ばれたプレハブを生成
                if (data.prefab != null)
                {
                    Instantiate(data.prefab, transform.position, transform.rotation);
                }
                break; // 生成したらループを抜ける
            }
        }
    }
}

