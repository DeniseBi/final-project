using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour {
    public bool spawningDiraction;
    Vector3 boxCollider;
    public bool IsBig = false;

    public void GetBigger()
    {if (IsBig)
            return;
        if (spawningDiraction)
        {
            boxCollider = transform.localScale;
            boxCollider.x = boxCollider.x * 3;
            transform.localScale = boxCollider;
        } 
    else
        {
            boxCollider = transform.localScale;
            boxCollider.z = boxCollider.z * 3;
            transform.localScale = boxCollider;
        }
        IsBig = !IsBig;

    }
    public void GetSmaller()
    {
        if (!IsBig)
            return;
        if (spawningDiraction)
        {
            boxCollider = transform.localScale;
            boxCollider.x = boxCollider.x * 3;
            transform.localScale = boxCollider;
        }
        else
        {
            boxCollider = transform.localScale;
            boxCollider.z = boxCollider.z * 3;
            transform.localScale = boxCollider;
        }
        IsBig = !IsBig;
    }

}
