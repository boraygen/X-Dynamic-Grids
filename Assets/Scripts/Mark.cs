using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    // [SerializeField] GameObject mark;
    BoxCollider2D boxCollider;
    MarkManager markManager;
    public List<GameObject> adjacents = new List<GameObject>();

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        markManager = MarkManager.Instance;
    }

    void Update()
    {
        DestroyMark();
    }

    void DestroyMark()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == boxCollider) 
            {
                Destroy(gameObject);
                markManager.SetMarks();
            }
        }
    }

    public void AddAdjacent(GameObject newAdj)
    {
        bool isUnique = true;
        foreach (GameObject adjacent in adjacents)
        {
            if (GameObject.ReferenceEquals(adjacent, newAdj))
            {
                isUnique = false;
            }
        }

        if (isUnique)
        {
            adjacents.Add(newAdj);
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        if (adjacents.Count >= 2)
        {
            for(int i = adjacents.Count - 1; i >= 0; i--)
            {
                StartCoroutine(CollapseAndDestroy(adjacents[i]));
            }

            StartCoroutine(CollapseAndDestroy(gameObject));
            markManager.SetMarks();
        }
    }

    IEnumerator CollapseAndDestroy(GameObject obj)
    {
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            obj.transform.localScale = new Vector3(i, i, 1);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(obj);

    }
}
