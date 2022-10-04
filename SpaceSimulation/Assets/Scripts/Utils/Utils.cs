using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public const ulong K = 1000;
    public const float _K = 0.001f;
    public const ulong M = 1000000;
    public const float _M = 0.000001f;
    public const ulong B = 1000000000;
    public const float _B = 0.000000001f;
    public const ulong T = 1000000000000;
    public const float _T = 0.000000000001f;
    public static string Caculation(ulong _ulong)
    {
        if (_ulong >= T)
        {
            return string.Format("{0:F1}T", (float)_ulong * _T);
        }
        else if (_ulong >= B)
        {
            return string.Format("{0:F1}B", (float)_ulong * _B);
        }
        else if (_ulong >= M)
        {
            return string.Format("{0:F1}M", (float)_ulong * _M);
        }
        else if (_ulong >= K)
        {
            return string.Format("{0:F1}K", (float)_ulong * _K);
        }
        else
        {
            return $"{_ulong}";
        }
    }
}
