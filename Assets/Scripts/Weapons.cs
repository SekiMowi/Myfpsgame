using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    //Variables
    public float distance = 20f;
    bool isFiring = false;
    public float rateOfFire = 0.5f;
    public float shotCounter;
    public int damage = 15;
    
    Animator m_anim;
 
    public ParticleSystem muzzleFire;
    public ParticleSystem casingEffect;

    public GameObject enemy;
    public GameObject[] impact;//Impact effect array

    public Camera mainCamera;
    
    public AudioClip[] m_shoot;//Gun clips
    AudioSource m_audiosource;
    Reload ammoScript;//Reload script
    // Start is called before the first frame update
    void Start()
    {
       
        //Getting componets
        m_anim = GetComponent<Animator>();
        m_audiosource = GetComponent<AudioSource>();
        ammoScript = GetComponent<Reload>();
    }
    // Update is called once per frame
    void Update()
    {
        //If LMB is pressed set isFiring bool to true
        if (Input.GetButtonDown("Fire1")&& ammoScript.canFire)
        {
            isFiring = true;
            m_anim.SetBool("m_recoil", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            isFiring = false;
            m_anim.SetBool("m_recoil", false);
        }
    }

    public void FixedUpdate()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;//when isFiring bool is true reduce shotCounters value by time
            
            //if shotCounters value is less than 0 set its value to rateOfFires value and call shoot function
            if (shotCounter <= 0)
            {
                shotCounter = rateOfFire;
                ammoScript.currentAmmo--;//Reduce currentAmmo by 1
                Shoot();
            }
        }
        else
            shotCounter -= Time.deltaTime;
        //To prevent player having infinite ammo by holding lmb
        if (ammoScript.needReload) 
        {
            shotCounter = 0.2f;
        }
        if (!ammoScript.canFire)
        {
            shotCounter = 0.2f;
        }
    }
    public void Shoot()
    {
        RaycastHit hit;//Hit variable
        
        //Play particle effects and play audio clips
        muzzleFire.Play();
        casingEffect.Play();
        m_audiosource.clip = m_shoot[0];
        m_audiosource.Play();

        //Shoots an raycast from middle of the camera and gets its hit information in hit variable
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance) && hit.collider.CompareTag("Enemy"))
        {
            //if hit enemy Instantiate correct impact effect and call EnemyManagers TakeDamage function
            Debug.Log("Hit Enemy");
            Instantiate(impact[1], hit.point, Quaternion.LookRotation(hit.normal));
            EnemyManager target = hit.transform.GetComponent<EnemyManager>();
            target.TakeDamage(damage);

        }
        else if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance) && !hit.collider.CompareTag("Enemy"))
        {
            //if hit something but not the enemy Instantiate correct impact effect
            Debug.Log("Hit");
            Instantiate(impact[0], hit.point, Quaternion.LookRotation(hit.normal));
        }
        else
            Debug.Log("Miss");
    }
}
