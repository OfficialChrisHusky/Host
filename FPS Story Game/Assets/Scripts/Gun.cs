using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private float shootDistance = 100f;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private GameObject sparks;

    [SerializeField] private Animator anim;
    [SerializeField] private Text ammoText;

    public int maxAmmo = 10;
    public int currentAmmo;
    public int totalAmmo = 20;
    public bool isReloading = false;
    public float reloadTime = 1f;

    private void Start()
    {
        currentAmmo = maxAmmo;
        ammoText.text = currentAmmo.ToString() + " / " + totalAmmo.ToString();
    }

    private void OnEnable()
    {
        isReloading = false;
        anim.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;
        if(currentAmmo <= 0) //Reload when you've ran out of ammo
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButtonDown("Fire1") && maxAmmo != 0) //Call the Shoot function
        {
            Shoot();
        }
        ammoText.text = currentAmmo.ToString() + " / " + totalAmmo.ToString() ;
    }

    IEnumerator Reload()
    {
        isReloading = true;

        anim.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f); //Wait for some seconds to reload

        if(totalAmmo > 0)
        {
            anim.SetBool("Reloading", false);
            totalAmmo -= maxAmmo;
            currentAmmo = maxAmmo;
            isReloading = false;
        }
    }

    void Shoot()
    {
        currentAmmo--;

        RaycastHit hitInfo;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, shootDistance)) //Raycast to detect if you've hit something
        {
            Debug.Log("hit");
            GameObject sparksGO = Instantiate(sparks, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)); //Instantiate sparks in the spot of the impact
            Destroy(sparksGO, 1f);
        }
    }
}
