using Sirenix.OdinInspector;
using UnityEngine;

namespace Yuumix.OdinToolkits.Editor
{
    [OdinToolkitsAttributeExample]
    public class SuppressInvalidErrorExample : ExampleSO
    {
        [Range(0, 10)]
        public string InvalidAttributeError = "此特性不匹配，会报错";

        [Range(0, 10)]
        [SuppressInvalidAttributeError]
        public string SuppressedError = "此特性不匹配，但是标记了抑制，也不会报错";
    }
}
