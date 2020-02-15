using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumamaeshombre : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
    }
    
    void FixedUpdate()
    {
        moveCharacter(movement);
    }
    
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
