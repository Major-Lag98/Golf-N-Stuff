using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Putter : MonoBehaviour
{

    public float MouseSensitivity = 1f;
    public float drag = 0.75f;
    public float decriment = 0.05f;
    public float power;
    public GameObject PutterObject;
    public GameObject PutterPivot;
    public GameObject Ball;
    public Rigidbody BallRB;
    public Ray ray;

    public RaycastHit hit;
    [SerializeField] private GameStateMachine StateMachine;
    public int scale = 2;

    [SerializeField] private float MinDistance = .8f;
    [SerializeField] private float MaxDistance = 5f;
    [SerializeField] private float velocityScaler;

    public Vector3 BallOrignalPos;

    public Vector3 BallPrevPos;

    float previousPos;



    Vector3 localTransform;



    // Start is called before the first frame update
    void Start()
    {
        BallRB = Ball.GetComponent<Rigidbody>();
        resetPutterPosition();
        BallPrevPos = BallOrignalPos = BallRB.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        BallRB.drag = drag;
        BallRB.useGravity = true;
        switch (StateMachine.currentState)
        {
            case (GameStateMachine.GameState.PUTTING):
                puttCaculation();
                break;
            case (GameStateMachine.GameState.AIMIMG):

                BallPrevPos = BallRB.transform.position;

                break;


        }



    }
    void puttCaculation()
    {

        // make the putter face the correct direction
        PutterPivot.transform.rotation = Quaternion.LookRotation(CameraOrbit.facingDirection, Vector3.up);

        previousPos = localTransform.z;

        localTransform.z += Input.GetAxis("Mouse Y") * MouseSensitivity;

        if (localTransform.z > -MinDistance) // move some to putt state
        {
            //Debug.Log("Hit");
            StateMachine.CameraObject.CameraControllsSet(false);
            CameraOrbit.ready = false;
            StateMachine.CameraObject.AimLineSet(false);
            Putt();
            resetPutterPosition();
        }

        localTransform.z = Mathf.Clamp(localTransform.z, MaxDistance * -1, MinDistance * -1);

        PutterObject.transform.localPosition = new Vector3(
            PutterObject.transform.localPosition.x,
         PutterObject.transform.localPosition.y,
         Mathf.Lerp(PutterObject.transform.localPosition.z, localTransform.z, 1));
    }

    // launch the ball
    void Putt()
    {
        // set the velocity of the vall relitive to how hard we hit
        float velocity = (localTransform.z - previousPos) * Mathf.Pow((Time.deltaTime * velocityScaler), -1);
        BallRB.velocity = CameraOrbit.facingDirection * velocity;

        // change the state to waiting
        StateMachine.ChangeState(GameStateMachine.GameState.WAITING);

    }


    public void resetPutterPosition()
    {
        localTransform.z = (-MaxDistance + -MinDistance) * 0.5f;
    }


    public void PutterSet(bool check)
    {
        PutterObject.SetActive(check);
    }


    void OnCollisionEnter(Collision collision)
    {
        BallRB.velocity = BallRB.velocity;
        //test if collied with ramp and at low enough speed(speed being a negitive number)
        if (collision.gameObject.CompareTag("Block"))
        {
            StateMachine.set = false;
            StateMachine.resetCounter();
            StateMachine.ChangeState(GameStateMachine.GameState.WAITING);
            BallRB.velocity += collision.relativeVelocity;
        }



    }
    public void ResetGolfBall(Vector3 lastPos)
    {
        BallRB.position = lastPos;
        // set velocity to 0
        BallRB.velocity = Vector3.zero;

        // set angular velocity to 0
        BallRB.angularVelocity = Vector3.zero;

    }
}
