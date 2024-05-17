using Interactable;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
public class FoodPick : MonoBehaviour, IDetector
{
    public GameObject _meat;
    void IDetector.Interaction()
    {
        //_meat.transform.SetParent(this.transform);
        //_meat.transform.localPosition = new Vector3(0f, 0f, -0.930999994f);
    }
}
