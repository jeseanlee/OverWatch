using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Attack,
    Dead,
}

public enum PlayItem
{
    Weapon1,
    Weapon2,
    Weapon3,
    Weapon4,
    Weapon5
}

public enum PlayCharacter
{
    para,
    win,
    road,
    trace
}

public class Player_Ctrl : MonoBehaviour
{

    public CharacterController CC;
    public Animator Ani;
    public Animator GunAny;
    public Animator DepoAny;
    public Animator AxeAny;

    RaycastHit Hit;


    public float MoveSpeed;
    float TurnSpeed;
    Vector3 V3;
    //
    public PlayCharacter PC;
    public PlayItem PI;
    //
    public PlayerState PS;

    public Vector3 lookDirection;
    public float Speed = 0f;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;

    Animation animation;
    public AnimationClip Idle_Ani;
    public AnimationClip Walk_Ani;
    public AnimationClip Run_Ani;
    //
    public GameObject winpilBullet;
    public AudioClip winpilShotSound;
    public GameObject winpilShotFX;
    //
    public GameObject winrightBullet;
    public AudioClip winrightShotSound;
    public GameObject winrightShotFX;
    //
    public GameObject winBullet;
    public AudioClip winShotSound;
    public GameObject winShotFX;
    //
    bool pil1;
    public GameObject tracePilBullet;
    public AudioClip tracePilShotSound;
    public GameObject tracePilShotFX;
    //
    public GameObject pararightBullet;
    public AudioClip pararightShotSound;
    public GameObject pararightlShotFX;
    //
    bool pil;
    public GameObject PilBullet;
    public AudioClip PilShotSound;
    public GameObject PilShotFX;
    public Transform ShotPoint;
    public GameObject ShotFX;
    public GameObject Bullet;
    //
    //public Transform ShotPoint11;
    //public GameObject ShotFX11;
    //public GameObject Bullet11;
    public AudioClip ShotSound;
    public AudioClip ReloadSound;



    public Transform ShotPoint1;
    public GameObject ShotFX1;
    public GameObject Bullet1;
    public AudioClip ShotSound1;
    public AudioClip ReloadSound1;

    public Transform ShotPoint2;
    public GameObject ShotFX2;
    public GameObject Bullet2;
    public AudioClip ShotSound2;

    public UISlider LifeBar;
    public float Max_hp = 100;
    public float hp = 100;

    public UISlider MpBar;
    public float Max_mp = 100;
    public float mp = 100;

    GameObject ParaMana;
    GameObject Weapon1;
    GameObject Weapon2;
    GameObject Weapon3;
    GameObject Weapon4;
    //
    float timer =0.0f;
    int waitingTime=2;
    bool inside=false;

    float timer1 = 0.0f;
    float waitingTime1 = 0.2f;
    bool inside1 = false;

    float timer2 = 0.0f;
    float waitingTime2 = 0.01f;
    bool inside2 = false;

    float timer3 = 0.0f;
    float waitingTime3 = 0.5f;
    bool inside3 = false;

    float timer4 = 0.0f;
    float waitingTime4 = 0.3f;
    bool inside4 = false;

    float timer5 = 0.0f;
    float waitingTime5 = 0.5f;
    bool inside5 = false;



    void KeyboardInput()
    {


        if (Input.GetKey(KeyCode.U))
        {
            PC = PlayCharacter.para;
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            Weapon3.SetActive(false);
            Weapon4.SetActive(false);
            PI = PlayItem.Weapon2;

        }
        else if (Input.GetKey(KeyCode.I))
        {
            PC = PlayCharacter.trace;
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
            Weapon4.SetActive(false);
            PI = PlayItem.Weapon1;
        }
        else if (Input.GetKey(KeyCode.O))
        {
            PC = PlayCharacter.win;
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
            Weapon4.SetActive(true);
            PI = PlayItem.Weapon4;
        } 
        else if (Input.GetKey(KeyCode.P))
            PC = PlayCharacter.road;

        float xx = Input.GetAxisRaw("Vertical");
        float ZZ = Input.GetAxisRaw("Horizontal");
        // if (PS != PlayerState.Attack)
        {
            if (Input.GetKey(KeyCode.W))
            {
                CC.Move(transform.forward * MoveSpeed * Time.deltaTime);
                PS = PlayerState.Walk;
                GunAny.SetBool("Move", true);
                DepoAny.SetBool("Move", true);
                AxeAny.SetBool("Move", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                CC.Move(transform.forward * -1f * MoveSpeed * Time.deltaTime);
                PS = PlayerState.Walk;
                GunAny.SetBool("Move", true);
                DepoAny.SetBool("Move", true);
                AxeAny.SetBool("Move", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                CC.Move(transform.right * -1f * MoveSpeed * Time.deltaTime);
                PS = PlayerState.Walk;
                GunAny.SetBool("Move", true);
                DepoAny.SetBool("Move", true);
                AxeAny.SetBool("Move", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CC.Move(transform.right * MoveSpeed * Time.deltaTime);
                PS = PlayerState.Walk;
                GunAny.SetBool("Move", true);
                DepoAny.SetBool("Move", true);
                AxeAny.SetBool("Move", true);
            }
            else
            { GunAny.SetBool("Move", false);
                DepoAny.SetBool("Move", false);
                AxeAny.SetBool("Move", false);
            }


            if (Input.GetKey(KeyCode.R))
            {
                inside = true;

                GunAny.SetBool("Reload", true);
                DepoAny.SetBool("Reload", true);
                if (PI != PlayItem.Weapon3)
                {
                    GetComponent<AudioSource>().clip = ReloadSound;
                    GetComponent<AudioSource>().Play();
                }
            }
            else
            { GunAny.SetBool("Reload", false);
                DepoAny.SetBool("Reload", false);
            }


            if (xx == 0 && ZZ == 0 && PS != PlayerState.Idle)
            {
                PS = PlayerState.Idle;
                Speed = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.F1) && PC == PlayCharacter.trace)
        {
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
            Weapon4.SetActive(false);
            PI = PlayItem.Weapon1;
        }
        else if (Input.GetKeyDown(KeyCode.F2) && PC == PlayCharacter.para)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            Weapon3.SetActive(false);
            Weapon4.SetActive(false);
            PI = PlayItem.Weapon2;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(true);
            Weapon4.SetActive(false);
            PI = PlayItem.Weapon3;
        }
        else if (Input.GetKeyDown(KeyCode.F4) && PC == PlayCharacter.win)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
            Weapon4.SetActive(true);
            PI = PlayItem.Weapon4;
        }
        ProgressBar.ProgressRadialBehaviour gz = GameObject.FindWithTag("gaze").GetComponent<ProgressBar.ProgressRadialBehaviour>();
        ProgressBar.ProgressBarBehaviour s1 = GameObject.FindWithTag("sk1").GetComponent<ProgressBar.ProgressBarBehaviour>();
        ProgressBar.ProgressBarBehaviour1 s2 = GameObject.FindWithTag("sk2").GetComponent<ProgressBar.ProgressBarBehaviour1>();
       // ProgressBar.ProgressBarBehaviour2 s3 = GameObject.FindWithTag("sk3").GetComponent<ProgressBar.ProgressBarBehaviour2>();
        UISlider hp = GameObject.FindWithTag("hpbar").GetComponent<UISlider>();
        if (Input.GetKeyDown(KeyCode.Q) && gz.m_Value > 1.0f && PC == PlayCharacter.para)
        {
            StartCoroutine("parapil");


            gz.DecrementValue(100.0f);
        }

        if (Input.GetKeyDown(KeyCode.Q) && gz.m_Value > 1.0f && PC == PlayCharacter.trace)
        {
            StartCoroutine("tracepil");


            gz.DecrementValue(100.0f);
        }


        if (Input.GetKey(KeyCode.Space) && PS != PlayerState.Dead && PC == PlayCharacter.para)
        {
            ParaMana.SetActive(true);
            if (mp > 0)
            {
                CC.Move(transform.up * 1 * MoveSpeed * Time.deltaTime);
                mp -= 1;
                MpBar.sliderValue = mp / Max_mp;
            }

        }
        else
        {
            ParaMana.SetActive(false);
            if (mp < 100)
                mp += 0.2f;
            MpBar.sliderValue = mp / Max_mp;
            if (pil == false)
                CC.Move(transform.up * -0.5f * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && PS != PlayerState.Dead)
        {
            inside4 = true;
        }
        //

        if (Input.GetMouseButton(0) && PS != PlayerState.Dead && PI == PlayItem.Weapon1 && inside == false)
        {

            PlayManager PM = GameObject.Find("PlayManager").GetComponent<PlayManager>();
            if (PM.GunTan_Count > 0)
            {
                StartCoroutine("Shot");
               // StartCoroutine("Shot11");
            }

                PM.MinusGun();

        }
        else if (Input.GetMouseButtonDown(0) && PS != PlayerState.Dead && PI == PlayItem.Weapon2 && inside == false)
        {
            inside1 = true;
            DepoAny.SetBool("Attack", true);
            PlayManager PM = GameObject.Find("PlayManager").GetComponent<PlayManager>();
            if (PM.GunTan_Count1 > 0)
                StartCoroutine("Shot1");
            PM.MinusGun();

        }


        if (Input.GetMouseButtonDown(0) && PS != PlayerState.Dead && PI == PlayItem.Weapon3)
        {
            inside2 = true;
            PlayManager PM = GameObject.Find("PlayManager").GetComponent<PlayManager>();
            //if (PM.GunTan_Count1 > 0)
            AxeAny.SetBool("Attack", true);
            StartCoroutine("Shot2");
            //PM.MinusGun();
        }
        else if (inside2 == false) {
            AxeAny.SetBool("Attack", false); }


        if (Input.GetMouseButton(0) && PS != PlayerState.Dead && PI == PlayItem.Weapon4 && inside == false)
        {

            PlayManager PM = GameObject.Find("PlayManager").GetComponent<PlayManager>();
            if (PM.GunTan_Count > 0)
                StartCoroutine("Shot3");
            PM.MinusGun();

        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && PS != PlayerState.Dead && s1.Value > 99.0f && PC == PlayCharacter.para)
        {
            inside3 = true;
            // s1.DecrementValue(1000.0f);
            s1.SetFillerSizeAsPercentage(0.0f);

        }

        if (Input.GetMouseButton(1) && PI == PlayItem.Weapon2 && s2.Value > 99.0f && PC == PlayCharacter.para)
        {
            StartCoroutine("pararight");
            s2.SetFillerSizeAsPercentage(0.0f);

        }

        if (Input.GetMouseButton(1) && PI == PlayItem.Weapon4 && s2.Value > 99.0f && PC == PlayCharacter.win)
        {
            StartCoroutine("winright");
            s2.SetFillerSizeAsPercentage(0.0f);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && PS != PlayerState.Dead && s1.Value > 49.0f && PC == PlayCharacter.win)
        {
            inside5 = true;
            s1.SetFillerSizeAsPercentage(0.0f);

        }

        if (Input.GetMouseButton(1) && PS != PlayerState.Dead && PC == PlayCharacter.trace && s1.Value > 29.0f)
        {
            CC.Move(transform.forward * 30.0f * MoveSpeed * Time.deltaTime);
            s1.SetFillerSizeAsPercentage(0.0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && PS != PlayerState.Dead && PC == PlayCharacter.trace && s2.Value > 79.0f)
        {
            CC.Move(transform.forward * -30.0f * MoveSpeed * Time.deltaTime);
            s2.SetFillerSizeAsPercentage(0.0f);
            hp.Set(200, true);
        }

        //조준애니메이션
        //if (Input.GetMouseButton(1))
        //{
        //    GunAny.SetBool("JJ", true);
        //}
        //else if (Input.GetMouseButtonUp(1))
        //{
        //    GunAny.SetBool("JJ", false);
        //}

    }

    void LookUpdate()
    {
        //Quaternion R = Quaternion.LookRotation(lookDirection);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 10f);

        //transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void Update()
    {
        if (inside5 == true)
        {
            timer5 += Time.deltaTime;
            CC.Move(transform.up * 3 * MoveSpeed * Time.deltaTime);
            CC.Move(transform.forward * 10 * MoveSpeed * Time.deltaTime);

            if (timer5 > waitingTime5)
            {

                timer5 = 0;
                inside5 = false;

            }

        }

        if (inside4 == true)
        {
            timer4 += Time.deltaTime;
            CC.Move(transform.up * 2 * MoveSpeed * Time.deltaTime);
           
            if (timer4 > waitingTime4)
            {

                timer4 = 0;
                inside4 = false;

            }
         
        }
        //
        if (inside3 == true)
        {
            timer3 += Time.deltaTime;
            CC.Move(transform.up * 4 * MoveSpeed * Time.deltaTime);
            if (timer3 > waitingTime3)
            {
             
                timer3 = 0;
                inside3 = false;
            }
        }


        if (inside2 == true)
        {
            timer2 += Time.deltaTime;
            if (timer2 > waitingTime1)
            {
               
                timer2 = 0;
                inside2 = false;
            }
        }

        if (inside1 == true)
        {
            timer1 += Time.deltaTime;
            if (timer1 > waitingTime1)
            {
                DepoAny.SetBool("Attack", false);
                timer1 = 0;
                inside1 = false;
            }
        }
        if (inside == true)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                //Action
                PlayManager PM = GameObject.Find("PlayManager").GetComponent<PlayManager>();
                PM.PlusGun();
                timer = 0;
                inside = false;
            }
        }

        V3 = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(V3 * TurnSpeed);
        if (PS != PlayerState.Dead)
        {
            KeyboardInput();
            LookUpdate();
        }

        AnimationUpdate();
    }

    void Start()
    {
        Weapon1 = GameObject.FindWithTag("Weapon1");
        Weapon2 = GameObject.FindWithTag("Weapon2");
        Weapon3 = GameObject.FindWithTag("Weapon3");
        Weapon4 = GameObject.FindWithTag("Weapon4");
        ParaMana = GameObject.FindWithTag("ParaMana");
        ParaMana.SetActive(false);

        if(PC==PlayCharacter.para)
        {
            Weapon4.SetActive(false);
            Weapon3.SetActive(false);
            Weapon1.SetActive(false);
            PC = PlayCharacter.para;
            PI = PlayItem.Weapon2;

        }
      




        MoveSpeed = 5f;
        TurnSpeed = 10;
        animation = this.GetComponent<Animation>();
    }

    void AnimationUpdate()
    {
        if (PS == PlayerState.Idle)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
        else if (PS == PlayerState.Walk)
        {
            animation.CrossFade(Walk_Ani.name, 0.2f);
        }
        else if (PS == PlayerState.Run)
        {
            animation.CrossFade(Run_Ani.name, 0.2f);
        }
        else if (PS == PlayerState.Attack)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
        else if (PS == PlayerState.Dead)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
    }

    public IEnumerator Shot()
    {
        GameObject bullet = Instantiate(Bullet,
                                        ShotPoint.position,
                                        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

        GetComponent<AudioSource>().clip = ShotSound;
        GetComponent<AudioSource>().Play();

        ShotFX.SetActive(true);

        PS = PlayerState.Attack;
        Speed = 0f;

        yield return new WaitForSeconds(0.15f);
        ShotFX.SetActive(false);

        yield return new WaitForSeconds(0.15f);
        PS = PlayerState.Idle;
    }

    //public IEnumerator Shot11()
    //{
    //    GameObject bullet = Instantiate(Bullet11,
    //                                    ShotPoint.position,
    //                                    Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

    //    Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

    //    GetComponent<AudioSource>().clip = ShotSound;
    //    GetComponent<AudioSource>().Play();

    //    ShotFX11.SetActive(true);

    //    PS = PlayerState.Attack;
    //    Speed = 0f;

    //    yield return new WaitForSeconds(0.15f);
    //    ShotFX11.SetActive(false);

    //    yield return new WaitForSeconds(0.15f);
    //    PS = PlayerState.Idle;
    //}

    public IEnumerator Shot1()
    {
        GameObject bullet1 = Instantiate(Bullet1,
                                        ShotPoint.position,
                                        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

        Physics.IgnoreCollision(bullet1.GetComponent<Collider>(), GetComponent<Collider>());

        GetComponent<AudioSource>().clip = ShotSound1;
        GetComponent<AudioSource>().Play();

        ShotFX.SetActive(true);

        PS = PlayerState.Attack;
        Speed = 0f;

        yield return new WaitForSeconds(0.15f);
        ShotFX.SetActive(false);

        yield return new WaitForSeconds(0.15f);
        PS = PlayerState.Idle;
    }

    public IEnumerator Shot2()
    {
        GameObject bullet2 = Instantiate(Bullet2,
                                        ShotPoint.position,
                                        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

        Physics.IgnoreCollision(bullet2.GetComponent<Collider>(), GetComponent<Collider>());


        GetComponent<AudioSource>().clip = ShotSound2;
        GetComponent<AudioSource>().Play();

        ShotFX.SetActive(true);

        PS = PlayerState.Attack;
        Speed = 0f;

        yield return new WaitForSeconds(0.01f);
        ShotFX.SetActive(false);

      
        PS = PlayerState.Idle;
    }

    public IEnumerator parapil()
    {
        pil = true;
        GameObject bullet1;
        bullet1 = Instantiate(PilBullet,
                 ShotPoint.position,
                 Quaternion.LookRotation(ShotPoint.forward)) as GameObject;
        bullet1 = Instantiate(PilShotFX,
             ShotPoint.position,
             Quaternion.LookRotation(ShotPoint.forward)) as GameObject;
        bullet1 = Instantiate(PilShotFX,
        ShotPoint.position,
        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;
        bullet1 = Instantiate(PilShotFX,
        ShotPoint.position,
        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

        Physics.IgnoreCollision(bullet1.GetComponent<Collider>(), GetComponent<Collider>());

        GetComponent<AudioSource>().clip = ShotSound1;
        GetComponent<AudioSource>().Play();

        //PilShotFX.SetActive(true);

        PS = PlayerState.Attack;
        Speed = 0f;
    
        yield return new WaitForSeconds(0.15f);
       // PilShotFX.SetActive(false);

        yield return new WaitForSeconds(2.0f);
        PS = PlayerState.Idle;

        pil = false;
    }


    public IEnumerator pararight()
    {
        GameObject bullet1 = Instantiate(pararightBullet,
                                        ShotPoint.position,
                                        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

        Physics.IgnoreCollision(bullet1.GetComponent<Collider>(), GetComponent<Collider>());

        GetComponent<AudioSource>().clip = ShotSound1;
        GetComponent<AudioSource>().Play();

        ShotFX.SetActive(true);

        PS = PlayerState.Attack;
        Speed = 0f;

        yield return new WaitForSeconds(0.15f);
        ShotFX.SetActive(false);

        yield return new WaitForSeconds(0.15f);
        PS = PlayerState.Idle;
    }


    public IEnumerator tracepil()
    {
        pil1 = true;
        GameObject bullet1;
        bullet1 = Instantiate(tracePilBullet,
                 ShotPoint.position,
                 Quaternion.LookRotation(ShotPoint.forward)) as GameObject;
        bullet1 = Instantiate(tracePilShotFX,
             ShotPoint.position,
             Quaternion.LookRotation(ShotPoint.forward)) as GameObject;
        bullet1 = Instantiate(tracePilShotFX,
        ShotPoint.position,
        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;
        bullet1 = Instantiate(tracePilShotFX,
        ShotPoint.position,
        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

        Physics.IgnoreCollision(bullet1.GetComponent<Collider>(), GetComponent<Collider>());

        GetComponent<AudioSource>().clip = ShotSound1;
        GetComponent<AudioSource>().Play();

        //PilShotFX.SetActive(true);

        PS = PlayerState.Attack;
        Speed = 0f;

        yield return new WaitForSeconds(0.15f);
        // PilShotFX.SetActive(false);

        yield return new WaitForSeconds(2.0f);
        PS = PlayerState.Idle;

        pil1 = false;
    }

    public IEnumerator Shot3()
    {
        GameObject bullet = Instantiate(winBullet,
                                        ShotPoint.position,
                                        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

        GetComponent<AudioSource>().clip = winShotSound;
        GetComponent<AudioSource>().Play();

        ShotFX.SetActive(true);

        PS = PlayerState.Attack;
        Speed = 0f;

        yield return new WaitForSeconds(0.15f);
        ShotFX.SetActive(false);

        yield return new WaitForSeconds(0.15f);
        PS = PlayerState.Idle;
    }

    public IEnumerator winright()
    {
        GameObject bullet1 = Instantiate(winrightBullet,
                                        ShotPoint.position,
                                        Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

    //    Physics.IgnoreCollision(bullet1.GetComponent<Collider>(), GetComponent<Collider>());

        GetComponent<AudioSource>().clip = ShotSound1;
        GetComponent<AudioSource>().Play();

        ShotFX.SetActive(true);

        PS = PlayerState.Attack;
        Speed = 0f;

        yield return new WaitForSeconds(0.15f);
        ShotFX.SetActive(false);

        yield return new WaitForSeconds(0.15f);
        PS = PlayerState.Idle;
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(0.15f);
    }

    public void Hurt(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            LifeBar.sliderValue = hp / Max_hp;
        }

        if (hp <= 0)
        {
            Speed = 0;
            PS = PlayerState.Dead;

            //PlayerManager를 찾아서 PM이라는 이름으로 가져와 함수 실행시키기.
            PlayManager PM = GameObject.Find("PlayManager").GetComponent<PlayManager>();
            PM.GameOver();
        }
    }
}
