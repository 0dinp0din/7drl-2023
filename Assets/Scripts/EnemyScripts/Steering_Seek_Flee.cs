using UnityEngine;

public class Steering_Seek_Flee : MonoBehaviour
{
	public enum State
	{
		Idle,
		Flee,
		Seek,
		Pursue,
		Arrive
	}
	public GameObject SteeringTarget;
	public float Power;

	private Material _material;
	private Rigidbody _rigidBody;
	[SerializeField]
	private State _activeState;

	// Use this for initialization
	void Start()
	{
		SteeringTarget = GameObject.FindWithTag("Player");
		_material = GetComponent<Renderer>().material;
		_rigidBody = GetComponent<Rigidbody>();

		_activeState = State.Pursue;
		StateEnter();
	}

	public void FixedUpdate()
	{
		float powerForCurrentFrame = Power * Time.deltaTime; 
		
		if (_activeState == State.Seek) {
			float targetDirectionX = SteeringTarget.transform.position.x - transform.position.x;
			float targetDirectionZ = SteeringTarget.transform.position.z - transform.position.z;
			Vector3 directionVectorNormalized = new Vector3(targetDirectionX, 0f, targetDirectionZ).normalized;
			Vector3 steeringForce = directionVectorNormalized * powerForCurrentFrame;

			_rigidBody.AddForce(steeringForce);
		} else if (_activeState == State.Pursue)
		{
			Vector3 targetPosition = SteeringTarget.transform.position;
			Vector3 targetVelocity = SteeringTarget.GetComponent<Rigidbody>().velocity;
			
			Vector3 predictedTargetPosition = targetPosition + targetVelocity;
			
			Vector3 directionToMove = (predictedTargetPosition - transform.position).normalized;
			
			Vector3 steeringForce = directionToMove * powerForCurrentFrame;
			_rigidBody.AddForce(steeringForce);

		}
	}

	private void StateEnter()
	{
		if (_activeState == State.Idle) {
			_material.color = Color.grey;
		} else if (_activeState == State.Pursue) {
			_material.color = Color.blue;
		} else if (_activeState == State.Seek) {
			_material.color = Color.red;
		}
	}

}
