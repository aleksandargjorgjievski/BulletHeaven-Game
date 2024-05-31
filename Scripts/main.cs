using Godot;
using System;
using System.Security.Cryptography;

public partial class main : Node2D
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	public float slimeHP = 2;

	PackedScene slime_scene;
	Node2D slime;

	AnimatedSprite2D soldier;
	public override void _Ready()
	{
		slime_scene = GD.Load<PackedScene>("res://Scenes/enemies.tscn");
		GetNode<Timer>("StartTimer").Start();
		soldier = GetNode<CharacterBody2D>("SoldierBody2D").GetNode<AnimatedSprite2D>("Soldier");
	}

		private void OnStartTimerTimeout()
	{
		GetNode<Timer>("EnemyTimer").Start();
	}


	private void OnEnemyTimerTimeout()
	{
		slime = slime_scene.Instantiate<Node2D>();

		Random rnd = new Random();
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





