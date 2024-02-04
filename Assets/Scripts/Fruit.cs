using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject explosionParticles;
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
            Miss();
        }
    }

    void Miss()
    {
        print(":(");
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explosionParticles);
        particles.transform.position = transform.position;
        Destroy(gameObject);
    }
}
