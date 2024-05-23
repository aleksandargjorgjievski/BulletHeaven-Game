using Godot;
using System;

public partial class main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var slime_scene = GD.Load<PackedScene>("res://Scenes/enemies.tscn");

		var slime = slime_scene.Instantiate();
		
		AddChild(slime);
	}

}
