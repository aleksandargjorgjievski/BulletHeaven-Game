using Godot;
using System;

public partial class Soldier : CharacterBody2D
{
	public const float Speed = 50.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		AnimatedSprite2D soldier = GetNode<AnimatedSprite2D>("Soldier");

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("go_left", "go_right", "go_up", "go_down");
		if (direction != Vector2.Zero)
		{
			soldier.Play("walking");
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		if (direction != Vector2.Zero)
		{
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;

		MoveAndSlide();
	}

	public void CharacterAnimation (Vector2 velocity)
	{
		AnimatedSprite2D soldier = GetNode<AnimatedSprite2D>("Soldier");

		if (velocity.X < 0) 
		{
			soldier.FlipH = true;
		}
		else if (velocity.X > 0)
		{
			soldier.FlipH = false;
		}
	}
}
