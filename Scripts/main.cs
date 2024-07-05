using Godot;
using System;
using System.Security.Cryptography;

public partial class main : Node2D
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	public Godot.Collections.Array<PackedScene> Scenes { get; set; }
	Node2D slime;

	RichTextLabel seconds_text, minutes_text;

	AnimatedSprite2D soldier;
	public override void _Ready()
	{
		GetNode<Timer>("StartTimer").Start();
		soldier = GetNode<CharacterBody2D>("SoldierBody2D").GetNode<AnimatedSprite2D>("Soldier");
		seconds_text = GetNode<CanvasLayer>("HUD").GetNode<Label>("GameTimeLabel").GetNode<RichTextLabel>("Seconds");
		minutes_text = GetNode<CanvasLayer>("HUD").GetNode<Label>("GameTimeLabel").GetNode<RichTextLabel>("Minutes");
	}

		private void OnStartTimerTimeout()
	{
		GetNode<Timer>("EnemyTimer").Start();
	}


	private void OnEnemyTimerTimeout()
	{

		Random rnd = new Random();

		int seconds = int.Parse(seconds_text.Text);
		int minutes = int.Parse(minutes_text.Text.Replace(":", ""));
		int time = minutes * 60 + seconds;

		if (time <= 30)
		{
			slime = Scenes[0].Instantiate<Node2D>();
		}
		else if (time > 30 && time <= 60)
		{
			slime = Scenes[rnd.Next(2)].Instantiate<Node2D>();
		}
		else if (time > 60 && time <= 90)
		{
			slime = Scenes[1].Instantiate<Node2D>();
		}
		else if (time > 90 && time <= 120)
		{
			slime = Scenes[rnd.Next(3)].Instantiate<Node2D>();
		}
		else if (time > 120 && time <= 150)
		{
			slime = Scenes[rnd.Next(1,3)].Instantiate<Node2D>();
		}
		else if (time > 150 && time <= 180)
		{
			slime = Scenes[2].Instantiate<Node2D>();
		}

		int randomX = rnd.Next(0,210) * (rnd.Next(0, 2) * 2 - 1);
		int randomY;
		if (randomX >= 160 || randomX <= -160)
		{
			randomY = rnd.Next(0,100) * (rnd.Next(0, 2) * 2 - 1);
		}
		else
		{
			randomY = rnd.Next(90,100) * (rnd.Next(0, 2) * 2 - 1);
		}
		slime.Position = soldier.GlobalPosition + new Vector2(randomX, randomY);
		AddChild(slime);
	}
}





