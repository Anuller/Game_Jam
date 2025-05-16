using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace SOG.CVDFilter
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Volume))]
    public class CVDFilter : MonoBehaviour
    {
        Volume postProcessVolume;

        [SerializeField]
        private CVDProfilesSO profiles;
        [SerializeField] VisionTypeNames currentType;
        public VisionTypeInfo SelectedVisionType { get; private set; }

        private const string soFileName = "CVDProfiles";

        void Reset()
        {
            Setup();
            ChangeProfile();
        }

        void Start()
        {
            Setup();
            ChangeProfile();
        }

        void Setup()
        {
            AssignProfileSO();
            ConfigureVolume();
        }

        void AssignProfileSO()
        {
            // Carregar o ScriptableObject a partir da pasta Resources
            profiles = Resources.Load<CVDProfilesSO>(soFileName);
            if (profiles == null)
            {
                Debug.LogErrorFormat("[{0}] ({1}): Error - Unable to locate file \"{2}\". "
                + "There should be a single ScriptableObject called \"{2}.asset\" in Resources", GetType().Name, MethodBase.GetCurrentMethod().Name, soFileName);
                return;
            }

            SelectedVisionType = profiles.VisionTypes[0];
        }

        void ConfigureVolume()
        {
            postProcessVolume = GetComponent<Volume>();
            postProcessVolume.isGlobal = true;
        }

        public void ChangeProfile()
        {
            if (profiles == null)
            {
                Debug.LogErrorFormat("[{0}] ({1}): Error - Unable to locate {2}.", GetType().Name, MethodBase.GetCurrentMethod().Name, soFileName);
                return;
            }

            SelectedVisionType = profiles.VisionTypes[(int)currentType];
            postProcessVolume.profile = SelectedVisionType.profile;
        }
    }

    public enum VisionTypeNames
    {
        Normal,
        Protanopia,
        Protanomaly,
        Deuteranopia,
        Deuteranomaly,
        Tritanopia,
        Tritanomaly,
        Achromatopsia,
        Achromatomaly
    }

    [System.Serializable]
    public struct VisionTypeInfo
    {
        public VisionTypeNames typeName;
        public string description;
        public VolumeProfile profile;
        public Texture2D previewImage;
    }
}
