using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformGizmos : MonoBehaviour
{
    public Color gizmoColor = Color.red;
    public float size = .1f;
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, size);
    }
}
