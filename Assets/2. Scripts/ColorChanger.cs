using UnityEngine;

namespace WEART
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private Renderer[] _objectRenderers; // Array of Renderers for each part
        [SerializeField] private Color[] _targetColors; // Array of target colors
        private int _currentColorIndex = 0; // Index of the current color

        void Start()
        {
            if (_objectRenderers == null || _objectRenderers.Length == 0)
            {
                // If Renderers are not assigned in the inspector, try to get them automatically
                _objectRenderers = GetComponentsInChildren<Renderer>();

                if (_objectRenderers == null || _objectRenderers.Length == 0)
                {
                    Debug.LogError("No Renderers found on the GameObject or its children.");
                }
            }
        }

        void Update()
        {
            // Assuming you have multiple buttons, each assigned a unique keycode
            for (int i = 0; i < _targetColors.Length; i++)
            {
                KeyCode keyCode = KeyCode.Alpha1 + i; // Assumes buttons are assigned keys 1, 2, 3, ...
                if (Input.GetKeyDown(keyCode))
                {
                    ChangeColor(i);
                }
            }
        }

        public void ChangeColor(int colorIndex)
        {
            if (_objectRenderers != null && colorIndex >= 0 && colorIndex < _targetColors.Length)
            {
                foreach (Renderer renderer in _objectRenderers)
                {
                    renderer.material.color = _targetColors[colorIndex];
                }

                _currentColorIndex = colorIndex;
            }
            else
            {
                Debug.LogWarning("Renderers are null or invalid color index. Please check your setup.");
            }
        }
    }
}