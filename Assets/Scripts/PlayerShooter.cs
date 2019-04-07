using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : PlayerController
{
    public LayerMask ShotTargets;
    public float ShotForce = 300.0f;
    public float ShotCooldown = 1.0f;
    private float _lastShotTime;
    public GameObject GM;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Input.GetMouseButtonDown(0))
        {
            FireBeam();
           
           
        }
    }

   

    private void FireBeam()
    {
        if (Time.time < _lastShotTime + ShotCooldown)
        {
            return;
        }

        Debug.Log("Shooting");
        Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
        Debug.DrawRay(Cam.transform.position, Cam.transform.forward, Color.red, 3f);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.origin + (ray.direction * 100), Color.red, 1);

        if (Physics.Raycast(ray, out hit, int.MaxValue, ShotTargets))
        {
            Debug.Log("Hit: " + hit.transform.name);



            // Destroy(hit.transform.gameObject);
            if (hit.transform.gameObject.GetComponent<Box>() != null)
            {
                if (hit.transform.gameObject.GetComponent<Box>().name.Contains("Black"))
                {
                    GM.GetComponent<Match3>().destoryBlack(hit.transform.gameObject.GetComponent<Box>());
                    GM.GetComponent<Match3>().check3();
                }
                else if (hit.transform.gameObject.GetComponent<Box>().name.Contains("White"))
                {
                    GM.GetComponent<Match3>().destoryWhite(hit.transform.gameObject.GetComponent<Box>());
                   
                    GM.GetComponent<Match3>().destorybox(hit.transform.gameObject.GetComponent<Box>());
                   
                    GM.GetComponent<Match3>().check3();
                }
                else 
                {
                    GM.GetComponent<Match3>().destorybox(hit.transform.gameObject.GetComponent<Box>());
                    
                    GM.GetComponent<Match3>().check3();
                }
            }

        }

        _lastShotTime = Time.time;
    }
   

}
