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
    public GameObject impactFX;
    public float asteroidHealth = 1;
    public float orbitRadius = 2.5f;
    public float orbitSpeed = 45f;
    public float shootForce = 55f;

    [Header("Gravity Settings")]
    public bool isInOrbit = false;
    public Transform targetAsteroid;
    public GameObject _targetPlanet;

    [Header("Turn Settings")]
    public string Owner;

    public enum AsteroidOwner {
        Player1,
        Player2
    }

    public AsteroidOwner asteroidOwner = AsteroidOwner.Player1;

    private float destroyDelay = 2;
    private GameObject impactObject;

    [HideInInspector]
    public OrbitShoot orbitShoot;
    [HideInInspector]
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

        switch (asteroidOwner) {
            case AsteroidOwner.Player1:
                Owner = "Player1";
                gameObject.layer = 10;
                break;

            case AsteroidOwner.Player2:
                Owner = "PLayer2";
                gameObject.layer = 11;
                break;
        }
    }

    void Start() {
        UpdatePlanetaryGravity();
        UpdateOrbitShoot();
    } 

	void Update () {
        switch (asteroidOwner) {
            case AsteroidOwner.Player1:
                Owner = "Player1";
                break;

            case AsteroidOwner.Player2:
                Owner = "Player2";
                break;
        }

        if (asteroidHealth <= 0)
            Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "planet") {
            Debug.Log(gameObject.name + " Says: " + "I'm in range of a planet: " + col.gameObject.name);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        StartCoroutine(DestroyEffect(destroyDelay));
        impactObject = coll.gameObject;
        Instantiate(impactFX, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void UpdatePlanetaryGravity() {
        planetaryGravity.targetAsteroid = targetAsteroid;
        planetaryGravity.orbitRadius = orbitRadius;
        planetaryGravity.orbitSpeed = orbitSpeed;
    }

    public void UpdateOrbitShoot() {
        if (orbitShoot != null) {
            orbitShoot.shootForceMultiplier = shootForce;
        }
    }

    // IENUMRATORS
    IEnumerator DestroyEffect(float _destoryDelay) {
        yield return new WaitForSeconds(_destoryDelay);

        if (impactObject != null)
            Destroy(impactObject);

        asteroidHealth -= .5f;
    }
}
