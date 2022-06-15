using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject mark;
    BoxCollider2D boxCollider;
    MarkManager markManager;
    GridManager gridManager;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        markManager = MarkManager.Instance;
        gridManager = FindObjectOfType<GridManager>();

    }

    void Update()
    {
        CreateMark();
    }

    void CreateMark()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == boxCollider) 
            {
                // Debug.Log(hit.collider.gameObject.name);
                GameObject newMark = (GameObject)Instantiate(mark, transform.position, transform.rotation);
                newMark.name = $"{transform.position.x / gridManager.tileSize}, {transform.position.y / gridManager.tileSize}";
                markManager.SetMarks();
            }
        }
    }
}
