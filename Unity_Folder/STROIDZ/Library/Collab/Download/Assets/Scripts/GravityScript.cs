using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour {

    public Transform target;
    public Rigidbody2D rb;

    private Vector3 dir = Vector3.zero;
    private Vector3 fwd;
    private Vector3 slide;
    private Vector3 cross;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        fwd = transform.forward;
        dir = target.transform.position - transform.position;
        slide = Vector3.Cross(dir, fwd);
    }

    void Update() {
        dir = target.transform.position - transform.position;
        //transform.LookAt(dir.normalized);
        rb.AddForce(dir.normalized * 25);
        cross = Vector3.Cross(dir, slide);
        rb.AddForce(cross.normalized * 10);
    }
}
