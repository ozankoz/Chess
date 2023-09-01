using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] harfler = { "A", "B", "C", "D", "E", "F", "G", "H" };
        ArrayList ihtimalkareler = new ArrayList();
        string secilikare = "";
        Label secililabel = null;
        bool turn = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            TahtaOlustur();
        }

        private void TahtaOlustur()
        {
            bool beyazkare = true;
            int satir = 0;
            int kacinci = 0;
            int iks = 0;
            int ye = 40;
            for (int i = 8; i > 0; i--)
            {
                Label lbl = new Label();
                lbl.BackColor = Color.Transparent;
                lbl.Size = new System.Drawing.Size(12, 12);
                lbl.Tag = "rakam";
                lbl.Text = i.ToString();
                panelBoard.Controls.Add(lbl);
            }
            foreach (Label lbl in panelBoard.Controls)
            {
                if (lbl.Tag == "rakam")
                {
                    kacinci++;
                    lbl.Location = new Point(5, ye);
                    ye += 51;

                }
            }
            for (int i = 1; i < 9; i++)
            {
                Label lbl = new Label();
                lbl.BackColor = Color.Transparent;
                lbl.Size = new System.Drawing.Size(12, 12);
                lbl.Tag = "harf";
                lbl.Text = harfler[i - 1];
                panelBoard.Controls.Add(lbl);
            }
            iks = 38;
            foreach (Label lbl in panelBoard.Controls)
            {
                if (lbl.Tag == "harf")
                {
                    lbl.Location = new Point(iks, 435);
                    iks += 51;
                }
            }
            for (int i = 0; i < 64; i++)
            {
                Label lbl = new Label();
                lbl.Click += lbl_Click;
                lbl.Tag = "kare";
                lbl.Height = lbl.Width = 50;
                lbl.Padding = new Padding(0);
                lbl.Margin = new Padding(0);
                if (i / 8 > satir)
                {
                    satir = i / 8;
                    if (beyazkare)
                    {
                        beyazkare = false;
                    }
                    else
                    {
                        beyazkare = true;
                    }
                }
                lbl.Name = harfler[(i % 8)] + ((satir - 8) * -1).ToString();
                if (lbl.Name == "A8")
                {
                    lbl.Tag = "siyahkale";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahkale.png");
                }
                if (lbl.Name == "B8")
                {
                    lbl.Tag = "siyahat";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahat.png");
                }
                if (lbl.Name == "C8")
                {
                    lbl.Tag = "siyahfil";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahfil.png");
                }
                if (lbl.Name == "D8")
                {
                    lbl.Tag = "siyahvezir";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahvezir.png");
                }
                if (lbl.Name == "E8")
                {
                    lbl.Tag = "siyahsah";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahsah.png");
                }
                if (lbl.Name == "F8")
                {
                    lbl.Tag = "siyahfil";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahfil.png");
                }
                if (lbl.Name == "G8")
                {
                    lbl.Tag = "siyahat";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahat.png");
                }
                if (lbl.Name == "H8")
                {
                    lbl.Tag = "siyahkale";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahkale.png");
                }
                if (lbl.Name.Substring(1, 1) == "7")
                {
                    lbl.Tag = "siyahpiyon";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\siyahpiyon.png");
                }
                if (lbl.Name == "A1")
                {
                    lbl.Tag = "beyazkale";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazkale.png");
                }
                if (lbl.Name == "B1")
                {
                    lbl.Tag = "beyazat";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazat.png");
                }
                if (lbl.Name == "C1")
                {
                    lbl.Tag = "beyazfil";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazfil.png");
                }
                if (lbl.Name == "D1")
                {
                    lbl.Tag = "beyazvezir";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazvezir.png");
                }
                if (lbl.Name == "E1")
                {
                    lbl.Tag = "beyazsah";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazsah.png");
                }
                if (lbl.Name == "F1")
                {
                    lbl.Tag = "beyazfil";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazfil.png");
                }
                if (lbl.Name == "G1")
                {
                    lbl.Tag = "beyazat";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazat.png");
                }
                if (lbl.Name == "H1")
                {
                    lbl.Tag = "beyazkale";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazkale.png");
                }
                if (lbl.Name.Substring(1, 1) == "2")
                {
                    lbl.Tag = "beyazpiyon";
                    lbl.Image = (Bitmap)Image.FromFile(Application.StartupPath + "\\images\\beyazpiyon.png");
                }
                if (beyazkare)
                {
                    lbl.BackColor = Color.SandyBrown;
                    beyazkare = false;
                }
                else
                {
                    lbl.BackColor = Color.DarkRed;
                    beyazkare = true;
                }
                panelBoard.Controls.Add(lbl);
            }
            iks = 20;
            ye = 20;
            kacinci = 0;
            foreach (Label lbl in panelBoard.Controls)
            {
                if (lbl.BackColor != Color.Transparent)
                {
                    kacinci++;
                    lbl.Location = new Point(iks, ye);
                    iks += 51;
                    if (iks >= 400)
                    {
                        iks = 20;
                    }
                    ye = ((kacinci / 8) * 50) + (kacinci / 8) + 20;
                }
            }
        }

        void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (turn)
            {
                if (lbl.Tag.ToString().IndexOf("siyah") > -1 && secilikare == "")
                {
                    return;
                }
                else if (lbl.Tag.ToString().IndexOf("siyah") > -1 && secilikare != "")
                {
                    bool ihtimal = false;
                    foreach (string item in ihtimalkareler)
                    {
                        if (item == lbl.Name)
                        {
                            ihtimal = true;
                        }
                    }
                    if (ihtimal == false)
                    {
                        return;
                    }
                }
            }
            if (turn == false)
            {
                if (lbl.Tag.ToString().IndexOf("beyaz") > -1 && secilikare == "")
                {
                    return;
                }
                else if (lbl.Tag.ToString().IndexOf("beyaz") > -1 && secilikare != "")
                {
                    bool ihtimal = false;
                    foreach (string item in ihtimalkareler)
                    {
                        if (item == lbl.Name)
                        {
                            ihtimal = true;
                        }
                    }
                    if (ihtimal == false)
                    {
                        return;
                    }
                }
            }
            if (lbl.Image != null && lbl.BorderStyle == BorderStyle.None)
            {
                foreach (string ihtimalkare in ihtimalkareler)
                {
                    if (lbl.Name == ihtimalkare)
                    {
                        foreach (Label item in panelBoard.Controls)
                        {
                            if (item.Name == secilikare)
                            {
                                lbl.Image = item.Image;
                                lbl.Tag = item.Tag;
                                item.Tag = "kare";
                                item.Image = null;
                                if (turn)
                                {
                                    turn = false;
                                }
                                else
                                {
                                    turn = true;
                                }
                                secilikare = "";
                                ihtimalkareler.Remove(ihtimalkare);
                                foreach (string kalanihtimalkare in ihtimalkareler)
                                {
                                    foreach (Label labl in panelBoard.Controls)
                                    {
                                        if (labl.Name == kalanihtimalkare && labl.Tag.ToString().IndexOf("siyah") == -1 && labl.Tag.ToString().IndexOf("beyaz") == -1)
                                        {
                                            labl.Image = null;
                                        }
                                        labl.BorderStyle = BorderStyle.None;
                                    }
                                }
                                lbl.BorderStyle = BorderStyle.Fixed3D;
                                ihtimalkareler.Clear();
                                return;
                            }
                        }
                    }
                }
                foreach (Label item in panelBoard.Controls)
                {
                    item.BorderStyle = BorderStyle.None;
                    foreach (string ihtimalkare in ihtimalkareler)
                    {
                        if (ihtimalkare == item.Name && item.Tag.ToString().IndexOf("siyah") == -1 && item.Tag.ToString().IndexOf("beyaz") == -1)
                        {
                            item.Image = null;
                        }
                    }
                }
                lbl.BorderStyle = BorderStyle.Fixed3D;
                Piyon(lbl);
                At(lbl);
                kale(lbl);
            }
            else
            {
                secilikare = "";
                foreach (Label item in panelBoard.Controls)
                {
                    item.BorderStyle = BorderStyle.None;
                    foreach (string ihtimalkare in ihtimalkareler)
                    {
                        if (ihtimalkare == item.Name && item.Tag.ToString().IndexOf("siyah") == -1 && item.Tag.ToString().IndexOf("beyaz") == -1)
                        {
                            item.Image = null;
                        }
                    }
                }
                ihtimalkareler.Clear();
            }
        }

        private void kale(Label lbl)
        {
            if (lbl.Tag.ToString().IndexOf("kale") > -1)
            {
                secilikare = lbl.Name;
                secililabel = lbl;
                ihtimalkareler.Clear();
                int kacinciharf = 0;
                foreach (string harf in harfler)
                {
                    if (harf == lbl.Name.Substring(0, 1))
                    {
                        foreach (Label item in panelBoard.Controls)
                        {
                            int sutun = Convert.ToInt32(lbl.Name.Substring(1, 1));
                            for (int i = kacinciharf; i >= 0; i--)
                            {
                                if (item.Name == harfler[i] + lbl.Name.Substring(1, 1))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                            for (int i = kacinciharf; i <= 7; i++)
                            {
                                if (item.Name == harfler[i] + lbl.Name.Substring(1, 1))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                            for (int i = sutun - 1; i >= 0; i--)
                            {
                                if (item.Name == lbl.Name.Substring(0, 1) + i.ToString())
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                            for (int i = sutun + 1; i <= 8; i++)
                            {
                                if (item.Name == lbl.Name.Substring(0, 1) + i.ToString())
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                        }
                        ArrayList silinecekihtimaller = new ArrayList();
                        foreach (string ihtimalkare in ihtimalkareler)
                        {
                            foreach (Label label in panelBoard.Controls)
                            {
                                if (label.Name == ihtimalkare && ((lbl.Tag.ToString().IndexOf("beyaz") > -1 && label.Tag.ToString().IndexOf("beyaz") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && label.Tag.ToString().IndexOf("siyah") > -1)))
                                {
                                    if (Convert.ToInt32(label.Name.Substring(1, 1)) < Convert.ToInt32(lbl.Name.Substring(1, 1)))
                                    {
                                        int denitibaren = Convert.ToInt32(label.Name.Substring(1, 1));
                                        for (int i = 1; i <= denitibaren; i++)
                                        {
                                            silinecekihtimaller.Add(label.Name.Substring(0, 1) + i);
                                        }
                                    }
                                    if (Convert.ToInt32(label.Name.Substring(1, 1)) > Convert.ToInt32(lbl.Name.Substring(1, 1)))
                                    {
                                        int denitibaren = Convert.ToInt32(label.Name.Substring(1, 1));
                                        for (int i = denitibaren; i < 9; i++)
                                        {
                                            silinecekihtimaller.Add(label.Name.Substring(0, 1) + i);
                                        }
                                    }
                                    int ihtimalharfsirasi = 0;
                                    bool bulundu = false;
                                    foreach (string ihtimalharfsira in harfler)
                                    {
                                        if (ihtimalharfsira == ihtimalkare.Substring(0, 1))
                                        {
                                            bulundu = true;
                                        }
                                        else if (bulundu == false)
                                        {
                                            ihtimalharfsirasi++;
                                        }
                                    }
                                    if (kacinciharf > ihtimalharfsirasi)
                                    {
                                        for (int i = 0; i < ihtimalharfsirasi; i++)
                                        {
                                            silinecekihtimaller.Add(harfler[i] + lbl.Name.Substring(1, 1));
                                        }
                                    }
                                    if (kacinciharf < ihtimalharfsirasi)
                                    {
                                        for (int i = ihtimalharfsirasi + 1; i < 8; i++)
                                        {
                                            silinecekihtimaller.Add(harfler[i] + lbl.Name.Substring(1, 1));
                                        }
                                    }
                                }
                                if (label.Name == ihtimalkare && ((lbl.Tag.ToString().IndexOf("beyaz") > -1 && label.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && label.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    if (Convert.ToInt32(label.Name.Substring(1, 1)) < Convert.ToInt32(lbl.Name.Substring(1, 1)))
                                    {
                                        int denitibaren = Convert.ToInt32(label.Name.Substring(1, 1));
                                        for (int i = 1; i <= denitibaren - 1; i++)
                                        {
                                            silinecekihtimaller.Add(label.Name.Substring(0, 1) + i);
                                        }
                                    }
                                    if (Convert.ToInt32(label.Name.Substring(1, 1)) > Convert.ToInt32(lbl.Name.Substring(1, 1)))
                                    {
                                        int denitibaren = Convert.ToInt32(label.Name.Substring(1, 1));
                                        for (int i = denitibaren + 1; i < 9; i++)
                                        {
                                            silinecekihtimaller.Add(label.Name.Substring(0, 1) + i);
                                        }
                                    }
                                }
                            }
                        }
                        foreach (string silinecekihtimal in silinecekihtimaller)
                        {
                            ihtimalkareler.Remove(silinecekihtimal);
                            foreach (Label silineceklabel in panelBoard.Controls)
                            {
                                if (silinecekihtimal == silineceklabel.Name && silineceklabel.Tag.ToString().IndexOf("beyaz") == -1 && silineceklabel.Tag.ToString().IndexOf("siyah") == -1)
                                {
                                    silineceklabel.Image = null;
                                }
                            }
                        }
                        silinecekihtimaller.Clear();
                    }
                    else
                    {
                        kacinciharf++;
                    }
                }
            }
        }

        private void At(Label lbl)
        {
            if (lbl.Tag.ToString().IndexOf("at") > -1)
            {
                secilikare = lbl.Name;
                secililabel = lbl;
                int kacinciharf = 0;
                foreach (string harf in harfler)
                {
                    if (harf == lbl.Name.Substring(0, 1))
                    {
                        foreach (Label item in panelBoard.Controls)
                        {
                            if (kacinciharf - 1 > -1)
                            {
                                if (item.Name == harfler[kacinciharf - 1] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 2).ToString() && (item.Image == null || (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                                if (item.Name == harfler[kacinciharf - 1] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 2).ToString() && (item.Image == null || (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                            if (kacinciharf + 1 < 8)
                            {
                                if (item.Name == harfler[kacinciharf + 1] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 2).ToString() && (item.Image == null || (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                                if (item.Name == harfler[kacinciharf + 1] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 2).ToString() && (item.Image == null || (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                            if (kacinciharf - 2 > -1)
                            {
                                if (item.Name == harfler[kacinciharf - 2] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 1).ToString() && (item.Image == null || (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                                if (item.Name == harfler[kacinciharf - 2] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 1).ToString() && (item.Image == null || (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                            if (kacinciharf + 2 < 8)
                            {
                                if (item.Name == harfler[kacinciharf + 2] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 1).ToString() && (item.Image == null || (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                                if (item.Name == harfler[kacinciharf + 2] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 1).ToString() && (item.Image == null || (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Tag.ToString().IndexOf("siyah") > -1) || (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Tag.ToString().IndexOf("beyaz") > -1)))
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        kacinciharf++;
                    }
                }
            }
        }

        private void Piyon(Label lbl)
        {
            if (lbl.Tag.ToString().IndexOf("piyon") > -1)
            {
                secilikare = lbl.Name;
                secililabel = lbl;
                if (lbl.Name.Substring(1, 1) == "2")
                {
                    foreach (Label item in panelBoard.Controls)
                    {
                        if (item.Name == lbl.Name.Substring(0, 1) + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 1).ToString() && item.Image != null)
                        {
                            foreach (Label silineceklabel in panelBoard.Controls)
                            {
                                if (silineceklabel.Name == lbl.Name.Substring(0, 1) + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 2).ToString() && silineceklabel.Image != null && turn)
                                {
                                    ihtimalkareler.Remove(silineceklabel.Name);
                                    silineceklabel.Image = null;
                                }
                            }
                        }
                        if (item.Name == lbl.Name.Substring(0, 1) + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 1).ToString() && item.Image == null && turn && item.Tag.ToString().IndexOf("siyah") == -1)
                        {
                            ihtimalkareler.Add(item.Name);
                            item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                        }
                        if (item.Name == lbl.Name.Substring(0, 1) + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 2).ToString() && item.Image == null && turn && item.Tag.ToString().IndexOf("siyah") == -1)
                        {
                            ihtimalkareler.Add(item.Name);
                            item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                        }
                    }
                }
                if (lbl.Name.Substring(1, 1) == "7")
                {
                    bool onundetasvarmi = true;
                    foreach (Label item in panelBoard.Controls)
                    {
                        if (item.Name == lbl.Name.Substring(0, 1) + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 1).ToString() && item.Image == null && turn == false)
                        {
                            onundetasvarmi = false;
                            ihtimalkareler.Add(item.Name);
                            item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                        }
                        if (item.Name == lbl.Name.Substring(0, 1) + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 2).ToString() && item.Image == null && onundetasvarmi == false && turn == false)
                        {
                            ihtimalkareler.Add(item.Name);
                            item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                        }
                    }
                }
                else
                {
                    foreach (Label item in panelBoard.Controls)
                    {
                        if (item.Name == lbl.Name.Substring(0, 1) + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 1).ToString() && item.Image == null && lbl.Tag.ToString().IndexOf("beyaz") > -1 && turn)
                        {
                            ihtimalkareler.Add(item.Name);
                            item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                        }
                        if (item.Name == lbl.Name.Substring(0, 1) + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 1).ToString() && item.Image == null && lbl.Tag.ToString().IndexOf("siyah") > -1 && turn == false)
                        {
                            ihtimalkareler.Add(item.Name);
                            item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                        }
                    }
                }
                int kacinciharf = 0;
                foreach (string harf in harfler)
                {
                    if (harf == lbl.Name.Substring(0, 1))
                    {
                        foreach (Label item in panelBoard.Controls)
                        {
                            if (kacinciharf - 1 > -1)
                            {
                                if (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Name == harfler[kacinciharf - 1] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 1).ToString() && item.Tag.ToString().IndexOf("siyah") > -1)
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                                if (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Name == harfler[kacinciharf - 1] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 1).ToString() && item.Tag.ToString().IndexOf("beyaz") > -1)
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                            if (kacinciharf + 1 < 8)
                            {
                                if (lbl.Tag.ToString().IndexOf("beyaz") > -1 && item.Name == harfler[kacinciharf + 1] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) + 1).ToString() && item.Tag.ToString().IndexOf("siyah") > -1)
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                                if (lbl.Tag.ToString().IndexOf("siyah") > -1 && item.Name == harfler[kacinciharf + 1] + (Convert.ToInt32(lbl.Name.Substring(1, 1)) - 1).ToString() && item.Tag.ToString().IndexOf("beyaz") > -1)
                                {
                                    ihtimalkareler.Add(item.Name);
                                    if (item.Image == null)
                                    {
                                        item.Image = Image.FromFile(Application.StartupPath + "\\images\\circle_green.png");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        kacinciharf++;
                    }
                }
            }
        }
    }
}
