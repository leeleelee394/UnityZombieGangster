using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{

    public enum State
    {
        PATROL,
        ROTATE,
        P_RUN
    }

    public SphereCollider spherecollider;
    public AudioClip[] sfx;
    private AudioSource _audio;
    int count = 0;
    public float smoothing = 1f;
    public ParticleSystem[] effects;
    public Transform effectPos;
    

    
    GameObject pObject;
    private const string theTag1 = "Player";
    public Transform Left;
    public Transform Right;

    public bool conRed;
    public bool conWall;
    public bool isCatched = false;

    public int timer1 = 0;
    public int timer2 = 0;

    public Transform Redsenser;
    public Transform FrontSenser;

    private int theLayer1;
    private int theLayer2;
    private int theLayer3;
    public State state = State.PATROL;

    private Transform citizenTr;
    private Rigidbody rg;
    private Animator anim;
    private GameObject Aiobject;

    Quaternion rot;
    public float speed = 5.0f;
    public float turn = 5.0f;
    bool isIdle;

    // Use this for initialization
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        //meshRenderer = GetComponent<SkinnedMeshRenderer>();
        Aiobject = GetComponent<GameObject>();
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        effects = effectPos.GetComponentsInChildren<ParticleSystem>();
        theLayer1 = LayerMask.NameToLayer("WALL");
        theLayer2 = LayerMask.NameToLayer("BUILDING");
        theLayer3 = LayerMask.NameToLayer("Enemy");
        pObject = GameObject.FindGameObjectWithTag("Player");

        //meshRenderer = this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            count = 1;
            //_audio.PlayOneShot(sfx[0], 1.0f);
            anim.SetTrigger("Catched");
            conWall = true;
            this.tag = "MYHOSTAGE";

        }
        if (collision.collider.tag == "HOSTAGE")
        {
            

            
            conWall = true;

        }
    }
    
        





    
    private void Update()
    {

        

        //anim.SetBool("isIdle", isIdle);

        Debug.DrawRay(FrontSenser.position, FrontSenser.forward * 4.3f, Color.blue);

        Debug.DrawRay(Redsenser.position, Redsenser.transform.forward * 4.3f, Color.red);

        RaycastHit hit;
        //
        if (Physics.Raycast(FrontSenser.position, FrontSenser.forward, out hit, 2.6f, 1 << theLayer1))
        {
            if (this.state != State.P_RUN)
            {
                conWall = true;
            }
        }

        if (Physics.Raycast(FrontSenser.position, FrontSenser.forward, out hit, 2.6f, 1 << theLayer3))
        {
            if (this.state != State.P_RUN)
            {
                conWall = true;
                _audio.PlayOneShot(sfx[1], 1.0f);
            }
        }

        if (!conRed && Physics.Raycast(this.Redsenser.position, this.Redsenser.forward, out hit, 2.6f, 1 << theLayer2))
        {
            if (this.state != State.P_RUN)
            {
                conRed = true;
                
            }


        }

        
        





        

    }

    void FixedUpdate()
    {
        float dist = Vector3.Distance(pObject.transform.position, this.gameObject.transform.position);


        

        if (conRed)
        {

            timer1++;
            if(timer1 == 1)
            {
                turn = Random.Range(9, 15);
                rot = Quaternion.LookRotation(Right.position - this.transform.position);
                
            }
            this.rg.rotation = Quaternion.Slerp(this.rg.rotation, rot, Time.deltaTime * turn);

        }

        


        if (conWall)
        {

            timer1++;
            if (timer1 == 1)
            {
                turn = Random.Range(5, 12);
                rot = Quaternion.LookRotation(Left.position - this.transform.position);

            }
            this.rg.rotation = Quaternion.Slerp(this.rg.rotation, rot, Time.deltaTime * turn);

        }

        if(conWall || conRed)
        {
            if(timer1 > 30)
            {
                conRed = conWall = false;
                timer1 = 0;
            }
        }


        switch (state)
        {
            case State.PATROL:

                break;
            case State.P_RUN:
                Vector3 targetPos = pObject.transform.position;
                //
                ////this.transform.rotation = playerObject.GetComponent<Rigidbody>().rotation;
                timer2++;
                //
                if (timer2 < 30)
                {
                    this.rg.transform.LookAt(pObject.transform, this.transform.up);
                    smoothing = 2;

                }
                else
                {
                    this.rg.rotation = pObject.GetComponent<Rigidbody>().rotation;
                    smoothing = 2;
                }

                if(dist < 1.3)
                {
                    smoothing = 0.5f;
                }

                //if (dist > 4) smoothing = 5;


                this.rg.position = Vector3.Lerp(this.rg.position, targetPos, smoothing * Time.deltaTime);

                if (timer2 > 30)
                {
                    timer2 = 31;
                }

                //else
                //{
                //    if (dist < 2) smoothing = 0.3f;
                //    this.rg.rotation = playerObject.GetComponent<Rigidbody>().rotation;
                //}
                //
                //
                //if (dist > 4)
                //{
                //    smoothing = 3.5f;
                //}
                //if (dist < 1) smoothing = 0.1f;
                //
                //this.rg.rotation = playerObject.GetComponent<Rigidbody>().rotation;
                //this.rg.position = Vector3.Lerp(this.rg.position, targetPos, smoothing * Time.deltaTime);
                ////this.transform.Translate(Vector3.forward * smoothing * Time.deltaTime);



                break;



        }
    }
}
