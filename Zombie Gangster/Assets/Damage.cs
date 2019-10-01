using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            other.GetComponent<EnemyAi>().currhp -= 11;
        }
    }
}
