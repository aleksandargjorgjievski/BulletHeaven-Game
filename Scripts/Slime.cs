using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Slime : CharacterBody2D
{
	public const float Speed = 20.0f;
	
	public override void _PhysicsProcess(double delta)
	{	
		Vector2 velocity = Velocity;

		AnimatedSprite2D player = GetNode<AnimatedSprite2D>("../SoldierBody2D/Soldier");
		AnimatedSprite2D slime = GetNode<AnimatedSprite2D>("Slime");

		Vector2 dir = (player.GlobalPosition - slime.GlobalPosition).Normalized();

		velocity += dir * Speed * (float)delta;

		Velocity = velocity;

		MoveAndSlide();
		
	}
}

