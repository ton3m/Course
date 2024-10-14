using System;
using UnityEngine;

public class DieBehaviour
{
    private readonly GameObject _user;
    private Action _onDying;

    public DieBehaviour(GameObject user, Action onDying = null)
    {
        _user = user;
        _onDying = onDying;
    }

    public void Die()
    {
        _onDying?.Invoke();
        
        UnityEngine.Object.Destroy(_user);
    }
}
