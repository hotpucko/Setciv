using UnityEngine;

public static class HexMetrics {

    public const float outerRadius = 2f;//0.577f

    public const float innerRadius = outerRadius * 0.866025404f;

	public enum TileType { Water, Claypit, Forest, Mountain, Settlement, Desert, Pasture };

	public static TileType GetRandomTileType (){
		return GetRandomEnum<TileType> ();
	}

	public static T GetRandomEnum<T>()
	{
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(1, A.Length));
		return V;
	}
}
