namespace Sastavi_slagalicu
{
    public partial class Form1 : Form
    {
        private Button[,] matrica = new Button[4, 4];
        private int[,] galerija = new int[4, 4];
        private Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(626, 626);
            for (int i = 0; i < 4; i++)
            {
                {
                    for (int j = 0; j < 4; j++)
                    {
                        matrica[i, j] = new Button();
                        matrica[i, j].Size = new Size(150, 150);
                        matrica[i, j].Location = new Point(10 + j * 152, 10 + i * 152);
                        galerija[i, j] = r.Next(1, 4);
                        string fileName = galerija[i, j] + "/image_part_" + Oznaka(i, j) + ".png";
                        matrica[i, j].Image = new Bitmap(fileName);
                        matrica[i, j].Tag = i * 10 + j;
                        matrica[i, j].Click += Klikni;
                        this.Controls.Add(matrica[i, j]);
                    }
                }
            }
        }

        private string Oznaka(int i, int j)
        {
            int br = i * 4 + j + 1;
            if (br < 10) return "00" + br;
            else return "0" + br;
        }

        private void Klikni(object? sender, EventArgs e)
        {
            int tag = (int)(sender as Button).Tag;
            int i = tag / 10;
            int j = tag % 10;
            //promena galerije za odabrano polje

            galerija[i, j]++;
            if (galerija[i, j] == 4) galerija[i, j] = 1;

            string fileName = galerija[i, j] + "/image_part_" + Oznaka(i, j) + ".png";
            matrica[i, j].Image = new Bitmap(fileName);

            if (Provera() == true) MessageBox.Show("Cestitamo pobedili ste");
        }

        private bool Provera()
        {
            int kontrolnaVrednost = galerija[3, 3];

            for (int i = 0; i < 4; i++)
            {
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (galerija[i, j] != kontrolnaVrednost) return false;
                    }
                }
            }
            return true;
        }
    }
}