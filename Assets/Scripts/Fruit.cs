using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject explosionParticles;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explosionParticles);
        particles.transform.position = transform.position;
        Destroy(gameObject);
    }
}
