using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterExpl : MonoBehaviour
{
    public void ExplComplete()
    {
        Destroy(gameObject);
    }
}
