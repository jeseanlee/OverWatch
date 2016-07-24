using UnityEngine;
using System.Collections;

public class flarebullet : MonoBehaviour {
			

	private Light flarelight;
	private AudioSource flaresound;
	private ParticleRenderer smokepParSystem;
	private bool myCoroutine;
	private float smooth = 2.4f;
	public 	float flareTimer = 9;
	public AudioClip flareBurningSound;
    public float Speed = 30f;
    public float Power = 12f;
    public float Life = 4f;

    // Use this for initialization
    void Start () {

		StartCoroutine("flareLightoff");
		
		GetComponent<AudioSource>().PlayOneShot(flareBurningSound);
		flarelight = GetComponent<Light>();
		flaresound = GetComponent<AudioSource>();
		smokepParSystem = GetComponent<ParticleRenderer>();

		
		Destroy(gameObject,flareTimer + 1f);
		
	
	}
	
	// Update is called once per frame
	void Update () {

		
		if (myCoroutine == true)
		{
			flarelight.intensity = Random.Range(0.5f,1.0f);
            //Life -= Time.deltaTime;
            //if (Life <= 0)
            //{
            //    Destroy(this.gameObject);
            //}
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);

            flarelight.intensity = Mathf.Lerp(flarelight.intensity, 0f, Time.deltaTime * smooth);
            flarelight.range = Mathf.Lerp(flarelight.range, 0f, Time.deltaTime * smooth);
            flaresound.volume = Mathf.Lerp(flaresound.volume, 0f, Time.deltaTime * smooth);
            smokepParSystem.maxParticleSize = Mathf.Lerp(smokepParSystem.maxParticleSize, 0f, Time.deltaTime * 5);       //switched to legacy

        }
        else
			
		{
			flarelight.intensity =  Mathf.Lerp(flarelight.intensity,0f,Time.deltaTime * smooth);
			flarelight.range =  Mathf.Lerp(flarelight.range,0f,Time.deltaTime * smooth);			
			flaresound.volume = Mathf.Lerp(flaresound.volume,0f,Time.deltaTime * smooth);
			smokepParSystem.maxParticleSize = Mathf.Lerp(smokepParSystem.maxParticleSize,0f,Time.deltaTime * 5);       //switched to legacy


		}

			
	}
	
	IEnumerator flareLightoff()
	{
		myCoroutine = true;
		yield return new WaitForSeconds(flareTimer);
		myCoroutine = false;

	}


    void OnCollisionEnter(Collision collision)
    {
        //탄환제거하기.
        Destroy(this.gameObject);

        if (collision.gameObject.tag == "Enemy")
        {
            //Enemy스크립트에 접근하기.
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            //Enemy 스크립트의 ES가 Die가 아닌 경우 Hurt 함수 실행.
            if (enemy.ES != EnemyState.Die)
            {
                enemy.Hurt(Power);
            }
        }
    }
}
