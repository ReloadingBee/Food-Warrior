using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        Application.targetFrameRate = 60;
        if(!Application.isEditor) Cursor.visible = false;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        rb.MovePosition(worldPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var fruit = other.gameObject.GetComponent<Fruit>();
        fruit.Slice();
    }
}
