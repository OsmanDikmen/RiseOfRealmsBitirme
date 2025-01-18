using UnityEngine;
public interface ITarget
{
    Transform GetTransform();
    bool IsValidTarget();
}
