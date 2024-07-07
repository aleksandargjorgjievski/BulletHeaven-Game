using Godot;
using System;

public partial class ScoreLabel : RichTextLabel
{
	// Called when the node enters the scene tree for the first time.

	Globals g;

	public override void _Ready()
	{
			g = (Globals)GetNode("/root/Globals");
			Text = "Score: " + g.totalScore.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
