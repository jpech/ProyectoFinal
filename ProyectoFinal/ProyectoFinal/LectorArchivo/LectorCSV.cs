using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProyectoFinal.LectorArchivo
{
    public class LectorCSV : ILector
    {
        public List<string> LeerDatos(string ruta)
        {
            try
            {
                if (string.IsNullOrEmpty(ruta))
                    throw new Exception("La ruta del archivo está vacía");

                List<string> lineas = new List<string>();
                FileInfo fileInfo = new FileInfo(ruta);
                ExcelPackage package = new ExcelPackage(fileInfo);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                if(worksheet == null)
                    throw new FileNotFoundException("No se encontró el archivo.");

                if (worksheet.Dimension != null)
                {
                    int rows = worksheet.Dimension.Rows; // 20
                    int columns = 1; // 7

                    for (int i = 1; i <= rows; i++)
                    {
                        if(!string.IsNullOrWhiteSpace(worksheet.Cells[i, columns].Value.ToString()))
                            lineas.Add(worksheet.Cells[i, columns].Value.ToString());
                    }
                }
                return lineas;
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
        }
    }
}
