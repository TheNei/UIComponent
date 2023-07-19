using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public  float sliceForce = 25f;
    private BoxCollider coll;
    public bool isSlicing;
    public Camera mainCamera;
    public TrailRenderer trailBlade;
    public Vector3 Direction
    {
        get;
        private set;
    }
    public float minSliceVelocity = 0.01f;
    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        coll = GetComponent<BoxCollider>();
        trailBlade = GetComponentInChildren<TrailRenderer>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartSlice();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopSlice();
        }
        else if(isSlicing)
        {
            ContiuneSlice();
        }
    }
    private void OnDisable()
    {
        StopSlice();
    }
    private void OnEnable()
    {
        StopSlice();
    }
    void StartSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;
        isSlicing = true;
        coll.enabled = true;
        trailBlade.enabled = true;
        trailBlade.Clear();
        trailBlade.endColor = Color.red;
    }
    void StopSlice()
    {
        isSlicing = false;
        coll.enabled = false;
    }
    void ContiuneSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        Direction = newPosition - transform.position;
        float velocity = Direction.magnitude / Time.deltaTime;
        coll.enabled = velocity > minSliceVelocity;
        transform.position = newPosition;
    }
}
