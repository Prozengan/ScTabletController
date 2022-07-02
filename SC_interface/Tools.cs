using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScTabletController
{
    internal class Tools
    {
        public static void writeInLogFile(string data, bool deleteFile = false)
        {
            String savePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\STC\\";

            try
            {
                //Création du dossier si besoin
                bool exists = System.IO.Directory.Exists(savePath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(savePath);

                String documentPath = savePath + "STCController.txt";
                if (deleteFile)
                {
                    System.IO.File.Delete(documentPath);
                }
                System.IO.File.AppendAllText(documentPath, data);
                System.IO.File.AppendAllText(documentPath, "\n");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
