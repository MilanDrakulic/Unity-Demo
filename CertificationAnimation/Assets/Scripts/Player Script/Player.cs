using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    Animator playerAnimator;
    Rigidbody rb;
    public float upJumpSpeed = 5;
    public float forwardJumpSpeed = 1;
	private bool isJumping = false;

	// Use this for initialization
	void Awake () {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.applyRootMotion = true;
        rb = GetComponent<Rigidbody>();
    }

	private void Update()
	{
		if (Input.GetButton("Duck"))
		{
			playerAnimator.SetBool("crouching", true);
		}
		else
		{
			playerAnimator.SetBool("crouching", false);
		}

		if (Input.GetButtonDown("Jump"))
		{
			playerAnimator.SetTrigger("jump");
			isJumping = true;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");


        playerAnimator.SetFloat("forwardSpeed", v);
        playerAnimator.SetFloat("turnSpeed", h);

		//if (Input.GetButtonDown("Duck"))
		//{
		//	playerAnimator.SetTrigger("duck");
		//}

		if (isJumping)
		{
			rb.velocity += Vector3.up * upJumpSpeed + transform.forward * forwardJumpSpeed;
			isJumping = false;
		}

		//if (Input.GetButtonDown("Jump"))
  //      {
  //          playerAnimator.SetTrigger("jump");
  //          rb.velocity += Vector3.up * upJumpSpeed + transform.forward * forwardJumpSpeed;
  //      }

        bool grounded = Mathf.Abs(Vector3.Dot(rb.velocity, Vector3.up)) < 0.01;
		bool turning = Mathf.Abs(h) > 0.01;
		playerAnimator.SetBool("turning", turning);
		playerAnimator.applyRootMotion = grounded;
        playerAnimator.SetBool("grounded", grounded);
    }
}
