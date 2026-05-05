using ClickableTransparentOverlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImGuiNET;
using System.Numerics;

namespace Postal2Cheats
{
    public class Renderer : Overlay
    {
        public bool customColorsBool = false;
        public bool M16A2Bool = false;
        private ImGuiStylePtr styleGUI;
        public Vector3 colorGUI;

        protected override void Render()
        {
            void DefaultColors()
            {
                Vector4 standartColor = new Vector4(0.19f, 0.58f, 1f, 0.5f);
                styleGUI.Colors[(int)ImGuiCol.TitleBg] = standartColor;
                styleGUI.Colors[(int)ImGuiCol.TitleBgActive] = standartColor;
                styleGUI.Colors[(int)ImGuiCol.TitleBgCollapsed] = standartColor;
            }

            styleGUI = ImGui.GetStyle();
            ImGui.Begin("Cheat GUI");
            ImGui.Checkbox("M16A2 Infinity ammo", ref M16A2Bool);
            ImGui.Checkbox("Custom GUI Colors", ref customColorsBool);
            DefaultColors();

            if (customColorsBool)
            {
                ImGui.ColorEdit3("GUI Color", ref colorGUI);
                Vector4 color4 = new Vector4(colorGUI, 1.0f);
                styleGUI.Colors[(int)ImGuiCol.TitleBg] = color4;
                styleGUI.Colors[(int)ImGuiCol.TitleBgActive] = color4;
                styleGUI.Colors[(int)ImGuiCol.TitleBgCollapsed] = color4;
            } else
            {
                DefaultColors();
            }
                ImGui.End();
        }
    }
}