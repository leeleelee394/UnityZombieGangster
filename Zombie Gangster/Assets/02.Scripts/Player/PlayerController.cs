using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 3f;
    private bool attack = false;
    int eating = 0;
    float maxAttackTime = 1f;
    float attackTime = 0f;
    bool die = false;

    Vector3 rotation = Vector3.zero;
    Animator animator;
    GameObject currentKillNumber;
    GameObject canvases;

	// Use this for initialization
	void Start () {
        rotation = transform.eulerAngles;
        animator = GetComponent<Animator>();
        eating = Animator.StringToHash("Base Layer.Zombie_Eating");
        currentKillNumber = GameObject.Find("CurrentKillNumber");
        canvases = GameObject.Find("Canvases");
    }
	
	// Update is called once per frame
	void Update () {
        if(die)
        {
            animator.Play("Zombie_Idle");
            canvases.SendMessage("PlayerDie");
        }
        else
        {
            attackTime += Time.deltaTime;

            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Zombie_Eating"))
            {
                attack = false;
                attackTime = 0f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                die = true;
                ManagerClass.Instance.SaveKillDataToJson();
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                ManagerClass.Instance.killNum += 10;
            }
            if (!attack && maxAttackTime < attackTime)
                attack = true;
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Zombie_Eating"))
            {
                Destroy(coll.gameObject);
                currentKillNumber.SendMessage("KillUp");
            }
            else
            {
                die = true;
            }
        }
    }

    public void Attack()
    {
        if(attack)
        {
            animator.Play("Zombie_Eating");
        }
    }
}
