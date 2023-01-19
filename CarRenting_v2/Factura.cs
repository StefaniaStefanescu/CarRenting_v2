using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.IO.Packaging;

namespace CarRenting_v2
{
    public class Factura
    {
        public string Nume_utilizator { get; set; }
        public string DataEmitere { get; set; }
        public string DetaliiFacturare { get; set; }
        public decimal Plata { get; set; }
        public string MergeInfo(string brand, string model, string data_1, string data_2, bool card, string card_number)
        {
            if (card)
            {
                return brand + " " + model + " [" + data_1 + "] [" + data_2 + "] " + " CARD CREDIT:" + card_number;
            }
            return brand + " " + model + " [" + data_1 + "] [" + data_2 + "] " + " CASH";
        }
        public Factura(string nume,string dataEmitere,string detaliiFacturare,decimal plata) {
            Nume_utilizator = nume;
            DataEmitere = dataEmitere;
            DetaliiFacturare = detaliiFacturare;
            Plata = plata;
        } 
        public void CreateDocument()
        {
            //Factura factura = new Factura
            //{
            //    Nume_utilizator = "Tudor Erick",
            //    DataEmitere = "2023-01-08",
            //    DetaliiFacturare = "BMW seria 7 2022 [2023-02-07]-[2023-02-08] CARD CREDIT", //aici voi folosi fct MergeInfo
            //    Plata = 700
            //};
            Document document = new Document(PageSize.A4,60,60,40,30);
            string ouputFile = Path.Combine("C:/Users/Erick/Desktop","factura_rent.pdf");
            FileStream fs= new FileStream(ouputFile, FileMode.Create);
           PdfWriter doc= PdfWriter.GetInstance(document,fs);
            document.Open();
            document.Add(new Paragraph("Invoice"));
            document.Add(new Paragraph("Customer Name: " + Nume_utilizator));
            document.Add(new Paragraph("Address: " + DataEmitere));
            document.Add(new Paragraph("Item Description: " + DetaliiFacturare));
            document.Add(new Paragraph("Price: " + Plata.ToString("C")));
            document.Close();
        }
    }




}