using UnityEngine;

namespace WEART
{
    public class MaterialChanger : MonoBehaviour
    {
        [SerializeField] private Renderer[] _objectRenderers; // Array of Renderers for each part
        [SerializeField] private Material[] _targetMaterials; // Array of target materials
        private int _currentMaterialIndex = 0; // Index of the current material
        private Color _storedColor; // Store the current color before changing material

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
            for (int i = 0; i < _targetMaterials.Length; i++)
            {
                KeyCode keyCode = KeyCode.Alpha1 + i; // Assumes buttons are assigned keys 1, 2, 3, ...
                if (Input.GetKeyDown(keyCode))
                {
                    ChangeMaterial(i);
                }
            }
        }

        public void ChangeMaterial(int materialIndex)
        {
            if (_objectRenderers != null && materialIndex >= 0 && materialIndex < _targetMaterials.Length)
            {
                // Store the current color before changing the material
                _storedColor = _objectRenderers[0].material.color;

                foreach (Renderer renderer in _objectRenderers)
                {
                    renderer.material = _targetMaterials[materialIndex];
                }

                // Apply the stored color back to all renderers after changing the material
                foreach (Renderer renderer in _objectRenderers)
                {
                    renderer.material.color = _storedColor;
                }

                _currentMaterialIndex = materialIndex;
            }
            else
            {
                Debug.LogWarning("Renderers are null or invalid material index. Please check your setup.");
            }
        }
    }
}