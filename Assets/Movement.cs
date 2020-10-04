using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    new Rigidbody2D rigidbody;
    [SerializeField]
    private int speed;
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        rigidbody.AddForce(new Vector2(speed, 0) * Time.smoothDeltaTime);
    }
}
