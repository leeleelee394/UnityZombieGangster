using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgent : MonoBehaviour
{

    public AudioClip[] ouch;
    public AudioClip[] dead;


    private AudioSource _audioSource;

    public float maxHp = 30.0f;

    public float currhp;
    public SphereCollider fist;

    public BoxCollider boxcollider;
    public Transform trans;

    Transform tr;
    Animator anim;
    Rigidbody rg;
    bool walking;
    bool backing;

    int timer = 0;

    bool attack = false;
    bool attack2 = false;

    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;
    private float s = 0.0f;

    public bool isGameover = false;


    public GameObject Fist;
    public Transform FistPos;

    public Quaternion rot;
    public float movespeed = 10.0f;
    public float rotspeed = 100.0f;

    private GameObject canvases;

    int name1;
    int name2;

    // Use this for initialization
    void Start()
    {

        currhp = maxHp;
        _audioSource = GetComponent<AudioSource>();
        tr = GetComponent<Transform>();
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        name1 = Animator.StringToHash("Attack1");
        name2 = Animator.StringToHash("Attack2");
        canvases = GameObject.Find("Canvases");
    }

    private void Update()
    {
        fist.enabled = false;
        int nameHash = anim.GetCurrentAnimatorStateInfo(0).nameHash;
        if (attack2)
        {
            if (nameHash != name1 && nameHash != name2)
            {
                anim.Play("Attack2");
            }
        }
        if(nameHash == name1 || nameHash == name2)
        {
            fist.enabled = true;
            //anim.SetTrigger("Attack");
            Instantiate(Fist, FistPos.position, FistPos.rotation);
        }

        if(attack || attack2)
        {
            fist.enabled = true;
            //anim.SetTrigger("Attack");
            Instantiate(Fist, FistPos.position, FistPos.rotation);
        }

        if (attack)
        {
            if (nameHash != name1 && nameHash != name2)
            {
                
                anim.Play("Attack1");
                
            }
        }
        if(nameHash != name1 && nameHash != name2)
        {
            attack = false;
            attack2 = false;
        }
        if (isGameover)
            canvases.SendMessage("PlayerDie");
    }

    void FixedUpdate()
    {
        //h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");
        //r = Input.GetAxis("Mouse X");





        //Vector3 movement = transform.forward * v * movespeed * Time.deltaTime;



        //if (v > 0)
        //{
        //    rg.MovePosition(rg.position + movement);
        //}
        //else
        //{
        //    rg.MovePosition(rg.position + (9 * movement) / 10);
        //}


        //float turn = h * rotspeed * Time.deltaTime;
        //rot = Quaternion.Euler(0f, turn, 0f);
        //rg.MoveRotation(rg.rotation * rot);

        Animating();

    }

    void Animating()
    {
        walking = v > 0f;// || h != 0f;
        backing = v < 0f;
        anim.SetBool("IsWalk", walking);
        anim.SetBool("IsBack", backing);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PALM" && this.currhp > 0.0f)
        {
            //Destroy(other.gameObject);
            this.currhp -= 3.4f;
            _audioSource.PlayOneShot(ouch[0], 1.0f);

            if (this.currhp <= 0.0)
            {
                _audioSource.PlayOneShot(dead[0], 1.0f);
                anim.SetTrigger("DIE");
                this.isGameover = true;
                this.GetComponent<CapsuleCollider>().enabled = false;
                this.GetComponent<SphereCollider>().enabled = false;
            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2") && this.currhp > 0.0f)
        {
            
            this.currhp -= 3.4f;
            _audioSource.PlayOneShot(ouch[0], 1.0f);

            if (this.currhp <= 0.0)
            {
                _audioSource.PlayOneShot(dead[0], 1.0f);
                anim.SetTrigger("DIE");
                this.isGameover = true;
                canvases.SendMessage("PlayerDie");
            }
        }
    }

    public void SetV()
    {
        v = 1;
    }

    public void VZero()
    {
        v = 0;
    }

    public void Attack1()
    {
        if(!attack && !attack2)
        {
            attack = true;
            attack2 = false;
        }
    }

    public void Attack2()
    {
        if (!attack && !attack2)
        {
            attack = false;
            attack2 = true;
        }
    }
}
