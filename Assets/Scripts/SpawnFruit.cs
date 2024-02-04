using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public GameObject fruitPrefab;
    public GameObject bombPrefab;
    public float spawnRate = 0.8f;
    [Range(0, 100)] public float bombChance;

    const float boundX = 6f;

    private void Start()
    {
        InvokeRepeating("Spawn", 1.5f, spawnRate);
    }

    public void Spawn()
    {
        var prefab = Random.Range(0, 100) < (100 - bombChance) ? fruitPrefab : bombPrefab;

        var obj = Instantiate(prefab);
        var x = Random.Range(-boundX, boundX);
        obj.transform.position = new Vector2(x, -5f);
    }
}
