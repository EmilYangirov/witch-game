using UnityEngine;

[ExecuteInEditMode]
public class LinkifyBone : MonoBehaviour
{
    [SerializeField]
    private Transform _targetIK;
    private void Update()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        if (_targetIK == null)
            return;

        if (transform.position == _targetIK.position && transform.rotation == _targetIK.rotation)
            return;

        transform.position = _targetIK.position;
        transform.rotation = _targetIK.rotation;
    }
}
