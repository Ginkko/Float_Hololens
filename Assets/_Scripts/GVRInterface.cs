using UnityEngine;
using System.Collections;

public class GVRInterface : MonoBehaviour
{
    private Rigidbody myRB;

    public Vector3 swipeThreshold;
    private Vector3 startPos;
    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        startPos = transform.position;
    }   

    // Update is called once per frame
    void Update()
    { 
        UpdatePointer();
        DriftHome();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoForce(Random.Range(1f, 60f));
        }
     
    }

    private void UpdatePointer()
    {
        if (GvrController.State == GvrConnectionState.Connected)
        {
            // transform.rotation = GvrController.Orientation;

            if (GvrController.Accel.y > swipeThreshold.y)
            {

               // Debug.Log("SWIPE DETECTED");
                DoForce(GvrController.Accel.y);
            }

        }

    }
    
    private void DoForce(float accel)
    {
        float force = accel / 10;
        //if (force > 2)
        //    force = 2;

        Debug.Log("Adding force: " + force);
        Vector3 dir = new Vector3(0, force * .2f, force);
        myRB.AddForce(dir);
        Debug.Log("GvrController.Orientation.eulerAngles");
        myRB.AddTorque(GvrController.Accel, ForceMode.Force);

    }

    private void DriftHome()
    {

    }
}

