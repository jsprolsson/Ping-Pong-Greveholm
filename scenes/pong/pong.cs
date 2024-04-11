using Godot;
using System;

public partial class pong : CharacterBody2D
{
	public pong()
	{
		random = new Random();
	}
	private float Speed = 950f;
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

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

		var collisionInfo = MoveAndCollide(Velocity * (float)delta);
		if(collisionInfo != null){
			var collidingObj = collisionInfo.GetCollider();

			if(collidingObj != null && collidingObj is CharacterBody2D body2d){
				
				if(body2d.Name == "Player" || body2d.Name == "Player2"){
					var root = GetTree().Root.GetNode("Level") as Node2D;
					var audio = root.GetNode("Paddle") as AudioStreamPlayer;

					if(audio != null)
						audio.Play();
				}

			}
		Vector2 newVelocity = Velocity.Bounce(collisionInfo.GetNormal());


		// Add a small random angle to the new velocity
		float angleOffset = (float)(random.NextDouble() * Math.PI / 18) - (float)(Math.PI / 36); // +/- 2.5 degrees
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
	}

	public void Reset()
	{
		Position = new Vector2(0, 0);
		_Ready();
	}
}



