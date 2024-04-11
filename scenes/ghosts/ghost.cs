using Godot;
using System;
using System.Diagnostics;

public partial class ghost : CharacterBody2D
{
	private const float Speed = 150f;
	private Random random;

	private Stopwatch timer = new();

	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		Vector2 velocity = Velocity;
		random = new Random();
		double angle = random.NextDouble() * 2 * Math.PI;

		velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
		velocity *= Speed;

		Velocity = velocity;
		MoveAndSlide();
	}

    public override void _PhysicsProcess(double delta)
	{
		var collisionInfo = MoveAndCollide(Velocity * (float)delta);
		if (collisionInfo != null)
		{
			var collidingObj = collisionInfo.GetCollider();
			if (Name == "Ghost2" && collidingObj != null && collidingObj is CharacterBody2D body2d && body2d.Name == "Pong")
			{
				var randomNum = random.Next(0, 70);

				if (randomNum < 5)
				{
					var sprite = GetNode("AnimatedSprite2D") as AnimatedSprite2D;
					sprite.Frame = 2;
					timer.Start();
				}
			}
			else{
			Velocity = Velocity.Bounce(collisionInfo.GetNormal());
			}
		}

		if(timer.IsRunning && timer.ElapsedMilliseconds > 10000){
			timer.Stop();
			timer.Reset();
			var sprite = GetNode("AnimatedSprite2D") as AnimatedSprite2D;
			sprite.Frame = 1;
		}
	}
}
