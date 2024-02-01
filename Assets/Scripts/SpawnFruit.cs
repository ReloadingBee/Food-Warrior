using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public GameObject fruit;
    public float spawnRate = 0.8f;

    const float boundX = 6f;

    private void Start()
    {
        InvokeRepeating("Spawn", 1.5f, spawnRate);
    }

    public void Spawn()
    {
        var obj = Instantiate(fruit);
        var x = Random.Range(-boundX, boundX);
        obj.transform.position = new Vector2(x, -5f);
    }
}
