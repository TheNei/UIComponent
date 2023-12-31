using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public Transform whole;
    public Transform sliced;
    
    public Rigidbody fruitRigidbody;
    public BoxCollider fruitCoiilder;
    bool isAwake = false;
    public ParticleSystem juice;
    private void Awake()
    {
        juice = GetComponentInChildren<ParticleSystem>();
        whole = transform.Find("Fruit_Whole");
        sliced = transform.Find("Fruit_Sliced");
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCoiilder = GetComponent<BoxCollider>();
        whole.gameObject.SetActive(true);
        sliced.gameObject.SetActive(false);
        whole.gameObject.GetComponent<Collider>().isTrigger = true;
    }

    void Slice(Vector3 direction,Vector3 position,float force)
    {
        UiManager.Instance.score++;
        whole.gameObject.SetActive(false);
        sliced.gameObject.SetActive(true);
        fruitCoiilder.enabled = false;
        juice.Play();
       
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach(var slice in slices)
        {
            slice.velocity = fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.Direction, blade.transform.position,blade.sliceForce); 
           
        }
    }
}
