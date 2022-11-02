using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTAI : MonoBehaviour
{
    [SerializeField] private Transform pointA;

    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointAB;

    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointBC;

    [SerializeField] private Transform pointD;
    [SerializeField] private Transform pointCD;

    [SerializeField] private Transform pointE;
    [SerializeField] private Transform pointDE;

    [SerializeField] private Transform pointF;
    [SerializeField] private Transform pointEF;

    private float interpolateAmount;


    private void Update()
    {
        interpolateAmount = (interpolateAmount + Time.deltaTime) % 1f;
        //pointAB.position = Vector3.Lerp(pointA.position, pointB.position, interpolateAmount);

        pointAB.GetComponent<Rigidbody>().velocity = transform.forward * Time.deltaTime * 300; 

    }
}
