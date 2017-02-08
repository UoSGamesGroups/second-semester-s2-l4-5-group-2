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
    public float shootForce = 20f;

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

        if (planetaryGravity.center != null) {
            targetAsteroid = planetaryGravity.center;
        }
        else {
            // Search for the nearest planet.
        }

        //Find the nearest planet first
        //Then assign the planet to the manager
        //Pass the planet to the gravity script
        //Set isInOrbit to true.

        // Debug <--
        isInOrbit = true; // == Set isInOrbit to true as hardcodin because we pass the planet in inspector.
        // -->

        orbitShoot.multiplier = shootForce;
        planetaryGravity.rotationsSpeed = orbitSpeed;
        planetaryGravity.radius = orbitRadius;
        planetaryGravity.center = targetAsteroid;
    }

	void Update () {
        if (!isInOrbit)
        {
            planetaryGravity.enabled = false;
        }
        else {
            planetaryGravity.enabled = true;
        }
    }

    //void OnTriggerEnter2D ( Collider2D collision ) {
        //if (collision.gameObject.tag == "planet") {
            //isInOrbit = true;

            //float _orbitSpeed = collision.gameObject.GetComponent<HubManager>().orbitSpeed;
            //float _orbitRange = collision.gameObject.GetComponent<HubManager>().orbitRange;

            //_targetPlanet = collision.gameObject;

            //SetValues(_orbitRange, _orbitSpeed);

            //Debug.Log("Planet Inbound: " + collision.gameObject.name + " | Radius: " + _orbitRange + " | Speed: " + _orbitSpeed);
        //}
    //}

    //void OnTriggerExit2D ( Collider2D collision ) {
        //isInOrbit = false;
    //}

    //void SetValues (float _orbitRange, float _orbitSpeed) {
        //orbitRadius = _orbitRange;
        //orbitSpeed = _orbitSpeed;

        //planetaryGravity.radius = _orbitRange;
        //planetaryGravity.rotationsSpeed = _orbitSpeed;
    //}

    void OnBecameInvsible() {
        Destroy(gameObject);
    }
}
