
using UnityEngine;
using System.Collections;

public enum PlayerState_Blue
{
    Idle,
    Walk,
    Run,
    Attack,
    Dead,
    Shot,
}

public class Player_Ctrl_Blue : MonoBehaviour
{

    public PlayerState_Blue PS;

    public Vector3 lookDirection_Blue;
    public float Speed = 0f;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;

    Animation animation;
    public AnimationClip Idle_Ani;
    public AnimationClip Walk_Ani;
    public AnimationClip Run_Ani;

    public GameObject Bullet;
    public Transform ShotPoint;
    public GameObject ShotFX;
    public AudioClip ShotSound;

    public UISlider LifeBar;
    public float Max_hp = 1000;
    public float hp = 1000;

    public Stick JoyStick;
    //public Vector3 dir;

    void KeyboardInput()
    {
        Vector3 dir;
        dir.x = Input.GetAxisRaw("Vertical");
        dir.z = Input.GetAxisRaw("Horizontal");

        if (PS != PlayerState_Blue.Attack)
        {
            //if (JoyStick != null)
            //{
            //    if (JoyStick.InputDirection != Vector3.zero)
            //    {

            //        dir = JoyStick.InputDirection;
            //        lookDirection = JoyStick.InputDirection;
            //        Speed = WalkSpeed;
            //        PS = PlayerState.Walk;

            //        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            //        {
            //            Speed = RunSpeed;
            //            PS = PlayerState.Run;
            //        }
            //    }
            //} 
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {                
                lookDirection_Blue = dir.x * Vector3.forward + dir.z * Vector3.right;
                Speed = WalkSpeed;
                PS = PlayerState_Blue.Walk;

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Speed = RunSpeed;
                    PS = PlayerState_Blue.Run;
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * Speed * Time.deltaTime);
            }

            if (dir.x == 0 && dir.z == 0 && PS != PlayerState_Blue.Idle)
            {
                PS = PlayerState_Blue.Idle;
                Speed = 0f;
            }
        }
        //-------------------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Space) && PS != PlayerState_Blue.Dead)
        {
            StartCoroutine("Shot");
        }
    }

    void LookUpdate()
    {
        if (lookDirection_Blue != Vector3.zero)
        {
            Quaternion RR = Quaternion.LookRotation(lookDirection_Blue);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, RR, 10f);

            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (PS != PlayerState_Blue.Dead)
        {
            KeyboardInput();
            LookUpdate();
        }

        AnimationUpdate();
    }

    void Start()
    {
        animation = this.GetComponent<Animation>();
        lookDirection_Blue = Vector3.zero;
    }

    void AnimationUpdate()
    {
        if (PS == PlayerState_Blue.Idle)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
        else if (PS == PlayerState_Blue.Walk)
        {
            animation.CrossFade(Walk_Ani.name, 0.2f);
        }
        else if (PS == PlayerState_Blue.Run)
        {
            animation.CrossFade(Run_Ani.name, 0.2f);
        }
        else if (PS == PlayerState_Blue.Attack)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
        else if (PS == PlayerState_Blue.Dead)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
    }

    public IEnumerator Shot()
    {
        while (Input.GetMouseButton(0))
        {
            GameObject bullet = Instantiate(Bullet, ShotPoint.position, Quaternion.LookRotation(ShotPoint.forward)) as GameObject;

            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

            GetComponent<AudioSource>().clip = ShotSound;
            GetComponent<AudioSource>().Play();

            ShotFX.SetActive(true);

            PS = PlayerState_Blue.Attack;
            Speed = 0f;

            yield return new WaitForSeconds(0.15f);
            ShotFX.SetActive(false);

            yield return new WaitForSeconds(0.15f);
            PS = PlayerState_Blue.Idle;

            yield return null;
        }
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
            PS = PlayerState_Blue.Dead;

            PlayerManager PM = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            PM.GameOver();
        }
    }
}
