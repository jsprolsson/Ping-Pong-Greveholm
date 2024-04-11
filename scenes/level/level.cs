using Godot;
using System;

public partial class level : Node2D
{
	private void _on_r_goal_body_entered(Node2D body)
{
	var player = GetNode("Player2") as Player;
	
	if(player != null)
	{
		var pong = GetNode("Pong") as pong;
		pong.Reset();
		SoundGoal();
		player.Score++;
	}
}

private void _on_l_goal_body_entered(Node2D body)
{
	var player = GetNode("Player") as Player;
	
	if(player != null)
	{
		var pong = GetNode("Pong") as pong;
		pong.Reset();
		SoundGoal();
		player.Score++;
	}
}

private void SoundGoal(){
	var goal = GetNode("Goal") as AudioStreamPlayer;
	GD.Print(goal);
	goal.Play();
}


}






