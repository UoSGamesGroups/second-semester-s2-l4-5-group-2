using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityV2 : MonoBehaviour {

    public Transform center;
    public Vector3 axis = Vector3.up;
    public float radius;
    public float radiusSpeed = .5f;
    public float rotationsSpeed = 80f; 

	void Start () {
        transform.position = (transform.position - center.position).normalized * radius + center.position;

        radius = Random.Range(3, 8);
	}
	
	void Update () {
        transform.RotateAround(center.position, axis, rotationsSpeed * Time.deltaTime);
        Vector3 desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
	}
}
