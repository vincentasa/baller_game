using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject replacementPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == gameObject.name)
        {
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(replacementPrefab, position, rotation);
        }
    }
}