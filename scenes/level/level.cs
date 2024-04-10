using Godot;
using System;

public partial class level : Node2D
{
	private void _on_r_goal_body_entered(Node2D body)
{
	var player = GetNode("Player2") as Player;
	
	if(player != null)
	{
		player.Score++;
		GD.Print(player.Score);
	}
}

private void _on_l_goal_body_entered(Node2D body)
{
	var player = GetNode("Player") as Player;
	
	if(player != null)
	{
		player.Score++;
		GD.Print(player.Score);
	}
}


}






