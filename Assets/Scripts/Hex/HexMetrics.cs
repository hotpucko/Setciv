using UnityEngine;

public static class HexMetrics {

    public const float outerRadius = 2f;//0.577f

    public const float innerRadius = outerRadius * 0.866025404f;

	public enum TileType {Claypit, Forest, Mountain, Settlement, Null};

	public static TileType GetRandomTileType (){
		return GetRandomEnum<TileType> ();
	}

	public static T GetRandomEnum<T>()
	{
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
		return V;
	}
}
