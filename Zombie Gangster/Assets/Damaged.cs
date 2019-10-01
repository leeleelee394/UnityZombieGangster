using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    public GameObject blood;

    public Transform trans;

    private bool coll = false;

    private float time = 0f;

    private void Update()
    {
        if(coll)
        {
            time += Time.deltaTime;
            if(time > 2.5f)
            {
                Destroy(blood);
                time = 0f;
                coll = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Enemy2")
        {
            Vector3 vec = transform.position;

            Vector3 vector = new Vector3(Random.Range(vec.x - 1.0f, vec.x + 2.0f), Random.Range(vec.y - 2.0f, vec.y + 1.0f), Random.Range(vec.z - 1.0f, vec.z + 1.0f)); 
            Instantiate(blood, vector, trans.rotation);
            coll = true;
            //Destroy(blood, 2.5f);
        }
    }
    
}
