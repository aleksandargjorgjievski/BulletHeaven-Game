using Godot;
using System;
using System.Collections.Generic;

public partial class projectiles : Area2D
{	
	[Export]
	public float projectileDmg = 1;
	public float speed = 75.0f;

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
			body.Call("LoseHP", projectileDmg);
			QueueFree();
		}
	}
}

