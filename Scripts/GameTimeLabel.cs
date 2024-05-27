using Godot;
using System;

public partial class GameTimeLabel : Label
{
	// Called when the node enters the scene tree for the first time.

	RichTextLabel gameTimeTextLabel;

	public override void _Ready()
	{
		gameTimeTextLabel = GetNode<RichTextLabel>("GameTimeTextLabel");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		gameTimeTextLabel.Text = "HI";
	}
}
