using Godot;
using System;

public partial class main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	PackedScene slime_scene;
	Node2D slime;
	public override void _Ready()
	{
		slime_scene = GD.Load<PackedScene>("res://Scenes/enemies.tscn");

		GetNode<Timer>("StartTimer").Start();
	
	}

		private void OnStartTimerTimeout()
	{
		GetNode<Timer>("EnemyTimer").Start();
	}


	private void OnEnemyTimerTimeout()
	{
		slime = slime_scene.Instantiate<Node2D>();

		var enemySpawnLocation = GetNode<PathFollow2D>("EnemyPath/EnemySpawnLocation");
		
		float randomSpawn = GD.Randf();
		enemySpawnLocation.ProgressRatio = randomSpawn;

		slime.Position = enemySpawnLocation.Position;

		AddChild(slime);
	}





}



