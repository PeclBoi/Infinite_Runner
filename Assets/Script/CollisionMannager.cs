using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CollisionMannager : MonoBehaviour 
{

    [SerializeField] private LayerMask layerMask;

    public bool isOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, layerMask);
        return hit.collider != null;
    }
}
