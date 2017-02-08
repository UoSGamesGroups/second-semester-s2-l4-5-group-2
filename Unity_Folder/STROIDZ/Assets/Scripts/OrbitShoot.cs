using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbitShoot : MonoBehaviour
{
    public float multiplier;
    private Vector3 initPos;

    public AsteroidManager asteroidManager;

    void Start() {
        asteroidManager = gameObject.GetComponent<AsteroidManager>();
    }

    //get the initial positon of the holder before the drag starts
    void OnMouseDown()
    {
        initPos = transform.position;
    }

    //move the holder according to the drag
    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    //the current position of the holder and its initial position 
    void OnMouseUp()
    {
        asteroidManager.isInOrbit = false;
        GetComponent<Rigidbody2D>().AddForce((initPos - transform.position) * Vector3.Distance(transform.position, initPos) * multiplier);
    }
}