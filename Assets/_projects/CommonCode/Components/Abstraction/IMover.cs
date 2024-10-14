using System;
using UnityEngine;

namespace ItemsGame
{
    public interface IMover
    {
        float Speed { get; }
        Vector3 Position { get; }
        public void Move(Vector3 direction);
    }
}