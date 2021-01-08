using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFlying : MonoBehaviour
{
    [SerializeField] float speed = 10;
    // Update is called once per frame


    private void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.deltaTime);
    }
}
