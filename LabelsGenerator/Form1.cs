using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Net;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;

namespace LabelsGenerator
{
    public partial class Form1 : Form
    {
        private List<string> ean = new List<string>();
        private List<string> sku = new List<string>();
        private List<string> description = new List<string>();
        string file = "test.csv";
        bool userSelect = false;
        Int64 numberOfLabels;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Etykiety zbiorcze";
        string textToWrite;
        Bitmap skuPicture;
        BarcodeWriter writer;
        public Form1()
        {
            loadCSV();
            InitializeComponent();
            createFolder(path);
            //sprawdzanieDubli();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(sku_txtBx.Text)) | (String.IsNullOrEmpty(amount_TxtBx.Text)))
            {
                MessageBox.Show("Pola nie mogą być puste.", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!skuExist(sku_txtBx.Text))
            {
                MessageBox.Show("SKU musi znajdować się w bazie! \nPopraw je i spróbuj ponownie.", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Int64.TryParse(numberLabels.Text, out numberOfLabels))
            {
                MessageBox.Show("Dane w ilości wydruku są niepoprawne. \nSprawdź zakres i ponów próbę.", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                amount_TxtBx.Text = amount_TxtBx.Text.Trim();
                sku_txtBx.Text = sku_txtBx.Text.Trim();
                if (brand404_rb.Checked)
                {
                    skuPicture = new Bitmap(LabelsGenerator.Properties.Resources.brand404);
                }
                else if (pp_rb.Checked)
                {
                    skuPicture = new Bitmap(LabelsGenerator.Properties.Resources.pp);
                }
                else if(wess_rb.Checked)
                {
                    skuPicture = new Bitmap(LabelsGenerator.Properties.Resources.wessper);
                }
                else if (hc_rb.Checked)
                {
                    skuPicture = new Bitmap(LabelsGenerator.Properties.Resources.hc);
                }
                else
                {
                    skuPicture = new Bitmap(LabelsGenerator.Properties.Resources.blank);
                }
                if (String.IsNullOrEmpty(searchEAN(sku_txtBx.Text)))
                    chb_palette.Checked = true;
                if (!chb_palette.Checked)
                {
                    textToWrite = searchEAN(sku_txtBx.Text);
                    writer = new BarcodeWriter
                    {
                        Format = BarcodeFormat.EAN_13,
                        Options = new QrCodeEncodingOptions
                        {
                            Width = 500,
                            PureBarcode = true,
                            Height = 200,
                            Margin = 0
                        }
                    };
                } else
                {
                    textToWrite = sku_txtBx.Text;
                    writer = new BarcodeWriter
                    {
                        Format = BarcodeFormat.QR_CODE,
                        Options = new QrCodeEncodingOptions
                        {
                            Width = 300,
                            //PureBarcode = true,
                            Height = 300,
                            Margin = 0
                        }
                    };
                }
                //skuPicture = ResizeImage(skuPicture, 400, 400);
                var result = writer.Write(textToWrite.Trim());
                var barcodeBitmap = new Bitmap(result);
                var final = textToBitmap(MergeImages(barcodeBitmap), sku_txtBx.Text, amount_TxtBx.Text, searchEAN(sku_txtBx.Text));
                exportarPDF(final, path + "\\" + sku_txtBx.Text + ".pdf");
                if (autoPrint.Checked)
                {
                    FindProgram pdfProgramName = new FindProgram();
                    string printer = pdfProgramName.findPrinter();
                    int k = -1;
                    do
                    {
                        k++;
                        if (!String.IsNullOrEmpty(printer))
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.FileName = (pdfProgramName.findPDFprogram("SumatraPDF") + "\\SumatraPDF.exe");
                            startInfo.Arguments = "-silent " + path + "\\" + sku_txtBx.Text + ".pdf" + " -print-settings fit -print-to \"" + printer + "\" -exit-when-done";
                            process.StartInfo = startInfo;
                            process.Start();
                        }
                    } while (k < numberOfLabels);
                }
                MessageBox.Show("Zapisano etykietę " + sku_txtBx.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
 
        public Bitmap MergeImages(Bitmap image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            int outputImageWidth;
            int outputImageHeight;
            int palette_int = 720;
            int palette_intBig = 1520;
            if (chb_palette.Checked)
            {
                palette_int = 800;
                palette_intBig = 1600;
            }
                
            if (smallLabel_chkBx.Checked)
            {
                outputImageWidth = 1000;
                outputImageHeight = 800;
            }
            else
            {
                outputImageWidth = 1000;
                outputImageHeight = 1600;
            }
            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.Clear(Color.White);
                graphics.DrawImage(image, new System.Drawing.Rectangle(new Point((1000-image.Width)/2, palette_int - image.Height), image.Size),
                    new System.Drawing.Rectangle(new Point(), image.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(skuPicture, new System.Drawing.Rectangle(new Point((1000 - skuPicture.Width) / 2, 100), skuPicture.Size),
                        new System.Drawing.Rectangle(new Point(), skuPicture.Size), GraphicsUnit.Pixel);
                if (!smallLabel_chkBx.Checked)
                {
                    graphics.DrawImage(image, new System.Drawing.Rectangle(new Point((1000 - image.Width) / 2, palette_intBig - image.Height), image.Size),
                        new System.Drawing.Rectangle(new Point(), image.Size), GraphicsUnit.Pixel);
                    graphics.DrawImage(skuPicture, new System.Drawing.Rectangle(new Point((1000 - skuPicture.Width) / 2, 900), skuPicture.Size),
                        new System.Drawing.Rectangle(new Point(), skuPicture.Size), GraphicsUnit.Pixel);
                }
                /* graphics.DrawImage(image, new System.Drawing.Rectangle(new Point(446, 10), image.Size),
                     new System.Drawing.Rectangle(new Point(), image.Size), GraphicsUnit.Pixel);*/
            }
            return outputImage;
        }
        private Bitmap textToBitmap(Bitmap image, string sku, string amount, string ean)
        {
            Bitmap m = new Bitmap(image);
            Graphics x = Graphics.FromImage(m);
            sku = "Art. Nr " + sku;
            System.Drawing.Font drawFont = new System.Drawing.Font("Tahoma", 50, FontStyle.Bold);
            SizeF stringSize = x.MeasureString(sku, drawFont);
            float skuStartX = (1000-stringSize.Width)/2;
            x.DrawString(sku, drawFont, Brushes.Black, skuStartX, 100);
            if(!smallLabel_chkBx.Checked)
                x.DrawString(sku, drawFont, Brushes.Black, skuStartX, 900);
            drawFont = new System.Drawing.Font("Arial", 85, FontStyle.Bold);
            stringSize = x.MeasureString(amount, drawFont);
            float amnoutStartX = (1000 - stringSize.Width) / 2;
            if (amnoutStartX < 0)
                amnoutStartX = 0;
            x.DrawString(amount, drawFont, Brushes.Black, amnoutStartX, 530-stringSize.Height);
            if(!smallLabel_chkBx.Checked)
                x.DrawString(amount, drawFont, Brushes.Black, amnoutStartX, 1330 - stringSize.Height);
            if (!chb_palette.Checked)
            {
                drawFont = new System.Drawing.Font("Times New Roman", 50, FontStyle.Bold);
                stringSize = x.MeasureString(ean, drawFont);
                float eanStartX = (1000 - stringSize.Width) / 2;
                if (eanStartX < 0)
                    eanStartX = 0;
                x.DrawString(ean, drawFont, Brushes.Black, eanStartX, 800 - stringSize.Height);
                if (!smallLabel_chkBx.Checked)
                    x.DrawString(ean, drawFont, Brushes.Black, eanStartX, 1600 - stringSize.Height);
            }
            //x.DrawString(sku, drawFont, Brushes.Black, 228, 115);
            //x.DrawString(sku, drawFont, Brushes.Black, 449, 115);
            return m;
        }
        public void exportarPDF(Bitmap img, string filepath)
        {
            System.Drawing.Image image = img;
            int x, y;
            if (smallLabel_chkBx.Checked)
            {
                x = 1000;
                y = 850;
            }
            else
            {
                x = 1000;
                y = 1700;
            }
            var pgSize = new iTextSharp.text.Rectangle(x, y);
            Document doc = new Document(pgSize, 0, 0, 0, 0);
            PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
            doc.Open();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(image, ImageFormat.Jpeg);
            doc.Add(pdfImage);
            doc.Close();
        }
        private void createFolder(string path)
        {
            if (!Directory.Exists(path)){
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(path + "\\" + "image"))
            {
                Directory.CreateDirectory(path + "\\" + "image");
            }

        }
        private bool downloadImage(string name)
        {
            if (File.Exists(path + "\\" + "image\\" + name + ".jpg"))
            {
                return true;
            }
            else
            {
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        
                        var photo = new JavaScriptSerializer().Deserialize<SKUImage>(webClient.DownloadString("Link_do_zdjec" + name));
                        //MessageBox.Show(photo.resulst, "404", MessageBoxButtons.OK);
                        if (photo.resulst == "success")
                        {
                            webClient.DownloadFile(photo.msg, path + "\\" + "image\\" + name + ".jpg");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Brak zdjęcia", "404", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                    catch (System.Net.WebException)
                    {
                        MessageBox.Show("Brak zdjęcia lub problem połączenia z serwerem", "404", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
        }
        string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
        private void loadCSV()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "dbname";
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM Produkty";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ean.Add(reader.GetString(0));
                    sku.Add(reader.GetString(1));
                    description.Add(reader.GetString(2));
                }
            }
            else
            {
                MessageBox.Show("Problem z bazą danych, program zakończy pracę!", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            /*string path = Directory.GetCurrentDirectory();
            foreach (string csv in Directory.GetFiles(path))
            {
                if (csv.Contains(".csv"))
                {
                    file = csv;
                }
            }
            if (File.Exists(file))
            {
                int i = 0;
                foreach(string data in File.ReadLines(file, Encoding.Default))
                {
                    i++;
                    if (i <= 3)
                            continue;
                    var tmp = data.Split(';');
                    ean.Add(tmp[0].Substring(1));
                    //MessageBox.Show(tmp[0].Substring(1), "404", MessageBoxButtons.OK);
                    sku.Add(tmp[1]);
                    description.Add(tmp[2]);
                    
                }
            }
            else
            {
                MessageBox.Show("Brak pliku z danymi, program zakończy pracę!", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }*/
        }

        private void sku_txtBx_TextChanged(object sender, EventArgs e)
        {
            if (!userSelect)
            {
                sku_lb.Items.Clear();
                for(int i =0; i<sku.Count(); i++)
                {
                    if (sku[i].IndexOf(sku_txtBx.Text, 0, StringComparison.OrdinalIgnoreCase) != -1)
                        sku_lb.Items.Add(sku[i] + ": " + description[i]);
                }
                userSelect = false;
            }

        }

        private string searchSKU(string eanTMP)
        {
            for(int i =0; i < ean.Count(); i++)
            {
                if (ean[i] == eanTMP)
                {
                    return sku[i];
                }
                
            }
            return null;
        }
        private string searchEAN(string skuTMP)
        {
            for (int i = 0; i < sku.Count(); i++)
            {
                if (sku[i] == skuTMP)
                {
                    return ean[i];
                }

            }
            return null;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            userSelect = false;
            if ((sku_lb.Items.Count > 0) & (sku_lb.SelectedIndex > -1))
            {
                userSelect = true;
                for (int i = 0; i < description.Count(); i++)
                {
                    if (sku_lb.Items[sku_lb.SelectedIndex].ToString().Contains(description[i]))
                        sku_txtBx.Text = sku[i];
                }
            }
        }

        private void sku_txtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            userSelect = false;
        }
        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private bool skuExist(string name)
        {
            bool isExist = false;
            foreach(var tmp in sku)
            {
                if (tmp.Contains(name))
                {
                    isExist = true;
                }
            }
            return isExist;
        }
        private void sprawdzanieDubli()
        {
            Dictionary<int, int> testnum = new Dictionary<int, int>();
            List<int> more = new List<int>();
            int k = 0;
            for(int i = 0; i<sku.Count(); i++)
            {
                k = 0;
                for(int j =0; j<sku.Count(); j++)
                {
                    if (sku[i] == sku[j])
                    {
                        testnum.Add(j, i);
                    }
                }
                foreach (var tmp in testnum)
                {
                    if (tmp.Value == i)
                        k++;
                }
                if (k > 1)
                    more.Add(i);
                testnum.Clear();
            }
            foreach(var tmp in more)
            {
                MessageBox.Show(sku[tmp], "404", MessageBoxButtons.OK);
            }
        }
    }
        public class SKUImage
        {
            public string resulst { get; set; }
            public string msg { get; set; }
        }
    }
