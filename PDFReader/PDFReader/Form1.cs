using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PDFReader;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System.Diagnostics;
using System.Drawing.Printing;

namespace PDFReader
{
    public partial class Form1 : Form
    {
        PrintDocument document = new PrintDocument();
        //PrintDialog dialog = new PrintDialog();
        string path = @"c:\\14.pdf";
        string str = "";
        public Form1()
        {
            InitializeComponent();
            timPrint.Interval = (60 * 1000);
            timPrint.Tick += new EventHandler(timPrint_Tick);
            timPrint.Start();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }
        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            float leftMargin = e.MarginBounds.Left;
            e.Graphics.DrawString(str, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 15, 50);
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            PDDocument p = PDDocument.load(path);
            PDFTextStripper sp = new PDFTextStripper();
            richTextBox1.Text = (sp.getText(p));
            str = (sp.getText(p));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            document.Print();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timPrint_Tick(object sender, EventArgs e)
        {
            //PDDocument p = PDDocument.load(path);
            //PDFTextStripper sp = new PDFTextStripper();
            //richTextBox1.Text = (sp.getText(p));
            //str = (sp.getText(p));
            //document.Print();
        }
    }
}
