using Godot;
using System;
using System.Collections.Generic;

public partial class projectiles : Area2D
{
	public float speed = 30.0f;

	public override void _PhysicsProcess(double delta)
	{
		Position += Transform.X * speed * (float)delta;
	}
	

	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body.IsInGroup("enemies"))
		{
			QueueFree();
		}
	}
	
}




