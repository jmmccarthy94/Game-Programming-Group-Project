using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent (typeof (Animator))]
public class Actions : MonoBehaviour {

	private Animator animator;
	private NavMeshAgent agent;
	public GameObject rotPos;
	public Camera cameraObj;
	Vector3 currentEulerAngles;
	Quaternion currentRotation;
	float rotX;
	float rotZ;
	float rotY;
	public GameObject boundaryText;

	const int countOfDamageAnimations = 3;
	int lastDamageAnimation = -1;

	
	void Awake () 
	{
		
	}

	private void Start()
	{
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}


	private void Update()
	{
		float speedPercent = agent.velocity.magnitude / agent.speed;
		if(Input.GetButtonDown("Vertical"))
		{
			/*
			rotX = cameraObj.transform.localRotation.x;
			rotY = cameraObj.transform.localRotation.y;
			rotZ = cameraObj.transform.localRotation.z;
			Debug.Log(rotY);
			currentEulerAngles = new Vector3(rotX, rotY *180 , rotZ);
			currentRotation.eulerAngles = currentEulerAngles;
			transform.rotation = currentRotation;
			*/

			Run();
			Debug.Log("Hi");
		}


		if (Input.GetButtonUp("Vertical"))
		{
			Stay();
			Debug.Log("Hello");
		}

		if (Input.GetButtonDown("Fire1"))
		{
			Aiming();
			Debug.Log("Fire1");
		}

		if (Input.GetButtonUp("Fire1"))
		{
			Stay();
			Debug.Log("Fire1");
		}

		if(Input.GetMouseButtonDown(0))
		{
			Attack();
		}

	}

	private void OnCollisionEnter(Collision collision)
	{
		boundaryText.SetActive(false);
		if(collision.collider.CompareTag("Walls"))
		{
			boundaryText.SetActive(true);

			Stay();
			Debug.Log("Wall touch");
			StartCoroutine(SetInactive());
		}
		
			
	}
	IEnumerator SetInactive()
	{
		yield return new WaitForSeconds(2);
		boundaryText.SetActive(false);

	}
	public void Stay () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0f);
		}

	public void Walk ()
	{ 
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0.5f);
	}

	public void Run () 
	{
		
		animator.SetBool("Aiming", false);
		animator.SetFloat("Speed", 1f);
		
	}

	public void Attack () {
		Aiming ();
		animator.SetTrigger ("Attack");
	}

	public void Death () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Death"))
			animator.Play("Idle", 0);
		else
			animator.SetTrigger ("Death");
	}

	public void Damage () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Death")) return;
		int id = Random.Range(0, countOfDamageAnimations);
		if (countOfDamageAnimations > 1)
			while (id == lastDamageAnimation)
				id = Random.Range(0, countOfDamageAnimations);
		lastDamageAnimation = id;
		animator.SetInteger ("DamageID", id);
		animator.SetTrigger ("Damage");
	}

	public void Jump () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", false);
		animator.SetTrigger ("Jump");
	}

	public void Aiming () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", true);
	}

	public void Sitting () {
		animator.SetBool ("Squat", !animator.GetBool("Squat"));
		animator.SetBool("Aiming", false);
	}
}
