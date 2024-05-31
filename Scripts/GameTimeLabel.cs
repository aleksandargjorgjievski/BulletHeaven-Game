using Godot;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public partial class GameTimeLabel : Label
{
	// Called when the node enters the scene tree for the first time.

	// variables for the time
	float time = 0.0f;
	int seconds = 0;
	int minutes = 0;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		time += (float)delta;
		seconds = (int)time % 60;
		minutes = (int)time / 60 % 60;
		GetNode<RichTextLabel>("Seconds").Text = seconds.ToString("00");
		GetNode<RichTextLabel>("Minutes").Text = minutes.ToString("00:");
		StopClock(minutes);
	}

	public void StopClock (int minutes)
	{
		if (minutes >= 10)
		{
			SetProcess(false);
		}
	}
}
