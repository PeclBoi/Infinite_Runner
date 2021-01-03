using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject projectilePrefap;
    [SerializeField] private float projectileSpeed = 50f;
    private Vector3 mousePosition;

    private void Start()
    {
        //Cursor.visible = false;
    }


    private void FixedUpdate()
    {
        //in fixed update for smoother pointer movement 
        pointer.transform.position = (Vector2)mousePosition;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDirection = CalculateAimDirection();
        CalculateAndSetAngleZForAimDirection(aimDirection);
        
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile(aimDirection);  
        }
    }


    private Vector3 CalculateAimDirection()
    {
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        return aimDirection; 
    }

     private void CalculateAndSetAngleZForAimDirection(Vector3 aimDirection)
     {
         float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
         transform.eulerAngles = new Vector3(0, 0, angle);
     }

    private void FireProjectile(Vector3 direction)
    {
        GameObject projectile = Instantiate(projectilePrefap) as GameObject;
        projectile.transform.position = transform.position;
        projectile.transform.eulerAngles = transform.eulerAngles;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        Destroy(projectile, 5);
    }
}
