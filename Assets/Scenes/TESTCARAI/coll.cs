using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll : MonoBehaviour
{

    private void Update()
    {
        //nothing

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

    }
}
