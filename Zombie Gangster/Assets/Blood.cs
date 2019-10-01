using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{


    private const string fistTag = "FIST";

    private GameObject bloodEffect;

    // Use this for initialization
    void Start()
    {
        bloodEffect = Resources.Load<GameObject>("Blood");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FIST")
        {
            ShowBloodEffect(other);

        }
    }

    void ShowBloodEffect(Collider other)
    {
        

        Vector3 point = other.transform.position;

        Vector3 pos = new Vector3(Random.Range(point.x - 1, point.x + 2), Random.Range(point.y - 1, point.y + 2), Random.Range(point.z, point.z + 1));

        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, other.transform.rotation);
        Destroy(blood, 1.0f);
    }

}
