using UnityEngine;

public class GameLocation : ScriptableObject
{
	public GameLocation(Sprite backgroundImage, string name, bool foreGround = false)
	{
		BackgroundImage = backgroundImage;
		Name = name;
		ForeGround = foreGround;
	}

	public Sprite BackgroundImage { get; private set; }
	public bool ForeGround { get; private set; }
	public string Name { get; private set; }
}