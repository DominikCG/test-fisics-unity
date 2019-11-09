using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    public bool inWindZone = false;
    public bool inWindZoneL = false;
    public GameObject windZone;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    private void FixedUpdate()
    {
        if (inWindZone)
        {
            rb.AddForce(windZone.GetComponent<windArea>().direction * windZone.GetComponent<windArea>().strength);
        }
        if (inWindZoneL)
        {
            rb.AddForce(windZone.GetComponent<windArea>().direction * windZone.GetComponent<windArea>().strength);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            windZone = coll.gameObject;
            inWindZone = true;
        }

        if (coll.gameObject.tag == "windAreaL")
        {
            windZone = coll.gameObject;
            inWindZoneL = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "windArea")
        {
            inWindZone = false;
        }

        if (coll.gameObject.tag == "windAreaL")
        {
            inWindZoneL = false;
        }
    }
}
