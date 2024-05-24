using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Slime : CharacterBody2D
{
	public const float Speed = 20.0f;
	


	public AnimatedSprite2D slime;

	public override void _Ready()
	{
		 slime = GetNode<AnimatedSprite2D>("Slime");
	}


	public override void _PhysicsProcess(double delta)
	{	
		var player = GetTree().GetFirstNodeInGroup("players").GetNode<AnimatedSprite2D>("Soldier");

		Vector2 velocity = Velocity;

		GD.Print(slime.GlobalPosition);

		velocity = slime.GlobalPosition.DirectionTo(player.GlobalPosition) * Speed;

		Velocity = velocity;

		AnimationPlayer(Velocity);

		MoveAndSlide();
		
	}

	public void AnimationPlayer(Vector2 velocity) {
		slime.Play("walking");

		if (velocity.X < 0)
		{
			slime.FlipH = false;
		}
		else if (velocity.X > 0)
		{
			slime.FlipH = true;
		}

	}
	
}

