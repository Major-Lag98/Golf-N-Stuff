using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putter : MonoBehaviour
{

    public float MouseSensitivity = 1f;
    public float drag ; 
    public float power;

    public GameObject PutterObject;
    public GameObject PutterPivot;
    public GameObject Ball;
    public GameStateMachine StateMachine;

    Rigidbody BallRB;

    public float MinDistance = .8f;
    public float MaxDistance = 5f;

    public float velocityScaler;

    float previousPos;

    

    Vector3 localTransform;
    


    // Start is called before the first frame update
    void Start()
    {
        BallRB = Ball.GetComponent<Rigidbody>();
        resetPutterPosition();
    }

    // Update is called once per frame
    void Update()
    {


        

        // if we are not in a putting state, do nothing
        if (StateMachine.currentState != GameStateMachine.GameState.PUTTING) return;

        // make the putter face the correct direction
        PutterPivot.transform.rotation = Quaternion.LookRotation(CameraOrbit.facingDirection, Vector3.up);

        previousPos = localTransform.z;

        localTransform.z += Input.GetAxis("Mouse Y") * MouseSensitivity;

        if (localTransform.z > -MinDistance) // move some to putt state
        {
            Debug.Log("Hit");
            CameraOrbit.CameraEnabled = false;
            CameraOrbit.ready = false;
            CameraOrbit.LR.enabled = false;
            Putt();
            resetPutterPosition();
        }

        localTransform.z = Mathf.Clamp(localTransform.z, MaxDistance * -1, MinDistance * -1);

        PutterObject.transform.localPosition = new Vector3(PutterObject.transform.localPosition.x, PutterObject.transform.localPosition.y, Mathf.Lerp(PutterObject.transform.localPosition.z, localTransform.z, 1));

        //previousPos = localTransform;
        

        

    }

    // launch the ball
    void Putt()
    {
        // set the velocity of the vall relitive to how hard we hit
        float velocity = (localTransform.z - previousPos) / (Time.deltaTime * velocityScaler);
        BallRB.velocity = CameraOrbit.facingDirection *  velocity;
           
        // change the state to waiting
        StateMachine.ChangeState(GameStateMachine.GameState.WAITING);
        
    }


    public void resetPutterPosition()
    {
        localTransform.z = (-MaxDistance + -MinDistance) / 2;
    }


    public void DisablePutter()
    {
        PutterObject.SetActive(false);
    }

    public void EnablePutter()
    {
        PutterObject.SetActive(true);
    }
void OnCollisionEnter(Collision collision)
{
     
if (collision.gameObject.CompareTag("Ramp") ) 
{
    BallRB.drag = 0 ;



}
else
{
    BallRB.drag = drag; 
}
}
}
