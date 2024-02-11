using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject explosionParticles;
    Rigidbody2D rb;

    public GameObject leftSide;
    public GameObject rightSide;
    public Color juiceColor;

    Rigidbody2D leftRb;
    Rigidbody2D rightRb;

    public AudioClip spawnSound;
    public AudioClip sliceSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = 200;
        AudioSystem.Play(spawnSound);
    }

    private void Update()
    {
        if(transform.position.y < -6)
        {
            Miss();
        }
        if(leftRb != null)
        {
            if (leftRb.transform.position.y < -6) Destroy(leftRb);
            leftRb.angularVelocity = 200;
        }
        if(rightRb != null)
        {
            if (rightRb.transform.position.y < -6) Destroy(rightRb);
            rightRb.angularVelocity = 200;
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
        if (!CompareTag("Bomb")) Split(particles);
        AudioSystem.Play(sliceSound);
    }

    void Split(GameObject particles)
    {
        // Separate children
        transform.DetachChildren();
        leftRb = leftSide.AddComponent<Rigidbody2D>();
        rightRb = rightSide.AddComponent<Rigidbody2D>();
        leftRb.velocity = rb.velocity + new Vector2(-2, 0);
        rightRb.velocity = rb.velocity + new Vector2(2, 0);

        particles.GetComponent<ParticleSystem>().startColor = juiceColor;
        particles.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = juiceColor;
    }
}
