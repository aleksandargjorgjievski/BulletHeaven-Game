using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Schema;



public partial class Slime : CharacterBody2D
{
	[Export]
	private float slimeHP = 2;

	[Export]
	private float slimeScore;

	public const float Speed = 20.0f;

	public Node2D xp;

	public AnimatedSprite2D slime;

	public AnimationPlayer hitAnimation;

	public PackedScene xp_scene;

	public AudioStreamPlayer2D slimeAudioPlayer;
	
	public override void _Ready()
	{
		slime = GetNode<AnimatedSprite2D>("Slime");
		hitAnimation = GetNode<AnimationPlayer>("AnimationPlayer");
		slimeAudioPlayer = GetNode<AudioStreamPlayer2D>("/root/World/SlimeAudioPlayer");
	}


	public override void _PhysicsProcess(double delta)
	{
		var player = GetTree().GetFirstNodeInGroup("players").GetNode<AnimatedSprite2D>("Soldier");

		Vector2 velocity = Velocity;

		velocity = slime.GlobalPosition.DirectionTo(player.GlobalPosition) * Speed;

		Velocity = velocity;

		AnimationPlayer(Velocity);

		MoveAndSlide();

	}

	public void AnimationPlayer(Vector2 velocity)
	{
		slime.Play("walking");

		if (velocity.X < 0)
		{
			slime.FlipH = false;
		}
		else if (velocity.X > 0)
		{
			slime.FlipH = true;
		}
	}

	public void LoseHP(float projectileDmg)
	{
		slimeHP -= projectileDmg;
		hitAnimation.Play("hit");
		slimeAudioPlayer.Play();
		if (slimeHP <= 0)
		{
			xp_scene = GD.Load<PackedScene>("res://Scenes/experience.tscn");
			xp = xp_scene.Instantiate<Node2D>();
			GetNode<Node2D>("/root/World/PickUps").CallDeferred("add_child", xp);
			xp.GlobalPosition = GlobalPosition;
			GetTree().GetFirstNodeInGroup("players").Call("IncreaseScore", slimeScore);
			QueueFree();	
		}
	}
	
}

