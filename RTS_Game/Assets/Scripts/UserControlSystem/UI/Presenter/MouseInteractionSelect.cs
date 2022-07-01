using System.Linq;
using UnityEngine;
using UserControlSystem;
using Zenject;

public static class MouseInteractionSelect<T>
{
    public static void GetleftClickSelectedObject(RaycastHit[] hits, [Inject] ScriptableObjectValueBase<T> scriptableValue)
    {
        var selectable = hits
        .Select(hit =>
        hit.collider.GetComponentInParent<T>())
        .Where(c => c != null)
        .FirstOrDefault();
        scriptableValue.SetValue(selectable);
    }
}
