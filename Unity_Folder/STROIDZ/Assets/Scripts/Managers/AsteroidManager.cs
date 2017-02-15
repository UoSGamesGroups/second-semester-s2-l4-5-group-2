using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

    /// <summary>
    /// Notes for the Manager.
    /// Make it so that when the planet is not in orbit anymore,
    /// make sure it still has some force so that it does not suddenly stop.
    /// </summary>

    [Header("Asteroid Variables")]
    public float orbitRadius = 2.5f;
    public float orbitSpeed = 45f;
    public float shootForce = 55f;

    [Header("Gravity Settings")]
    public bool isInOrbit = false;
    public Transform targetAsteroid;
    public GameObject _targetPlanet;

    //[HideInInspector]
    public OrbitShoot orbitShoot;
    //[HideInInspector]
    public PlanetaryGravity planetaryGravity;

    void Awake() {
        orbitShoot = gameObject.GetComponent<OrbitShoot>();
        planetaryGravity = gameObject.GetComponent<PlanetaryGravity>();

        //Find the nearest planet first
        //Then assign the planet to the manager
        //Pass the planet to the gravity script
        //Set isInOrbit to true.

        // Debug <--
        isInOrbit = true; // == Set isInOrbit to true as hardcodin because we pass the planet in inspector.
        // -->
    }

    void Start() {
        UpdatePlanetaryGravity();
        UpdateOrbitShoot();
    } 

	void Update () {
        //if (!isInOrbit)
        //{
        //    planetaryGravity.enabled = false;
        //}
        //else {
        //      planetaryGravity.enabled = true;
        //}
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "planet") {
            Debug.Log(gameObject.name + " Says: " + "I'm in range of a planet: " + col.gameObject.name);
        }
    }

    public void UpdatePlanetaryGravity() {
        planetaryGravity.targetAsteroid = targetAsteroid;
        planetaryGravity.orbitRadius = orbitRadius;
        planetaryGravity.orbitSpeed = orbitSpeed;
    }

    public void UpdateOrbitShoot() {
        if (orbitShoot != null)
        {
            orbitShoot.shootForceMultiplier = shootForce;
        }
    }

    void OnBecameInvsible() {
        Destroy(gameObject);
    }
}
