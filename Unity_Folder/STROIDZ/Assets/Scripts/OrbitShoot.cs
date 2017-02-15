using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbitShoot : MonoBehaviour
{
    public float shootForceMultiplier;
    private Vector3 orbitPos;
    private Vector3 clickPos;
    private Vector3 initialPos;

    public AsteroidManager asteroidManager;

    void Start()
    {
        asteroidManager = gameObject.GetComponent<AsteroidManager>();
    }

    //get the initial positon of the holder before the drag starts
    void OnMouseDown()
    {
        orbitPos = transform.position;
    }

    //move the holder according to the drag
    void OnMouseDrag()
    {
        asteroidManager.targetAsteroid = null;
        asteroidManager.UpdatePlanetaryGravity();

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var allowedPos = clickPos - orbitPos;
        allowedPos = Vector3.ClampMagnitude(allowedPos, 3);
        transform.position = orbitPos + allowedPos;
    }

    //the current position of the holder and its initial position 
    void OnMouseUp()
    {
        asteroidManager.isInOrbit = false;
        GetComponent<Rigidbody2D>().AddForce((orbitPos - transform.position) * Vector3.Distance(transform.position, orbitPos) * shootForceMultiplier);
    }
}










/*
 * Take the position of the object, minus the origin of the circle. 
 * This will give you a vector from the origin to the object. 
 * The length of this vector is the distance to the object. 
 * Multiply this vector by the circle's radius divided by the distance to the object. 
 * Set the object's position to the circle's origin plus this vector.

Vector FromCircleToObject = Object.Position - Circle.Origin;
FromCircleToObject *= Circle.Radius / FromCircleToObject.Length;
Object.Position = Circle.Origin + FromCircleToObject;

    */