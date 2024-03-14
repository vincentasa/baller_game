using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public int points = 1;
    public GameObject nextFruit;
    private AudioSource source;

    void OnCollisionEnter2D(Collision2D other)
    {

        if (!other.gameObject.CompareTag("Fruit")) return;
        if (transform.position.y < other.transform.position.y) return;
        //if (points != other.gameObject.GetComponent<CollisionHandler>().points) return;

        Destroy(gameObject);
        Destroy(other.gameObject);

        Instantiate(nextFruit, transform.position, Quaternion.identity);
        source.Play();
    }

}