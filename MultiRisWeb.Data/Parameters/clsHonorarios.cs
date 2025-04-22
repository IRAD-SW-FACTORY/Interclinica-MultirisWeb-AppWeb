// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Parameters.clsHonorarios
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using MultiRisWeb.Data.DataAccess;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using System.Web;

namespace MultiRisWeb.Data.Parameters
{
  public class ClsHonorarios
  {
    public string fechaExamen { get; set; }

    public string idPaciente { get; set; }

    public string codigoExamen { get; set; }

    public string fechaAsignacion { get; set; }

    public string fechaValidacionInforme { get; set; }

    public string prestacionInforme { get; set; }

    public string userNameRadiologo { get; set; }

    public string radiologoInforme { get; set; }

    public string tipoRadiologo { get; set; }

    public string institucion { get; set; }

        public Stream DataTableToExcel(DataTable dt)
        {
            try
            {
                // Crear el libro de trabajo y la hoja
                XSSFWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Informe Honorarios");

                // Crear la fila de encabezados
                IRow headerRow = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }

                // Agregar las filas de datos
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                // Ajustar el ancho de las columnas
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.AutoSizeColumn(i);
                }

                // Usar un archivo temporal para escribir los datos
                string tempFilePath = Path.GetTempFileName();

                using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);
                }

                // Leer el archivo temporal en un MemoryStream
                var finalStream = new MemoryStream();
                using (var fileStream = new FileStream(tempFilePath, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(finalStream);
                }

                // Eliminar el archivo temporal
                File.Delete(tempFilePath);

                // Posicionar el stream al inicio
                finalStream.Position = 0;

                return finalStream;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //XSSFWorkbook xssfWorkbook = new XSSFWorkbook();
            //MemoryStream excel = new MemoryStream();
            //ISheet sheet = xssfWorkbook.CreateSheet("Informe Honorarios");
            //XSSFRow xssfRow1;
            //XSSFRow xssfRow2 = xssfRow1 = (XSSFRow) sheet.CreateRow(0);

            //try
            //{
            //    foreach (DataColumn column in (InternalDataCollectionBase) dt.Columns) xssfRow2.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            //    int rownum = 1;

            //    foreach (DataRow row1 in (InternalDataCollectionBase) dt.Rows)
            //    {
            //        XSSFRow row2 = (XSSFRow) sheet.CreateRow(rownum);

            //        foreach (DataColumn column in (InternalDataCollectionBase) dt.Columns) row2.CreateCell(column.Ordinal).SetCellValue(row1[column].ToString());

            //        ++rownum;
            //    }

            //    for (int column = 0; column <= dt.Columns.Count; ++column) sheet.AutoSizeColumn(column);

            //    xssfWorkbook.Write((Stream) excel);

            //    excel.Flush();
            //}
            //catch (Exception ex)
            //{
            //    return (Stream) null;
            //}
            //finally
            //{
            //    excel.Close();
            //    xssfRow1 = (XSSFRow) null;
            //}

            //return (Stream) excel;
        }

        public void descargarExcelHonorarios(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                // Obtener el DataTable
                DataTable dataTable = RisExamenDataAccess.GetByFilterHonorariosWeb(fechaInicio, fechaFinal, HttpContext.Current.Session["username"].ToString());

                // Convertir el DataTable a Stream (XLSX)
                Stream excel = this.DataTableToExcel(dataTable);

                if (excel == null) return;

                // Preparar la respuesta HTTP para la descarga del archivo
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Informe_Honorarios.xlsx");

                // Escribir el archivo en la respuesta
                excel.CopyTo(HttpContext.Current.Response.OutputStream);

                // Finalizar la respuesta
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                // Manejar el error
                HttpContext.Current.Response.Write("Error: " + ex.Message);
                HttpContext.Current.Response.End();
            }
        }
    }
}
