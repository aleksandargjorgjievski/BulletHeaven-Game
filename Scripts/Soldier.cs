using Godot;
using System;
using System.Numerics;

public partial class Soldier : CharacterBody2D
{
	public const float Speed = 30.0f;

	PackedScene arrow_scene;

	Node2D arrow;

	AnimatedSprite2D soldier;

	public override void _Ready()
	{
		arrow_scene = GD.Load<PackedScene>("res://Scenes/projectiles.tscn");
		soldier = GetNode<AnimatedSprite2D>("Soldier");
		GetNode<Timer>("ArrowsTimer").Start();
	}


	public override void _PhysicsProcess(double delta)
	{
		Godot.Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.

		if (Input.IsActionPressed("go_left") || Input.IsActionPressed("go_right") || Input.IsActionPressed("go_up") || Input.IsActionPressed("go_down"))
		{
			soldier.Play("walking");
		}
		else
		{
			soldier.Stop();
		}

		Godot.Vector2 direction = Input.GetVector("go_left", "go_right", "go_up", "go_down");

		if (direction != Godot.Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		if (direction != Godot.Vector2.Zero)
		{
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;

		CharacterAnimation(Velocity);
		ArrowsDirection (Velocity);
		MoveAndSlide();
	}

	public void CharacterAnimation (Godot.Vector2 velocity)
	{

		if (velocity.X < 0) 
		{
			soldier.FlipH = true;
		}
		else if (velocity.X > 0)
		{
			soldier.FlipH = false;
		}
	}

	public void ArrowsDirection (Godot.Vector2 velocity)
	{
		Marker2D arrowsSpawnLocaiton = GetNode<Marker2D>("ProjectilesSpawnLocation");

		// Arrows move in a diagonal direction
		if (velocity.X > 0 && velocity.Y > 0)
		{
			arrowsSpawnLocaiton.RotationDegrees = 45;
		}
		else if (velocity.X > 0 && velocity.Y < 0)
		{
			arrowsSpawnLocaiton.RotationDegrees = 315;
		}
		else if (velocity.X < 0 && velocity.Y < 0)
		{
			arrowsSpawnLocaiton.RotationDegrees = 225;
		}
		else if (velocity.X < 0 && velocity.Y > 0)
		{
			arrowsSpawnLocaiton.RotationDegrees = 135;
		}
		else if (velocity.X < 0) 
		{
			arrowsSpawnLocaiton.RotationDegrees = 180;
		}
		else if (velocity.X > 0)
		{
			arrowsSpawnLocaiton.RotationDegrees = 0;
		}
		else if (velocity.Y < 0)
		{
			arrowsSpawnLocaiton.RotationDegrees = 270;
		}
		else if (velocity.Y > 0)
		{
			arrowsSpawnLocaiton.RotationDegrees = 90;
		}
	}

	private void OnArrowsTimerTimeout()
	{
		arrow = arrow_scene.Instantiate<Node2D>(); 
		Owner.AddChild(arrow);
		arrow.Transform = GetNode<Marker2D>("ProjectilesSpawnLocation").GlobalTransform;
	}
}
