using Godot;
using System;

public partial class ScoreL : Label
{

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var player = GetNode("../../Player") as Player;
		if (player != null)
		{
			var score = player.Score.ToString();
			GD.Print(score);
			Text = score;
		}
	}
}
