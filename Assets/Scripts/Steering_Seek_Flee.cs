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
		// Get a reference to our own material.
		_material = GetComponent<Renderer>().material;
		_rigidBody = GetComponent<Rigidbody>();

		// Initialize the state system/set starting state.
		_activeState = State.Pursue;
		StateEnter();
	}

	// For physics-related state updates.
    // (Invoked through Unity's FixedUpdate event.)
	public void StateFixedUpdate()
	{
		float powerForCurrentFrame = Power * Time.deltaTime;

		// NOTE: Could ("should") have reused the physics code over both states. This was a quick 
		//       implementation, consider it "work in progress" that you can improve on. :-)
		if (_activeState == State.Flee) {
			float targetDirectionX = transform.position.x - SteeringTarget.transform.position.x;
			float targetDirectionZ = transform.position.z - SteeringTarget.transform.position.z;
			Vector3 directionVectorNormalized = new Vector3(targetDirectionX, 0f, targetDirectionZ).normalized;
			Vector3 steeringForce = directionVectorNormalized * powerForCurrentFrame;

			_rigidBody.AddForce(steeringForce);

		} else if (_activeState == State.Seek) {
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
			
		}else if (_activeState == State.Arrive)
		{
			float targetDirectionX = SteeringTarget.transform.position.x - transform.position.x;
			float targetDirectionZ = SteeringTarget.transform.position.z - transform.position.z;
			Vector3 directionVectorNormalized = new Vector3(targetDirectionX, 0f, targetDirectionZ).normalized;
			Vector3 steeringForce = directionVectorNormalized * Vector3.Distance(SteeringTarget.transform.position, transform.position);

			_rigidBody.velocity = steeringForce;
		}
	}

	public void ChangeState(State state)
	{
		_activeState = state;
		StateEnter();
	}
	

	// Private helper method for doing stuff when we enter a new state.
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
