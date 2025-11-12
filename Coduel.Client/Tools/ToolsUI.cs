using System.Drawing;

namespace Coduel.Client
{
    public static class ToolsUI
    {
        public static string ColorToHex(Color color) {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
        public static string ColorToHex(int r, int g, int b)
        {
            return "#"+r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
        }
    }
}
