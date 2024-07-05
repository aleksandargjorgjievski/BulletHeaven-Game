using Godot;
using System;

public partial class experience : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public int xpGain = 1;

	AudioStreamPlayer2D XPAudioPlayer;

	public override void _Ready()
	{
		XPAudioPlayer = GetNode<AudioStreamPlayer2D>("/root/World/XPAudioPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body.IsInGroup("players"))
		{
			XPAudioPlayer.Play();
			body.Call("IncreaseXP", xpGain);
			QueueFree();
		}
	}
}



