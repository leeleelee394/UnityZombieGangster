using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MANAGER : MonoBehaviour {

    public List<GameObject> EnemyKind;
    public List<GameObject> LadyObject;


    public bool isGameOver = false;
    public Vector3 EnemyValues;

    public Vector3 LadyValues;

    public int _Kiils;
    public int _Saves;


    public Transform a1;
    public Transform a2;
    public Transform a3;
    public Transform a4;
    public Transform a5;
    public Transform a6;
    public Transform a7;
    public Transform a8;

    public int EnemyCount;
    public int LadyGreenCount;

    private int sixteen;
    public float EnemyDelay;
    public float LadyDelay;

    private void Start()
    {
        StartCoroutine(enemySpawn());
        StartCoroutine(ladySpawn());
    }

    private void Update()
    {
        _Kiils = GameObject.FindGameObjectsWithTag("EnemyDead").Length;
        _Saves = GameObject.FindGameObjectsWithTag("MYHOSTAGE").Length;
    }



    IEnumerator enemySpawn()
    {

        for (int i = 0; i < EnemyCount; i++)
        {

            int idx = Random.Range(0,3);

            Vector3 EnemyPosition = new Vector3(Random.Range(-EnemyValues.x, EnemyValues.x), EnemyValues.y, Random.Range(-EnemyValues.z, EnemyValues.z));
            sixteen = Random.Range(1, 9);
            
            if (sixteen == 1) Instantiate(EnemyKind[idx], EnemyPosition, Quaternion.LookRotation(a1.position - a2.position));
            if (sixteen == 2) Instantiate(EnemyKind[idx], EnemyPosition, Quaternion.LookRotation(a2.position - a1.position));
            if (sixteen == 3) Instantiate(EnemyKind[idx], EnemyPosition, Quaternion.LookRotation(a3.position - a4.position));
            if (sixteen == 4) Instantiate(EnemyKind[idx], EnemyPosition, Quaternion.LookRotation(a4.position - a3.position));

            if (sixteen == 5) Instantiate(EnemyKind[idx], EnemyPosition, Quaternion.LookRotation(a5.position - a6.position));
            if (sixteen == 6) Instantiate(EnemyKind[idx], EnemyPosition, Quaternion.LookRotation(a6.position - a5.position));
            if (sixteen == 7) Instantiate(EnemyKind[idx], EnemyPosition, Quaternion.LookRotation(a7.position - a8.position));
            if (sixteen == 8) Instantiate(EnemyKind[idx], EnemyPosition, Quaternion.LookRotation(a8.position - a7.position));



            yield return new WaitForSeconds(EnemyDelay);
        }


    }

    IEnumerator ladySpawn()
    {

        for (int i = 0; i < LadyGreenCount; i++)
        {
            int idx = Random.Range(0, 2);
            Vector3 ladyPosition = new Vector3(Random.Range(-LadyValues.x, LadyValues.x), LadyValues.y, Random.Range(-LadyValues.z, LadyValues.z));
            sixteen = Random.Range(1, 9);

            if (sixteen == 1) Instantiate(LadyObject[idx], ladyPosition, Quaternion.LookRotation(a1.position - a2.position));
            if (sixteen == 2) Instantiate(LadyObject[idx], ladyPosition, Quaternion.LookRotation(a2.position - a1.position));
            if (sixteen == 3) Instantiate(LadyObject[idx], ladyPosition, Quaternion.LookRotation(a3.position - a4.position));
            if (sixteen == 4) Instantiate(LadyObject[idx], ladyPosition, Quaternion.LookRotation(a4.position - a3.position));

            if (sixteen == 5) Instantiate(LadyObject[idx], ladyPosition, Quaternion.LookRotation(a5.position - a6.position));
            if (sixteen == 6) Instantiate(LadyObject[idx], ladyPosition, Quaternion.LookRotation(a6.position - a5.position));
            if (sixteen == 7) Instantiate(LadyObject[idx], ladyPosition, Quaternion.LookRotation(a7.position - a8.position));
            if (sixteen == 8) Instantiate(LadyObject[idx], ladyPosition, Quaternion.LookRotation(a8.position - a7.position));



            yield return new WaitForSeconds(LadyDelay);
        }


    }
}
