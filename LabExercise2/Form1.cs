using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExercise2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKira_Click(object sender, EventArgs e)
        {
            double bilakhir, bayaranakhir,tunggakan,kadar1,kadar2,kadar3,kadar4,kadar5,
                jumlah1,jumlah2,jumlah3,jumlah4,jumlah5,
                jumlahsemasa,jumlahbil,penggenapan,jumlahperludibayar;
            double kegunaanXgst, kegunaangst, jumlahKegunaan, icpt1, icpt2, jumlahicpt, blnsemasaXgst,
                blnsemasagst, jumlahblnsemasa, jumlahgst, kwtbb, cajsemasa;
            int kWhXgst, kWhgst, JumlahkWh;
            int bacaanakhir, bacaanterkini, jumlahunit;
            int blokprorata1, blokprorata2, blokprorata3, blokprorata4, blokprorata5;

            bilakhir = double.Parse(txtBilAkhir.Text);
            bayaranakhir = double.Parse(txtBayaranAkhir.Text);
            tunggakan = bilakhir - bayaranakhir;

            bacaanakhir = int.Parse(txtBacaanAkhir.Text);
            bacaanterkini = int.Parse(txtBacaanTerkini.Text);
            jumlahunit = bacaanterkini - bacaanakhir;

            kadar1 = 0.218;
            kadar2 = 0.334;
            kadar3 = 0.516;
            kadar4 = 0.546;
            kadar5 = 0.571;



            if (jumlahunit > 0 && jumlahunit <= 200)
            {
                blokprorata1 = jumlahunit;
                blokprorata2 = 0;
                blokprorata3 = 0;
                blokprorata4 = 0;
                blokprorata5 = 0;
            }
            else if(jumlahunit > 200 && jumlahunit <= 300)
            {
                blokprorata1 = 200;
                blokprorata2 = jumlahunit - 200;
                blokprorata3 = 0;
                blokprorata4 = 0;
                blokprorata5 = 0;
            }
            else if(jumlahunit > 300 && jumlahunit <= 600)
            {
                blokprorata1 = 200;
                blokprorata2 = 100;
                blokprorata3 = jumlahunit - 300;
                blokprorata4 = 0;
                blokprorata5 = 0;
            }
            else if (jumlahunit > 600 && jumlahunit <=900)
            {
                blokprorata1 = 200;
                blokprorata2 = 100;
                blokprorata3 = 300;
                blokprorata4 = jumlahunit - 600;
                blokprorata5 = 0;
            }
            else
            {
                blokprorata1 = 200;
                blokprorata2 = 100;
                blokprorata3 = 300;
                blokprorata4 = 300;
                blokprorata5 = jumlahunit - 900;
            }

            lblBP1.Text = blokprorata1.ToString();
            lblBP2.Text = blokprorata2.ToString();
            lblBP3.Text = blokprorata3.ToString();
            lblBP4.Text = blokprorata4.ToString();
            lblBP5.Text = blokprorata5.ToString();


            jumlah1 = blokprorata1 * kadar1;
            jumlah2 = blokprorata2 * kadar2;
            jumlah3 = blokprorata3 * kadar3;
            jumlah4 = blokprorata4 * kadar4;
            jumlah5 = blokprorata5 * kadar5;

            lblJumlahBP.Text = jumlahunit.ToString();
            jumlahsemasa = jumlah1 + jumlah2 + jumlah3 + jumlah4 + jumlah5;
            

            

            lblTunggakan.Text = tunggakan.ToString("RM 0.00");
            lblJumlahUnit.Text = jumlahunit.ToString();

            if (jumlahunit > 300)
            {
                kWhXgst = 300;
                kWhgst = jumlahunit - 300;
                kegunaanXgst = jumlah1 + jumlah2;
                kegunaangst = jumlahsemasa - kegunaanXgst;
            }
            else
            {
                kWhXgst = jumlahunit;
                kWhgst = 0;
                kegunaanXgst = jumlah1 + jumlah2;
                kegunaangst = 0;

            }

            JumlahkWh = kWhgst + kWhXgst;
            jumlahKegunaan = kegunaanXgst + kegunaangst;

            icpt1 = kWhXgst * 0.0152;
            icpt2 = kWhgst * 0.0152;
            jumlahicpt = icpt1 + icpt2;

            blnsemasaXgst = kegunaanXgst - icpt1;
            blnsemasagst = kegunaangst - icpt2;
            jumlahblnsemasa = jumlahKegunaan - jumlahicpt;
            jumlahgst = blnsemasagst * 0.06;
            kwtbb = jumlahsemasa * 0.016;

            cajsemasa = jumlahblnsemasa + jumlahgst + kwtbb;
            jumlahbil = cajsemasa + tunggakan;
            jumlahperludibayar = Math.Round(jumlahbil / 0.05) * 0.05;
            penggenapan = jumlahperludibayar - jumlahbil;


            lblKadar1.Text = kadar1.ToString();
            lblKadar2.Text = kadar2.ToString();
            lblKadar3.Text = kadar3.ToString();
            lblKadar4.Text = kadar4.ToString();
            lblKadar5.Text = kadar5.ToString();
            lblJumlah1.Text = jumlah1.ToString("RM 0.00");
            lblJumlah2.Text = jumlah2.ToString("RM 0.00");
            lblJumlah3.Text = jumlah3.ToString("RM 0.00");
            lblJumlah4.Text = jumlah4.ToString("RM 0.00");
            lblJumlah5.Text = jumlah5.ToString("RM 0.00");
            lblJumlahSemasa.Text = jumlahsemasa.ToString("RM 0.00");
            lblJumlahBil.Text = jumlahbil.ToString("RM 0.00");
            lblPenggenapan.Text = penggenapan.ToString("RM 0.00");
            lblJumlahPerluBayar.Text = jumlahperludibayar.ToString("RM 0.00");
            lblkWhXgst.Text = kWhXgst.ToString();
            lblkWhgst.Text = kWhgst.ToString();
            lblkegunaanRMxgst.Text = kegunaanXgst.ToString("0.00");
            lblkegunaanRMgst.Text = kegunaangst.ToString("0.00");
            lblJumlahkWh.Text = JumlahkWh.ToString();
            lbljumlahkegunaanRM.Text = jumlahKegunaan.ToString("0.00");
            lblICPT1.Text = icpt1.ToString("0.00");
            lblICPT2.Text = icpt2.ToString("0.00");
            lblICPT3.Text = jumlahicpt.ToString("0.00");
            lblBulanSemasaXGST.Text = blnsemasaXgst.ToString("0.00");
            lblBulanSemasaGST.Text = blnsemasagst.ToString("0.00");
            lblBulanSemasaJumlah.Text = jumlahblnsemasa.ToString("0.00");
            lblJumlahGST.Text = jumlahgst.ToString("0.00");
            lblJumlahKWTB.Text = kwtbb.ToString("0.00");
            lblcajsemasa.Text = cajsemasa.ToString("RM 0.00");


        }

    }
}
