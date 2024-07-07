using Godot;
using System;

public partial class XPBar : ProgressBar
{
	// Called when the node enters the scene tree for the first time.

	StyleBoxFlat sb;

	public override void _Ready()
	{
		sb = new StyleBoxFlat();
		AddThemeStyleboxOverride("fill", sb);
		sb.BgColor = Color.Color8(0, 255, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
