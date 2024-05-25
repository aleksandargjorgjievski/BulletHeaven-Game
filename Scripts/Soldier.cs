using Godot;
using System;

public partial class Soldier : CharacterBody2D
{
	public const float Speed = 50.0f;

	[Signal]
	public delegate void SoldierPositionChangedEventHandler(Vector2 position);

	PackedScene arrow_scene;

	Node2D arrow;

	public override void _Ready()
	{
		arrow_scene = GD.Load<PackedScene>("res://Scenes/projectiles.tscn");

		GetNode<Timer>("ArrowsTimer").Start();
	}


	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		AnimatedSprite2D soldier = GetNode<AnimatedSprite2D>("Soldier");

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.

		if (Input.IsActionPressed("go_left") || Input.IsActionPressed("go_right"))
		{
			soldier.Play("walking");
		}
		else
		{
			soldier.Stop();
		}


		Vector2 direction = Input.GetVector("go_left", "go_right", "go_up", "go_down");
		if (direction != Vector2.Zero)
		{
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

		EmitSignal(SignalName.SoldierPositionChanged, soldier.GlobalPosition);
		CharacterAnimation(Velocity);
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

	private void OnArrowsTimerTimeout()
	{
		arrow = arrow_scene.Instantiate<Node2D>(); 
		Owner.AddChild(arrow);
		arrow.Transform = GetNode<Marker2D>("ProjectilesSpawnLocation").GlobalTransform;
		GD.Print("SUP");
	}
}
