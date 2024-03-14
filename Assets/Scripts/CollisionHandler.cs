using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject replacementPrefab; // Assign the prefab in the Unity Inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == gameObject.name)
        {
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;

            if (gameObject.name.CompareTo(collision.gameObject.name) < 0)
            {
                Destroy(collision.gameObject);
                if (replacementPrefab != null)
                {
                    Vector3 spawnPosition = new Vector3(position.x, position.y + 1, position.z); // Offset the prefab slightly above the current position
                    Instantiate(replacementPrefab, spawnPosition, rotation);
                }
            }
            else
            {
                Destroy(gameObject);
                Instantiate(replacementPrefab, position, rotation);
            }
        }
    }
}