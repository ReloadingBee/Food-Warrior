using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject explosionParticles;
    Rigidbody2D rb;

    public GameObject leftSide;
    public GameObject rightSide;
    public Color juiceColor;

    public AudioClip spawnSound;
    public AudioClip sliceSound;
    public AudioClip missSound;

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
    }

    void Miss()
    {
        Destroy(gameObject);
        if(!GameManager.isGameOver)
        {
            if (!gameObject.CompareTag("Bomb"))
            {
                AudioSystem.Play(missSound);
                GameManager.lives--;
            }
        }
    }

    public void Slice()
    {
        var particles = Instantiate(explosionParticles);
        particles.transform.position = transform.position;

        Destroy(gameObject);
        if (!CompareTag("Bomb")) Split(particles);
        else
        {
            GameManager.lives = 0;
        }
        AudioSystem.Play(sliceSound);
    }

    void Split(GameObject particles)
    {
        // Separate children
        transform.DetachChildren();
        var leftRb = leftSide.AddComponent<Rigidbody2D>();
        var rightRb = rightSide.AddComponent<Rigidbody2D>();
        leftRb.velocity = rb.velocity + new Vector2(-2, 0);
        rightRb.velocity = rb.velocity + new Vector2(2, 0);
        leftRb.angularVelocity = -200;
        rightRb.angularVelocity = 200;

        particles.GetComponent<ParticleSystem>().startColor = juiceColor;
        particles.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = juiceColor;
    }
}
