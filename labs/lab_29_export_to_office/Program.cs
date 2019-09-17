using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using System.Diagnostics;

namespace lab_29_export_to_office
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToSaveIn = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string fileName = @"RabbitReport.docx";
            string DesktopName = pathToSaveIn  + fileName;

            //var doc = DocX.Create(fileName);
            var doc2 = DocX.Create(DesktopName);

            doc2.InsertParagraph("Rabbit Report");

            doc2.InsertParagraph("Number of rabbits created: 1000");

            doc2.InsertParagraph("Time taken: 7.356 seconds with one loop");
            doc2.InsertParagraph("Time taken: 17.356 seconds with 1000 loop");

            doc2.Save();

            //Process.Start("WINWORD.EXE", fileName);
            Process.Start("WINWORD.EXE", DesktopName);
        }
    }
}
