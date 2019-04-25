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
    public Match3 match3;

     public override void Awake()
     {
         base.Awake();
     }

    protected override void Update()
    {
        base.Update();

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

       
        Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
        Debug.DrawRay(Cam.transform.position, Cam.transform.forward, Color.red, 3f);
        RaycastHit hit;

       Debug.DrawRay(ray.origin, ray.origin + (ray.direction * 100), Color.red, 1);

        if (Physics.Raycast(ray, out hit, int.MaxValue, ShotTargets))
        {
 
            Destroy(hit.transform.gameObject);
            
            if (hit.transform.gameObject.GetComponent<Box>() != null)
            {
                if (hit.transform.gameObject.GetComponent<Box>().name.Contains("Black"))
                {
                    Debug.Log(hit.transform.gameObject.GetComponent<Box>());
                    match3.destoryBlack(hit.transform.gameObject.GetComponent<Box>());
                    //Debug.Log("hit");
                    match3.check3();

                }
                else if (hit.transform.gameObject.GetComponent<Box>().name.Contains("White"))
                {
                    match3.destoryWhite(hit.transform.gameObject.GetComponent<Box>());

                    match3.destorybox(hit.transform.gameObject.GetComponent<Box>());
                    Debug.Log("hit");
                    match3.check3();
                    
                }
                else 
                {
                    match3.destorybox(hit.transform.gameObject.GetComponent<Box>());
                    Debug.Log("hit");
                    match3.check3();
                    
                }
            }
            

        }

        _lastShotTime = Time.time;
    }
   

}
