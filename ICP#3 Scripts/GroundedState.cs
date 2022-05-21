using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : BaseState
{
	public GroundedState(PlayerStateMachine psm) : base("Grounded", psm) { }

	public override void Enter()
	{
		base.Enter();
		playerController.ApplySlowdown();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void UpdateLogic()
	{
		base.UpdateLogic();
		if (!playerController.IsGrounded())
		{
			playerStateMachine.ChangeState(playerStateMachine.jumpingState);
		}
		else if (playerController.IsGrounded() && playerController.HasHorizontalVelocity())
        {
			playerStateMachine.ChangeState(playerStateMachine.movingState);
		}
		else
        {
			// Do nothing for other conditions.
        }
	}

	public override void UpdatePhysics()
	{
		base.UpdatePhysics();
		playerController.Move();
		
		if (Input.GetKey(KeyCode.Space))
		{
			playerStateMachine.ChangeState(playerStateMachine.jumpingState);
			playerController.Jump();
		}
	}

}
