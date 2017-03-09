using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Image[] Arrows;
    public float imageTimer = 1f;

    public static GameManager gameManager = null;

    public enum GameState {
        Menu,
        Player1Turn,
        Player2Turn,
        Intermission,
        EndRound
    }

    [Header("Turn Switch Things")]
    public GameState gameState = GameState.Player1Turn;
    public string TurnState = "Player1";
    public float IntermissionLength = 2f;
    public Text gameStateTxt;

    [Header("Camera Settings")]
    public Camera gameCamera;
    public Vector3 player1Pos = Vector3.zero;
    public Vector3 player2Pos = Vector3.zero;
    public Vector3 InterPos = Vector3.zero;
    public float defCamSize = 15f;
    public float interCamSize = 25f;
    public float shootCamSize = 10f;
    public bool moveToAsteroid = false;
    public bool moveToGameSpace = false;
    public bool moveToP1 = false;
    public bool moveToP2 = false;
    public bool moveToInter = false;

    private float time = 0;

    void Awake() {
        if (gameManager == null)
            gameManager = this;
        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

	void Start () {
        gameStateTxt.text = TurnState + " turn!";
	}
	
	void Update () {
        if (moveToInter) {
            // Zoom camera in towards the asteroid.
            float currentSize = Camera.main.orthographicSize;
            float endSize = interCamSize;

            time += Time.deltaTime;
            gameCamera.orthographicSize = Mathf.SmoothStep(currentSize, endSize, time);

            // Move camera towards the asteroid.
            Vector3 startPos = Camera.main.transform.position;
            Vector3 endPos = gameManager.InterPos;
            gameCamera.transform.position = Vector3.Lerp(startPos, new Vector3(endPos.x, endPos.y, -10), time);

            if (gameCamera.transform.position == endPos) {
                moveToInter = false;
                time = 0;
            }
        }

        if (moveToP1) {
            // Zoom camera in towards the asteroid.
            float currentSize = Camera.main.orthographicSize;
            float endSize = defCamSize;

            time += Time.deltaTime;
            gameCamera.orthographicSize = Mathf.SmoothStep(currentSize, endSize, time);

            // Move camera towards the asteroid.
            Vector3 startPos = Camera.main.transform.position;
            Vector3 endPos = gameManager.player1Pos;
            gameCamera.transform.position = Vector3.Lerp(startPos, new Vector3(endPos.x, endPos.y, -10), time);

            if (gameCamera.transform.position == endPos) {
                moveToP1 = false;
                time = 0;
            }
        }

        if (moveToP2) {
            // Zoom camera in towards the asteroid.
            float currentSize = Camera.main.orthographicSize;
            float endSize = defCamSize;

            time += Time.deltaTime;
            gameCamera.orthographicSize = Mathf.SmoothStep(currentSize, endSize, time);

            // Move camera towards the asteroid.
            Vector3 startPos = Camera.main.transform.position;
            Vector3 endPos = gameManager.player2Pos;
            gameCamera.transform.position = Vector3.Lerp(startPos, new Vector3(endPos.x, endPos.y, -10), time);

            if (gameCamera.transform.position == endPos) {
                moveToP2 = false;
                time = 0;
            }
        }

        foreach (Image i in Arrows) {
            imageTimer -= .1f * Time.deltaTime;

            i.fillAmount = imageTimer;
        }
    }

    public void ChangeTurn ( ) {
        /* CHANGING TURN:
         * Changing turn system will allow the game to change,
         * from P1 to P2. There is a small intermission,
         * before next player's move. This can be made to create
         * a strategy or take a breather.
         */
        StartCoroutine(Intermission());
    }

    void MoveCamToInter ( ) {
        Vector3 currentPos = gameCamera.transform.position;
        Vector3 endPos = InterPos;

    }

    void MoveCamToPlayerSpace ( ) {
        
    }

    IEnumerator Intermission ( ) {
        if (TurnState == "Player1") {
            TurnState = "Intermission";
            moveToInter = true;
            gameState = GameState.Intermission;
            gameStateTxt.text = TurnState;
            yield return new WaitForSeconds(IntermissionLength);
            moveToP2 = true;
            gameState = GameState.Player2Turn;
            TurnState = "Player2";
            gameStateTxt.text = TurnState + " turn!";
        }
        else if (TurnState == "Player2") {
            TurnState = "Intermission";
            moveToInter = true;
            gameState = GameState.Intermission;
            gameStateTxt.text = TurnState;
            yield return new WaitForSeconds(IntermissionLength);
            moveToP1 = true;
            gameState = GameState.Player1Turn;
            TurnState = "Player1";
            gameStateTxt.text = TurnState + " turn!";
        }
    }
}
