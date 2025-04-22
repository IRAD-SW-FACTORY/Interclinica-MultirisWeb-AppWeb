// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.PDF.PDFHeaderFooter
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace MultiRisWeb.Data.PDF
{
  public class PDFHeaderFooter : PdfPageEventHelper
  {
    private PdfContentByte cb;
    private PdfTemplate template;
    private BaseFont bf;
    private DateTime PrintTime = DateTime.Now;
    private string _Title1;
    private string _Title2;
    private string _Title3;
    private string _TextHeader;
    private string _TextFooter;
    private string _PathLogoIzq;
    private string _PathWaterMark;
    private string _PathLogoDer;
    private string _UniqueCode;
    private bool _flagPageNumber;
    private string _textoIzq;
    private string _textoDer;

    public string Title1
    {
      get => this._Title1;
      set => this._Title1 = value;
    }

    public string Title2
    {
      get => this._Title2;
      set => this._Title2 = value;
    }

    public string Title3
    {
      get => this._Title3;
      set => this._Title3 = value;
    }

    public string TextHeader
    {
      get => this._TextHeader;
      set => this._TextHeader = value;
    }

    public string TextFooter
    {
      get => this._TextFooter;
      set => this._TextFooter = value;
    }

    public string PathLogoIzq
    {
      get => this._PathLogoIzq;
      set => this._PathLogoIzq = value;
    }

    public string PathWaterMark
    {
      get => this._PathWaterMark;
      set => this._PathWaterMark = value;
    }

    public string PathLogoDer
    {
      get => this._PathLogoDer;
      set => this._PathLogoDer = value;
    }

    public string UniqueCode
    {
      get => this._UniqueCode;
      set => this._UniqueCode = value;
    }

    public bool FlagPageNumber
    {
      get => this._flagPageNumber;
      set => this._flagPageNumber = value;
    }

    public string TextoIzq
    {
      get => this._textoIzq;
      set => this._textoIzq = value;
    }

    public string TextoDer
    {
      get => this._textoDer;
      set => this._textoDer = value;
    }

    public override void OnOpenDocument(PdfWriter writer, Document document)
    {
      try
      {
        this.PrintTime = DateTime.Now;
        this.bf = BaseFont.CreateFont("Helvetica", "Cp1252", false);
        this.cb = writer.DirectContent;
        this.template = this.cb.CreateTemplate(50f, 50f);
      }
      catch (IOException ex)
      {
        ex.ToString();
      }
    }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
      base.OnStartPage(writer, document);
      PdfPTable pdfPtable = new PdfPTable(2);
      pdfPtable.TotalWidth = document.PageSize.Width;
      if (this.PathLogoIzq != null && this.PathLogoIzq.Length > 0)
      {
        Image instance = Image.GetInstance(this.PathLogoIzq);
        instance.ScaleToFit(620f, 100f);
        PdfPCell cell = new PdfPCell(instance);
        cell.HorizontalAlignment = 0;
        cell.PaddingLeft = 0.0f;
        cell.Border = 0;
        pdfPtable.AddCell(cell);
      }
      double num = (double) pdfPtable.WriteSelectedRows(0, -1, 0.0f, document.PageSize.Height - 0.0f, writer.DirectContent);
      if (this.PathWaterMark == null || this.PathWaterMark.Length <= 0)
        return;
      Image instance1 = Image.GetInstance(this.PathWaterMark);
      instance1.SetAbsolutePosition(0.0f, 0.0f);
      instance1.ScaleToFit(800f, 800f);
      PdfContentByte directContentUnder = writer.DirectContentUnder;
      new PdfGState().FillOpacity = 0.8f;
      Image image = instance1;
      directContentUnder.AddImage(image);
    }

    public override void OnEndPage(PdfWriter writer, Document document)
    {
      base.OnEndPage(writer, document);
      Rectangle pageSize = document.PageSize;
      float margin = 30f;
      if (this.Title1 != null && this.Title1 != string.Empty)
      {
        this.cb.BeginText();
        this.cb.SetFontAndSize(this.bf, 10f);
        this.cb.SetTextMatrix(pageSize.GetLeft(40f) + 150f, pageSize.GetBottom(80f));
        this.cb.ShowText(this.Title1);
        this.cb.EndText();
      }
      if (this.Title2 != null && this.Title2 != string.Empty)
      {
        this.cb.BeginText();
        this.cb.SetFontAndSize(this.bf, 10f);
        this.cb.SetTextMatrix(pageSize.GetLeft(40f) + 100f, pageSize.GetBottom(65f));
        this.cb.ShowText(this.Title2);
        this.cb.EndText();
      }
      if (this.Title3 != null && this.Title3 != string.Empty)
      {
        this.cb.BeginText();
        this.cb.SetFontAndSize(this.bf, 10f);
        this.cb.SetTextMatrix(pageSize.GetLeft(40f) + 220f, pageSize.GetBottom(50f));
        this.cb.ShowText(this.Title3);
        this.cb.EndText();
      }
      long num = 1;
      if (this.UniqueCode != null && this.UniqueCode != string.Empty && num == 1L)
      {
        Barcode128 barcode128 = new Barcode128();
        barcode128.TextAlignment = 1;
        barcode128.Code = this._UniqueCode;
        barcode128.CodeType = 1;
        Image imageWithBarcode = barcode128.CreateImageWithBarcode(this.cb, BaseColor.BLACK, BaseColor.BLACK);
        imageWithBarcode.SetAbsolutePosition((float) ((double) pageSize.Width / 2.0 - 120.0), pageSize.GetBottom(margin + 10f));
        this.cb.AddImage(imageWithBarcode);
      }
      if (this.FlagPageNumber)
      {
        string text = "Página " + writer.PageNumber.ToString() + " de ";
        float widthPoint = this.bf.GetWidthPoint(text, 8f);
        this.cb.SetRGBColorFill(100, 100, 100);
        this.cb.BeginText();
        this.cb.SetFontAndSize(this.bf, 8f);
        this.cb.SetTextMatrix(pageSize.GetLeft(40f), pageSize.GetBottom(margin));
        this.cb.ShowText(text);
        this.cb.EndText();
        this.cb.AddTemplate(this.template, pageSize.GetLeft(40f) + widthPoint, pageSize.GetBottom(margin));
      }
      this.cb.BeginText();
      this.cb.SetFontAndSize(this.bf, 8f);
      this.cb.ShowTextAligned(2, this.TextFooter + " IMP:" + this.PrintTime.ToString("dd/MM/yyyy HH:mm"), pageSize.GetRight(40f), pageSize.GetBottom(margin), 0.0f);
      this.cb.EndText();
    }

    public override void OnCloseDocument(PdfWriter writer, Document document)
    {
      base.OnCloseDocument(writer, document);
      this.template.BeginText();
      this.template.SetFontAndSize(this.bf, 8f);
      this.template.SetTextMatrix(0.0f, 0.0f);
      this.template.ShowText((writer.PageNumber - 1).ToString() ?? "");
      this.template.EndText();
    }
  }
}
