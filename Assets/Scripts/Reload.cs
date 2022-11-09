using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reload : MonoBehaviour
{
    //Variables
    public int maxAmmo = 30;
    public int currentAmmo;
    public int ammoConsumption = 1;

    public bool needReload;
    public bool canFire;
    public bool canReload = false;
    public bool reloadCoolDown = false;

    public float reloadSpeed = 1.9f;

    public TextMeshProUGUI ammoText;
    AudioSource audioSource;
    Animator anim;
    Weapons weaponScript; //Weapon script
    // Start is called before the first frame update
    void Start()
    {
        //Allows the player to shoot at the start and sets guns ammo to max ammo
        canFire = true;
        currentAmmo = maxAmmo;
        //Getting components
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        weaponScript = GetComponent<Weapons>();
    }

    // Update is called once per frame
    void Update()
    {
        //If guns current ammo is 29 or less player can reload if the want
        if(currentAmmo <= 29)
        {
            canReload = true;
        }
        //If guns current ammo is 0 or less player can reload
        if(currentAmmo <= 0)
        {
            needReload = true;
            canFire = false;
            anim.SetBool("noAmmo", true);
        }
        
        //if player presses R key and the gun has no ammo starts Reloading corountines
        if(needReload && !reloadCoolDown && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadGun());
            StartCoroutine(ReloadCooldown());
        }
        //if player presses R key and the gun has some ammo left starts Reloading corountines
        if (canReload && !reloadCoolDown && Input.GetKeyDown(KeyCode.R))
        {
            needReload = true;
            canFire = false;
            StartCoroutine(ReloadGun());
            StartCoroutine(ReloadCooldown());
        }
        //Shows the guns current ammo at the UI
        ammoText.text = currentAmmo.ToString();
    }
    //Starts the reloading animation, plays the reload audio clip and sets current ammo to max ammo
    IEnumerator ReloadGun()
    {
        Debug.Log("Reload");
        needReload = false;
        canReload = false;
        anim.SetBool("m_reload", true);
        audioSource.PlayOneShot(weaponScript.m_shoot[1]);
        currentAmmo = maxAmmo;
        yield return new WaitForSeconds(reloadSpeed);
        anim.SetBool("m_reload", false);
        anim.SetBool("noAmmo", false);
        canFire = true;
    }
    //Puts cooldown to the reloading to prevent back to back reloading
    IEnumerator ReloadCooldown()
    {
        reloadCoolDown = true;
        yield return new WaitForSeconds(1);
        reloadCoolDown = false;
    }
}
