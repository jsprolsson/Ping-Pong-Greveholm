using Godot;
using System;

public partial class AudioStreamPlayer : Godot.AudioStreamPlayer
{
	private void _on_finished()
{
	Play();
}

}


