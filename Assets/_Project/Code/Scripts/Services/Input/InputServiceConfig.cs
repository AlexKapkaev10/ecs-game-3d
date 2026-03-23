using UnityEngine;

namespace Project.Services
{
    [CreateAssetMenu(fileName = nameof(InputServiceConfig), menuName = "Config/Service/Input")]
    public class InputServiceConfig : ScriptableObject
    {
        [field: SerializeField] public float LookMax { get; private set; } = 75f;
        [field: SerializeField] public float LookMin { get; private set; } = -86f;
    }
}