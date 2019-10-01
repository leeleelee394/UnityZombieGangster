using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    public AudioClip[] pigyeok;
    public AudioClip[] attackSfx;
    public AudioClip[] dieSfx;

    public enum State
    {
        PATROL,
        TRACE,
        ATTACK
    }

    //public GameObject 

    public Transform attackpos;

    public GameObject Palm;

    public int count;

    public float maxhp = 10;

    public float currhp;

    public GameObject hpBarPrefab;

    public Vector3 hpbaroffset = new Vector3(0, 2.2f, 0);

    private Canvas uiCanvas;

    private Image hpBarImage;


    public bool attack = false;

    public AudioClip sfx;
    private AudioSource _audio;
    public float smoothing = 1f;
    public ParticleSystem[] effects;
    public Transform effectPos;

    GameObject pObject;
    private const string theTag1 = "Player";

    public Transform Left;
    public Transform Right;

    public bool conRed;
    public bool conWall;
    public bool isDead = false;

    public int timer1 = 0;
    public int timer2 = 0;
    public int timer3 = 0;
    public float dist;

    private bool tracing;

    public Transform Redsenser;
    public Transform FrontSenser;

    private int theLayer1;
    private int theLayer2;

    public State state = State.PATROL;

    private Transform enemyTr;
    private Rigidbody rg;
    private Animator anim;

    Quaternion rot;
    public float speed = 5.0f;
    public float turn = 5.0f;
    CapsuleCollider cap;

    // Use this for initialization
    void Start()
    {

        currhp = maxhp;

        _audio = GetComponent<AudioSource>();
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        effects = effectPos.GetComponentsInChildren<ParticleSystem>();
        theLayer1 = LayerMask.NameToLayer("WALL");
        theLayer2 = LayerMask.NameToLayer("BUILDING");
        pObject = GameObject.FindGameObjectWithTag("Player");
        cap = GetComponent<CapsuleCollider>();

        //SetHpBar();
    }

    //void SetHpBar()
    //{
    //    //uiCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();

    //    GameObject hpbar = Instantiate<GameObject>(hpBarPrefab, uiCanvas.transform);

    //    hpBarImage = hpbar.GetComponentsInChildren<Image>()[1];

    //    var _hpbar = hpbar.GetComponent<EnemyHpBar>();
    //    _hpbar.target = this.gameObject.transform;
    //    _hpbar.offset = hpbaroffset;
    //}

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(FrontSenser.position, FrontSenser.forward * 4.3f, Color.blue);

        Debug.DrawRay(Redsenser.position, Redsenser.transform.forward * 4.3f, Color.red);

        RaycastHit hit;
        //
        if (Physics.Raycast(FrontSenser.position, FrontSenser.forward, out hit, 2.6f, 1 << theLayer1))
        {
            conWall = true;
        }

        if (!conRed && Physics.Raycast(this.Redsenser.position, this.Redsenser.forward, out hit, 2.6f, 1 << theLayer2))
        {
            conRed = true;


        }

        if (count >= 3)
        {
            if(this.tag == "Enemy2")
            {
                this.tag = "EnemyDead";
                attack = false;
                this.isDead = true;
                ManagerClass.Instance.killNum++;
            }
            count = 0;
            
        }

        if(this.isDead)
        {
            timer3++;
            if(timer3 == 1)
            {
                anim.SetTrigger("DIE");
                _audio.PlayOneShot(dieSfx[0], 1.0f);
            }
            this.tracing = false;
            //rg.isKinematic = true;
            cap.isTrigger = true;
            cap.enabled = false;
        }

        //if(this.isDead)
        anim.SetBool("Trace", tracing);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PUNCH" && this.currhp > 0.0f)
        {
            
            count ++;
            _audio.PlayOneShot(pigyeok[0], 1.0f);
        }



        if (other.tag == "FIST" && this.currhp > 0.0f)
        {
            //Destroy(this.gameObject);
            this.currhp -= 3.7f;
            
            _audio.PlayOneShot(pigyeok[0], 1.0f);
            if (this.currhp <= 0.0)
            {
                _audio.PlayOneShot(dieSfx[0], 1.0f);
                this.tag = "EnemyDead";
                ManagerClass.Instance.killNum++;
                anim.SetTrigger("DIE");
                attack = false;
                this.isDead = true;
                
            }

        }

        

    }


    void FixedUpdate()
    {
        if(currhp < 1)
        {

        }
        
        dist = Vector3.Distance(pObject.transform.position, this.gameObject.transform.position);


        if(dist < 11)
        {
            if (pObject.GetComponent<MoveAgent>().currhp > 0)
            {
                tracing = true;
            }
            else
            {
                anim.SetTrigger("DANCE");
            }
            this.rg.transform.LookAt(pObject.transform, this.transform.up);
        }
        else
        {
            tracing = false;
        }

        if(dist < 2.5)
        {
            if(pObject.GetComponent<MoveAgent>().currhp > 0)
            {
                attack = true;
            }
            
            
            this.rg.transform.LookAt(pObject.transform, this.transform.up);
            

        }
        else
        {
            attack = false;
        }

        if (attack && !isDead)
        {

            int idx = Random.Range(0, 3);

            timer2++;
            if (timer2 == 27)
            {
                
                anim.SetTrigger("Attack");
                Instantiate(Palm, attackpos.position, attackpos.rotation);
            }

            if(timer2 == 35)
            {
                _audio.PlayOneShot(attackSfx[idx], 1.0f);
            }





        }

        if(pObject.GetComponent<MoveAgent>().isGameover)
        {
            attack = false;
            tracing = false;
        }


        if (timer2 > 53) timer2 = 0;


        if (conRed)
        {

            timer1++;
            if (timer1 == 1)
            {
                turn = Random.Range(5, 15);
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

        if (conWall || conRed)
        {
            if (timer1 > 30)
            {
                conRed = conWall = false;
                timer1 = 0;
            }
        }

    }
}
