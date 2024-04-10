using System.Runtime.InteropServices;

namespace WinFormsAppVirus
{
    public partial class Form1 : Form
    {
        // variaveis //
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

        // metodo que executa o evento de clique // 
        [DllImport("user32.dll",
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]

        public static extern void mouse_event(
            int dwFlags,
            int dx,
            int dy,
            int cButtons,
            int dwExtraInfo);

        // gerar as posições aleatorias // 
        private Random random = new Random();

        // movimento aleatorio do mouse //
        private void MoverCursor()
        {
            // obter largura da tela //
            int larguraTela = Screen.PrimaryScreen.Bounds.Width;

            // obter altura da tela //
            int alturaTela = Screen.PrimaryScreen.Bounds.Height;

            //gerar posição X aleatoria//
            int posicaoXAleatoria = random.Next(larguraTela);

            //gerar posição Y aleatoria//
            int posicaoYAleatoria = random.Next(alturaTela);

            // posição nova do cursor //
            Cursor.Position = new Point(posicaoXAleatoria, posicaoYAleatoria);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnVirus_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                // chamando o metodo que move o cursor aleatoriamente // 
                MoverCursor();

                for(int tico = 1; tico <=2; tico++)
                {
                    MouseClicar();
                }
                // cerebro dormir por 1 segundo //
                Thread.Sleep(25);
            }
        }

        private void MouseClicar()
        {
            // executa o pressionar botao esquerdo do mouse //
            mouse_event(MOUSEEVENTF_LEFTDOWN, // codigo do evento de pressionar o mouse //
                Cursor.Position.X,            // posição X do cursor //
                Cursor.Position.Y, 0, 0);     // posição Y do cursor //

            // executa o soltar o botao esquerdo do mouse //
            mouse_event(MOUSEEVENTF_LEFTUP, // codigo do evento de soltar o mouse //
                Cursor.Position.X,          // posição X do cursor //
                Cursor.Position.Y, 0, 0);   // posição Y do cursor //
        }
    }
}
