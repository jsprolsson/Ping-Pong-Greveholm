using Godot;
using System;

public partial class pong : CharacterBody2D
{
	public pong()
	{
		random = new Random();
	}
	public float Speed = 950f;
	private Random random;

	public override void _Ready()
	{
		Vector2 velocity;

		// Choose a direction: left or right.
		if (random.Next(0, 2) == 0)
		{
			// Left direction
			velocity = new Vector2(-1, 0);
		}
		else
		{
			// Right direction
			velocity = new Vector2(1, 0);
		}

		velocity *= Speed;
		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _PhysicsProcess(double delta)
	{
		var collisionInfo = MoveAndCollide(Velocity * (float)delta);
		float angleOffset;

		if(collisionInfo != null){
			var collidingObj = collisionInfo.GetCollider();

			if(collidingObj != null && collidingObj is CharacterBody2D body2d){
				
				if(body2d.Name == "Player" || body2d.Name == "Player2"){
					var root = GetTree().Root.GetNode("Level") as Node2D;
					var audio = root.GetNode("Paddle") as AudioStreamPlayer;

					if(audio != null)
						audio.Play();
				
				angleOffset = (float)(random.NextDouble() * Math.PI / 4.5) - (float)(Math.PI / 9);
				}

			}

			Vector2 newVelocity = Velocity.Bounce(collisionInfo.GetNormal());
		angleOffset = (float)(random.NextDouble() * Math.PI / 18) - (float)(Math.PI / 36);
		
		newVelocity = newVelocity.Rotated(angleOffset);
		Velocity = newVelocity;

		}
		
	}


	public override void _Process(double delta)
	{
		// Move the pong
		if (Input.IsActionPressed("r"))
		{
			Reset();
		}

		
		if(Input.IsActionPressed("z") && Speed < 10000)
		{
			Speed += 10;
		}
		else if(Input.IsActionPressed("x"))
		{
			Speed -= 10;
		}
		else if(Input.IsActionPressed("esc")){
			GetTree().ChangeSceneToFile("res://scenes/main/main.tscn");
		}
	}

	public void Reset()
	{
		Position = new Vector2(0, 0);
		_Ready();
	}
}



