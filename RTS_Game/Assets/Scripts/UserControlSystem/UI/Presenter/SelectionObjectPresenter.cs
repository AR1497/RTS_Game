using System.Linq;
using Abstractions;
using UnityEngine;
using UserControlSystem;

public class SelectionObjectPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    private ISelectable _activeSelectabeObject;

    void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        if (_activeSelectabeObject != null)
        {
            _activeSelectabeObject.UnsetSelected();
        }

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .FirstOrDefault(c => c != null);

        _selectedObject.SetValue(selectable);
        _activeSelectabeObject = selectable;

        if (selectable != null)
        {
            selectable.SetSelected();
        }

        if (selectable is IUnitProducer)
        {
            var mainBuilding = (IUnitProducer)selectable;
            mainBuilding.ProduceUnit();
        }
    }
}
