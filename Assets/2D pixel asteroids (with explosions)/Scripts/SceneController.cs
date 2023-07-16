using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject[] allExplosions;

    int index = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                AsterController aster = hit.collider.GetComponent<AsterController>();
                aster.StartExplosion();
            } else
            {
                Instantiate(allExplosions[index++], new Vector3(pos.x, pos.y, 0.0f), Quaternion.identity);
                if (index >= allExplosions.Length)
                    index = 0;
            }
        }
    }
}
