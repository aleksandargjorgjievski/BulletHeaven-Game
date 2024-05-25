using Godot;
using System;

public partial class projectiles : Area2D
{
	public float speed = 30.0f;

	public override void _PhysicsProcess(double delta)
	{
		Position += Transform.X * speed * (float)delta;
	}
}
