using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public GameObject bombPrefab;
    public float spawnRate = 0.8f;
    [Range(0, 100)] public float bombChance;

    public List<Wave> waves = new();

    const float boundX = 5f;

    async void Start()
    {
        foreach (var wave in waves)
        {
            foreach (var item in wave.items)
            {
                // Check for randomness
                if (item.isRandomBomb) item.isBomb = Random.Range(0f, 1f) < 0.5f;
                if (item.isRandomPosition) item.x = Random.Range(-boundX, boundX);
                if (item.isRandomVelocity)
                {
                    // Logic so it doesn't fly off screen
                    var t = Mathf.InverseLerp(-boundX, boundX, item.x);
                    t--; // Make it from -1 to 1

                    var maxSpeed = 5f;
                    item.velocity = new Vector2
                        (
                            Random.Range(-t * maxSpeed + t * Random.Range(-maxSpeed / 2, maxSpeed / 2), boundX),
                            Random.Range(8.5f, 12f)
                        );
                }

                await new WaitForSeconds(item.delay);

                var prefab = item.isBomb ? bombPrefab : fruitPrefab;
                var go = Instantiate(prefab);
                go.transform.position = new Vector2(item.x, -5);
                go.GetComponent<Rigidbody2D>().velocity = item.velocity;
            }
            await new WaitForSeconds(3f);
        }
    }

    public void Spawn()
    {
        var prefab = Random.Range(0, 100) < (100 - bombChance) ? fruitPrefab : bombPrefab;

        var obj = Instantiate(prefab);
        var x = Random.Range(-boundX, boundX);
        obj.transform.position = new Vector2(x, -5f);
    }
}
