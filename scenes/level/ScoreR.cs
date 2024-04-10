using Godot;
using System;

public partial class ScoreR : Label
{

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var player = GetNode("../../Player2") as Player;
		if(player != null)
		{
			var score = player.Score.ToString();
			Text = score;
		}
	}
}
