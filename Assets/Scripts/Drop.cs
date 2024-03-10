using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    Rigidbody2D item;
    public List<GameObject> items;
    public float dropY;
    public float dropForce;
    private bool hasInstantiatedItem = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasInstantiatedItem)
        {
            SpawnItem();
            DropItem();
            hasInstantiatedItem = true;
        }
    }

    void DropItem()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = new Vector3(mousePos.x, dropY, 0);
        item.constraints = RigidbodyConstraints2D.None;
        item.gravityScale = 1f;
        item.AddForce(Vector2.down * dropForce, ForceMode2D.Impulse);
    }

    void SpawnItem()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int randomItem = Random.Range(0, 5);
        Instantiate(items[randomItem], new Vector3(mousePos.x, dropY, 0f), Quaternion.identity);
    }
}