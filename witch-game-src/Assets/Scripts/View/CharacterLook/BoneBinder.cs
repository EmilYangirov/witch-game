using UnityEngine;

namespace View.CharacterLook
{
    [ExecuteInEditMode]
    public class BoneBinder : MonoBehaviour
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

}

