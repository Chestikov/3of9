using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] private int _level = 1;
    public event Action<int> LevelChanged;

    public int GetLevel() => _level;

    public void SetLevel(float level)
    {
        int wholeLevel = Convert.ToInt32(level);

        if (_level != wholeLevel)
        {
            _level = wholeLevel;

            LevelChanged?.Invoke(_level);
        }
    }
}
