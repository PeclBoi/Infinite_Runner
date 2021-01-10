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
    [SerializeField] private AudioClip shootSound;
    private Vector3 mousePosition;
    private GameObject bulletSpawn;

    private void Start()
    {
        //Cursor.visible = false;
        bulletSpawn = GameObject.Find("Gun");
    }


    private void FixedUpdate()
    {
        //in fixed update for smoother pointer movement 
        pointer.transform.position = (Vector2)mousePosition;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector3 CalculateAimDirection()
    {
        Vector3 difference = mousePosition - bulletSpawn.transform.position;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        return direction.normalized;
    }

    private float CalculateAngleZForAimDirection(Vector3 aimDirection)
    {
        return Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    }

    private void FireProjectile()
    {
        GameObject.Find("Sound").GetComponent<AudioSource>().PlayOneShot(shootSound);

        GameObject projectile = Instantiate(projectilePrefap) as GameObject;
        Vector2 direction = CalculateAimDirection();
        projectile.transform.position = bulletSpawn.transform.position;
        projectile.transform.eulerAngles = new Vector3(0, 0, CalculateAngleZForAimDirection(direction));
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        Destroy(projectile, 5);
    }
}
