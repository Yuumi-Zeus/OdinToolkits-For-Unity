using Sirenix.OdinInspector;

namespace Yuumix.OdinToolkits.Editor
{
    [OdinToolkitsAttributeExample]
    public class ToggleLeftExample : ExampleSO
    {
        [InfoBox("绘制勾选框在左侧")]
        [ToggleLeft]
        public bool leftToggled;

        [EnableIf("leftToggled")]
        public int A;

        [EnableIf("leftToggled")]
        public bool B;

        [EnableIf("leftToggled")]
        public bool C;
    }
}
