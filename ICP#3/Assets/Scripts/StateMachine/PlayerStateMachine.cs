using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStateMachine : MonoBehaviour
{

	BaseState currentState;
	PlayerController playerController;

	//Normally you would put these in separate SUB-state machines, but it'll be in a single FSM for simplicity
	//Most sites advise you have separate states for grounded / movement / action / animation states etc.
	//So you would have a MovementStateMachine that inherits from *this* machine, for example, and you would put Running/Walking/BOOSTING states there
	//Which means you can handle all input and physics in the "Moving State Machine", since that's where you'll be when...well.....moving.
	//But don't worry about that part for now.
	[HideInInspector]
	public JumpingState jumpingState;
	[HideInInspector]
	public GroundedState groundedState;

	public TextMeshProUGUI screenText;

	private void Awake()
	{
		playerController = GetComponent<PlayerController>();
		jumpingState = new JumpingState(this);
		groundedState = new GroundedState(this);
	}


	// Start is called before the first frame update
	void Start()
    {

		if (currentState == null)
			currentState = GetInitialState();
		currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
		if (currentState != null)
			currentState.UpdateLogic();

		Debug.Log(currentState.StateName);
    }

	void LateUpdate()
	{
		if (currentState != null)
			currentState.UpdatePhysics();
	}


	public void ChangeState(BaseState newState)
	{
		currentState.Exit();

		currentState = newState;

		currentState.Enter();

		screenText.SetText(currentState.StateName);
	}

	public BaseState GetInitialState()
	{
		return groundedState;
	}

	public PlayerController GetPlayerController()
	{
		return playerController;
	}
}
