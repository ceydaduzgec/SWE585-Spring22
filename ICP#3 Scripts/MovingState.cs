using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BaseState
{
	private GameObject _player;
	private Renderer _playerRenderer;
	private Color _originalColor;

	public MovingState(PlayerStateMachine psm) : base("Moving", psm) { }

	public override void Enter()
	{
		base.Enter();
		playerController.ApplySlowdown();
		
		if (_player == null)
        {
			_player = GameObject.FindGameObjectWithTag("Player");
			_playerRenderer = _player.GetComponent<Renderer>();
        }

		_originalColor = _player.GetComponent<Renderer>().material.color;
		_playerRenderer.material.color = Color.red;
	}

	public override void Exit()
	{
		base.Exit();

		_playerRenderer.material.color = _originalColor;
	}

	public override void UpdateLogic()
	{
		base.UpdateLogic();

		if (playerController.IsGrounded() && !playerController.HasHorizontalVelocity())
		{
			playerStateMachine.ChangeState(playerStateMachine.groundedState);
		}
		else if (!playerController.IsGrounded())
        {
			playerStateMachine.ChangeState(playerStateMachine.jumpingState);
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
