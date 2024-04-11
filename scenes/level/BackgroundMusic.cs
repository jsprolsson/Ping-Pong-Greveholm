using Godot;
using System;

public partial class BackgroundMusic : AudioStreamPlayer
{
	private void _on_finished(){
		Play();
	}
}
