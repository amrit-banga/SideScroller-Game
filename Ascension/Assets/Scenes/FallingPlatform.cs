using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 defaultPos;

    [SerializeField] float fallDelay, respawnTime;

    void Start()
    {
        defaultPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("PlatformDrop");
        }
    }

    IEnumerator PlatformDrop()
    {
        yield return new WaitForSeconds(fallDelay);
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(respawnTime);
        Reset();
    }

    private void Reset()
    {
        rb2d.bodyType = RigidbodyType2D.Static;
        transform.position = defaultPos;
    }
}