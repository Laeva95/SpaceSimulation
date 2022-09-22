using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public const ulong K = 1000;
    public const ulong M = 1000000;
    public const ulong T = 1000000000;
    public static string Cacul(ulong _ulong)
    {
        if (_ulong > K)
        {
            return string.Format("{0:F2}K", (float)_ulong / K);
        }
        else if (_ulong > M)
        {
            return string.Format("{0:F2}M", (float)_ulong / M);
        }
        else if (_ulong > T)
        {
            return string.Format("{0:F2}T", (float)_ulong / T);
        }
        else
        {
            return $"{_ulong}";
        }

    }
}
