using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera Cam;
    public float LookSpeed;
    public float MaxYRotation;
    private Quaternion _originalCamRotation;

     private CharacterController _cc;
    //public bool gameLoded = false;
  
    public virtual void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _originalCamRotation = Cam.transform.localRotation;
    }



    protected virtual void Update()
    {
       
        //if(gameLoded)
        //{ // Rotate view up/down
            var lookY = Input.GetAxis("Mouse Y") * LookSpeed;
            var newRotation = Cam.transform.localRotation * Quaternion.AngleAxis(-lookY, Vector3.right); ;
            if (Mathf.Abs(Quaternion.Angle(_originalCamRotation, newRotation)) < MaxYRotation)
            {
                Cam.transform.Rotate(-lookY, 0, 0);
            }

            // Rotate view right/left
            var lookX = Input.GetAxis("Mouse X") * LookSpeed;
            var newRotationX = Cam.transform.localRotation * Quaternion.AngleAxis(-lookX, Vector3.up); ;
            if (Mathf.Abs(Quaternion.Angle(_originalCamRotation, newRotationX)) < MaxYRotation)
            {
                transform.Rotate(0, lookX, 0);
            }
       // }


    }
}