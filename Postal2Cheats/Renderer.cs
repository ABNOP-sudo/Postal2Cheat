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
        public bool teleportUpBool = false;
        public int teleportHeight = 1000000;
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
            ImGui.Begin("Postal2 Cheat GUI");
            ImGui.SetNextWindowSize(new Vector2(800, 600));
            if (ImGui.BeginTabBar("CheatMenu"))
            {
                if (ImGui.BeginTabItem("General"))
                {
                    ImGui.Checkbox("M16A2 Infinity ammo", ref M16A2Bool);
                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("Movement"))
                {
                    ImGui.InputInt("Teleport Height", ref teleportHeight);
                    if (ImGui.Button("Teleport Up"))
                    {
                        teleportUpBool = true;
                    }
                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("Misc"))
                {
                    ImGui.Checkbox("Custom GUI Colors", ref customColorsBool);
                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }
            styleGUI = ImGui.GetStyle();
            
            
            
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