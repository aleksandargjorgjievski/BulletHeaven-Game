using Godot;
using System;

public partial class experience : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public int xpGain = 1;

	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body.IsInGroup("players"))
		{
			body.Call("IncreaseXP", xpGain);
			QueueFree();
		}
	}
}



