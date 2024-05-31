using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;



public partial class Slime : CharacterBody2D
{
	[Export]
	private float slimeHP = 2;
	public const float Speed = 20.0f;

	public AnimatedSprite2D slime;

	public AnimationPlayer hitAnimation;
	public override void _Ready()
	{
		slime = GetNode<AnimatedSprite2D>("Slime");
		hitAnimation = GetNode<AnimationPlayer>("AnimationPlayer");
	}


	public override void _PhysicsProcess(double delta)
	{
		var player = GetTree().GetFirstNodeInGroup("players").GetNode<AnimatedSprite2D>("Soldier");

		Vector2 velocity = Velocity;

		velocity = slime.GlobalPosition.DirectionTo(player.GlobalPosition) * Speed;

		Velocity = velocity;

		AnimationPlayer(Velocity);

		MoveAndSlide();

	}

	public void AnimationPlayer(Vector2 velocity)
	{
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

	public void LoseHP(float projectileDmg)
	{
		slimeHP -= projectileDmg;
		hitAnimation.Play("hit");
		if (slimeHP <= 0)
		{
			QueueFree();
		}
	}
}

