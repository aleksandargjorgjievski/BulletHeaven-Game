using Godot;
using System;

public partial class start_button : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	private void OnPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main.tscn");
	}
}
