using iText.Kernel.Pdf;
using iText.Pdfocr;
using iText.Pdfocr.Tesseract4;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Program
{
	private static readonly Tesseract4OcrEngineProperties tesseract4OcrEngineProperties =
			new Tesseract4OcrEngineProperties();

	private static string OUTPUT_PDF = "/pdfout/output.pdf";
	private static string TESS_DATA_FOLDER = "/tessdata/deu.traineddata";

	private static IList LIST_IMAGES_OCR = new ArrayList
	{
		new FileInfo("invoice_front.jpg")
	};

	private static void Main()
	{
		{
			var tesseractReader = new Tesseract4LibOcrEngine(tesseract4OcrEngineProperties);
			tesseract4OcrEngineProperties.SetPathToTessData(new FileInfo(TESS_DATA_FOLDER));

			var ocrPdfCreator = new OcrPdfCreator(tesseractReader);
			using (var writer = new PdfWriter(OUTPUT_PDF))
			{
				ocrPdfCreator.CreatePdf((IList<FileInfo>)LIST_IMAGES_OCR, writer).Close();
			}
		}
	}
}