using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, Random.Range(8.5f, 12f));
        rb.angularVelocity = 200;
    }

    private void Update()
    {
        if(transform.position.y < -6)
        {
            print(":(");
            Destroy(gameObject);
        }
    }
}
