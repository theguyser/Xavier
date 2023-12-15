using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappedObjectManager
{
    public static Dictionary<string, int> snappedCounts = new Dictionary<string, int>();

    public static void RegisterAssetType(string assetType)
    {
        if (!snappedCounts.ContainsKey(assetType))
        {
            snappedCounts[assetType] = 0;
        }
    }

    public static void IncrementCount(string assetType)
    {
        if (snappedCounts.ContainsKey(assetType))
        {
            snappedCounts[assetType]++;
        }
    }

    public static void DecrementCount(string assetType)
    {
        if (snappedCounts.ContainsKey(assetType) && snappedCounts[assetType] > 0)
        {
            snappedCounts[assetType]--;
        }
    }

    public static int GetCount(string assetType)
    {
        if (snappedCounts.ContainsKey(assetType))
        {
            return snappedCounts[assetType];
        }
        return 0;
    }
}
