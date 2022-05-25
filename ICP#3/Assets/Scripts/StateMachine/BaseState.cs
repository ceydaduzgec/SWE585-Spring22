using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
	//taken from https://medium.com/c-sharp-progarmming/make-a-basic-fsm-in-unity-c-f7d9db965134

	public string StateName;
	protected PlayerStateMachine playerStateMachine;
	protected PlayerController playerController;

    public BaseState(string name, PlayerStateMachine psm)
	{
		StateName = name;
		playerStateMachine = psm;
		playerController = psm.GetPlayerController();
	}

	public virtual void Enter() {
		Debug.Log("Now entering: " + StateName);
	}
	public virtual void UpdateLogic() { }
	public virtual void UpdatePhysics() { }
	public virtual void Exit() { }
}
