using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    private Rigidbody mRigidBody;
    private Animator mAnimator;


    //[Header("Locomotion")]
    //[Header("Movement")]
    private Vector3 mInputDirection;
    public float mMaxSpeed;
    private float mXTimer;
    //private float mZTimer;
    public AnimationCurve mAcceleration;
    public AnimationCurve mDeceleration;

    //[Header("Rotation")]


	// Use this for initialization
	void Start ()
    {
        if (GetComponent<Animator>())
        {
            mAnimator = GetComponent<Animator>();
        }
        else if (GetComponentInChildren<Animator>())
        {
            mAnimator = GetComponentInChildren<Animator>();
        }

        if (GetComponent<Rigidbody>())
        {
            mRigidBody = GetComponent<Rigidbody>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        mInputDirection.x = Input.GetAxis("Horizontal");
        mInputDirection.z = Input.GetAxis("Vertical");

        Vector3 tempVelocity = mRigidBody.velocity;

        tempVelocity.x = mInputDirection.x;
        tempVelocity.z = mInputDirection.z;

        Debug.Log(tempVelocity.x);
        
        mRigidBody.velocity = tempVelocity;

        mAnimator.speed = 1.0f;//mRigidBody.velocity.magnitude;

        mAnimator.SetFloat("XDir", mInputDirection.x);
        mAnimator.SetFloat("YDir", mInputDirection.z);

        //mRigidBody

        float temp = mAcceleration.Evaluate(0.75f);

	}
}
