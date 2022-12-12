using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Net.Mime;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Diagnostics;
using System.Xml.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using iTextSharp.text;
using Font = Syncfusion.Drawing.Font;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Syncfusion.Pdf.Interactive;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DDU.Controllers
{
    public class GeneratePayrollController : Controller
    {
        private const bool V = false;
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        //private string strConnectionString="User Id=sa;Password=Ahmi;Server=.;Database=DDUDB;";
        //Generate a new PDF document.

        //Create a new PDF document.


        public GeneratePayrollController(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }
        string shipName="", address="", shipCity="", shipCountry="";
        float total = 0;

        public PdfBookmark AddSection1(PdfBookmark bookmark, PdfPage page, string title, PointF point, bool isSubSection, PdfFont font)
        {
            PdfGraphics graphics = page.Graphics;
            //Add bookmark in PDF document
            PdfBookmark bookmarks = bookmark.Add(title);

            PdfBrush brush = new PdfSolidBrush(Color.Green);

            if (bookmark.Title.StartsWith("Section"))
            {
                brush = new PdfSolidBrush(Color.Blue);
            }

            //Draw the content in the PDF page
            graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));

            bookmarks.Destination = new PdfDestination(page);
            bookmarks.Destination.Location = point;

            return bookmarks;
        }

        public PdfBookmark AddBookmark1(PdfDocument document, PdfPage page, string title, PointF point, PdfFont font)
        {

            PdfGraphics graphics = page.Graphics;

            //Add bookmark in PDF document
            PdfBookmark bookmarks = document.Bookmarks.Add(title);

            PdfBrush brush = new PdfSolidBrush(Color.Red);

            //Draw the content in the PDF page
            graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));

            bookmarks.Destination = new PdfDestination(page);
            bookmarks.Destination.Location = point;

            return bookmarks;
        }

        public IActionResult Index(DateTime StartTime, DateTime EndTime)
        {
                
            if (StartTime!=EndTime)
            {
                if (!PayrollModelExists(EndTime))
                {
                    using (IDbConnection con = new SqlConnection(_db.strConnectionString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        var startTime = StartTime;
                        var endTime = EndTime;
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@StartTime", startTime);
                        parameters.Add("@EndTime", endTime);
                        parameters.Add("@HDate", startTime);
                        parameters.Add("@FDate", startTime.Day);
                        parameters.Add("@TDate", endTime.Day);
                        parameters.Add("@insert", 1);
                        con.Execute("[dbo].[GeneratePayroll]", parameters, commandType: CommandType.StoredProcedure);
                    } 
                    
                    TempData["success"] = "Payroll Processed Successfully.";
                   
                    return RedirectToAction("Payroll", "Home");
                }
                else
                {

                    //Creates a new PDF document.
                    PdfDocument document = new PdfDocument();

                    //Set the Font
                    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);

                    //Set PdfBrush
                    PdfBrush brush = new PdfSolidBrush(Color.Black);

                    List<Payroll> list = new List<Payroll>();
                    IEnumerable<Payroll> objpayroll = _db.payroll;
                     int i=0;
                    foreach (Payroll cust in objpayroll)
                    {
                        
                        document.PageSettings.Orientation = PdfPageOrientation.Portrait;
                        document.PageSettings.Margins.All = 20;


                        PdfPage pages = document.Pages.Add();

                        //Create PDF graphics for the page.
                        PdfGraphics graphics = pages.Graphics;

                        
                        //Create a text element with the text and font.
                        PdfTextElement element = new PdfTextElement("Dambi Dollo University\nPhone +25157555\nEmail info@dadu.edu.et,\nDambi Dollo Ethiopia..");
                        element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                        element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                        PdfLayoutResult result = element.Draw(pages, new RectangleF(1, 1, pages.Graphics.ClientSize.Width / 2, 200));

                        //Draw the image to PDF page with specified size. 
                        FileStream imageStream = new FileStream(_hostingEnvironment.WebRootPath + "/assets/images/main-logo.jpg", FileMode.Open, FileAccess.Read);
                        PdfImage img = new PdfBitmap(imageStream);

                        graphics.DrawImage(img, new RectangleF(graphics.ClientSize.Width - 200, result.Bounds.Y, 90, 90));
                        PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
                        graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(192, 192, 192)), new RectangleF(0, result.Bounds.Bottom + 40, graphics.ClientSize.Width, 30));



                        //Add bookmark in PDF document
                        PdfBookmark bookmark = AddBookmark1(document, pages, cust.FirstName +" "+ cust.MiddleName +" "+cust.LastName +"("+cust.IDNo+")" , new PointF(40, 100), font);
                        bookmark.Color = Color.White;

                        //Add sections to bookmark
                        PdfBookmark section1 = AddSection1(bookmark, pages, "Department :", new PointF(30, 130), false, font);
                        section1.Color = Color.Green;
                        PdfBookmark section2 = AddSection1(bookmark, pages, Convert.ToString(cust.DepartmentID), new PointF(110, 130), false, font);
                        section2.Color = Color.Green;
                        PdfBookmark section3 = AddSection1(bookmark, pages, "Sub-Department :", new PointF(30, 150), false, font);
                        section3.Color = Color.Green;
                        PdfBookmark section4 = AddSection1(bookmark, pages, Convert.ToString(cust.SubDepartmentID), new PointF(110, 150), false, font);
                        section4.Color = Color.Green;

                        PdfBookmark section5 = AddSection1(bookmark, pages, "Shift-Group :", new PointF(30, 170), false, font);
                        section5.Color = Color.Green;
                        PdfBookmark section6 = AddSection1(bookmark, pages, Convert.ToString(cust.ShiftGroupID), new PointF(110, 170), false, font);
                        section6.Color = Color.Green;
                        //Add bookmark in PDF document
                        PdfBookmark bookmark2 = AddBookmark1(document, pages, "Other Earnings", new PointF(400, 100), font);
                        PdfBookmark section7 = AddSection1(bookmark, pages, "Total OT Payment:", new PointF(350, 130), false, font);
                        section7.Color = Color.Green;
                        PdfBookmark section8 = AddSection1(bookmark, pages, "OT Hrs :", new PointF(350, 140), false, font);
                        section8.Color = Color.Green;
                        PdfBookmark section9 = AddSection1(bookmark, pages, "Increment:", new PointF(350, 150), false, font);
                        section9.Color = Color.Green;
                        PdfBookmark section10 = AddSection1(bookmark, pages, "Tel & Transport:", new PointF(350, 160), false, font);
                        section10.Color = Color.Green;
                        PdfBookmark section11 = AddSection1(bookmark, pages, "Allowance:", new PointF(350, 170), false, font);
                        section11.Color = Color.Green;

                        PdfBookmark section12 = AddSection1(bookmark, pages, Convert.ToString(cust.SundayOTPayment+cust.NationalHolydayOTPayment+cust.WeekdayOTPayment+cust.WeekdayNightOTPayment), new PointF(450, 130), false, font);
                        section12.Color = Color.Green;
                        PdfBookmark section13 = AddSection1(bookmark, pages, Convert.ToString(cust.SundayOTHours + cust.NationalHolydayOTHours + cust.WeekdayOTHours + cust.WeekdayNightOTHours), new PointF(450, 140), false, font);
                        section13.Color = Color.Green;
                        PdfBookmark section14 = AddSection1(bookmark, pages, Convert.ToString(cust.IncrementPayment), new PointF(450, 150), false, font);
                        section14.Color = Color.Green;
                        PdfBookmark section15 = AddSection1(bookmark, pages, Convert.ToString(cust.PhoneAllowance), new PointF(450, 160), false, font);
                        section15.Color = Color.Green;
                        PdfBookmark section16 = AddSection1(bookmark, pages, Convert.ToString(cust.OtherAllowance), new PointF(450, 170), false, font);
                        section16.Color = Color.Green;

                        
                        PdfBookmark bookmark3 = AddBookmark1(document, pages, "Information", new PointF(30, 200), font);
                        bookmark.Color = Color.Red;

                        //Add sections to bookmark
                        PdfBookmark section17 = AddSection1(bookmark, pages, "Monthly Working Hours :", new PointF(30, 210), false, font);
                        section17.Color = Color.Green;
                        PdfBookmark section18 = AddSection1(bookmark, pages, "Holiday Hours :", new PointF(30, 220), false, font);
                        section18.Color = Color.Green;
                        PdfBookmark section20 = AddSection1(bookmark, pages, "Hourly Earning :", new PointF(30, 230), false, font);
                        section20.Color = Color.Green;
                        PdfBookmark section21 = AddSection1(bookmark, pages, "Basic Salary", new PointF(30, 240), false, font);
                        section21.Color = Color.Green;
                        PdfBookmark section22 = AddSection1(bookmark, pages, "Basic Earning", new PointF(30, 250), false, font);
                        section22.Color = Color.Green;

                        //net payment Rectangle
                        graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(192, 192, 192)), new RectangleF(180, result.Bounds.Bottom + 120, graphics.ClientSize.Width-390, 50));

                        // Add Net Pay 
                        PdfBookmark section38 = AddSection1(bookmark, pages, "Net Payment :", new PointF(190, 180), false, font);
                        section38.Color = Color.Green;
                        PdfBookmark section39 = AddSection1(bookmark, pages, Convert.ToString(cust.NetPayment), new PointF(260, 190), false, font);
                        section39.Color = Color.Green;
                        PdfBookmark section40 = AddSection1(bookmark, pages, "Net Payment= ", new PointF(190, 200), false, font);
                        section40.Color = Color.Green;
                        PdfBookmark section41 = AddSection1(bookmark, pages, "Gross Earning-Total deduction", new PointF(200, 210), false, font);
                        section41.Color = Color.Green;

                        //Add sections to bookmark
                        PdfBookmark section23 = AddSection1(bookmark, pages,Convert.ToString(cust.MonthlyWorkedHours), new PointF(140, 210), false, font);
                        section23.Color = Color.Green;
                        PdfBookmark section24 = AddSection1(bookmark, pages, Convert.ToString(cust.HolidayHours), new PointF(140, 220), false, font);
                        section24.Color = Color.Green;
                        PdfBookmark section25 = AddSection1(bookmark, pages, Convert.ToString(Math.Round(cust.HourlyEarning,2)), new PointF(140, 230), false, font);
                        section25.Color = Color.Green;
                        PdfBookmark section26 = AddSection1(bookmark, pages, Convert.ToString(Math.Round(cust.BasicSalary,2)), new PointF(140, 240), false, font);
                        section26.Color = Color.Green;
                        PdfBookmark section27 = AddSection1(bookmark, pages, Convert.ToString(Math.Round(cust.BasicEarning,2)), new PointF(140, 250), false, font);
                        section27.Color = Color.Green;

                        //Add bookmark in PDF document
                        PdfBookmark bookmark4 = AddBookmark1(document, pages, "Deduction", new PointF(400, 200), font);
                        PdfBookmark section28 = AddSection1(bookmark, pages, "Staff Recivable:", new PointF(350, 210), false, font);
                        section28.Color = Color.Green;
                        PdfBookmark section29 = AddSection1(bookmark, pages, "Labour Union:", new PointF(350, 220), false, font);
                        section29.Color = Color.Green;
                        PdfBookmark section30 = AddSection1(bookmark, pages, "Tax:", new PointF(350, 230), false, font);
                        section30.Color = Color.Green;
                        PdfBookmark section31 = AddSection1(bookmark, pages, "Pension:", new PointF(350, 240), false, font);
                        section31.Color = Color.Green;
                        PdfBookmark section32 = AddSection1(bookmark, pages, "Total Deduction:", new PointF(350, 250), false, font);
                        section32.Color = Color.Green;

                        PdfBookmark section33 = AddSection1(bookmark, pages, Convert.ToString(cust.StaffRecivable), new PointF(450, 210), false, font);
                        section33.Color = Color.Green;
                        PdfBookmark section34 = AddSection1(bookmark, pages, Convert.ToString(cust.OtherDeduction), new PointF(450, 220), false, font);
                        section34.Color = Color.Green;
                        PdfBookmark section35 = AddSection1(bookmark, pages, Convert.ToString(cust.Tax), new PointF(450, 230), false, font);
                        section35.Color = Color.Green;
                        PdfBookmark section36 = AddSection1(bookmark, pages, Convert.ToString(cust.Pension), new PointF(450, 240), false, font);
                        section36.Color = Color.Green;
                        PdfBookmark section37 = AddSection1(bookmark, pages, Convert.ToString(cust.TotalDeduction), new PointF(450, 250), false, font);
                        section37.Color = Color.Green;
                        string resource = "Income tax proclamation No. 979/2016. \r\n According to this law, the first Birr 600 of monthly personal income is exempted from payment of income tax.\r\n For monthly income of Birr 601 and above the marginal tax rates range from 10 per cent to 35 per cent with 7 income brackets as shown below. \r\n 0–600 0% 0,601–1 650 10% 60.00 , 1651–3200 15% 142.50 ,3201–5250 20% 302.50 ,5251–7 800 25% 565.00 ,7801–10 900 30% 955,00 ,More than 10900 35% 1500.00";
                        
                        PdfBookmark subsection1 = AddSection1(section37, pages, resource, new PointF(30, 270), true, font);
                        subsection1.Color = Color.Blue;

                        //PdfPage page1 = document.Pages.Add();
                        //string basePath = _hostingEnvironment.WebRootPath;
                        //string dataPath = string.Empty;
                        //dataPath = basePath + @"/PDF/";

                        //FileStream stream = new FileStream(dataPath + "arial.ttf", FileMode.Open, FileAccess.Read);
                        //PdfFont fontnormal = new PdfTrueTypeFont(stream, 9);
                        ////#region content string
                        //string pdfChapter = "Well begin with a conceptual overview of a simple PDF document. This chapter is designed to be a brief orientation before diving in and creating a real document from scratch \r\n \r\n A PDF file can be divided into four parts: a header, body, cross-reference table, and trailer. The header marks the file as a PDF, the body defines the visible document, the cross-reference table lists the location of everything in the file, and the trailer provides instructions for how to start reading the file.";
                        //string header = "The header is simply a PDF version number and an arbitrary sequence of binary data.The binary data prevents na�ve applications from processing the PDF as a text file. This would result in a corrupted file, since a PDF typically consists of both plain text and binary data (e.g., a binary font file can be directly embedded in a PDF).";
                        //string body = "The page tree serves as the root of the document. In the simplest case, it is just a list of the pages in the document. Each page is defined as an independent entity with metadata (e.g., page dimensions) and a reference to its resources and content, which are defined separately. Together, the page tree and page objects create the �paper� that composes the document.\r\n \r\n  Resources are objects that are required to render a page. For example, a single font is typically used across several pages, so storing the font information in an external resource is much more efficient. A content object defines the text and graphics that actually show up on the page. Together, content objects and resources define theappearance of an individual page. \r\n \r\n  Finally, the document�s catalog tells applications where to start reading the document. Often, this is just a pointer to the root page tree.";
                        //string resource = "The third object is a resource defining a font configuration. \r\n \r\n The /Font key contains a whole dictionary, opposed to the name/value pairs we�ve seen previously (e.g., /Type /Page). The font we configured is called /F0, and the font face we selected is /Times-Roman. The /Subtype is the format of the font file, and /Type1 refers to the PostScript type 1 file format. The specification defines 14 �standard� fonts that all PDF applications should support.";
                        //string crossRef = "After the header and the body comes the cross-reference table. It records the byte location of each object in the body of the file. This enables random-access of the document, so when rendering a page, only the objects required for that page are read from the file. This makes PDFs much faster than their PostScript predecessors, which had to read in the entire file before processing it.";
                        //string trailer = "Finally, we come to the last component of a PDF document. The trailer tells applications how to start reading the file. At minimum, it contains three things: \r\n 1. A reference to the catalog which links to the root of the document. \r\n 2. The location of the cross-reference table. \r\n 3. The size of the cross-reference table. \r\n \r\n Since a trailer is all you need to begin processing a document, PDFs are typically read back-to-front: first, the end of the file is found, and then you read backwards until you arrive at the beginning of the trailer. After that, you should have all the information you need to load any page in the PDF.";
                        ////#endregion

                        //PdfStructureElement hTextElement1 = new PdfStructureElement(PdfTagType.HeadingLevel1);
                        //PdfStructureElement headingFirstLevel = new PdfStructureElement(PdfTagType.HeadingLevel2);
                        //PdfStructureElement hTextElementLevel3 = new PdfStructureElement(PdfTagType.HeadingLevel3);
                        //headingFirstLevel.Parent = hTextElement1;
                        //hTextElementLevel3.Parent = hTextElement1;

                        //PdfStructureElement textElement3 = new PdfStructureElement(PdfTagType.Paragraph);
                        //textElement3.Parent = hTextElementLevel3;
                        //textElement3.ActualText = body;

                        //PdfTextElement element3 = new PdfTextElement(body, fontnormal);
                        //element3.PdfTag = textElement3;
                        //element3.Brush = new PdfSolidBrush(Color.Black);
                        //element3.Draw(page1, new PointF(0, 210)); 


                        i++;
                    }

                   

                    

                    //Save the PDF to the MemoryStream
                    MemoryStream ms = new MemoryStream();

                    document.Save(ms);

                    //If the position is not set to '0' then the PDF will be empty.
                    ms.Position = 0;

                    document.Close(true);

                    //Download the PDF document in the browser.
                    FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                    fileStreamResult.FileDownloadName = "Bookmarks.pdf";
                    return fileStreamResult;


                    //string basePath = _hostingEnvironment.WebRootPath;
                    //string dataPath = string.Empty;
                    //dataPath = basePath + @"/PDF/";

                    //FileStream stream = new FileStream(dataPath + "arial.ttf", FileMode.Open, FileAccess.Read);
                    //PdfFont fontnormal = new PdfTrueTypeFont(stream, 9);
                    //PdfFont fontTitle = new PdfTrueTypeFont(stream, 22);
                    //PdfFont fontHead = new PdfTrueTypeFont(stream, 10);
                    //PdfFont fontHead2 = new PdfTrueTypeFont(stream, 16);

                    //#region content string
                    //string pdfChapter = "Well begin with a conceptual overview of a simple PDF document. This chapter is designed to be a brief orientation before diving in and creating a real document from scratch \r\n \r\n A PDF file can be divided into four parts: a header, body, cross-reference table, and trailer. The header marks the file as a PDF, the body defines the visible document, the cross-reference table lists the location of everything in the file, and the trailer provides instructions for how to start reading the file.";
                    //string header = "The header is simply a PDF version number and an arbitrary sequence of binary data.The binary data prevents na�ve applications from processing the PDF as a text file. This would result in a corrupted file, since a PDF typically consists of both plain text and binary data (e.g., a binary font file can be directly embedded in a PDF).";
                    //string body = "The page tree serves as the root of the document. In the simplest case, it is just a list of the pages in the document. Each page is defined as an independent entity with metadata (e.g., page dimensions) and a reference to its resources and content, which are defined separately. Together, the page tree and page objects create the �paper� that composes the document.\r\n \r\n  Resources are objects that are required to render a page. For example, a single font is typically used across several pages, so storing the font information in an external resource is much more efficient. A content object defines the text and graphics that actually show up on the page. Together, content objects and resources define theappearance of an individual page. \r\n \r\n  Finally, the document�s catalog tells applications where to start reading the document. Often, this is just a pointer to the root page tree.";
                    //string resource = "The third object is a resource defining a font configuration. \r\n \r\n The /Font key contains a whole dictionary, opposed to the name/value pairs we�ve seen previously (e.g., /Type /Page). The font we configured is called /F0, and the font face we selected is /Times-Roman. The /Subtype is the format of the font file, and /Type1 refers to the PostScript type 1 file format. The specification defines 14 �standard� fonts that all PDF applications should support.";
                    //string crossRef = "After the header and the body comes the cross-reference table. It records the byte location of each object in the body of the file. This enables random-access of the document, so when rendering a page, only the objects required for that page are read from the file. This makes PDFs much faster than their PostScript predecessors, which had to read in the entire file before processing it.";
                    //string trailer = "Finally, we come to the last component of a PDF document. The trailer tells applications how to start reading the file. At minimum, it contains three things: \r\n 1. A reference to the catalog which links to the root of the document. \r\n 2. The location of the cross-reference table. \r\n 3. The size of the cross-reference table. \r\n \r\n Since a trailer is all you need to begin processing a document, PDFs are typically read back-to-front: first, the end of the file is found, and then you read backwards until you arrive at the beginning of the trailer. After that, you should have all the information you need to load any page in the PDF.";
                    //#endregion

                    ////Create a new PDF document.

                    //PdfDocument document = new PdfDocument();

                    //document.DocumentInformation.Title = "CustomTag";

                    //#region page1
                    ////Add a page to the document.

                    //PdfPage page1 = document.Pages.Add();

                    ////Load the image from the disk.
                    //FileStream fileStream1 = new FileStream(dataPath + "CustomTag.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    //PdfBitmap image = new PdfBitmap(fileStream1);

                    //PdfStructureElement imageElement = new PdfStructureElement(PdfTagType.Figure);
                    //imageElement.AlternateText = "PDF Succintly image";
                    ////adding tag to the PDF image
                    //image.PdfTag = imageElement;
                    ////Draw the image
                    //page1.Graphics.DrawImage(image, 0, 0, page1.GetClientSize().Width, page1.GetClientSize().Height - 20);

                    //#endregion


                    //#region page2

                    //PdfPage page2 = document.Pages.Add();

                    //PdfStructureElement hTextElement1 = new PdfStructureElement(PdfTagType.HeadingLevel1);
                    //PdfStructureElement headingFirstLevel = new PdfStructureElement(PdfTagType.HeadingLevel2);
                    //PdfStructureElement hTextElementLevel3 = new PdfStructureElement(PdfTagType.HeadingLevel3);
                    //headingFirstLevel.Parent = hTextElement1;
                    //hTextElementLevel3.Parent = hTextElement1;

                    //PdfTextElement headerElement1 = new PdfTextElement("Chapter 1 Conceptual Overview", fontTitle, PdfBrushes.Black);

                    //headerElement1.PdfTag = headingFirstLevel;
                    //headerElement1.Draw(page2, new PointF(100, 0));

                    ////Initialize the structure element with tag type paragraph.

                    //PdfStructureElement textElement1 = new PdfStructureElement(PdfTagType.Paragraph);
                    //textElement1.Parent = headingFirstLevel;
                    //textElement1.ActualText = pdfChapter;

                    //PdfTextElement element1 = new PdfTextElement(pdfChapter, fontnormal);
                    //element1.PdfTag = textElement1;
                    //element1.Brush = new PdfSolidBrush(Color.Black);
                    //element1.Draw(page2, new RectangleF(0, 40, page2.GetClientSize().Width, 70));

                    //PdfStructureElement hTextElement2 = new PdfStructureElement(PdfTagType.HeadingLevel2);
                    //hTextElement2.Parent = hTextElement1;
                    //hTextElement2.ActualText = "Header";

                    //PdfTextElement headerElement2 = new PdfTextElement("Header", fontHead2, PdfBrushes.Black);
                    //headerElement2.PdfTag = hTextElement2;
                    //headerElement2.Draw(page2, new PointF(0, 140));

                    //PdfStructureElement textElement2 = new PdfStructureElement(PdfTagType.Paragraph);
                    //textElement2.Parent = hTextElementLevel3;
                    //textElement2.ActualText = header;

                    //PdfTextElement element2 = new PdfTextElement(header, fontnormal);
                    //element2.PdfTag = textElement2;
                    //element2.Brush = new PdfSolidBrush(Color.Black);
                    //element2.Draw(page2, new RectangleF(0, 170, page2.GetClientSize().Width, 40));


                    //PdfStructureElement hTextElement3 = new PdfStructureElement(PdfTagType.HeadingLevel2);
                    //hTextElement3.Parent = hTextElement1;
                    //hTextElement3.ActualText = "Body";

                    //PdfTextElement headerElement3 = new PdfTextElement("Body", fontHead2, PdfBrushes.Black);
                    //headerElement3.PdfTag = hTextElement3;
                    //headerElement3.Draw(page2, new PointF(0, 210));

                    //PdfStructureElement textElement3 = new PdfStructureElement(PdfTagType.Paragraph);
                    //textElement3.Parent = hTextElementLevel3;
                    //textElement3.ActualText = body;

                    //PdfTextElement element3 = new PdfTextElement(body, fontnormal);
                    //element3.PdfTag = textElement3;
                    //element3.Brush = new PdfSolidBrush(Color.Black);
                    //element3.Draw(page2, new RectangleF(0, 240, page2.GetClientSize().Width, 120));

                    //PdfStructureElement hTextElement6 = new PdfStructureElement(PdfTagType.HeadingLevel2);
                    //hTextElement6.Parent = hTextElement1;
                    //hTextElement6.ActualText = "Cross-Reference Table";

                    //PdfTextElement headerElement5 = new PdfTextElement("Cross-Reference Table", fontHead2, PdfBrushes.Black);
                    //headerElement5.PdfTag = hTextElement6;
                    //headerElement5.Draw(page2, new PointF(0, 380));

                    //PdfStructureElement textElement6 = new PdfStructureElement(PdfTagType.Paragraph);
                    //textElement6.Parent = hTextElementLevel3;
                    //textElement6.ActualText = crossRef;

                    //PdfTextElement element6 = new PdfTextElement(crossRef, fontnormal);
                    //element6.PdfTag = textElement6;
                    //element6.Brush = new PdfSolidBrush(Color.Black);
                    //element6.Draw(page2, new RectangleF(0, 410, page2.GetClientSize().Width, 50));

                    //PdfStructureElement hTextElement7 = new PdfStructureElement(PdfTagType.HeadingLevel2);
                    //hTextElement7.Parent = hTextElement1;
                    //hTextElement7.ActualText = "Trailer";

                    //PdfTextElement headerElement6 = new PdfTextElement("Trailer", fontHead2, PdfBrushes.Black);
                    //headerElement6.PdfTag = hTextElement7;
                    //headerElement6.Draw(page2, new PointF(0, 470));

                    //PdfStructureElement textElement7 = new PdfStructureElement(PdfTagType.Paragraph);
                    //textElement7.Parent = hTextElementLevel3;
                    //textElement7.ActualText = trailer;

                    //PdfTextElement element7 = new PdfTextElement(trailer, fontnormal);
                    //element7.PdfTag = textElement7;
                    //element7.Brush = new PdfSolidBrush(Color.Black);
                    //element7.Draw(page2, new RectangleF(0, 500, page2.GetClientSize().Width, 110));



                    //#endregion

                    //#region page3

                    //PdfPage page3 = document.Pages.Add();

                    //PdfStructureElement hTextElement4 = new PdfStructureElement(PdfTagType.HeadingLevel2);
                    //hTextElement4.Parent = hTextElement1;
                    //hTextElement4.ActualText = "Resource";

                    //PdfTextElement headerElement4 = new PdfTextElement("Resource", fontHead2, PdfBrushes.Black);
                    //headerElement4.PdfTag = hTextElement4;
                    //headerElement4.Draw(page3, new PointF(0, 0));

                    //PdfStructureElement textElement4 = new PdfStructureElement(PdfTagType.Paragraph);
                    //textElement4.Parent = hTextElementLevel3;
                    //textElement4.ActualText = resource;

                    //PdfTextElement element4 = new PdfTextElement(resource, fontnormal);
                    //element4.PdfTag = textElement4;
                    //element4.Brush = new PdfSolidBrush(Color.Black);
                    //element4.Draw(page3, new RectangleF(0, 40, page2.GetClientSize().Width, 70));

                    ////Create a new PdfGrid.
                    //PdfGrid pdfGrid = new PdfGrid();

                    //PdfStructureElement element = new PdfStructureElement(PdfTagType.Table);

                    ////Adding tag to PDF grid.
                    //pdfGrid.PdfTag = element;

                    ////Add three columns.
                    //pdfGrid.Columns.Add(3);
                    //PdfGridRow[] headerRow = pdfGrid.Headers.Add(3);
                    //PdfGridRow pdfGridHeader = pdfGrid.Headers[0];
                    //pdfGridHeader.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

                    //PdfGridCellStyle headerStyle = new PdfGridCellStyle();
                    //headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 13);
                    //pdfGridHeader.ApplyStyle(headerStyle);

                    //pdfGridHeader.Cells[0].Value = "Times Roman Family";
                    //pdfGridHeader.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

                    //pdfGridHeader.Cells[1].Value = "Helvetica Family";
                    //pdfGridHeader.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);
                    //pdfGridHeader.Cells[2].Value = "Courier Family";
                    //pdfGridHeader.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

                    //PdfGridRow pdfGridRow1 = pdfGrid.Rows.Add();
                    //pdfGridRow1.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

                    //pdfGridRow1.Cells[0].Value = "Times roman";

                    //pdfGridRow1.Cells[1].Value = "Helvetica";

                    //pdfGridRow1.Cells[2].Value = "Courier";

                    //pdfGridRow1.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
                    //pdfGridRow1.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
                    //pdfGridRow1.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);


                    //PdfGridRow pdfGridRow2 = pdfGrid.Rows.Add();
                    //pdfGridRow2.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

                    //pdfGridRow2.Cells[0].Value = "Times-Bold";

                    //pdfGridRow2.Cells[1].Value = "Helvetica-Bold";

                    //pdfGridRow2.Cells[2].Value = "Courier-Bold";

                    //pdfGridRow2.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
                    //pdfGridRow2.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
                    //pdfGridRow2.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

                    //PdfGridRow pdfGridRow3 = pdfGrid.Rows.Add();

                    //pdfGridRow3.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

                    //pdfGridRow3.Cells[0].Value = "Times-Italic";

                    //pdfGridRow3.Cells[1].Value = "Helvetica-Oblique";

                    //pdfGridRow3.Cells[2].Value = "Courier-Oblique";

                    //pdfGridRow3.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
                    //pdfGridRow3.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
                    //pdfGridRow3.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

                    //PdfGridRow pdfGridRow4 = pdfGrid.Rows.Add();

                    //pdfGridRow4.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

                    //pdfGridRow4.Cells[0].Value = "Times-BoldItalic";

                    //pdfGridRow4.Cells[1].Value = "Helvetica-BoldOblique";

                    //pdfGridRow4.Cells[2].Value = "Courier-BoldOblique";

                    //pdfGridRow4.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
                    //pdfGridRow4.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
                    //pdfGridRow4.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);



                    ////pdfGrid.BeginCellLayout += PdfGrid_BeginCellLayout;
                    //pdfGrid.Draw(page3, new PointF(20, 130));

                    //PdfStructureElement element8 = new PdfStructureElement(PdfTagType.Figure);
                    //element8.AlternateText = "Rectangle Sample";
                    //PdfRectangle rect = new PdfRectangle(20, 120, 490, 90);
                    //rect.PdfTag = element8;
                    //rect.Draw(page3.Graphics);



                    //#endregion




                    ////Saving the PDF to the MemoryStream
                    //MemoryStream ms = new MemoryStream();
                    //document.Save(ms);
                    ////If the position is not set to '0' then the PDF will be empty.
                    //ms.Position = 0;

                    ////Download the PDF document in the browser.
                    //FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                    //fileStreamResult.FileDownloadName = "Customtag.pdf";
                    //return fileStreamResult;





                    //PdfDocument document = new PdfDocument();
                    //document.PageSettings.Orientation = PdfPageOrientation.Landscape;
                    //document.PageSettings.Margins.All = 50;               


                    //    //Add a page to the document.
                    //    PdfPage page = document.Pages.Add();

                    //    //Create PDF graphics for the page.
                    //    PdfGraphics graphics = page.Graphics;

                    //    //Create a text element with the text and font.
                    //    PdfTextElement element = new PdfTextElement("Dambi Dollo University\nPhone +25157555\nEmail info@dadu.edu.et,\nDambi Dollo Ethiopia..");
                    //    element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                    //    element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                    //    PdfLayoutResult result = element.Draw(page, new RectangleF(1, 1, page.Graphics.ClientSize.Width / 2, 200));

                    //    //Draw the image to PDF page with specified size. 
                    //    FileStream imageStream = new FileStream(_hostingEnvironment.WebRootPath + "/assets/images/main-logo.jpg", FileMode.Open, FileAccess.Read);
                    //    PdfImage img = new PdfBitmap(imageStream);

                    //    graphics.DrawImage(img, new RectangleF(graphics.ClientSize.Width - 200, result.Bounds.Y, 90, 90));
                    //    PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
                    //    graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(126, 151, 173)), new RectangleF(0, result.Bounds.Bottom + 40, graphics.ClientSize.Width, 30));

                    //    //Get Payrolls list to create Payroll.
                    //    List<Payroll> list = new List<Payroll>();
                    //    IEnumerable<Payroll> objpayroll = _db.payroll;
                    //    foreach (Payroll cust in objpayroll)
                    //    {
                    //        list.Add(cust);
                    //    }
                    //    var reducedList = list.Select(f => new { f.IDNo,f.FirstName, f.MiddleName, f.LastName, f.BasicSalary, f.BasicEarning, }).ToList();
                    //    //Create a PDF grid with product details.
                    //    PdfGrid grid = new PdfGrid();
                    //    grid.DataSource = reducedList;
                    //    //Create a text element and draw it to PDF page.
                    //    element = new PdfTextElement(shipName, new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                    //    element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                    //    result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 5, graphics.ClientSize.Width / 2, 100));

                    //    //Create a text element and draw it to PDF page.
                    //    element = new PdfTextElement(string.Format("{0}, {1}, {2}", address, shipCity, shipCountry), new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                    //    element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                    //    result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 3, graphics.ClientSize.Width / 2, 100));



                    //    PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                    //    layoutFormat.Layout = PdfLayoutType.Paginate;

                    //    //Draw grid to the page of PDF document.
                    //    PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(graphics.ClientSize.Width-400, graphics.ClientSize.Height+4000  )), layoutFormat);



                    //var reducedList1 = list.Select(f => new { f.TotalDeduction, f.Tax, f.GrossEarning, f.NetPayment, f.PhoneAllowance, f.OtherAllowance, f.PayrollMonth, f.PayrollYear }).ToList();
                    ////Create a PDF grid with product details.
                    //PdfGrid grid1 = new PdfGrid();
                    //grid1.DataSource = reducedList1;
                    ////Create a text element and draw it to PDF page.
                    //element = new PdfTextElement(shipName, new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                    //element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                    //result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 5, graphics.ClientSize.Width / 2, 100));

                    ////Create a text element and draw it to PDF page.
                    //element = new PdfTextElement(string.Format("{0}, {1}, {2}", address, shipCity, shipCountry), new PdfStandardFont(PdfFontFamily.TimesRoman, 10));
                    //element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                    //result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 3, graphics.ClientSize.Width / 2, 100));



                    //PdfGridLayoutFormat layoutFormat1 = new PdfGridLayoutFormat();
                    //layoutFormat.Layout = PdfLayoutType.Paginate;

                    ////Draw grid to the page of PDF document.
                    //PdfGridLayoutResult gridResult1 = grid1.Draw(page, new RectangleF(new PointF(400, result.Bounds.Bottom + 40), new SizeF(graphics.ClientSize.Width+400, graphics.ClientSize.Height +300)), layoutFormat1);



                    //MemoryStream stream = new MemoryStream();
                    //    document.Save(stream);
                    //    //Set the position as '0'.
                    //    stream.Position = 0;
                    //    //Download the PDF document in the browser.
                    //    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
                    //    fileStreamResult.FileDownloadName = "Payroll.pdf";
                    //    TempData["error"] = "Payroll has been already generated";
                    //    return fileStreamResult;

                }
            }
            return View();
        }
        private bool PayrollModelExists(DateTime EndTime)
        {
            return _db.payroll.Any(e => e.PayrollMonth== EndTime.Month && e.PayrollYear== EndTime.Year);
        }

        public static string DataPathBase
        {
            get
            {

                return System.Environment.CurrentDirectory + @"\..\..\Data\";

            }
        }
        public static string DataPathOutput
        {
            get
            {
                if (!System.IO.Directory.Exists(System.Environment.CurrentDirectory + @"\..\..\Output\"))
                    System.IO.Directory.CreateDirectory(System.Environment.CurrentDirectory + @"\..\..\Output\");
                return System.Environment.CurrentDirectory + @"\..\..\Output\";
            }
        }
    
    }
}

