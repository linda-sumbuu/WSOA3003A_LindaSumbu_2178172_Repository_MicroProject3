using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushScript : MonoBehaviour
{
    public float distance = 7f;

    public LayerMask boxMask;

    public GameObject box;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
       RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if(hit.collider != null && Input.GetKey(KeyCode.E))
        {
            box = hit.collider.gameObject;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, (Vector2) transform.position + Vector2.right * transform.localScale.x*  distance);
    }
}
