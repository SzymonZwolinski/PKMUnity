using UnityEngine;

public static class HidePlayer
{
    public static void HidePlayerModel()
    {
		GameObject.Find("PlayerModel").transform.localScale = new Vector3(0, 0, 0);
	}
	public static void ShowPlayerModel()
	{
		GameObject.Find("PlayerModel").transform.localScale = new Vector3(1, 1, 1);
	}
}
