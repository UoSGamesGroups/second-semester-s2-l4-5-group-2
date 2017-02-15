using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryGravity : MonoBehaviour {

    public Transform targetAsteroid;
    public float orbitRadius;
    public float orbitSpeed;
    public float radiusSpeed;

    private Vector3 orbitAxis = new Vector3(0, 0, 1);

    AsteroidManager asteroidManager;

    void Awake() {
        asteroidManager = GetComponent<AsteroidManager>();

        targetAsteroid = asteroidManager.targetAsteroid;
        orbitRadius = asteroidManager.orbitRadius;
        orbitSpeed = asteroidManager.orbitSpeed;
    }

	void Start () {
        transform.position = (transform.position - targetAsteroid.position).normalized * orbitRadius + targetAsteroid.position;
	}
	
	void Update () {
        if (asteroidManager.targetAsteroid != null)
        {
            transform.RotateAround(targetAsteroid.position, orbitAxis, orbitSpeed * Time.deltaTime);
            Vector3 desiredPosition = (transform.position - targetAsteroid.position).normalized * orbitRadius + targetAsteroid.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
        else {
            Debug.Log("No targetAsteroid in: " + gameObject.name);
        }
	}
}
