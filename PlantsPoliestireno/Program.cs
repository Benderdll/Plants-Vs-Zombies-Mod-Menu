using ImGuiNET;
using ClickableTransparentOverlay;
using Swed32;
using System.Runtime.InteropServices;

namespace PlantsPoliestireno
{

    public class Program : Overlay
    {

        bool solesNoGastan = false;
        bool instantRefill = false;
        bool solesValen99 = false;

        IntPtr moduleBase;
        int sunAddress = 0x1F636;
        int refillAddress = 0x958C5;

        int sunAddAddress = 0x1F4D0;
        //Swed swed = new Swed("popcapgame1");
        Swed swed;

         [DllImport("user32.dll")]
         static extern short GetAsyncKeyState(int vKey);
            bool showWindow = true;
        protected override void Render()
        {

            if (GetAsyncKeyState(0x70)<0) // Comprueba si se ha presionado la tecla Tabulador
            {
                showWindow = !showWindow; // Cambia el estado de visibilidad de la ventana
                Thread.Sleep(200);
            }

            if (showWindow)
            {
                ImGui.SetNextWindowSize(new System.Numerics.Vector2(300, 300));

                cambiarColores();

                ImGui.Begin("Poliestireno Mod Menu");
                if (ImGui.BeginTabBar("Chetitos"))
                {
                    if (ImGui.BeginTabItem("Cheat's"))
                    {
                        ImGui.Text("Cheat's Tab");
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Checkbox("Don't spend sun's", ref solesNoGastan);
                        ImGui.Checkbox("No cooldown ", ref instantRefill);
                        ImGui.Checkbox("Suns give 9990", ref solesValen99);
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        
                        if (ImGui.Button("Hide Mod Menu"))
                        {
                            showWindow = !showWindow;
                        }
                        ImGui.Text("Or Press F1 to hide");
                        ImGui.Text("F4 Close Mod Menu");
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Credits"))
                    {
                        ImGui.Text("Este es el primer Cheat que hago.");
                        ImGui.Text("He utilizado ImGui para la interfaz");
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Text("This is the first Cheat I made.");
                        ImGui.Text("I have used ImGui for the interface");
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGui.Text("Made in C#");
                        ImGui.EndTabItem();
                    }


                    if (GetAsyncKeyState(0x73) < 0) // Comprueba si se ha presionado la tecla F1
                    {
                        Environment.Exit(0);
                    }
                    if (ImGui.BeginTabItem("Close Mod Menu"))
                    {
                        Environment.Exit(0);
                        ImGui.EndTabItem();
                    }
                    ImGui.End();
                }
            }
            else
            {
                return;
            }

        }

        private static void cambiarColores()
        {
            ImGui.PushStyleColor(ImGuiCol.TitleBgActive, new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.Tab, new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.TabActive, new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.TabHovered, new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 0.7f)); // Cambia el color de la pestaña al pasar el ratón por encima a verde
            ImGui.PushStyleColor(ImGuiCol.Border, new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 0.7f));
            ImGui.PushStyleColor(ImGuiCol.CheckMark, new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 0.5f));
            ImGui.PushStyleColor(ImGuiCol.FrameBgHovered, new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 0.7f));
        }

        public void HackLogic()
        {
            while (true)
            {
                moduleBase = swed.GetModuleBase(".exe");
                if (solesNoGastan)
                {
                    swed.WriteBytes(moduleBase, sunAddress, "90 90 90 90 90 90");

                }
                else
                {
                    swed.WriteBytes(moduleBase, sunAddress, "89 B7 78 55 00 00");
                }

                if (instantRefill)
                {
                    swed.WriteBytes(moduleBase, refillAddress, "90 90");
                }
                else
                {
                    swed.WriteBytes(moduleBase, refillAddress, "7E 14");

                }

                if (solesValen99)
                {
                    swed.WriteBytes(moduleBase, sunAddAddress, "89 B7 78 55 00 00");
                }
                else
                {
                    swed.WriteBytes(moduleBase, sunAddAddress, "01 88 78 55 00 00");
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Made by Poliestireno");
            Program program = new Program();
            program.Start().Wait();

            while (true)
            {
                try
                {
                    program.swed = new Swed("popcapgame1");
                    Console.WriteLine("PlantsVsZombies encontrado");
                    Console.WriteLine("Iniciando Mod Menu...");
                    break; // Si no se produce ninguna excepción, se sale del bucle
                }
                catch
                {
                    Console.WriteLine("PlantsVsZombies no encontrado, reintentando en 5 segundos...");
                    Thread.Sleep(5000); // Espera 5 segundos antes de volver a intentarlo
                }
            }

            Thread hackThread = new Thread(program.HackLogic) { IsBackground = true };
            Console.WriteLine("()------------------()");
            Console.WriteLine("Mod Menu iniciado");
            Console.WriteLine("()------------------()");
            hackThread.Start();
        }

    }
}