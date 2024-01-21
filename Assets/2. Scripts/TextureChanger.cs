using UnityEngine;
using UnityEngine.UI;
using WeArt.Components;
using WeArt.Core;

public class TextureChanger : MonoBehaviour
{
    public WeArtTouchableObject[] weArtTouchableObjects; // Array of WeArtTouchableObjects
    public Temperature[] associatedTemperatures; // Array of associated temperatures
    public Force[] associatedStiffness; // Array of associated stiffness
    public WeArt.Core.Texture[] associatedTextures; // Array of associated textures

    // Method to handle texture change along with temperature and stiffness
    public void ChangeTexture(int textureIndex)
    {
        if (textureIndex >= 0 && textureIndex < associatedTextures.Length)
        {
            // Ensure arrays are of equal length
            int numObjects = weArtTouchableObjects.Length;

            if (numObjects == associatedTemperatures.Length && numObjects == associatedStiffness.Length)
            {
                for (int i = 0; i < numObjects; i++)
                {
                    var touchableObject = weArtTouchableObjects[i];

                    // Set the corresponding temperature, stiffness, and texture for each WeArtTouchableObject
                    if (touchableObject != null)
                    {
                        touchableObject.Temperature = associatedTemperatures[textureIndex];
                        touchableObject.Stiffness = associatedStiffness[textureIndex];
                        touchableObject.Texture = associatedTextures[textureIndex];
                    }
                }
            }
            else
            {
                Debug.LogError("Arrays are not of equal length. Ensure each WeArtTouchableObject has a corresponding Temperature and Stiffness element.");
            }
        }
    }
}