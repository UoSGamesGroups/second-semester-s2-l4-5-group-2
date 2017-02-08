using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public Transform bird;
	public Transform boundryRight;
	public Transform boundryLeft;

	void Update () {
		Vector3 newPos = transform.position;
		newPos.x = bird.position.x;
		newPos.x = Mathf.Clamp (newPos.x, boundryLeft.position.x, boundryRight.position.x);
		transform.position = newPos;
	}
}
