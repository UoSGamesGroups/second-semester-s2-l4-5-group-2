using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbitShoot : MonoBehaviour {
    public float shootForceMultiplier;
    private Vector3 orbitPos;
    private Vector3 clickPos;
    private Vector3 initialPos;

    private Vector3 fingPos;
    private Vector3 radPos;

    public GameObject RadVis;
    public GameObject RadVisInstance;

    public AsteroidManager asteroidManager;

    private float startSize;
    private float endSize;
    private float defSize;

    private float time = 0;

    public bool moveToAsteroid = false;
    public bool moveToGameSpace = false;

    void Start ( ) {
        asteroidManager = gameObject.GetComponent<AsteroidManager>();
    }

    void FixedUpdate ( ) {
        #region Player1ShootingCamera
        if (GameManager.gameManager.TurnState == "Player1") {
            if (moveToAsteroid && !moveToGameSpace) {
                // Zoom camera in towards the asteroid.
                startSize = Camera.main.orthographicSize;
                endSize = GameManager.gameManager.shootCamSize;

                time += Time.deltaTime;
                GameManager.gameManager.gameCamera.orthographicSize = Mathf.SmoothStep(startSize, endSize, time);

                // Move camera towards the asteroid.
                Vector3 startPos = Camera.main.transform.position;
                Vector3 endPos = gameObject.transform.position;
                GameManager.gameManager.gameCamera.transform.position = Vector3.Lerp(startPos, new Vector3(endPos.x, endPos.y, -10), time);
            }
        }
        #endregion

        #region Player2ShootingCamera
        if (GameManager.gameManager.TurnState == "Player2") {
            if (moveToAsteroid && !moveToGameSpace) {
                // Zoom camera in towards teh asteroid.
                startSize = Camera.main.orthographicSize;
                endSize = GameManager.gameManager.shootCamSize;

                time += Time.deltaTime;
                GameManager.gameManager.gameCamera.orthographicSize = Mathf.SmoothStep(startSize, endSize, time);

                // Move camera towards teh asteroid.
                Vector3 startPos = Camera.main.transform.position;
                Vector3 endPos = gameObject.transform.position;
                GameManager.gameManager.gameCamera.transform.position = Vector3.Lerp(startPos, new Vector3(endPos.x, endPos.y, -10), time);
            }
        }
        #endregion

        #region MoveBackToGameSpace
        if (moveToGameSpace && !moveToAsteroid) {
            // Zoom camera out back to GameSpace
            startSize = Camera.main.orthographicSize;
            endSize = GameManager.gameManager.defCamSize;

            time += Time.deltaTime;
            GameManager.gameManager.gameCamera.orthographicSize = Mathf.SmoothStep(startSize, endSize, time);

            // Move camera back to the GameSpace
            Vector3 startPos = Camera.main.transform.position;
            Vector3 endPos;

            if (GameManager.gameManager.TurnState == "Player1")
                endPos = GameManager.gameManager.player1Pos;
            else
                endPos = GameManager.gameManager.player2Pos;

            GameManager.gameManager.gameCamera.transform.position = Vector3.Lerp(startPos, new Vector3(endPos.x, endPos.y, -10), time);

            if (GameManager.gameManager.gameCamera.transform.position == endPos) {
                moveToGameSpace = false;
            }
        }
        #endregion
    }

    //get the initial positon of the holder before the drag starts
    void OnMouseDown ( )
    {
        time = 0;
        moveToAsteroid = true;
        moveToGameSpace = false;

        if (asteroidManager.Owner == GameManager.gameManager.TurnState)
        {
            orbitPos = transform.position;
        }

        Vector3 fingPos = Input.mousePosition;
        fingPos.z = 11;
        Vector3 radPos = Camera.main.ScreenToWorldPoint(fingPos);
        RadVisInstance = Instantiate(RadVis, radPos, Quaternion.identity);

    }

    //move the holder according to the drag
    void OnMouseDrag ( ) {
        if (asteroidManager.Owner == GameManager.gameManager.TurnState) {
            asteroidManager.targetAsteroid = null;
            asteroidManager.UpdatePlanetaryGravity();

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var allowedPos = clickPos - orbitPos;
            allowedPos = Vector3.ClampMagnitude(allowedPos, 3);
            transform.position = orbitPos + allowedPos;

            
        }
    }

    //the current position of the holder and its initial position 
    void OnMouseUp ( )
    {
        Destroy(RadVisInstance);

        moveToAsteroid = false;
        time = 0;
        moveToGameSpace = true;

        if (asteroidManager.Owner == GameManager.gameManager.TurnState) {
            asteroidManager.isInOrbit = false;
            GetComponent<Rigidbody2D>().AddForce(( orbitPos - transform.position ) * Vector3.Distance(transform.position, orbitPos) * shootForceMultiplier);

        }
  
    }
}