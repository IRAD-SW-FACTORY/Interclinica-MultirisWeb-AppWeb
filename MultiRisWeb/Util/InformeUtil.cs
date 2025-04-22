// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Util.InformeUtil
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.PDF;
using MultiRisWeb.Data.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;

namespace MultiRisWeb.Util
{
    public class InformeUtil
    {
        private static string ObtenerPathXML() => HttpContext.Current.Request.MapPath("~/Web/Xml/");

        public static MemoryStream createPDFInforme(InstitucionDomain institucion, RisInformeDomain informe)
        {
            MemoryStream os = new MemoryStream();
            RisExamenDomain byCodExamen = RisExamenDataAccess.GetByCodExamen(informe.codExamen);
            RisPatologiaCriticaDomain byId1 = RisPatologiaCriticaDataAccess.GetById(informe.id_patologia_grave);
            string estructura = institucion.estructura;
            AgeUtil ageUtil = new AgeUtil();
            RisInformeDatoDomain informeDatoDomain = new RisInformeDatoDomain();
            string str11 = ConfigurationManager.AppSettings.Get("urlFirma").ToString();
            string str1 = estructura.Replace("#FECHAEXAMEN#", byCodExamen.fechaexamen.ToString("dd-MM-yyyy HH:mm")).Replace("#INFORMEFECHA#", byCodExamen.fechavalidacion.ToString("dd-MM-yyyy HH:mm")).Replace("#SOLICITANTE#", byCodExamen.medicosolicitante);
            RisInformeDatoDomain byMultuple1 = RisInformeDatoDataAccess.GetByMultuple(informe.id_ris_informe, institucion.id_institucion, informe.codExamen, 11);
            string str2 = string.IsNullOrEmpty(byMultuple1.valor) ? str1.Replace("#ANTECEDENTES#", string.Empty).Replace("#ANTECEDENTESCLINICOS#", string.Empty) : str1.Replace("#ANTECEDENTES#", "<p><b>Antecedentes:</b></p> " + byMultuple1.valor.Replace("</p>\r\n\r\n<p>", "<br/>").Replace("\r\n\r\n", "<br/>")).Replace("#ANTECEDENTESCLINICOS#", "<p><b>Antecedentes:</b></p> " + byMultuple1.valor.Replace("</p>\r\n\r\n<p>", "<br/>").Replace("\r\n\r\n", "<br/>"));
            RisInformeDatoDomain byMultuple2 = RisInformeDatoDataAccess.GetByMultuple(informe.id_ris_informe, institucion.id_institucion, informe.codExamen, 12);
            string str3 = string.IsNullOrEmpty(byMultuple2.valor) ? str2.Replace("#HALLAZGOS#", string.Empty) : str2.Replace("#HALLAZGOS#", "<p><b>Hallazgos:</b></p>" + byMultuple2.valor.Replace("</p>\r\n\r\n<p>", "<br/>").Replace("\r\n\r\n", "<br/>"));
            RisInformeDatoDomain byMultuple3 = RisInformeDatoDataAccess.GetByMultuple(informe.id_ris_informe, institucion.id_institucion, informe.codExamen, 13);
            string str4 = string.IsNullOrEmpty(byMultuple3.valor) ? str3.Replace("#IMPRESION#", string.Empty).Replace("#IMPRESIONDIAGNOSTICA#", string.Empty) : str3.Replace("#IMPRESION#", "<p><b>Impresión: </b></p> " + byMultuple3.valor.Replace("</p>\r\n\r\n<p>", "<br/>").Replace("\r\n\r\n", "<br/>")).Replace("#IMPRESIONDIAGNOSTICA#", "<p><b>Impresión: </b></p> " + byMultuple3.valor.Replace("</p>\r\n\r\n<p>", "<br/>").Replace("\r\n\r\n", "<br/>"));
            RisInformeDatoDomain byMultuple4 = RisInformeDatoDataAccess.GetByMultuple(informe.id_ris_informe, institucion.id_institucion, informe.codExamen, 16);
            string str5 = string.IsNullOrEmpty(byMultuple4.valor) ? str4.Replace("#TECNICA#", string.Empty) : str4.Replace("#TECNICA#", "<p><b>Técnica: </b></p>" + byMultuple4.valor.Replace("</p>\r\n\r\n<p>", "<br/>").Replace("\r\n\r\n", "<br/>"));
            string str6 = string.IsNullOrEmpty(informe.patologia_grave) || informe.flag_patologia_grave <= 0 ? str5.Replace("#NOTIFICACION#", "") : (byId1 == null || byId1.marca_leyenda_informe != 0 ? str5.Replace("#NOTIFICACION#", "Resultado crítico que requiere notificación") : str5.Replace("#NOTIFICACION#", ""));
            IList<RisAddendumDomain> codExamenIdInforme = RisAddendumDataAccess.GetByCodExamenIDInforme(informe.codExamen, informe.id_ris_informe);
            string newValue1 = string.Empty;
            foreach (RisAddendumDomain risAddendumDomain in (IEnumerable<RisAddendumDomain>)codExamenIdInforme)
            {
                UsuarioDomain usuarioAddendum = UsuarioDataAccess.GetUsuarioAddendum(risAddendumDomain.username, institucion.id_institucion);
                newValue1 = "<b>Addendum con Fecha: </b>" + risAddendumDomain.fecha_hora.ToString("dd-MM-yyyy HH:mm");
                newValue1 += risAddendumDomain.addendum;
                // newValue1 += "<br />" + usuarioAddendum.nombre + " " + usuarioAddendum.apellido_paterno + " " + usuarioAddendum.apellido_materno;               
                newValue1 += "<br />";
                newValue1 += "<br />";
                newValue1 += "#FIRMAADD#";


                UsuarioInstitucionDomain usuarioInstitucion = UsuarioInstitucionDataAccess.GetByUserAndInst(usuarioAddendum.id_usuario, institucion.id_institucion);

                if (usuarioInstitucion.id_tipo_firma == 1)
                {
                    UsuarioDomain byId2 = UsuarioDataAccess.GetById((long)usuarioAddendum.id_usuario_referencia);
                    string newValue4 = !string.IsNullOrEmpty(byId2.firma) ? "<div style='width: 30%; float: left; height: 180px!important;'> <p style='text-align: center;'></p></div><div style='width: 50%; float: left; height: 180px!important;'><img style='width: 100% !important' src=\"" + str11 + byId2.firma + "\" ></img></div><div style='width: 20%; float: left; height: 200px!important;'></div>" : "";
                    newValue1 = newValue1.Replace("#FIRMAADD#", newValue4).Replace("#FIRMAADD#", newValue4).Replace("#FIRMAADD#", string.Empty);
                }
                else if (usuarioInstitucion.id_tipo_firma == 2)
                {
                    UsuarioDomain byId3 = UsuarioDataAccess.GetById((long)usuarioAddendum.id_usuario_referencia);
                    string empty = string.Empty;
                    string newValue5 = string.Empty + (!string.IsNullOrEmpty(byId3.firma) ? "<div style='width: 30%; float: left; height: 180px!important;'> <p style='text-align: center;'></p></div><div style='width: 50%; float: left; height: 180px!important;'><img src=\"" + str11 + byId3.firma + "\" style='width: 100% !important;'></img></div><div style='width: 20%; float: left; height: 200px!important;'></div>" : "");
                    string newValue6 = empty + (!string.IsNullOrEmpty(usuarioAddendum.firma) ? "<div style='width: 30%; float: left; height: 180px!important;'> <p style='text-align: center;'></p></div><div style='width: 50%; float: left; height: 180px!important;'><img src=\"" + str11 + usuarioAddendum.firma + "\" style=\"width: 50px !important;\"></img></div><div style='width: 20%; float: left; height: 200px!important;'></div>" : "");
                    newValue1 = newValue1.Replace("#FIRMAADD#", newValue6).Replace("#FIRMAADD#", newValue6).Replace("#FIRMAADD#", newValue5);
                }
                else if (usuarioInstitucion.id_tipo_firma == 3)
                {
                    string newValue7 = !string.IsNullOrEmpty(usuarioAddendum.firma) ? "<div style='width: 30%; float: left; height: 180px!important;'> <p style='text-align: center;'></p></div><div style='width: 50%; float: left; height: 180px!important;'><img src=\"" + str11 + usuarioAddendum.firma + "\" style='width: 100% !important;'></img></div><div style='width: 20%; float: left; height: 200px!important;'></div>" : "";
                    newValue1 = newValue1.Replace("#FIRMAADD#", newValue7).Replace("#FIRMAADD#", newValue7).Replace("#FIRMAADD#", string.Empty);
                }
                else
                {
                    string newValue8 = !string.IsNullOrEmpty(usuarioAddendum.firma) ? "<div style='width: 30%; float: left; height: 180px!important;'> <p style='text-align: center;'></p></div><div style='width: 50%; float: left; height: 180px!important;'><img src=\"" + str11 + usuarioAddendum.firma + "\" style='width: 100% !important;'></img></div><div style='width: 20%; float: left; height: 200px!important;'></div>" : "";
                    newValue1 = newValue1.Replace("#FIRMAADD#", newValue8).Replace("#FIRMAADD#", newValue8).Replace("#FIRMAADD#", string.Empty).Replace("#MEDICO#", usuarioAddendum.nombre + " " + usuarioAddendum.apellido_paterno + " " + usuarioAddendum.apellido_materno);
                }
            }


            string str7 = str6.Replace("#ADDENDUM#", newValue1).Replace("#RUT#", byCodExamen.idpaciente).Replace("#IDPACIENTE#", byCodExamen.idpaciente);
            DateTime dateTime = byCodExamen.fechaexamen;
            string newValue2 = dateTime.ToString("dd-MM-yyyy HH:mm");
            string str8 = str7.Replace("#EXAMENFECHA#", newValue2).Replace("#NOMBRE#", byCodExamen.nombre).Replace("#APELLIDOPATERNO#", byCodExamen.apellidopaterno).Replace("#APELLIDOMATERNO#", byCodExamen.apellidomaterno).Replace("#MEDICOSOLICITANTE#", byCodExamen.medicosolicitante);
            dateTime = byCodExamen.fechanacimiento;
            string newValue3 = dateTime.ToString("dd-MM-yy");
            string str9 = str8.Replace("#FECHANACIMIENTO#", newValue3).Replace("#EDAD#", ageUtil.calculateAge(byCodExamen.fechanacimiento)).Replace("#QR#", !string.IsNullOrEmpty(institucion.codigo_qr) ? "<img style=\"width: 200px !important\" src=\"" + institucion.codigo_qr + "\" ></img>" : "").Replace("#TITULO#", informe.descripcion.ToUpper()).Replace("#LOGO#", institucion.logo).Replace("#LOGOFEET#", "logoAsistencialCAVRR.png").Replace("#EXAMENDESCRIPCION#", informe.descripcion.ToUpper());
            dateTime = informe.fecha_validacion;
            string upper = dateTime.ToString("dd-MM-yyyy HH:mm").ToUpper();
            string str10 = str9.Replace("#FECHAINFORME#", upper);
            UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername(informe.username_radiologo);
            UsuarioInstitucionDomain byUserAndInst = UsuarioInstitucionDataAccess.GetByUserAndInst(byUsername.id_usuario, institucion.id_institucion);
            string str12;
            if (byUserAndInst.id_tipo_firma == 1)
            {
                UsuarioDomain byId2 = UsuarioDataAccess.GetById((long)byUsername.id_usuario_referencia);
                string newValue4 = !string.IsNullOrEmpty(byId2.firma) ? "<img style=\"width: 100% !important\" src=\"" + str11 + byId2.firma + "\" ></img>" : "";
                str12 = str10.Replace("#FIRMA#", newValue4).Replace("#FIRMA1#", newValue4).Replace("#FIRMA2#", string.Empty);
            }
            else if (byUserAndInst.id_tipo_firma == 2)
            {
                UsuarioDomain byId3 = UsuarioDataAccess.GetById((long)byUsername.id_usuario_referencia);
                string empty = string.Empty;
                string newValue5 = string.Empty + (!string.IsNullOrEmpty(byId3.firma) ? "<img src=\"" + str11 + byId3.firma + "\" style=\"width: 100% !important;\"></img>" : "");
                string newValue6 = empty + (!string.IsNullOrEmpty(byUsername.firma) ? "<img src=\"" + str11 + byUsername.firma + "\" style=\"width: 100% !important;\"></img>" : "");
                str12 = str10.Replace("#FIRMA#", newValue6).Replace("#FIRMA1#", newValue6).Replace("#FIRMA2#", newValue5);
            }
            else if (byUserAndInst.id_tipo_firma == 3)
            {
                string newValue7 = !string.IsNullOrEmpty(byUsername.firma) ? "<img src=\"" + str11 + byUsername.firma + "\" style=\"width: 100% !important\"></img>" : "";
                str12 = str10.Replace("#FIRMA#", newValue7).Replace("#FIRMA1#", newValue7).Replace("#FIRMA2#", string.Empty);
            }
            else
            {
                string newValue8 = !string.IsNullOrEmpty(byUsername.firma) ? "<img src=\"" + str11 + byUsername.firma + "\" style=\"width: 100% !important\"></img>" : "";
                str12 = str10.Replace("#FIRMA#", newValue8).Replace("#FIRMA1#", newValue8).Replace("#FIRMA2#", string.Empty).Replace("#MEDICO#", byUsername.nombre + " " + byUsername.apellido_paterno + " " + byUsername.apellido_materno);
            }
            string s = str12.Replace("#MEDICO#", "");
            long margenSuperior = (long)institucion.margen_superior;
            long margenInferior = (long)institucion.margen_inferior;
            long margenIzquierda = (long)institucion.margen_izquierda;
            long margenDerecha = (long)institucion.margen_derecha;
            Document document = new Document(PageSize.LETTER, (float)margenIzquierda, (float)margenDerecha, (float)margenSuperior, (float)margenInferior);
            try
            {
                PdfWriter instance = PdfWriter.GetInstance(document, (Stream)os);
                PDFHeaderFooter pdfHeaderFooter1 = new PDFHeaderFooter();
                pdfHeaderFooter1.TextHeader = informe.descripcion.ToUpper();
                pdfHeaderFooter1.FlagPageNumber = true;
                foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (address.AddressFamily.ToString() == "InterNetwork")
                        address.ToString();
                }
                string path = ConfigurationManager.AppSettings["urlFirma"] + institucion.logo;
                if (System.IO.File.Exists(path))
                    pdfHeaderFooter1.PathLogoIzq = path;
                PDFHeaderFooter pdfHeaderFooter2 = pdfHeaderFooter1;
                string str13 = informe.id_ris_informe.ToString();
                dateTime = informe.fecha_validacion;
                string str14 = dateTime.ToString("dd-MM-yyyy HH:mm");
                string str15 = "ID informe: " + str13 + ", " + str14;
                pdfHeaderFooter2.TextFooter = str15;
                instance.PageEvent = (IPdfPageEvent)pdfHeaderFooter1;
                instance.InitialLeading = 12f;
                StringReader reader = new StringReader(s);

                if (institucion.id_institucion == 150)
                    new IradLogFile.LogFile(s.ToString());

                document.Open();
                CssAppliersImpl cssAppliersImpl = new CssAppliersImpl((IFontProvider)new XMLWorkerFontProvider());
                new CssFilesImpl().Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                StyleAttrCSSResolver styleAttrCssResolver = new StyleAttrCSSResolver();
                HtmlPipelineContext hpc = new HtmlPipelineContext((CssAppliers)cssAppliersImpl);
                hpc.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
                new XMLParser((IXMLParserListener)new XMLWorker((IPipeline)new CssResolverPipeline(XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true), (IPipeline)new HtmlPipeline(hpc, (IPipeline)new PdfWriterPipeline(document, instance))), true)).Parse((TextReader)reader);

                if (institucion.id_institucion == 150)
                    new IradLogFile.LogFile(os.Capacity.ToString());

                return os;
            }
            catch (Exception ex)
            {
                new IradLogFile.LogFile(ex.ToString());
                return os;
            }
            finally
            {
                if (document.IsOpen())
                    document.Close();
            }
        }

        public static void ConvertImageToPdf(string srcFilename, string dstFilename)
        {
            iTextSharp.text.Rectangle pageSize = (iTextSharp.text.Rectangle)null;
            using (Bitmap bitmap = new Bitmap(srcFilename))
                pageSize = new iTextSharp.text.Rectangle(0.0f, 0.0f, (float)bitmap.Width, (float)bitmap.Height);
            using (MemoryStream os = new MemoryStream())
            {
                Document document = new Document(pageSize, 0.0f, 0.0f, 0.0f, 0.0f);
                PdfWriter.GetInstance(document, (Stream)os).SetFullCompression();
                document.Open();
                document.Add((IElement)iTextSharp.text.Image.GetInstance(srcFilename));
                document.Close();
                System.IO.File.WriteAllBytes(dstFilename, os.ToArray());
            }
        }

        public static MemoryStream createPDFInformeOIT(InstitucionDomain institucion)
        {
            MemoryStream os = new MemoryStream();
            string estructura = institucion.estructura;
            long margenSuperior = (long)institucion.margen_superior;
            long margenInferior = (long)institucion.margen_inferior;
            long margenIzquierda = (long)institucion.margen_izquierda;
            long margenDerecha = (long)institucion.margen_derecha;
            Document document = new Document(PageSize.LETTER, (float)margenIzquierda, (float)margenDerecha, (float)margenSuperior, (float)margenInferior);
            try
            {
                PdfWriter instance = PdfWriter.GetInstance(document, (Stream)os);
                PDFHeaderFooter pdfHeaderFooter = new PDFHeaderFooter();
                pdfHeaderFooter.TextHeader = "Informe OIT";
                pdfHeaderFooter.FlagPageNumber = true;
                foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (address.AddressFamily.ToString() == "InterNetwork")
                        address.ToString();
                }
                string path = ConfigurationManager.AppSettings["urlFirma"] + institucion.logo;
                if (System.IO.File.Exists(path))
                    pdfHeaderFooter.PathLogoIzq = path;
                pdfHeaderFooter.TextFooter = "ID informe: Prueba de informe OIT ";
                instance.PageEvent = (IPdfPageEvent)pdfHeaderFooter;
                instance.InitialLeading = 12f;
                StringReader reader = new StringReader(estructura);
                document.Open();
                CssAppliersImpl cssAppliersImpl = new CssAppliersImpl((IFontProvider)new XMLWorkerFontProvider());
                new CssFilesImpl().Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                StyleAttrCSSResolver styleAttrCssResolver = new StyleAttrCSSResolver();
                HtmlPipelineContext hpc = new HtmlPipelineContext((CssAppliers)cssAppliersImpl);
                hpc.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
                new XMLParser((IXMLParserListener)new XMLWorker((IPipeline)new CssResolverPipeline(XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true), (IPipeline)new HtmlPipeline(hpc, (IPipeline)new PdfWriterPipeline(document, instance))), true)).Parse((TextReader)reader);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (document.IsOpen())
                    document.Close();
            }
            return os;
        }

        public static MemoryStream createPDFInformeOIT2(InstitucionDomain institucion, RisExamenDomain examen)
        {
            MemoryStream os = new MemoryStream();
            RisExamenDomain byCodExamen1 = RisExamenDataAccess.GetByCodExamen(examen.codexamen);
            string estructuraOit = institucion.estructura_oit;
            AgeUtil ageUtil = new AgeUtil();
            RisInformeOITDomain byCodExamen2 = RisInformeDataAccess.GetByCodExamen(examen.codexamen);
            IList<RisAddendumDomain> codExamenIdInforme = RisAddendumDataAccess.GetByCodExamenIDInforme(byCodExamen1.codexamen, byCodExamen1.id_ris_examen);
            string newValue = string.Empty;
            foreach (RisAddendumDomain risAddendumDomain in (IEnumerable<RisAddendumDomain>)codExamenIdInforme)
            {
                UsuarioDomain byUsername = UsuarioDataAccess.GetByUsername(risAddendumDomain.username);
                newValue = newValue + "<b>Addendum con Fecha: </b>" + risAddendumDomain.fecha_hora.ToString("dd-MM-yyyy HH:mm");
                newValue += risAddendumDomain.addendum;
                newValue = newValue + "<img src='" + ConfigurationManager.AppSettings["urlFirma"] + "#FIRMA#' width='100px'></img>";
                newValue = newValue + "<br />" + byUsername.nombre + " " + byUsername.apellido_paterno + " " + byUsername.apellido_materno;
                newValue += "<br />Medico Radiologo";
                newValue += "<br />";
                newValue += "<br />";
            }
            string str1 = estructuraOit.Replace("#ADDENDUM#", newValue).Replace("#lblInstitucion#", "HOSPITAL DEL COBRE").Replace("#lblFECHARAD#", "FECHA RADIOGRAFÍA").Replace("#lblNOMBRE#", "NOMBRE").Replace("#lblRUT#", "NÚMERO IDENTIFICADOR ").Replace("#NOMBRE#", byCodExamen1.nombre + " " + byCodExamen1.apellidopaterno + " " + byCodExamen1.apellidomaterno).Replace("#RUT#", byCodExamen1.idpaciente).Replace("#FECHARADIOGRAFIA#", byCodExamen1.fechaexamen.ToString("dd-MM-yyyy HH:mm")).Replace("#lblRADDIG#", "RADIOGRAFÍA DIGITAL").Replace("#lblMEDICO#", "MÉDICO").Replace("#lblTECNOLOGO#", "TECNÓLOGO").Replace("#lblLECTURA#", "LECTURA DE MEGATOSCOPIO").Replace("#SI#", "SI").Replace("#NO#", "NO").Replace("#NUMERORADIOGRAFIA#", byCodExamen2.numeroRadiografia.ToString()).Replace("#MEDICO#", byCodExamen1.medicosolicitante).Replace("#TECNOLOGO#", byCodExamen1.tecnologo).Replace("#VISIBLEFALSE#", "visible='false'").Replace("#LOGO#", ConfigurationManager.AppSettings["urlFirma"] + institucion.logo).Replace("#lblNoRAD#", "No DE RADIOGRAFÍA");
            string str2;
            switch (byCodExamen2.radiografiaDigital)
            {
                case "SI":
                    str2 = str1.Replace("#RADIGITALSI#", " background-color:rgb(255,0,0); border: 1px solid black;").Replace("#RADIGITALNO#", " bborder: 1px solid black; ");
                    break;
                case "NO":
                    str2 = str1.Replace("#RADIGITALNO#", " background-color:rgb(255,0,0); border: 1px solid black;; ").Replace("#RADIGITALSI#", " border: 1px solid black; ");
                    break;
                default:
                    str2 = str1.Replace("#RADIGITALNO#", " border: 1px solid black; ").Replace("#RADIGITALSI#", " border: 1px solid black; ");
                    break;
            }
            string str3;
            switch (byCodExamen2.lecturaNegatoscopio)
            {
                case "SI":
                    str3 = str2.Replace("#LECTURASI#", " background-color:rgb(255,0,0); border: 1px solid black;").Replace("#LECTURANO#", " border: 1px solid black; ");
                    break;
                case "NO":
                    str3 = str2.Replace("#LECTURANO#", " background-color:rgb(255,0,0); border: 1px solid black;").Replace("#LECTURASI#", " border: 1px solid black;");
                    break;
                default:
                    str3 = str2.Replace("#LECTURANO#", " border: 1px solid black; ").Replace("#LECTURASI#", " border: 1px solid black; ");
                    break;
            }
            string str4 = str3.Replace("#lblCALCOMENT#", "CALIDAD COMENTARIO").Replace("#lblRADNORMAL#", "RADIOGRAFÍA NORMAL");
            switch (byCodExamen2.tecnicaQualidaden)
            {
                case "1":
                    str4 = str4.Replace("#CALCOMENTARIO1#", " background-color:rgb(255,0,0); border: 1px solid black; ").Replace("#CALCOMENTARIO2#", " border: 1px solid black; ").Replace("#CALCOMENTARIO3#", " border: 1px solid black; ").Replace("#CALCOMENTARIO4#", " border: 1px solid black; ");
                    break;
                case "2":
                    str4 = str4.Replace("#CALCOMENTARIO2#", " background-color:rgb(255,0,0); border: 1px solid black; ").Replace("#CALCOMENTARIO1#", " border: 1px solid black; ").Replace("#CALCOMENTARIO3#", " border: 1px solid black; ").Replace("#CALCOMENTARIO4#", " border: 1px solid black; ");
                    break;
                case "3":
                    str4 = str4.Replace("#CALCOMENTARIO3#", " background-color:rgb(255,0,0); border: 1px solid black; ").Replace("#CALCOMENTARIO1#", " border: 1px solid black; ").Replace("#CALCOMENTARIO2#", " border: 1px solid black; ").Replace("#CALCOMENTARIO4#", " border: 1px solid black; ");
                    break;
                case "4":
                    str4 = str4.Replace("#CALCOMENTARIO4#", " background-color:rgb(255,0,0); border: 1px solid black; ").Replace("#CALCOMENTARIO1#", " border: 1px solid black; ").Replace("#CALCOMENTARIO2#", " border: 1px solid black; ").Replace("#CALCOMENTARIO3#", " border: 1px solid black; ");
                    break;
            }
            string radiografiaNormal = byCodExamen2.radiografiaNormal;
            if (radiografiaNormal == "SI")
                str4 = str4.Replace("#SIRADNORMAL#", "  background-color:rgb(255,0,0);  ");
            if (radiografiaNormal == "NO")
                str4 = str4.Replace("#NORADNORMAL#", "  background-color:rgb(255,0,0); ");
            string str5 = str4.Replace("#lblANORMPAREN#", "ALGUNA ANORMALIDAD PARENQUIMATOSA CONSISTENTE CON NEUMOCONIOSIS ").Replace("#lblALGNORPLE#", "ALGUNA NORMALIDAD PLEURAL CONSISTENTE CON NEUMOCONIOSIS ");
            string anormalidadParenquimatosa = byCodExamen2.anormalidadParenquimatosa;
            string str6 = !(anormalidadParenquimatosa == "SI") ? str5.Replace("#SIANORMPAREN#", " border: 1px solid black; ") : str5.Replace("#SIANORMPAREN#", "  background-color:rgb(255,0,0); border: 1px solid black; ");
            string str7 = (!(anormalidadParenquimatosa == "NO") ? str6.Replace("#NOANORMPAREN#", " border: 1px solid black; ") : str6.Replace("#NOANORMPAREN#", "  background-color:rgb(255,0,0); border: 1px solid black; ")).Replace("#lblOPPEQ#", "OPACIDADES PEQUEÑAS").Replace("#lblOPGRA#", "OPACIDADES GRANDES");
            string primaria1 = byCodExamen2.primaria1;
            if (primaria1 == "p")
                str7 = str7.Replace("#PRIP#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#PRIS#", " ");
            if (primaria1 == "s")
                str7 = str7.Replace("#PRIS#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#PRIP#", " ");
            string secundaria1 = byCodExamen2.secundaria1;
            if (secundaria1 == "p")
                str7 = str7.Replace("#SECP#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#SECS#", " ");
            if (secundaria1 == "s")
                str7 = str7.Replace("#SECS#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#SECP#", " ");
            string primaria2 = byCodExamen2.primaria2;
            if (primaria2 == "q")
                str7 = str7.Replace("#PRIQ#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#PRIT#", " ");
            if (primaria2 == "t")
                str7 = str7.Replace("#PRIT#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#PRIQ#", " ");
            string secundaria2 = byCodExamen2.secundaria2;
            if (secundaria2 == "q")
                str7 = str7.Replace("#SECQ#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#SECT#", " ");
            if (secundaria2 == "t")
                str7 = str7.Replace("#SECT#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#SECQ#", " ");
            string primaria3 = byCodExamen2.primaria3;
            if (primaria3 == "r")
                str7 = str7.Replace("#PRIR#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#PRIU#", " ");
            if (primaria3 == "u")
                str7 = str7.Replace("#PRIU#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#PRIR#", " ");
            string secundaria3 = byCodExamen2.secundaria3;
            if (secundaria3 == "r")
                str7 = str7.Replace("#SECR#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#SECU#", " ");
            if (secundaria3 == "u")
                str7 = str7.Replace("#SECU#", " font-color:white; background-color:rgb(255,0,0); ").Replace("#SECR#", " ");
            string zonas1 = byCodExamen2.zonas1;
            if (zonas1 == "D")
                str7 = str7.Replace("#ZOND#", " background-color:rgb(255,0,0); ").Replace("#FZOND#", " font-color:white; ").Replace("#FZONI#", " ").Replace("#ZONI#", " ");
            if (zonas1 == "I")
                str7 = str7.Replace("#ZONI#", "  background-color:RGB(255,0,0); ").Replace("#FZONI#", "  font-color:white;  ").Replace("#ZOND#", " ").Replace("#FZOND#", " ");
            switch (byCodExamen2.profusion1)
            {
                case "0/0":
                    str7 = str7.Replace("#PRO00#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "0/1":
                    str7 = str7.Replace("#PRO01#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.profusion2)
            {
                case "1/0":
                    str7 = str7.Replace("#PRO10#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "1/1":
                    str7 = str7.Replace("#PRO11#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "1/2":
                    str7 = str7.Replace("#PRO12#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.profusion3)
            {
                case "2/1":
                    str7 = str7.Replace("#PRO21#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "2/2":
                    str7 = str7.Replace("#PRO22#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "2/3":
                    str7 = str7.Replace("#PRO23#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.profusion4)
            {
                case "3/2":
                    str7 = str7.Replace("#PRO32#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "3/3":
                    str7 = str7.Replace("#PRO33#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.opacidadesPequenas1)
            {
                case "O":
                    str7 = str7.Replace("#OPO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "A":
                    str7 = str7.Replace("#OPA#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "C":
                    str7 = str7.Replace("#OPC#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "B":
                    str7 = str7.Replace("#OPB#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            string anormalidadPleural = byCodExamen2.anormalidadPleural;
            if (anormalidadPleural == "SI")
                str7 = str7.Replace("#SINORPLEURAL#", " background-color:rgb(255,0,0); ");
            if (anormalidadPleural == "NO")
                str7 = str7.Replace("#NONORPLEURAL#", " background-color:rgb(255,0,0); ");
            string placasPleurales = byCodExamen2.placasPleurales;
            if (placasPleurales == "SI")
                str7 = str7.Replace("#SIPLAPLEURALES#", " background-color:rgb(255,0,0); ").Replace("#NOPLAPLEURALES#", " background-color:rgb(255,255,255); ");
            if (placasPleurales == "NO")
                str7 = str7.Replace("#NOPLAPLEURALES#", " background-color:rgb(255,0,0); ").Replace("#SIPLAPLEURALES#", " background-color:rgb(255,255,255);");
            switch (byCodExamen2.placasPleuralesSitioPerfil)
            {
                case "O":
                    str7 = str7.Replace("#SPO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#SPD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#SPI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesCalcificacionPerfil)
            {
                case "O":
                    str7 = str7.Replace("#CALPO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#CALPD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#CALPI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesSitioFrente)
            {
                case "O":
                    str7 = str7.Replace("#SFO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#SFD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#SFI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesCalcificacionFrente)
            {
                case "O":
                    str7 = str7.Replace("#CALFO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#CALFD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#CALFI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesSitioDiagrama)
            {
                case "O":
                    str7 = str7.Replace("#SDO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#SDD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#SDI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesCalcificacionDiagrama)
            {
                case "O":
                    str7 = str7.Replace("#CALDO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#CALDD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#CALDI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesSitioOtro)
            {
                case "O":
                    str7 = str7.Replace("#SOO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#SOD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#SOI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesCalcificacionOtro)
            {
                case "O":
                    str7 = str7.Replace("#CALOO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#CALOD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#CALOI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesExtencionPared1)
            {
                case "O":
                    str7 = str7.Replace("#EXO1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#EXD1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "1":
                    str7 = str7.Replace("#EX11#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "2":
                    str7 = str7.Replace("#EX21#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "3":
                    str7 = str7.Replace("#EX31#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesExtencionPared2)
            {
                case "O":
                    str7 = str7.Replace("#EXO2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#EXI2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "1":
                    str7 = str7.Replace("#EX12#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "2":
                    str7 = str7.Replace("#EX22#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "3":
                    str7 = str7.Replace("#EX32#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesAncho1)
            {
                case "D":
                    str7 = str7.Replace("#ANCHD1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "a":
                    str7 = str7.Replace("#ANCHA1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "b":
                    str7 = str7.Replace("#ANCHB1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "c":
                    str7 = str7.Replace("#ANCHC1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.placasPleuralesAncho2)
            {
                case "I":
                    str7 = str7.Replace("#ANCHI2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "a":
                    str7 = str7.Replace("#ANCHA2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "b":
                    str7 = str7.Replace("#ANCHB2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "c":
                    str7 = str7.Replace("#ANCHC2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.obliteracionAnguloCostofrenico)
            {
                case "O":
                    str7 = str7.Replace("#OBLIO#", " background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#OBLID#", " background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#OBLII#", " background-color:rgb(255,0,0); ");
                    break;
            }
            string engrosamientoPleuralDifuso = byCodExamen2.engrosamientoPleuralDifuso;
            if (engrosamientoPleuralDifuso == "SI")
                str7 = str7.Replace("#ENGROPLEUSI#", " background-color:rgb(255,0,0); ");
            if (engrosamientoPleuralDifuso == "NO")
                str7 = str7.Replace("#ENGROPLEUNO#", " background-color:rgb(255,0,0); ");
            switch (byCodExamen2.engrosamientoPleuralDifusoSitioPerfil)
            {
                case "O":
                    str7 = str7.Replace("#SITPERO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#SITPERD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#SITPERI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.engrosamientoPleuralDifusoCalcificacionPerfil)
            {
                case "O":
                    str7 = str7.Replace("#CALPERO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#CALPERD#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#CALPERI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.engrosamientoPleuralDifusoSitioFrente)
            {
                case "O":
                    str7 = str7.Replace("#SITFREO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#SITFRED#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#SITFREI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.engrosamientoPleuralDifusoCalcificacionFrente)
            {
                case "O":
                    str7 = str7.Replace("#CALFREO#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#CALFRED#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#CALFREI#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.engrosamientoPleuralDifusoExtencionPared1)
            {
                case "O":
                    str7 = str7.Replace("#EXPARO1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#EXPARD1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "1":
                    str7 = str7.Replace("#EXPAR11#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "2":
                    str7 = str7.Replace("#EXPAR21#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "3":
                    str7 = str7.Replace("#EXPAR31#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.engrosamientoPleuralDifusoExtencionPared2)
            {
                case "O":
                    str7 = str7.Replace("#EXPARO2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#EXPARI2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "1":
                    str7 = str7.Replace("#EXPAR12#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "2":
                    str7 = str7.Replace("#EXPAR22#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "3":
                    str7 = str7.Replace("#EXPAR32#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.engrosamientoPleuralDifusoAncho1)
            {
                case "A":
                    str7 = str7.Replace("#ANCHOOPCA1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "B":
                    str7 = str7.Replace("#ANCHOOPCB1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "C":
                    str7 = str7.Replace("#ANCHOOPCC1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "D":
                    str7 = str7.Replace("#ANCHOOPCD1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "a":
                    str7 = str7.Replace("#ANCHOOPCA1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "b":
                    str7 = str7.Replace("#ANCHOOPCB1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "c":
                    str7 = str7.Replace("#ANCHOOPCC1#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            switch (byCodExamen2.engrosamientoPleuralDifusoAncho2)
            {
                case "A":
                    str7 = str7.Replace("#ANCHOOPCA2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "B":
                    str7 = str7.Replace("#ANCHOOPCB2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "C":
                    str7 = str7.Replace("#ANCHOOPCC2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "I":
                    str7 = str7.Replace("#ANCHOOPCI2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "a":
                    str7 = str7.Replace("#ANCHOOPCA2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "b":
                    str7 = str7.Replace("#ANCHOOPCB2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
                case "c":
                    str7 = str7.Replace("#ANCHOOPCC2#", " font-color:white; background-color:rgb(255,0,0); ");
                    break;
            }
            string otrasAnormalidades = byCodExamen2.otrasAnormalidades;
            if (otrasAnormalidades == "SI")
                str7 = str7.Replace("#OTRASANORSI#", " background-color:rgb(255,0,0); ");
            if (otrasAnormalidades == "NO")
                str7 = str7.Replace("#OTRASANORNO#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_aa == 1)
                str7 = str7.Replace("#AA#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_at == 1)
                str7 = str7.Replace("#AT#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_ax == 1)
                str7 = str7.Replace("#AX#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_bu == 1)
                str7 = str7.Replace("#BU#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_ca == 1)
                str7 = str7.Replace("#CA#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_cg == 1)
                str7 = str7.Replace("#CG#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_cn == 1)
                str7 = str7.Replace("#CN#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_co == 1)
                str7 = str7.Replace("#CO#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_cp == 1)
                str7 = str7.Replace("#CP#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_cv == 1)
                str7 = str7.Replace("#CV#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_di == 1)
                str7 = str7.Replace("#DI#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_ef == 1)
                str7 = str7.Replace("#EF#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_em == 1)
                str7 = str7.Replace("#EM#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_es == 1)
                str7 = str7.Replace("#ES#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_fr == 1)
                str7 = str7.Replace("#FR#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_hi == 1)
                str7 = str7.Replace("#HI#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_ho == 1)
                str7 = str7.Replace("#HO#", " background-color:rgb(255,0,0);  ");
            if (byCodExamen2.simbolo_id == 1)
                str7 = str7.Replace("#ID#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_ih == 1)
                str7 = str7.Replace("#IH#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_kl == 1)
                str7 = str7.Replace("#KL#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_me == 1)
                str7 = str7.Replace("#ME#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_pa == 1)
                str7 = str7.Replace("#PA#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_pb == 1)
                str7 = str7.Replace("#PB#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_pi == 1)
                str7 = str7.Replace("#PI#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_px == 1)
                str7 = str7.Replace("#PX#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_ra == 1)
                str7 = str7.Replace("#RA#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_rp == 1)
                str7 = str7.Replace("#RP#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_tb == 1)
                str7 = str7.Replace("#TB#", " background-color:rgb(255,0,0); ");
            if (byCodExamen2.simbolo_od == 1)
                str7 = str7.Replace("#OD#", " background-color:rgb(255,0,0); ");
            string s = str7.Replace("#COMENTARIOGENERAL#", byCodExamen2.comentarioGeneral).Replace("#NOMBRERADIOLOGO#", byCodExamen1.nombreradiologo).Replace("#FECHALECTURA#", byCodExamen2.fechaLectura.ToString("dd-MM-yyyy HH:mm")).Replace("#FIRMARADIOLOGO#", ConfigurationManager.AppSettings["urlFirma"] + byCodExamen2.RadiologoValidador + ".png");
            long margenSuperior = (long)institucion.margen_superior;
            long margenInferior = (long)institucion.margen_inferior;
            long margenIzquierda = (long)institucion.margen_izquierda;
            long margenDerecha = (long)institucion.margen_derecha;
            Document document = new Document(PageSize.LETTER, (float)margenIzquierda, (float)margenDerecha, (float)margenSuperior, (float)margenInferior);
            try
            {
                PdfWriter instance = PdfWriter.GetInstance(document, (Stream)os);
                PDFHeaderFooter pdfHeaderFooter = new PDFHeaderFooter();
                pdfHeaderFooter.TextHeader = institucion.nombre;
                pdfHeaderFooter.FlagPageNumber = true;
                foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (address.AddressFamily.ToString() == "InterNetwork")
                        address.ToString();
                }
                string path = ConfigurationManager.AppSettings["urlFirma"] + institucion.logo;
                if (System.IO.File.Exists(path))
                    pdfHeaderFooter.PathLogoIzq = path;
                pdfHeaderFooter.TextFooter = "ID informe: " + byCodExamen1.id_ris_examen.ToString() + ", " + byCodExamen1.fechavalidacion.ToString("dd-MM-yyyy HH:mm");
                instance.PageEvent = (IPdfPageEvent)pdfHeaderFooter;
                instance.InitialLeading = 12f;
                StringReader reader = new StringReader(s);
                document.Open();
                CssAppliersImpl cssAppliersImpl = new CssAppliersImpl((IFontProvider)new XMLWorkerFontProvider());
                new CssFilesImpl().Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                StyleAttrCSSResolver styleAttrCssResolver = new StyleAttrCSSResolver();
                HtmlPipelineContext hpc = new HtmlPipelineContext((CssAppliers)cssAppliersImpl);
                hpc.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
                new XMLParser((IXMLParserListener)new XMLWorker((IPipeline)new CssResolverPipeline(XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true), (IPipeline)new HtmlPipeline(hpc, (IPipeline)new PdfWriterPipeline(document, instance))), true)).Parse((TextReader)reader);
                return os;
            }
            catch (Exception ex)
            {
                string str8 = ex.ToString();
                ApiErrorDataAccess.Save(new ApiErrorDomain()
                {
                    staktrace = "Error al crear PDF : " + str8
                });
                return os;
            }
            finally
            {
                if (document.IsOpen())
                    document.Close();
            }
        }

        #region InformeOIT nuevo
        public static MemoryStream createPDFOIT(DataRow data)
        {
            MemoryStream memoryStream = new MemoryStream();

            var doc = new Document(PageSize.LEGAL, 25, 25, 20, 20);
            var writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();

            #region Fuentes de letras
            var titleFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);
            var sectionFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            var textFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);
            var textFontSel = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            var textFontSub = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);
            var textFontSeccion = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            var fontinstitucion = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
            var sectionColor = new BaseColor(201, 199, 199);
            var central = new PdfPTable(1);
            #endregion Fuentes de letras

            writer.CloseStream = false;

            #region TITULO
            var title = new Paragraph(data["INSTITUCION"].ToString(), fontinstitucion);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 5;

            doc.Add(title);
            central.WidthPercentage = 100;

            var TituloPlantilla = new PdfPTable(1);
            TituloPlantilla.WidthPercentage = 100;

            PdfPCell _cell1 = new PdfPCell(new Phrase(string.Format("INTERPRETACIÓN RADIOLÓGICA {0}", data["RISINFORME"].ToString()), titleFont));
            _cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            _cell1.HorizontalAlignment = Element.ALIGN_CENTER;

            TituloPlantilla.AddCell(_cell1);

            PdfPCell _cell2 = new PdfPCell(new Phrase());
            _cell2.HorizontalAlignment = Element.ALIGN_CENTER;

            _cell2.AddElement(TituloPlantilla);

            central.AddCell(_cell2);

            doc.Add(central);
            #endregion TITULO

            #region Datos del paciente
            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;

            float[] anchosColumnas = new float[] { 50f, 25f, 25f };

            table.SetWidths(anchosColumnas);

            var celda1 = new PdfPCell(new Phrase(string.Format("Nombre: {0}", data["NOMBREPACIENTE"].ToString()), textFont));
            celda1.PaddingTop = 3f;
            celda1.PaddingBottom = 5f;

            var celda2 = new PdfPCell(new Phrase(string.Format("Rut: {0}", data["PACIENTEID"].ToString()), textFont));
            celda2.PaddingTop = 3f;
            celda2.PaddingBottom = 5f;

            var celda3 = new PdfPCell(new Phrase(string.Format("Fecha Radiografía:/n {0}", data["FECHARADIOGRAFIA"].ToString()), textFont));
            celda3.PaddingTop = 3f;
            celda3.PaddingBottom = 5f;

            table.AddCell(celda1);
            table.AddCell(celda2);
            table.AddCell(celda3);

            doc.Add(table);
            #endregion Datos del paciente

            #region Segunda linea informe 
            PdfPTable table2 = new PdfPTable(4);
            table2.WidthPercentage = 100;

            float[] row2Columnas = new float[] { 25f, 25f, 25f, 25f };

            table2.SetWidths(row2Columnas);

            var row2celda1 = new PdfPCell();

            var tablerow2celda1 = new PdfPTable(1);
            tablerow2celda1.WidthPercentage = 100;
            tablerow2celda1.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow2celda1.AddCell(new PdfPCell(new Phrase("N de radiografía:", textFont)) { Border = PdfPCell.NO_BORDER });

            var tablerow2celda2 = new PdfPTable(1);
            tablerow2celda2.WidthPercentage = 100;
            tablerow2celda2.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow2celda2.AddCell(new PdfPCell(new Phrase(string.Format("{0}", data["NUMRADIOGRAFIA"].ToString()), textFont)) { Border = PdfPCell.NO_BORDER });

            row2celda1.AddElement(tablerow2celda1);
            row2celda1.AddElement(tablerow2celda2);

            row2celda1.PaddingTop = 3f;
            row2celda1.PaddingBottom = 8f;

            var row2celda2 = new PdfPCell();

            var table1row1celda1 = new PdfPTable(1);
            table1row1celda1.WidthPercentage = 100;
            table1row1celda1.DefaultCell.Border = PdfPCell.NO_BORDER;
            table1row1celda1.AddCell(new PdfPCell(new Phrase("Radiografía digital:", textFont)) { Border = PdfPCell.NO_BORDER, PaddingBottom = 5f });

            var table1row2celda1 = new PdfPTable(4);

            float[] row2ColumnasRD = new float[] { 25f, 25f, 30f, 20f };

            table1row2celda1.SetWidths(row2ColumnasRD);

            table1row2celda1.WidthPercentage = 100;
            table1row2celda1.DefaultCell.Border = PdfPCell.NO_BORDER;
            table1row2celda1.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            if (data["RADIOGRAFIADIG"].ToString().Equals("1"))
            {
                table1row2celda1.AddCell(CellCircle(BaseColor.RED, "SI", textFont));
                table1row2celda1.AddCell(CellCircle(BaseColor.WHITE, "NO  ", textFont, 4f));
            }
            else
            {
                table1row2celda1.AddCell(CellCircle(BaseColor.WHITE, "SI", textFont));
                table1row2celda1.AddCell(CellCircle(BaseColor.RED, "NO  ", textFont, 4f));
            }

            table1row2celda1.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            row2celda2.AddElement(table1row1celda1);
            row2celda2.AddElement(table1row2celda1);

            var row2celda3 = new PdfPCell();

            var table1row1celda3 = new PdfPTable(1);
            table1row1celda3.WidthPercentage = 100;
            table1row1celda3.DefaultCell.Border = PdfPCell.NO_BORDER;
            table1row1celda3.AddCell(new PdfPCell(new Phrase("Médico:", textFont)) { Border = PdfPCell.NO_BORDER });

            var table1row2celda3 = new PdfPTable(1);
            table1row2celda3.WidthPercentage = 100;
            table1row2celda3.DefaultCell.Border = PdfPCell.NO_BORDER;
            table1row2celda3.AddCell(new PdfPCell(new Phrase(data["MEDICO"].ToString(), textFont)) { Border = PdfPCell.NO_BORDER });

            row2celda3.AddElement(table1row1celda3);
            row2celda3.AddElement(table1row2celda3);

            var row2celda4 = new PdfPCell();

            var table1row1celda4 = new PdfPTable(1);
            table1row1celda4.WidthPercentage = 100;
            table1row1celda4.DefaultCell.Border = PdfPCell.NO_BORDER;
            table1row1celda4.AddCell(new PdfPCell(new Phrase("Lectura de Negastocópio:", textFont)) { Border = PdfPCell.NO_BORDER, PaddingBottom = 5f });

            var table1row2celda4 = new PdfPTable(4);

            float[] row2ColumnasLN = new float[] { 25f, 25f, 30f, 20f };

            table1row2celda4.SetWidths(row2ColumnasLN);

            table1row2celda4.WidthPercentage = 100;
            table1row2celda4.DefaultCell.Border = PdfPCell.NO_BORDER;
            table1row2celda4.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            if (data["NEGASTOCOPIA"].ToString().Equals("1"))
            {
                table1row2celda4.AddCell(CellCircle(BaseColor.RED, "SI", textFont));
                table1row2celda4.AddCell(CellCircle(BaseColor.WHITE, "NO  ", textFont, 4f));
            }
            else
            {
                table1row2celda4.AddCell(CellCircle(BaseColor.WHITE, "SI", textFont));
                table1row2celda4.AddCell(CellCircle(BaseColor.RED, "NO  ", textFont, 4f));
            }

            table1row2celda4.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            row2celda4.PaddingTop = 3f;
            row2celda4.PaddingBottom = 5f;

            row2celda4.AddElement(table1row1celda4);
            row2celda4.AddElement(table1row2celda4);

            table2.AddCell(row2celda1);
            table2.AddCell(row2celda2);
            table2.AddCell(row2celda3);
            table2.AddCell(row2celda4);

            doc.Add(table2);
            #endregion Segunda linea informe 

            #region Espacio Tecnologo
            if (data["AETITLE"].ToString().Contains("CODELCO"))
            {
                PdfPTable tbtecnologo = new PdfPTable(1);
                tbtecnologo.WidthPercentage = 100;

                float[] rowColtecnologo = new float[] { 100 };

                tbtecnologo.SetWidths(rowColtecnologo);

                var celTecno = new PdfPCell();

                var _user = ConfigurationManager.AppSettings["UserWsCodelco"].ToString();
                var _pass = ConfigurationManager.AppSettings["PassWsCodelco"].ToString();

               
                var name = string.Empty;

                var tab1 = new PdfPTable(1);
                tab1.WidthPercentage = 100;
                tab1.DefaultCell.Border = PdfPCell.NO_BORDER;
                tab1.AddCell(new PdfPCell(new Phrase("Tecnólogo: " + name, textFont)) { Border = PdfPCell.NO_BORDER });

                celTecno.AddElement(tab1);

                celTecno.PaddingTop = 3f;
                celTecno.PaddingBottom = 5f;

                tbtecnologo.AddCell(celTecno);

                doc.Add(tbtecnologo);
            }
            #endregion Espacio Tecnologo

            #region Seteo Tabla Seccion
            PdfPTable table3 = new PdfPTable(2);
            table3.WidthPercentage = 100;

            float[] row3Columnas = new float[] { 50f, 50f };

            table3.SetWidths(row3Columnas);

            var row3celda1 = new PdfPCell();

            var tablerow3celda1 = new PdfPTable(2);

            float[] row3ColumnasSe = new float[] { 6f, 94f };
            #endregion Seteo Tabla Seccion

            #region Sector 1A
            tablerow3celda1.SetWidths(row3ColumnasSe);

            tablerow3celda1.WidthPercentage = 100;
            tablerow3celda1.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow3celda1.AddCell(new PdfPCell(new Phrase("1A", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tablerow3celda1.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            PdfPTable table4 = new PdfPTable(2);
            table4.WidthPercentage = 100;

            float[] row3Columnas1 = new float[] { 45f, 59f };

            table4.SetWidths(row3Columnas1);

            var tb4celda2 = new PdfPCell(new Phrase(string.Format("Técnica Qualidaden:"), textFont)) { Border = PdfPCell.NO_BORDER, PaddingBottom = 5f };

            var tb4celda3 = new PdfPCell() { Border = PdfPCell.NO_BORDER };

            var table4row2celda3 = new PdfPTable(4);

            float[] row2ColumnasQA = new float[] { 25f, 25f, 25f, 25f };

            table4row2celda3.SetWidths(row2ColumnasQA);

            table4row2celda3.WidthPercentage = 100;

            for (int i = 1; i < 5; i++)
            {
                if (data["CALIDAD"].ToString().Equals(i.ToString()))
                    table4row2celda3.AddCell(CellCircle(BaseColor.RED, string.Format("{0}", i.ToString()), textFont));
                else
                    table4row2celda3.AddCell(CellCircle(BaseColor.WHITE, string.Format("{0}", i.ToString()), textFont));
            }

            tb4celda3.AddElement(table4row2celda3);

            table4.AddCell(tb4celda2);
            table4.AddCell(tb4celda3);

            PdfPTable table5row3celda1 = new PdfPTable(1);
            float[] row3Columnas2 = new float[] { 100f };

            table5row3celda1.SetWidths(row3Columnas2);
            table5row3celda1.WidthPercentage = 100;
            table5row3celda1.AddCell(new PdfPCell(new Phrase(string.Format("Comentario: {0}", data["COMENTARIO"].ToString()), textFont)) { Border = PdfPCell.NO_BORDER });
            #endregion Sector 1A

            #region sector 1B
            var row3celda2 = new PdfPCell();

            var tablerow3celda2 = new PdfPTable(2);

            tablerow3celda2.SetWidths(row3ColumnasSe);

            tablerow3celda2.WidthPercentage = 100;
            tablerow3celda2.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow3celda2.AddCell(new PdfPCell(new Phrase("1B", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });

            tablerow3celda2.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            PdfPTable table6row3celda1 = new PdfPTable(3);

            table6row3celda1.WidthPercentage = 100;

            float[] row3ColumnasRN = new float[] { 6f, 40f, 54f };

            table6row3celda1.SetWidths(row3ColumnasRN);

            var tb6celda1 = new PdfPCell(new Phrase(string.Format(""), textFont)) { Border = PdfPCell.NO_BORDER, PaddingBottom = 5f };
            var tb6celda2 = new PdfPCell(new Phrase(string.Format("Radiografía Normal: "), textFont)) { Border = PdfPCell.NO_BORDER, PaddingBottom = 5f };
            var tb6celda3 = new PdfPCell(new Phrase()) { Border = PdfPCell.NO_BORDER, PaddingBottom = 5f };

            var table6row3celda2 = new PdfPTable(2);

            float[] row2ColumnasRND = new float[] { 25f, 30f };

            table6row3celda2.SetWidths(row2ColumnasRND);

            table6row3celda2.WidthPercentage = 70;

            if (data["RADIOGRAFIANOR"].ToString().Equals("1"))
            {
                table6row3celda2.AddCell(CellCircle(BaseColor.RED, "SI", textFont));
                table6row3celda2.AddCell(CellCircle(BaseColor.WHITE, "NO  ", textFont));
            }
            else
            {
                table6row3celda2.AddCell(CellCircle(BaseColor.WHITE, "SI", textFont));
                table6row3celda2.AddCell(CellCircle(BaseColor.RED, "NO  ", textFont));
            }

            tb6celda3.AddElement(table6row3celda2);

            table6row3celda1.AddCell(tb6celda1);
            table6row3celda1.AddCell(tb6celda2);
            table6row3celda1.AddCell(tb6celda3);

            row3celda1.AddElement(tablerow3celda1);
            row3celda1.AddElement(table4);
            row3celda1.AddElement(table5row3celda1);
            row3celda2.AddElement(tablerow3celda2);
            row3celda2.AddElement(table6row3celda1);

            table3.AddCell(row3celda1);
            table3.AddCell(row3celda2);

            doc.Add(table3);
            #endregion sector 1B

            #region Sector 2A
            PdfPTable table5 = new PdfPTable(1);
            table5.WidthPercentage = 100;

            float[] row5Columnas = new float[] { 100f };

            table5.SetWidths(row5Columnas);

            var row4celda1 = new PdfPCell() { PaddingBottom = 5f };

            var tablerow5 = new PdfPTable(3);
            float[] row5ColumnasSe = new float[] { 3f, 77f, 20f };

            tablerow5.SetWidths(row5ColumnasSe);

            tablerow5.WidthPercentage = 100;
            tablerow5.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow5.AddCell(new PdfPCell(new Phrase("2A", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tablerow5.AddCell(new PdfPCell(new Phrase("ALGUNA ANORMALIDAD PARENQUIMATOSA CONSISTENTE CON NEUMOCONIOSIS:", textFont)) { Border = PdfPCell.NO_BORDER });
            tablerow5.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            row4celda1.AddElement(tablerow5);

            var table1row5 = new PdfPTable(6);
            float[] row5Columnas1 = new float[] { 10f, 5f, 30f, 2f, 5f, 46 };

            table1row5.SetWidths(row5Columnas1);
            table1row5.WidthPercentage = 100;
            table1row5.DefaultCell.Border = PdfPCell.NO_BORDER;
            table1row5.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER, PaddingTop = 3f, PaddingBottom = 5f });

            if (data["PARENQUIMATOSA"].ToString().Equals("SI"))
                table1row5.AddCell(CellCircle(BaseColor.RED, "", textFont));
            else
                table1row5.AddCell(CellCircle(BaseColor.WHITE, "", textFont));

            table1row5.AddCell(new PdfPCell(new Phrase(" Si (completar 2B y 2C) ", textFont)) { Border = PdfPCell.NO_BORDER, PaddingTop = 3f, PaddingBottom = 5f });
            table1row5.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER, PaddingTop = 3f, PaddingBottom = 5f });

            if (data["PARENQUIMATOSA"].ToString().Equals("NO"))
                table1row5.AddCell(CellCircle(BaseColor.RED, "", textFont));
            else
                table1row5.AddCell(CellCircle(BaseColor.WHITE, "", textFont));

            table1row5.AddCell(new PdfPCell(new Phrase(" NO (pasar por sección 3) ", textFont)) { Border = PdfPCell.NO_BORDER, PaddingTop = 3f, PaddingBottom = 5f });

            row4celda1.AddElement(table1row5);

            table5.AddCell(row4celda1);

            doc.Add(table5);
            #endregion sector 2A

            #region Sector 2B Opacidades Pequeñas
            PdfPTable table6 = new PdfPTable(2);
            table6.WidthPercentage = 100;

            float[] row6Columnas = new float[] { 75f, 25f };

            table6.SetWidths(row6Columnas);

            var row5celda1 = new PdfPCell() { PaddingBottom = 5f };

            var tablerow6 = new PdfPTable(2);
            float[] row6ColumnasSe = new float[] { 4f, 96f };

            tablerow6.SetWidths(row6ColumnasSe);

            tablerow6.WidthPercentage = 100;
            tablerow6.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow6.AddCell(new PdfPCell(new Phrase("2B", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tablerow6.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            row5celda1.AddElement(tablerow6);

            var tablerow8 = new PdfPTable(2);
            float[] row7Columnas = new float[] { 5f, 95f };

            tablerow8.SetWidths(row7Columnas);

            tablerow8.WidthPercentage = 100;
            tablerow8.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow8.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });
            tablerow8.AddCell(new PdfPCell(new Phrase("Opacidades Pequeñas:", textFont)) { Border = PdfPCell.NO_BORDER });

            row5celda1.AddElement(tablerow8);

            var tablerow10 = new PdfPTable(6);
            float[] row9Columnas = new float[] { 4f, 30f, 4f, 25f, 4f, 35f };

            tablerow10.SetWidths(row9Columnas);

            tablerow10.WidthPercentage = 100;
            tablerow10.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow10.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablerow10.AddCell(new PdfPCell(new Phrase("a) Forma y Tamaño:", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablerow10.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablerow10.AddCell(new PdfPCell(new Phrase("b) Zonas", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablerow10.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablerow10.AddCell(new PdfPCell(new Phrase("c) profusión", textFontSub)) { Border = PdfPCell.NO_BORDER });

            row5celda1.AddElement(tablerow10);

            var tablerow11 = new PdfPTable(6);
            float[] row10Columnas = new float[] { 4f, 30f, 4f, 25f, 4f, 35f };

            tablerow11.SetWidths(row10Columnas);

            tablerow11.WidthPercentage = 100;
            tablerow11.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow11.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });

            var row5celda1int1 = new PdfPCell() { Border = PdfPCell.NO_BORDER, PaddingBottom = 0f };

            var tablerow7int1 = new PdfPTable(2);
            float[] row10Columnas1 = new float[] { 50f, 50f };

            tablerow7int1.SetWidths(row10Columnas1);
            tablerow7int1.WidthPercentage = 100;
            tablerow7int1.AddCell(new PdfPCell(new Phrase("Primaria", textFontSub)) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
            tablerow7int1.AddCell(new PdfPCell(new Phrase("Secundaria", textFontSub)) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });

            row5celda1int1.AddElement(tablerow7int1);

            var tablerow8int1 = new PdfPTable(8);
            float[] row11Columnas1 = new float[] { 4f, 7f, 4f, 7f, 4f, 7f, 4f, 7f };

            tablerow8int1.SetWidths(row11Columnas1);
            tablerow8int1.WidthPercentage = 100;

            PdfPCell _pr0 = new PdfPCell(new Phrase("p", textFont)) { BorderWidthLeft = 1f, BorderWidthTop = 1f, BorderWidthBottom = 0f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 0f };

            tablerow8int1.AddCell(_pr0);

            PdfPCell pr0 = (CellCircle(data["OPACIPRIMARIAC1"].ToString().Equals("p") ? BaseColor.RED : BaseColor.WHITE, " ", textFont));

            pr0.BorderWidthLeft = 0f; pr0.BorderWidthBottom = 0f; pr0.BorderWidthTop = 1f; pr0.BorderWidthRight = 1f; pr0.PaddingRight = 5f; pr0.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int1.AddCell(pr0);

            PdfPCell _pr1 = new PdfPCell(new Phrase("s", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 1f, BorderWidthBottom = 0f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f };

            tablerow8int1.AddCell(_pr1);

            PdfPCell pr1 = CellCircle(data["OPACIPRIMARIAC2"].ToString().Equals("s") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pr1.BorderWidthLeft = 0f; pr1.BorderWidthBottom = 0f; pr1.BorderWidthTop = 1f; pr1.BorderWidthRight = 1f; pr1.PaddingRight = 5f; pr1.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int1.AddCell(pr1);

            PdfPCell _pr2 = new PdfPCell(new Phrase("p", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 1f, BorderWidthBottom = 0f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 0f };

            tablerow8int1.AddCell(_pr2);

            PdfPCell pr2 = CellCircle(data["OPACISECUNDARIAC1"].ToString().Equals("p") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pr2.BorderWidthLeft = 0f; pr2.BorderWidthBottom = 0f; pr2.BorderWidthTop = 1f; pr2.BorderWidthRight = 1f; pr2.PaddingRight = 5f; pr2.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int1.AddCell(pr2);

            PdfPCell _pr3 = new PdfPCell(new Phrase("s", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 1f, BorderWidthBottom = 0f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f };

            tablerow8int1.AddCell(_pr3);

            PdfPCell pr3 = CellCircle(data["OPACISECUNDARIAC2"].ToString().Equals("s") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pr3.BorderWidthLeft = 0f; pr3.BorderWidthBottom = 0f; pr3.BorderWidthTop = 1f; pr3.BorderWidthRight = 1f; pr3.PaddingRight = 5f; pr3.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int1.AddCell(pr3);

            row5celda1int1.AddElement(tablerow8int1);

            //Linea 2
            var tablerow8int2 = new PdfPTable(8);

            tablerow8int2.SetWidths(row11Columnas1);
            tablerow8int2.WidthPercentage = 100;

            PdfPCell _pq0 = new PdfPCell(new Phrase("q", textFont)) { BorderWidthLeft = 1f, BorderWidthTop = 0f, BorderWidthBottom = 0f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 0f };

            tablerow8int2.AddCell(_pq0);

            PdfPCell pq0 = (CellCircle(data["OPACIPRIMARIAC1"].ToString().Equals("q") ? BaseColor.RED : BaseColor.WHITE, " ", textFont));

            pq0.BorderWidthLeft = 0f; pq0.BorderWidthBottom = 0f; pq0.BorderWidthTop = 0f; pq0.BorderWidthRight = 1f; pq0.PaddingRight = 5f; pq0.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int2.AddCell(pq0);

            PdfPCell _pq1 = new PdfPCell(new Phrase("t", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 0f, BorderWidthBottom = 0f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f };

            tablerow8int2.AddCell(_pq1);

            PdfPCell pq1 = CellCircle(data["OPACIPRIMARIAC2"].ToString().Equals("t") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pq1.BorderWidthLeft = 0f; pq1.BorderWidthBottom = 0f; pq1.BorderWidthTop = 0f; pq1.BorderWidthRight = 1f; pq1.PaddingRight = 5f; pq1.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int2.AddCell(pq1);

            PdfPCell _pq2 = new PdfPCell(new Phrase("q", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 0f, BorderWidthBottom = 0f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 0f };

            tablerow8int2.AddCell(_pq2);

            PdfPCell pq2 = CellCircle(data["OPACISECUNDARIAC1"].ToString().Equals("q") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pq2.BorderWidthLeft = 0f; pq2.BorderWidthBottom = 0f; pq2.BorderWidthTop = 0f; pq2.BorderWidthRight = 1f; pq2.PaddingRight = 5f; pq2.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int2.AddCell(pq2);

            PdfPCell _pq3 = new PdfPCell(new Phrase("t", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 0f, BorderWidthBottom = 0f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f };

            tablerow8int2.AddCell(_pq3);

            PdfPCell pq3 = CellCircle(data["OPACISECUNDARIAC2"].ToString().Equals("t") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pq3.BorderWidthLeft = 0f; pq3.BorderWidthBottom = 0f; pq3.BorderWidthTop = 0f; pq3.BorderWidthRight = 1f; pq3.PaddingRight = 5f; pq3.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int2.AddCell(pq3);

            row5celda1int1.AddElement(tablerow8int2);

            //Linea 3
            var tablerow8int3 = new PdfPTable(8);

            tablerow8int3.SetWidths(row11Columnas1);
            tablerow8int3.WidthPercentage = 100;

            PdfPCell _pu0 = new PdfPCell(new Phrase("r", textFont)) { BorderWidthLeft = 1f, BorderWidthTop = 0f, BorderWidthBottom = 1f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f };

            tablerow8int3.AddCell(_pu0);

            PdfPCell pu0 = (CellCircle(data["OPACIPRIMARIAC1"].ToString().Equals("r") ? BaseColor.RED : BaseColor.WHITE, " ", textFont));

            pu0.BorderWidthLeft = 0f; pu0.BorderWidthBottom = 1f; pu0.BorderWidthTop = 0f; pu0.BorderWidthRight = 1f; pu0.PaddingRight = 5f; pu0.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int3.AddCell(pu0);

            PdfPCell _pu1 = new PdfPCell(new Phrase("u", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 0f, BorderWidthBottom = 1f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f };

            tablerow8int3.AddCell(_pu1);

            PdfPCell pu1 = CellCircle(data["OPACIPRIMARIAC2"].ToString().Equals("u") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pu1.BorderWidthLeft = 0f; pu1.BorderWidthBottom = 1f; pu1.BorderWidthTop = 0f; pu1.BorderWidthRight = 1f; pu1.PaddingRight = 5f; pu1.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int3.AddCell(pu1);

            PdfPCell _pu2 = new PdfPCell(new Phrase("r", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 0f, BorderWidthBottom = 1f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f };

            tablerow8int3.AddCell(_pu2);

            PdfPCell pu2 = CellCircle(data["OPACISECUNDARIAC1"].ToString().Equals("r") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pu2.BorderWidthLeft = 0f; pu2.BorderWidthBottom = 1f; pu2.BorderWidthTop = 0f; pu2.BorderWidthRight = 1f; pu2.PaddingRight = 5f; pu2.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int3.AddCell(pu2);

            PdfPCell _pu3 = new PdfPCell(new Phrase("u", textFont)) { BorderWidthLeft = 0f, BorderWidthTop = 0f, BorderWidthBottom = 1f, BorderWidthRight = 0f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f };

            tablerow8int3.AddCell(_pu3);

            PdfPCell pu3 = CellCircle(data["OPACISECUNDARIAC2"].ToString().Equals("u") ? BaseColor.RED : BaseColor.WHITE, " ", textFont);

            pu3.BorderWidthLeft = 0f; pu3.BorderWidthBottom = 1f; pu3.BorderWidthTop = 0f; pu3.BorderWidthRight = 1f; pu3.PaddingRight = 5f; pu3.HorizontalAlignment = Element.ALIGN_LEFT;

            tablerow8int3.AddCell(pu3);

            row5celda1int1.AddElement(tablerow8int3);

            tablerow11.AddCell(row5celda1int1);

            tablerow11.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });
            #endregion Sector 2B Opacidades Pequeñas

            #region Sector 2B Zonas
            var row5celda1int2 = new PdfPCell() { Border = PdfPCell.NO_BORDER };

            var tablerow7int2 = new PdfPTable(2);
            float[] row10Columnas2 = new float[] { 40f, 40f };

            tablerow7int2.SetWidths(row10Columnas2);
            tablerow7int2.WidthPercentage = 100;

            tablerow7int2.AddCell(new PdfPCell(new Phrase("  D", textFontSub)) { BorderWidthLeft = 1f, BorderWidthTop = 1f, BorderWidthRight = 1f, HorizontalAlignment = Element.ALIGN_CENTER });
            tablerow7int2.AddCell(new PdfPCell(new Phrase("  I", textFontSub)) { BorderWidthTop = 1f, BorderWidthRight = 1f, HorizontalAlignment = Element.ALIGN_CENTER });

            row5celda1int2.AddElement(tablerow7int2);

            var tOpazona1 = new PdfPTable(2);
            tOpazona1.SetWidths(row10Columnas2);
            tOpazona1.WidthPercentage = 100;

            PdfPCell pz1;

            if (data["OPACIDADZONAD1"].ToString().Equals("1"))
                pz1 = CellCircle(BaseColor.RED, " ", textFont);
            else
                pz1 = CellCircle(BaseColor.WHITE, " ", textFont);

            pz1.BorderWidthLeft = 1f;
            pz1.BorderWidthBottom = 1f;
            pz1.BorderWidthTop = 0f;
            pz1.BorderWidthRight = 1f;

            tOpazona1.AddCell(pz1);

            PdfPCell pz2;

            if (data["OPACIDADZONAI1"].ToString().Equals("1"))
                pz2 = CellCircle(BaseColor.RED, " ", textFont);
            else
                pz2 = CellCircle(BaseColor.WHITE, " ", textFont);

            pz2.BorderWidthLeft = 0f;
            pz2.BorderWidthBottom = 1f;
            pz2.BorderWidthTop = 0f;
            pz2.BorderWidthRight = 1f;

            tOpazona1.AddCell(pz2);

            row5celda1int2.AddElement(tOpazona1);

            PdfPCell pz3;

            var tOpazona2 = new PdfPTable(2);
            tOpazona2.SetWidths(row10Columnas2);
            tOpazona2.WidthPercentage = 100;

            if (data["OPACIDADZONAD2"].ToString().Equals("1"))
                pz3 = CellCircle(BaseColor.RED, " ", textFont);
            else
                pz3 = CellCircle(BaseColor.WHITE, " ", textFont);

            pz3.BorderWidthLeft = 1f;
            pz3.BorderWidthBottom = 1f;
            pz3.BorderWidthTop = 0f;
            pz3.BorderWidthRight = 1f;

            tOpazona2.AddCell(pz3);

            PdfPCell pz4;

            if (data["OPACIDADZONAI2"].ToString().Equals("1"))
                pz4 = CellCircle(BaseColor.RED, " ", textFont);
            else
                pz4 = CellCircle(BaseColor.WHITE, " ", textFont);

            pz4.BorderWidthLeft = 0f;
            pz4.BorderWidthBottom = 1f;
            pz4.BorderWidthTop = 0f;
            pz4.BorderWidthRight = 1f;

            tOpazona2.AddCell(pz4);

            row5celda1int2.AddElement(tOpazona2);

            var tOpazona3 = new PdfPTable(2);
            tOpazona3.SetWidths(row10Columnas2);
            tOpazona3.WidthPercentage = 100;

            PdfPCell pz5;

            if (data["OPACIDADZONAD3"].ToString().Equals("1"))
                pz5 = CellCircle(BaseColor.RED, " ", textFont);
            else
                pz5 = CellCircle(BaseColor.WHITE, " ", textFont);

            pz5.BorderWidthLeft = 1f;
            pz5.BorderWidthBottom = 1f;
            pz5.BorderWidthTop = 0f;
            pz5.BorderWidthRight = 1f;

            tOpazona3.AddCell(pz5);

            PdfPCell pz6;

            if (data["OPACIDADZONAI3"].ToString().Equals("1"))
                pz6 = CellCircle(BaseColor.RED, " ", textFont);
            else
                pz6 = CellCircle(BaseColor.WHITE, " ", textFont);

            pz6.BorderWidthLeft = 0f;
            pz6.BorderWidthBottom = 1f;
            pz6.BorderWidthTop = 0f;
            pz6.BorderWidthRight = 1f;

            tOpazona3.AddCell(pz6);

            row5celda1int2.AddElement(tOpazona3);

            tablerow11.AddCell(row5celda1int2);
            #endregion Sector 2B Zonas

            #region Secot 2B Profusion
            tablerow11.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });

            var row5celda1int3 = new PdfPCell() { Border = PdfPCell.NO_BORDER };

            #region linea 1
            var tablerow7int3 = new PdfPTable(4);
            tablerow7int3.WidthPercentage = 100;

            float[] row10Columnas3 = new float[] { 32f, 30f, 30f, 8f };

            tablerow7int3.SetWidths(row10Columnas3);

            PdfPCell _l1c1 = CellCircle(BaseColor.LIGHT_GRAY, " 0/-  ", textFont);

            _l1c1.BorderWidthLeft = _l1c1.BorderWidthTop = 1f; _l1c1.BorderWidthBottom = _l1c1.BorderWidthRight = 0f;

            tablerow7int3.AddCell(_l1c1);

            PdfPCell _l1c2 = CellCircle(data["OPACPROFUSION"].ToString().Equals("0/0") ? BaseColor.RED : BaseColor.WHITE, "0/0 ", textFont);

            _l1c2.BorderWidthLeft = 0f; _l1c2.BorderWidthTop = 1f; _l1c2.BorderWidthBottom = _l1c2.BorderWidthRight = 0f;

            tablerow7int3.AddCell(_l1c2);

            PdfPCell _l1c3 = CellCircle(data["OPACPROFUSION"].ToString().Equals("0/1") ? BaseColor.RED : BaseColor.WHITE, "0/1 ", textFont);

            _l1c3.BorderWidthLeft = 0f; _l1c3.BorderWidthTop = 1f; _l1c3.BorderWidthBottom = _l1c3.BorderWidthRight = 0f;

            tablerow7int3.AddCell(_l1c3);

            PdfPCell _l1c4 = new PdfPCell(new Phrase(" ", textFontSub));

            _l1c4.BorderWidthLeft = 1f; _l1c4.BorderWidthTop = 0f; _l1c4.BorderWidthBottom = 0f; _l1c4.BorderWidthRight = 0f;

            tablerow7int3.AddCell(_l1c4);

            tablerow7int3.HorizontalAlignment = Element.ALIGN_CENTER;

            row5celda1int3.AddElement(tablerow7int3);
            #endregion linea 1

            #region Linea 2
            var tablerow9int1 = new PdfPTable(4);
            tablerow9int1.WidthPercentage = 100;

            float[] row11Columnas7 = new float[] { 32f, 30f, 30f, 8f };

            tablerow9int1.SetWidths(row11Columnas7);

            PdfPCell _l2c1 = CellCircle(data["OPACPROFUSION"].ToString().Equals("1/0") ? BaseColor.RED : BaseColor.WHITE, " 1/0  ", textFont);

            _l2c1.BorderWidthLeft = 1f; _l2c1.BorderWidthTop = 0f; _l2c1.BorderWidthBottom = _l2c1.BorderWidthRight = 0f;

            tablerow9int1.AddCell(_l2c1);

            PdfPCell _l2c2 = CellCircle(data["OPACPROFUSION"].ToString().Equals("1/1") ? BaseColor.RED : BaseColor.WHITE, "1/1 ", textFont);

            _l2c2.BorderWidthLeft = 0f; _l2c2.BorderWidthTop = 0f; _l2c2.BorderWidthBottom = _l2c2.BorderWidthRight = 0f;

            tablerow9int1.AddCell(_l2c2);

            PdfPCell _l2c3 = CellCircle(data["OPACPROFUSION"].ToString().Equals("1/2") ? BaseColor.RED : BaseColor.WHITE, "1/2 ", textFont);

            _l2c3.BorderWidthLeft = 0f; _l2c3.BorderWidthTop = 0f; _l2c3.BorderWidthBottom = _l2c3.BorderWidthRight = 0f;

            tablerow9int1.AddCell(_l2c3);

            PdfPCell _l2c4 = new PdfPCell(new Phrase(" ", textFontSub));

            _l2c4.BorderWidthLeft = 1f; _l2c4.BorderWidthTop = 0f; _l2c4.BorderWidthBottom = 0f; _l2c4.BorderWidthRight = 0f;

            tablerow9int1.AddCell(_l2c4);

            tablerow9int1.HorizontalAlignment = Element.ALIGN_CENTER;

            row5celda1int3.AddElement(tablerow9int1);
            #endregion Linea 2

            #region Linea 3
            var tablerow9int2 = new PdfPTable(4);
            tablerow9int2.WidthPercentage = 100;

            float[] row11Columnas8 = new float[] { 32f, 30f, 30f, 8f };

            tablerow9int2.SetWidths(row11Columnas8);

            PdfPCell _l3c1 = CellCircle(data["OPACPROFUSION"].ToString().Equals("2/1") ? BaseColor.RED : BaseColor.WHITE, " 2/1  ", textFont);

            _l3c1.BorderWidthLeft = 1f; _l3c1.BorderWidthTop = 0f; _l3c1.BorderWidthBottom = _l3c1.BorderWidthRight = 0f;

            tablerow9int2.AddCell(_l3c1);

            PdfPCell _l3c2 = CellCircle(data["OPACPROFUSION"].ToString().Equals("2/2") ? BaseColor.RED : BaseColor.WHITE, "2/2 ", textFont);

            _l3c2.BorderWidthLeft = 0f; _l3c2.BorderWidthTop = 0f; _l3c2.BorderWidthBottom = _l3c2.BorderWidthRight = 0f;

            tablerow9int2.AddCell(_l3c2);

            PdfPCell _l3c3 = CellCircle(data["OPACPROFUSION"].ToString().Equals("2/3") ? BaseColor.RED : BaseColor.WHITE, "2/3 ", textFont);

            _l3c3.BorderWidthLeft = 0f; _l3c3.BorderWidthTop = 0f; _l3c3.BorderWidthBottom = _l3c3.BorderWidthRight = 0f;

            tablerow9int2.AddCell(_l3c3);

            PdfPCell _l3c4 = new PdfPCell(new Phrase(" ", textFontSub));

            _l3c4.BorderWidthLeft = 1f; _l3c4.BorderWidthTop = 0f; _l3c4.BorderWidthBottom = 0f; _l3c4.BorderWidthRight = 0f;

            tablerow9int2.AddCell(_l3c4);

            tablerow9int2.HorizontalAlignment = Element.ALIGN_CENTER;

            row5celda1int3.AddElement(tablerow9int2);
            #endregion Linea 3

            #region Linea 4
            var tablerow9int3 = new PdfPTable(4);

            tablerow9int3.WidthPercentage = 100;

            float[] row11Columnas9 = new float[] { 32f, 30f, 30f, 8f };

            tablerow9int3.SetWidths(row11Columnas9);

            PdfPCell _l4c1 = CellCircle(data["OPACPROFUSION"].ToString().Equals("3/2") ? BaseColor.RED : BaseColor.WHITE, " 3/2  ", textFont);

            _l4c1.BorderWidthLeft = 1f; _l4c1.BorderWidthTop = 0f; _l4c1.BorderWidthBottom = 1f; _l4c1.BorderWidthRight = 0f;

            tablerow9int3.AddCell(_l4c1);

            PdfPCell _l4c2 = CellCircle(data["OPACPROFUSION"].ToString().Equals("3/3") ? BaseColor.RED : BaseColor.WHITE, "3/3 ", textFont);

            _l4c2.BorderWidthLeft = 0f; _l4c2.BorderWidthTop = 0f; _l4c2.BorderWidthBottom = 1f; _l4c2.BorderWidthRight = 0f;

            tablerow9int3.AddCell(_l4c2);

            PdfPCell _l4c3 = CellCircle(BaseColor.LIGHT_GRAY, "3/+ ", textFont);

            _l4c3.BorderWidthLeft = _l4c3.BorderWidthTop = _l4c3.BorderWidthRight = 0f; _l4c3.BorderWidthBottom = 1f;

            tablerow9int3.AddCell(_l4c3);

            PdfPCell _l4c4 = new PdfPCell(new Phrase(" ", textFontSub));

            _l4c4.BorderWidthLeft = 1f; _l4c4.BorderWidthTop = 0f; _l4c4.BorderWidthBottom = 0f; _l4c4.BorderWidthRight = 0f;

            tablerow9int3.AddCell(_l4c4);

            tablerow9int3.HorizontalAlignment = Element.ALIGN_CENTER;

            row5celda1int3.AddElement(tablerow9int3);
            #endregion Linea 4

            tablerow11.AddCell(row5celda1int3);
            #endregion Secot 2B Profusion

            #region Sector 2C 
            tablerow11.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });

            row5celda1.AddElement(tablerow11);

            table6.AddCell(row5celda1);

            var row5celda2 = new PdfPCell() { PaddingBottom = 5f };
            var tablerow7 = new PdfPTable(2);

            float[] row2Columnas2Se = new float[] { 13f, 85f };

            tablerow7.SetWidths(row2Columnas2Se);

            tablerow7.WidthPercentage = 100;
            tablerow7.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow7.AddCell(new PdfPCell(new Phrase("2C", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tablerow7.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            row5celda2.AddElement(tablerow7);

            var tablerow9 = new PdfPTable(2);
            float[] row8Columnas = new float[] { 8f, 85f };

            tablerow9.SetWidths(row8Columnas);

            tablerow9.WidthPercentage = 100;
            tablerow9.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablerow9.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });
            tablerow9.AddCell(new PdfPCell(new Phrase("Opacidades Grandes:", textFont)) { Border = PdfPCell.NO_BORDER });

            row5celda2.AddElement(tablerow9);

            var table10row = new PdfPTable(1);
            float[] row10Columnas2C = new float[] { 100f };

            table10row.SetWidths(row10Columnas2C);

            table10row.WidthPercentage = 100;
            table10row.DefaultCell.Border = PdfPCell.NO_BORDER;
            table10row.AddCell(new PdfPCell(new Phrase(" ", textFont)) { Border = PdfPCell.NO_BORDER });

            row5celda2.AddElement(table10row);

            var table11row = new PdfPTable(6);
            float[] row1Columnas2C = new float[] { 8f, 21f, 21f, 21f, 21f, 8f };

            table11row.SetWidths(row1Columnas2C);

            table11row.WidthPercentage = 100;
            table11row.DefaultCell.Border = PdfPCell.NO_BORDER;
            table11row.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            PdfPCell og1;

            if (data["OPACIDAGRANDE"].ToString().Equals("O"))
                og1 = CellCircle(BaseColor.RED, " O ", textFont, 5f);
            else
                og1 = CellCircle(BaseColor.WHITE, " O ", textFont, 5f);

            og1.BorderWidthLeft = 1f;
            og1.BorderWidthTop = 1f;
            og1.BorderWidthBottom = 1f;
            og1.BorderWidthRight = 0f;
            og1.VerticalAlignment = Element.ALIGN_MIDDLE;

            table11row.AddCell(og1);

            PdfPCell og2;

            if (data["OPACIDAGRANDE"].ToString().Equals("A"))
                og2 = CellCircle(BaseColor.RED, " A ", textFont, 5f);
            else
                og2 = CellCircle(BaseColor.WHITE, " A ", textFont, 5f);

            og2.BorderWidthLeft = 0f;
            og2.BorderWidthTop = 1f;
            og2.BorderWidthBottom = 1f;
            og2.BorderWidthRight = 0f;
            og2.VerticalAlignment = Element.ALIGN_MIDDLE;

            table11row.AddCell(og2);

            PdfPCell og3;

            if (data["OPACIDAGRANDE"].ToString().Equals("C"))
                og3 = CellCircle(BaseColor.RED, " C ", textFont, 5f);
            else
                og3 = CellCircle(BaseColor.WHITE, " C ", textFont, 5f);

            og3.BorderWidthLeft = 0f;
            og3.BorderWidthTop = 1f;
            og3.BorderWidthBottom = 1f;
            og3.BorderWidthRight = 0f;
            og3.VerticalAlignment = Element.ALIGN_MIDDLE;

            table11row.AddCell(og3);

            PdfPCell og4;

            if (data["OPACIDAGRANDE"].ToString().Equals("B"))
                og4 = CellCircle(BaseColor.RED, " B ", textFont, 5f);
            else
                og4 = CellCircle(BaseColor.WHITE, " B ", textFont, 5f);

            og4.BorderWidthLeft = 0f;
            og4.BorderWidthTop = 1f;
            og4.BorderWidthBottom = 1f;
            og4.BorderWidthRight = 1f;
            og4.VerticalAlignment = Element.ALIGN_MIDDLE;

            table11row.AddCell(og4);

            table11row.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            row5celda2.AddElement(table11row);

            table6.AddCell(row5celda2);
            #endregion Sector 2C 

            doc.Add(table6);


            PdfPTable tableSe3 = new PdfPTable(1);
            tableSe3.WidthPercentage = 100;

            float[] rowSe3 = new float[] { 100f };

            tableSe3.SetWidths(rowSe3);

            var rowSe3celda1 = new PdfPCell() { PaddingBottom = 5f };

            #region Sector 3A
            var tableSe3A = new PdfPTable(3);
            float[] rowSe3Columnas = new float[] { 3f, 77f, 20f };

            tableSe3A.SetWidths(rowSe3Columnas);

            tableSe3A.WidthPercentage = 100;
            tableSe3A.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe3A.AddCell(new PdfPCell(new Phrase("3A", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tableSe3A.AddCell(new PdfPCell(new Phrase("ALGUNA ANORMALIDAD PLEURAL CONSISTENTE CON NEUMOCONIOSIS:", textFont)) { Border = PdfPCell.NO_BORDER });
            tableSe3A.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe3celda1.AddElement(tableSe3A);

            var tableSe3AOp = new PdfPTable(6);
            float[] rowSe3ColumnasA = new float[] { 10f, 5f, 30f, 3f, 5f, 46 };

            tableSe3AOp.SetWidths(rowSe3ColumnasA);
            tableSe3AOp.WidthPercentage = 100;
            tableSe3AOp.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe3AOp.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER, PaddingTop = 3f, PaddingBottom = 5f });

            if (data["ANORMALPLEURAL"].ToString().Equals("SI"))
                tableSe3AOp.AddCell(CellCircle(BaseColor.RED, " ", textFont));
            else
                tableSe3AOp.AddCell(CellCircle(BaseColor.WHITE, " ", textFont));

            tableSe3AOp.AddCell(new PdfPCell(new Phrase(" Si (completar 3B, 3C y 3C) ", textFont)) { Border = PdfPCell.NO_BORDER, PaddingTop = 3f, PaddingBottom = 5f });
            tableSe3AOp.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER, PaddingTop = 3f, PaddingBottom = 5f });

            if (data["ANORMALPLEURAL"].ToString().Equals("NO"))
                tableSe3AOp.AddCell(CellCircle(BaseColor.RED, " ", textFont));
            else
                tableSe3AOp.AddCell(CellCircle(BaseColor.WHITE, " ", textFont));

            tableSe3AOp.AddCell(new PdfPCell(new Phrase(" NO (pasar por sección 4) ", textFont)) { Border = PdfPCell.NO_BORDER, PaddingTop = 3f, PaddingBottom = 5f });

            rowSe3celda1.AddElement(tableSe3AOp);

            tableSe3.AddCell(rowSe3celda1);

            doc.Add(tableSe3);
            #endregion Sector 3A

            #region Titulo 3B
            PdfPTable tableSe3B = new PdfPTable(1);
            tableSe3B.WidthPercentage = 100;

            float[] rowColumnas3B = new float[] { 100f };

            tableSe3B.SetWidths(rowColumnas3B);

            var rowSe3Bcelda1 = new PdfPCell() { PaddingBottom = 5f };

            var tableSe3B1 = new PdfPTable(2);
            float[] rowColumnasSe3B = new float[] { 3f, 96f };

            tableSe3B1.SetWidths(rowColumnasSe3B);

            tableSe3B1.WidthPercentage = 100;
            tableSe3B1.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe3B1.AddCell(new PdfPCell(new Phrase("3B", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tableSe3B1.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe3Bcelda1.AddElement(tableSe3B1);
            #endregion Titulo 3B

            #region Seccion 3B placas Pleurales
            var tablesE3B2 = new PdfPTable(6);
            float[] rowColumnasSE3B = new float[] { 3f, 20f, 4f, 6f, 8f, 59f };

            tablesE3B2.SetWidths(rowColumnasSE3B);

            tablesE3B2.WidthPercentage = 100;
            tablesE3B2.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablesE3B2.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });
            tablesE3B2.AddCell(new PdfPCell(new Phrase("Placas Pleurales: ", textFont)) { Border = PdfPCell.NO_BORDER });
            tablesE3B2.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            if (data["PLACAPLEURAL"].ToString().Equals("SI"))
                tablesE3B2.AddCell(CellCircle(BaseColor.RED, "SI", textFont));
            else
                tablesE3B2.AddCell(CellCircle(BaseColor.WHITE, "SI", textFont));

            if (data["PLACAPLEURAL"].ToString().Equals("NO"))
                tablesE3B2.AddCell(CellCircle(BaseColor.RED, "NO ", textFont, 4f));
            else
                tablesE3B2.AddCell(CellCircle(BaseColor.WHITE, "NO ", textFont, 4f));

            tablesE3B2.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe3Bcelda1.AddElement(tablesE3B2);
            #endregion Seccion 3B placas Pleurales

            #region titulos PP
            var tablesE3B3 = new PdfPTable(7);
            float[] rowColumnasSE3B1 = new float[] { 11f, 19f, 18f, 2f, 25f, 1f, 23f };

            tablesE3B3.SetWidths(rowColumnasSE3B1);

            tablesE3B3.WidthPercentage = 100;
            tablesE3B3.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablesE3B3.AddCell(new PdfPCell(new Phrase(" ", textFont)) { Border = PdfPCell.NO_BORDER });
            tablesE3B3.AddCell(new PdfPCell(new Phrase("\n  SITIO", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablesE3B3.AddCell(new PdfPCell(new Phrase("\n CALSIFICACIÓN", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablesE3B3.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });
            tablesE3B3.AddCell(new PdfPCell(new Phrase(" EXTENSIÓN: PARED \n (Combinado de perfil y frente)", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablesE3B3.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });
            tablesE3B3.AddCell(new PdfPCell(new Phrase("  ANCHO (OPCIONAL) \n  (Solo en perfil, 3m grosor mÍnimo)", textFontSub)) { Border = PdfPCell.NO_BORDER });

            rowSe3Bcelda1.AddElement(tablesE3B3);

            var tablesE3B4 = new PdfPTable(7);
            float[] rowColumnasSE3B2 = new float[] { 10f, 19f, 18f, 1f, 27f, 1f, 24f };

            tablesE3B4.SetWidths(rowColumnasSE3B2);

            tablesE3B4.WidthPercentage = 100;
            tablesE3B4.DefaultCell.Border = PdfPCell.NO_BORDER;

            var cellSe3B2 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };
            cellSe3B2.AddElement(CellData(new PdfPTable(1), new string[] { "Perfil" }, true));
            cellSe3B2.AddElement(CellData(new PdfPTable(1), new string[] { "Frente" }, true));
            cellSe3B2.AddElement(CellData(new PdfPTable(1), new string[] { "Diagrama" }, true));
            cellSe3B2.AddElement(CellData(new PdfPTable(1), new string[] { "Otro" }, true));

            tablesE3B4.AddCell(cellSe3B2);
            #endregion titulos PP

            #region Sitio PP
            var cellSe3B3 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };

            var array1 = new string[] { "PP_SITIOPERFIL", "PP_SITIOFRENTE", "PP_SITIODIAGRAMA", "PP_SITIOOTRO" };

            for (int i = 0; i < 4; i++)
            {
                var s_pp = new PdfPTable(3) { WidthPercentage = 100 };

                PdfPCell c_op1;

                if (data[array1[i]].Equals("O"))
                    c_op1 = CellCircle(BaseColor.RED, "O ", textFont);
                else
                    c_op1 = CellCircle(BaseColor.WHITE, "O ", textFont);

                c_op1.BorderWidthTop = 1f;
                c_op1.BorderWidthLeft = 1f;
                c_op1.BorderWidthBottom = i.Equals(3) ? 1f : 0f;
                c_op1.BorderWidthRight = 0;

                s_pp.AddCell(c_op1);

                PdfPCell c_op2;

                if (data[array1[i]].Equals("D"))
                    c_op2 = CellCircle(BaseColor.RED, "D", textFont);
                else
                    c_op2 = CellCircle(BaseColor.WHITE, "D", textFont);

                c_op2.BorderWidthTop = 1f;
                c_op2.BorderWidthLeft = 0f;
                c_op2.BorderWidthBottom = i.Equals(3) ? 1f : 0f;
                c_op2.BorderWidthRight = 0;

                s_pp.AddCell(c_op2);

                PdfPCell c_op3;

                if (data[array1[i]].Equals("I"))
                    c_op3 = CellCircle(BaseColor.RED, "I", textFont);
                else
                    c_op3 = CellCircle(BaseColor.WHITE, "I", textFont);

                c_op3.BorderWidthTop = 1f;
                c_op3.BorderWidthLeft = 0f;
                c_op3.BorderWidthBottom = i.Equals(3) ? 1f : 0f;
                c_op3.BorderWidthRight = 1;

                s_pp.AddCell(c_op3);

                cellSe3B3.AddElement(s_pp);
            }

            tablesE3B4.AddCell(cellSe3B3);
            #endregion Perfil PP Sitio

            #region Calsificacion PP
            var cellSe3B4 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };

            var array2 = new string[] { "PP_CALSIFICACIONPERFIL", "PP_CALSIFICACIONFRENTE", "PP_CALSIFICACIONDIAGRAMA", "PP_CALSIFICACIONOTRO" };

            for (int i = 0; i < 4; i++)
            {
                var c_pp = new PdfPTable(3) { WidthPercentage = 100 };

                PdfPCell c_op1;

                if (data[array2[i]].Equals("O"))
                    c_op1 = CellCircle(BaseColor.RED, "O ", textFont);
                else
                    c_op1 = CellCircle(BaseColor.WHITE, "O ", textFont);

                c_op1.BorderWidthTop = 1f;
                c_op1.BorderWidthLeft = 1f;
                c_op1.BorderWidthBottom = i.Equals(3) ? 1f : 0f;
                c_op1.BorderWidthRight = 0;

                c_pp.AddCell(c_op1);

                PdfPCell c_op2;

                if (data[array2[i]].Equals("D"))
                    c_op2 = CellCircle(BaseColor.RED, "D", textFont);
                else
                    c_op2 = CellCircle(BaseColor.WHITE, "D", textFont);

                c_op2.BorderWidthTop = 1f;
                c_op2.BorderWidthLeft = 0f;
                c_op2.BorderWidthBottom = i.Equals(3) ? 1f : 0f;
                c_op2.BorderWidthRight = 0;

                c_pp.AddCell(c_op2);

                PdfPCell c_op3;

                if (data[array2[i]].Equals("I"))
                    c_op3 = CellCircle(BaseColor.RED, "I", textFont);
                else
                    c_op3 = CellCircle(BaseColor.WHITE, "I", textFont);

                c_op3.BorderWidthTop = 1f;
                c_op3.BorderWidthLeft = 0f;
                c_op3.BorderWidthBottom = i.Equals(3) ? 1f : 0f;
                c_op3.BorderWidthRight = 1;

                c_pp.AddCell(c_op3);

                cellSe3B4.AddElement(c_pp);
            }

            tablesE3B4.AddCell(cellSe3B4);

            tablesE3B4.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });
            #endregion Calsificacion PP

            #region Extension PP
            var cellSe3B5 = new PdfPCell() { Border = PdfPCell.NO_BORDER };
            var array3 = new string[] { "PP_EXTENSIONPAREDPERFILOP", "PP_EXTENSIONPAREDFRENTEOP" };
            var array4 = new string[] { "PP_EXTENSIONPAREDPERFILSE", "PP_EXTENSIONPAREDFRENTESE" };

            for (int i = 0; i < 2; i++)
            {
                var c_ex = new PdfPTable(4);

                if (data[array3[i]].Equals("O") || data[array3[i]].Equals("I"))
                {
                    PdfPCell ppe = CellCircle(BaseColor.RED, data[array3[i]].Equals("O") ? "O" : " I", textFont);

                    ppe.BorderWidthTop = 1f;
                    ppe.BorderWidthLeft = 1f;
                    ppe.BorderWidthBottom = i.Equals(1) ? 1f : 0f;
                    ppe.BorderWidthRight = 1f;

                    c_ex.AddCell(ppe);

                    PdfPCell ppe1;

                    if (data[array4[i]].Equals("1"))
                        ppe1 = CellCircle(BaseColor.RED, "1", textFont);
                    else
                        ppe1 = CellCircle(BaseColor.WHITE, "1", textFont);

                    ppe1.BorderWidthTop = 1f;
                    ppe1.BorderWidthLeft = 0f;
                    ppe1.BorderWidthBottom = i.Equals(1) ? 1f : 0f;
                    ppe1.BorderWidthRight = 0f;

                    c_ex.AddCell(ppe1);

                    PdfPCell ppe2;

                    if (data[array4[i]].Equals("2"))
                        ppe2 = CellCircle(BaseColor.RED, "2", textFont);
                    else
                        ppe2 = CellCircle(BaseColor.WHITE, "2", textFont);

                    ppe2.BorderWidthTop = 1f;
                    ppe2.BorderWidthLeft = 0f;
                    ppe2.BorderWidthBottom = i.Equals(1) ? 1f : 0f;
                    ppe2.BorderWidthRight = 0f;

                    c_ex.AddCell(ppe2);

                    PdfPCell ppe3;

                    if (data[array4[i]].Equals("3"))
                        ppe3 = CellCircle(BaseColor.RED, "3", textFont);
                    else
                        ppe3 = CellCircle(BaseColor.WHITE, "3", textFont);

                    ppe3.BorderWidthTop = 1f;
                    ppe3.BorderWidthLeft = 0f;
                    ppe3.BorderWidthBottom = i.Equals(1) ? 1f : 0f;
                    ppe3.BorderWidthRight = 1f;

                    c_ex.AddCell(ppe3);

                }
                else if (data[array3[i]].Equals("D"))
                {
                    PdfPCell ppe = CellCircle(BaseColor.RED, "D", textFont);

                    ppe.BorderWidthTop = 1f;
                    ppe.BorderWidthLeft = 1f;
                    ppe.BorderWidthBottom = i.Equals(0) ? 0f : 1f;
                    ppe.BorderWidthRight = 1f;

                    c_ex.AddCell(ppe);

                    PdfPCell ppe1;

                    if (data[array4[i]].Equals("1"))
                        ppe1 = CellCircle(BaseColor.RED, "1", textFont);
                    else
                        ppe1 = CellCircle(BaseColor.WHITE, "1", textFont);

                    ppe1.BorderWidthTop = 1f;
                    ppe1.BorderWidthLeft = 0f;
                    ppe1.BorderWidthBottom = i.Equals(0) ? 0f : 1f;
                    ppe1.BorderWidthRight = 0f;

                    c_ex.AddCell(ppe1);

                    PdfPCell ppe2;

                    if (data[array4[i]].Equals("2"))
                        ppe2 = CellCircle(BaseColor.RED, "2", textFont);
                    else
                        ppe2 = CellCircle(BaseColor.WHITE, "2", textFont);

                    ppe2.BorderWidthTop = 1f;
                    ppe2.BorderWidthLeft = 0f;
                    ppe2.BorderWidthBottom = i.Equals(0) ? 0f : 1f;
                    ppe2.BorderWidthRight = 0f;

                    c_ex.AddCell(ppe2);

                    PdfPCell ppe3;

                    if (data[array4[i]].Equals("3"))
                        ppe3 = CellCircle(BaseColor.RED, "3", textFont);
                    else
                        ppe3 = CellCircle(BaseColor.WHITE, "3", textFont);

                    ppe3.BorderWidthTop = 1f;
                    ppe3.BorderWidthLeft = 0f;
                    ppe3.BorderWidthBottom = i.Equals(0) ? 0f : 1f;
                    ppe3.BorderWidthRight = 1f;

                    c_ex.AddCell(ppe3);
                }
                else
                {
                    if (array3[i].Equals("PP_EXTENSIONPAREDPERFILOP"))
                    {
                        PdfPCell ppe = CellCircle(BaseColor.WHITE, " ", textFont);

                        ppe.BorderWidthTop = 1f;
                        ppe.BorderWidthLeft = 1f;
                        ppe.BorderWidthBottom = 0f;
                        ppe.BorderWidthRight = 1f;

                        c_ex.AddCell(ppe);

                        PdfPCell ppe1 = CellCircle(BaseColor.WHITE, "1", textFont);

                        ppe1.BorderWidthTop = 1f;
                        ppe1.BorderWidthLeft = 0f;
                        ppe1.BorderWidthBottom = 0f;
                        ppe1.BorderWidthRight = 0f;

                        c_ex.AddCell(ppe1);

                        PdfPCell ppe2 = CellCircle(BaseColor.WHITE, "2", textFont);

                        ppe2.BorderWidthTop = 1f;
                        ppe2.BorderWidthLeft = 0f;
                        ppe2.BorderWidthBottom = 0f;
                        ppe2.BorderWidthRight = 0f;

                        c_ex.AddCell(ppe2);

                        PdfPCell ppe3 = CellCircle(BaseColor.WHITE, "3", textFont);

                        ppe3.BorderWidthTop = 1f;
                        ppe3.BorderWidthLeft = 0f;
                        ppe3.BorderWidthBottom = 0f;
                        ppe3.BorderWidthRight = 1f;

                        c_ex.AddCell(ppe3);
                    }
                    else
                    {
                        PdfPCell ppe = CellCircle(BaseColor.WHITE, " ", textFont);

                        ppe.BorderWidthTop = 1f;
                        ppe.BorderWidthLeft = 1f;
                        ppe.BorderWidthBottom = 1f;
                        ppe.BorderWidthRight = 1f;

                        c_ex.AddCell(ppe);

                        PdfPCell ppe1 = CellCircle(BaseColor.WHITE, "1", textFont);

                        ppe1.BorderWidthTop = 1f;
                        ppe1.BorderWidthLeft = 0f;
                        ppe1.BorderWidthBottom = 1f;
                        ppe1.BorderWidthRight = 0f;

                        c_ex.AddCell(ppe1);

                        PdfPCell ppe2 = CellCircle(BaseColor.WHITE, "2", textFont);

                        ppe2.BorderWidthTop = 1f;
                        ppe2.BorderWidthLeft = 0f;
                        ppe2.BorderWidthBottom = 1f;
                        ppe2.BorderWidthRight = 0f;

                        c_ex.AddCell(ppe2);

                        PdfPCell ppe3 = CellCircle(BaseColor.WHITE, "3", textFont);

                        ppe3.BorderWidthTop = 1f;
                        ppe3.BorderWidthLeft = 0f;
                        ppe3.BorderWidthBottom = 1f;
                        ppe3.BorderWidthRight = 1f;

                        c_ex.AddCell(ppe3);
                    }
                }

                cellSe3B5.AddElement(c_ex);
            }

            cellSe3B5.AddElement(CellData(new PdfPTable(1), new string[] { "Para 1/4 de la pared lateral = 1" }, true));
            cellSe3B5.AddElement(CellData(new PdfPTable(1), new string[] { "1/4 a 1/2 de pared lateral = 2" }, true));
            cellSe3B5.AddElement(CellData(new PdfPTable(1), new string[] { "> a 1/2 de pared lateral = 3" }, true));
            tablesE3B4.AddCell(cellSe3B5);

            tablesE3B4.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });
            #endregion Extension PP

            #region Ancho PP
            var cellSe3B6 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };
            var array5 = new string[] { "PP_ANCHODERECHAOP", "PP_ANCHOIZQUIERDAOP" };
            var array6 = new string[] { "PP_ANCHODERECHASE", "PP_ANCHOIZQUIERDASE" };

            for (int i = 0; i < 2; i++)
            {
                var c_an = new PdfPTable(4);

                if (data[array5[i]].Equals("D"))
                {
                    PdfPCell pan = CellCircle(BaseColor.RED, "D", textFont, 4f);

                    pan.BorderWidthTop = 1f;
                    pan.BorderWidthLeft = 1f;
                    pan.BorderWidthBottom = 0f;
                    pan.BorderWidthRight = 1f;

                    c_an.AddCell(pan);

                    PdfPCell pan1;

                    if (data[array6[i]].Equals("a"))
                        pan1 = CellCircle(BaseColor.RED, "a", textFont);
                    else
                        pan1 = CellCircle(BaseColor.WHITE, "a", textFont);

                    pan1.BorderWidthTop = 1f;
                    pan1.BorderWidthLeft = 0f;
                    pan1.BorderWidthBottom = 0f;
                    pan1.BorderWidthRight = 0f;

                    c_an.AddCell(pan1);

                    PdfPCell pan2;

                    if (data[array6[i]].Equals("b"))
                        pan2 = CellCircle(BaseColor.RED, "b", textFont);
                    else
                        pan2 = CellCircle(BaseColor.WHITE, "b", textFont);

                    pan2.BorderWidthTop = 1f;
                    pan2.BorderWidthLeft = 0f;
                    pan2.BorderWidthBottom = 0f;
                    pan2.BorderWidthRight = 0f;

                    c_an.AddCell(pan2);

                    PdfPCell pan3;

                    if (data[array6[i]].Equals("c"))
                        pan3 = CellCircle(BaseColor.RED, "c", textFont);
                    else
                        pan3 = CellCircle(BaseColor.WHITE, "c", textFont);

                    pan3.BorderWidthTop = 1f;
                    pan3.BorderWidthLeft = 0f;
                    pan3.BorderWidthBottom = 0f;
                    pan3.BorderWidthRight = 1f;

                    c_an.AddCell(pan3);
                }
                else if (data[array5[i]].Equals("I"))
                {
                    PdfPCell pan = CellCircle(BaseColor.RED, " I", textFont, 4f);

                    pan.BorderWidthTop = 1f;
                    pan.BorderWidthLeft = 1f;
                    pan.BorderWidthBottom = 1f;
                    pan.BorderWidthRight = 1f;

                    c_an.AddCell(pan);

                    PdfPCell pan1;

                    if (data[array6[i]].Equals("a"))
                        pan1 = CellCircle(BaseColor.RED, "a", textFont);
                    else
                        pan1 = CellCircle(BaseColor.WHITE, "a", textFont);

                    pan1.BorderWidthTop = 1f;
                    pan1.BorderWidthLeft = 0f;
                    pan1.BorderWidthBottom = 1f;
                    pan1.BorderWidthRight = 0f;

                    c_an.AddCell(pan1);

                    PdfPCell pan2;

                    if (data[array6[i]].Equals("b"))
                        pan2 = CellCircle(BaseColor.RED, "b", textFont);
                    else
                        pan2 = CellCircle(BaseColor.WHITE, "b", textFont);

                    pan2.BorderWidthTop = 1f;
                    pan2.BorderWidthLeft = 0f;
                    pan2.BorderWidthBottom = 1f;
                    pan2.BorderWidthRight = 0f;

                    c_an.AddCell(pan2);

                    PdfPCell pan3;

                    if (data[array6[i]].Equals("c"))
                        pan3 = CellCircle(BaseColor.RED, "c", textFont);
                    else
                        pan3 = CellCircle(BaseColor.WHITE, "c", textFont);

                    pan3.BorderWidthTop = 1f;
                    pan3.BorderWidthLeft = 0f;
                    pan3.BorderWidthBottom = 1f;
                    pan3.BorderWidthRight = 1f;

                    c_an.AddCell(pan3);
                }
                else
                {
                    if (array5[i].Equals("PP_ANCHODERECHAOP"))
                    {
                        PdfPCell pan = CellCircle(BaseColor.WHITE, "D", textFont);

                        pan.BorderWidthTop = 1f;
                        pan.BorderWidthLeft = 1f;
                        pan.BorderWidthBottom = 0f;
                        pan.BorderWidthRight = 1f;

                        c_an.AddCell(pan);

                        PdfPCell pan1 = CellCircle(BaseColor.WHITE, "a", textFont);

                        pan1.BorderWidthTop = 1f;
                        pan1.BorderWidthLeft = 0f;
                        pan1.BorderWidthBottom = 0f;
                        pan1.BorderWidthRight = 0f;

                        c_an.AddCell(pan1);

                        PdfPCell pan2 = CellCircle(BaseColor.WHITE, "b", textFont);

                        pan2.BorderWidthTop = 1f;
                        pan2.BorderWidthLeft = 0f;
                        pan2.BorderWidthBottom = 0f;
                        pan2.BorderWidthRight = 0f;

                        c_an.AddCell(pan2);

                        PdfPCell pan3 = CellCircle(BaseColor.WHITE, "c", textFont);

                        pan3.BorderWidthTop = 1f;
                        pan3.BorderWidthLeft = 0f;
                        pan3.BorderWidthBottom = 0f;
                        pan3.BorderWidthRight = 1f;

                        c_an.AddCell(pan3);
                    }
                    else
                    {
                        PdfPCell pan = CellCircle(BaseColor.WHITE, " I", textFont);

                        pan.BorderWidthTop = 1f;
                        pan.BorderWidthLeft = 1f;
                        pan.BorderWidthBottom = 1f;
                        pan.BorderWidthRight = 1f;

                        c_an.AddCell(pan);

                        PdfPCell pan1 = CellCircle(BaseColor.WHITE, "a", textFont);

                        pan1.BorderWidthTop = 1f;
                        pan1.BorderWidthLeft = 0f;
                        pan1.BorderWidthBottom = 1f;
                        pan1.BorderWidthRight = 0f;

                        c_an.AddCell(pan1);

                        PdfPCell pan2 = CellCircle(BaseColor.WHITE, "b", textFont);

                        pan2.BorderWidthTop = 1f;
                        pan2.BorderWidthLeft = 0f;
                        pan2.BorderWidthBottom = 1f;
                        pan2.BorderWidthRight = 0f;

                        c_an.AddCell(pan2);

                        PdfPCell pan3 = CellCircle(BaseColor.WHITE, "c", textFont);

                        pan3.BorderWidthTop = 1f;
                        pan3.BorderWidthLeft = 0f;
                        pan3.BorderWidthBottom = 1f;
                        pan3.BorderWidthRight = 1f;

                        c_an.AddCell(pan3);
                    }
                }

                cellSe3B6.AddElement(c_an);
            }

            cellSe3B6.AddElement(CellData(new PdfPTable(1), new string[] { "3 a 5mm = 1" }, true));
            cellSe3B6.AddElement(CellData(new PdfPTable(1), new string[] { "5 a 10mm = 2" }, true));
            cellSe3B6.AddElement(CellData(new PdfPTable(1), new string[] { "> a 10mm = 3" }, true));
            tablesE3B4.AddCell(cellSe3B6);

            tablesE3B4.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });

            rowSe3Bcelda1.AddElement(tablesE3B4);

            tableSe3B.AddCell(rowSe3Bcelda1);
            #endregion Ancho PP

            doc.Add(tableSe3B);

            #region Obliteracion  3C
            PdfPTable tableSe3C = new PdfPTable(1);
            tableSe3C.WidthPercentage = 100;

            float[] rowColumnas3C = new float[] { 100f };

            tableSe3C.SetWidths(rowColumnas3C);

            var rowSe3Ccelda1 = new PdfPCell() { PaddingBottom = 5f };

            var tableSe3C1 = new PdfPTable(4);
            float[] rowColumnasSe3C = new float[] { 3f, 35f, 30f, 32F };

            tableSe3C1.SetWidths(rowColumnasSe3C);

            tableSe3C1.WidthPercentage = 100;
            tableSe3C1.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe3C1.AddCell(new PdfPCell(new Phrase("3C", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tableSe3C1.AddCell(new PdfPCell(new Phrase("OBLITERACIÓN ANGULO COSTO FRENICO: ", textFont)) { Border = PdfPCell.NO_BORDER });

            var cellSe3C = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };

            var tb3C1 = new PdfPTable(3) { WidthPercentage = 80 };

            PdfPCell oaf = CellCircle(data["OBLITERACION"].ToString().Equals("O") ? BaseColor.RED : BaseColor.WHITE, "  O", textFont);

            oaf.BorderWidthTop = 1f; oaf.BorderWidthLeft = 1f;
            oaf.BorderWidthBottom = 1f;
            oaf.BorderWidthRight = 0f;
            oaf.VerticalAlignment = Element.ALIGN_MIDDLE;

            tb3C1.AddCell(oaf);

            PdfPCell oaf1;

            if (data["OBLITERACION"].ToString().Equals("D"))
                oaf1 = CellCircle(BaseColor.RED, "  D", textFont);
            else
                oaf1 = CellCircle(BaseColor.WHITE, "  D", textFont);

            oaf1.BorderWidthTop = 1f;
            oaf1.BorderWidthLeft = 0f;
            oaf1.BorderWidthBottom = 1f;
            oaf1.BorderWidthRight = 0f;
            oaf1.VerticalAlignment = Element.ALIGN_MIDDLE;

            tb3C1.AddCell(oaf1);

            PdfPCell oaf2 = CellCircle(data["OBLITERACION"].ToString().Equals("I") ? BaseColor.RED : BaseColor.WHITE, "  I", textFont);

            oaf2.BorderWidthTop = 1f;
            oaf2.BorderWidthLeft = 0f;
            oaf2.BorderWidthBottom = 1f;
            oaf2.BorderWidthRight = 1f;
            oaf2.VerticalAlignment = Element.ALIGN_MIDDLE;

            tb3C1.AddCell(oaf2);

            cellSe3C.AddElement(tb3C1);

            tableSe3C1.AddCell(cellSe3C);
            #endregion Obliteracion  3C

            tableSe3C1.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe3Ccelda1.AddElement(tableSe3C1);

            tableSe3C.AddCell(rowSe3Ccelda1);

            doc.Add(tableSe3C);

            #region Engrosamiento Inicial
            PdfPTable tableSe3D = new PdfPTable(1);
            tableSe3D.WidthPercentage = 100;

            float[] rowColumnas3D = new float[] { 100f };

            tableSe3D.SetWidths(rowColumnas3D);

            var rowSe3Dcelda1 = new PdfPCell() { PaddingBottom = 5f };

            var tableSe3D1 = new PdfPTable(4);
            float[] rowColumnasSe3D = new float[] { 3f, 33f, 10f, 54F };

            tableSe3D1.SetWidths(rowColumnasSe3C);

            tableSe3D1.WidthPercentage = 100;
            tableSe3D1.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe3D1.AddCell(new PdfPCell(new Phrase("3D", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tableSe3D1.AddCell(new PdfPCell(new Phrase("ENGROSAMIENTO PLEURAL DIFUSO: ", textFont)) { Border = PdfPCell.NO_BORDER });

            var cellSe3D = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };

            var tb3D1 = new PdfPTable(2) { WidthPercentage = 100 };

            if (data["ENGROSAPLERURALDIFUSO"].ToString().Equals("SI"))
                tb3D1.AddCell(CellCircle(BaseColor.RED, "SI", textFont));
            else
                tb3D1.AddCell(CellCircle(BaseColor.WHITE, "SI", textFont));

            if (data["ENGROSAPLERURALDIFUSO"].ToString().Equals("NO"))
                tb3D1.AddCell(CellCircle(BaseColor.RED, "NO", textFont));
            else
                tb3D1.AddCell(CellCircle(BaseColor.WHITE, "NO", textFont));

            cellSe3D.AddElement(tb3D1);

            tableSe3D1.AddCell(cellSe3D);
            #endregion Engrosamiento Inicial

            #region Engrosamiento Titulos
            tableSe3D1.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe3Dcelda1.AddElement(tableSe3D1);

            var tablesE3DI = new PdfPTable(1);
            float[] rowColumnasSE3DI = new float[] { 100f };

            tablesE3DI.SetWidths(rowColumnasSE3DI);

            tablesE3DI.WidthPercentage = 100;
            tablesE3DI.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablesE3DI.AddCell(new PdfPCell(new Phrase(" ", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe3Dcelda1.AddElement(tablesE3DI);

            var tablesE3D2 = new PdfPTable(7);
            float[] rowColumnasSE3D1 = new float[] { 10f, 19f, 19f, 2f, 25f, 2f, 23f };

            tablesE3D2.SetWidths(rowColumnasSE3D1);

            tablesE3D2.WidthPercentage = 100;
            tablesE3D2.DefaultCell.Border = PdfPCell.NO_BORDER;
            tablesE3D2.AddCell(new PdfPCell(new Phrase(" ", textFont)) { Border = PdfPCell.NO_BORDER });
            tablesE3D2.AddCell(new PdfPCell(new Phrase("\n SITIO", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablesE3D2.AddCell(new PdfPCell(new Phrase("\nCALSIFICACIÓN", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablesE3D2.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });
            tablesE3D2.AddCell(new PdfPCell(new Phrase("EXTENSIÓN: PARED \n(Combinado de perfil y frente)", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tablesE3D2.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });
            tablesE3D2.AddCell(new PdfPCell(new Phrase("  ANCHO (OPCIONAL) \n(Solo en perfil, 3m grosor mÍnimo)", textFontSub)) { Border = PdfPCell.NO_BORDER });

            rowSe3Dcelda1.AddElement(tablesE3D2);
            #endregion Engrosamiento Titulos

            #region Engrosamiento Sitio 
            var tablesE3D3 = new PdfPTable(7);
            float[] rowColumnasSE3D3 = new float[] { 8f, 18f, 18f, 1f, 26f, 1f, 24f };

            tablesE3D3.SetWidths(rowColumnasSE3D3);

            tablesE3D3.WidthPercentage = 100;
            tablesE3D3.DefaultCell.Border = PdfPCell.NO_BORDER;

            var cellSe3D2 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };
            cellSe3D2.AddElement(CellData(new PdfPTable(1), new string[] { " Perfil" }, true));
            cellSe3D2.AddElement(CellData(new PdfPTable(1), new string[] { " Frente" }, true));
            tablesE3D3.AddCell(cellSe3D2);

            var cellSe3D3 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };
            var array7 = new string[] { "EPD_SITIOPERFIL", "EPD_SITIOFRENTE" };

            for (int i = 0; i < array7.Length; i++)
            {
                var s_epd = new PdfPTable(3) { WidthPercentage = 100 };

                PdfPCell epd1;

                if (data[array7[i]].Equals("O"))
                    epd1 = CellCircle(BaseColor.RED, "O ", textFont);
                else
                    epd1 = CellCircle(BaseColor.WHITE, "O ", textFont);

                epd1.BorderWidthTop = 1f;
                epd1.BorderWidthLeft = 1f;
                epd1.BorderWidthBottom = i.Equals(array7.Length - 1) ? 1f : 0f;
                epd1.BorderWidthRight = 0f;

                s_epd.AddCell(epd1);

                PdfPCell epd2;

                if (data[array7[i]].Equals("D"))
                    epd2 = CellCircle(BaseColor.RED, "D", textFont);
                else
                    epd2 = CellCircle(BaseColor.WHITE, "D", textFont);

                epd2.BorderWidthTop = 1f;
                epd2.BorderWidthLeft = 0f;
                epd2.BorderWidthBottom = i.Equals(array7.Length - 1) ? 1f : 0f;
                epd2.BorderWidthRight = 0f;

                s_epd.AddCell(epd2);

                PdfPCell epd3;

                if (data[array7[i]].Equals("I"))
                    epd3 = CellCircle(BaseColor.RED, "I", textFont);
                else
                    epd3 = CellCircle(BaseColor.WHITE, "I", textFont);

                epd3.BorderWidthTop = 1f;
                epd3.BorderWidthLeft = 0f;
                epd3.BorderWidthBottom = i.Equals(array7.Length - 1) ? 1f : 0f;
                epd3.BorderWidthRight = 1f;

                s_epd.AddCell(epd3);

                cellSe3D3.AddElement(s_epd);
            }

            tablesE3D3.AddCell(cellSe3D3);
            #endregion Engrosamiento Sitio 

            #region Engrosamiento Calsificacion
            var cellSe3D4 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };
            var array8 = new string[] { "EPD_CALSIFICACIONPERFIL", "EPD_CALSIFICACIONFRENTE" };

            for (int i = 0; i < array8.Length; i++)
            {
                var s_epd = new PdfPTable(3) { WidthPercentage = 100 };

                PdfPCell epd1;

                if (data[array8[i]].Equals("O"))
                    epd1 = CellCircle(BaseColor.RED, "O ", textFont);
                else
                    epd1 = CellCircle(BaseColor.WHITE, "O ", textFont);

                epd1.BorderWidthTop = 1f;
                epd1.BorderWidthLeft = 1f;
                epd1.BorderWidthBottom = i.Equals(array8.Length - 1) ? 1f : 0f;
                epd1.BorderWidthRight = 0f;

                s_epd.AddCell(epd1);

                PdfPCell epd2;

                if (data[array8[i]].Equals("D"))
                    epd2 = CellCircle(BaseColor.RED, "D", textFont);
                else
                    epd2 = CellCircle(BaseColor.WHITE, "D", textFont);

                epd2.BorderWidthTop = 1f;
                epd2.BorderWidthLeft = 0f;
                epd2.BorderWidthBottom = i.Equals(array8.Length - 1) ? 1f : 0f;
                epd2.BorderWidthRight = 0f;

                s_epd.AddCell(epd2);

                PdfPCell epd3;

                if (data[array8[i]].Equals("I"))
                    epd3 = CellCircle(BaseColor.RED, "I", textFont);
                else
                    epd3 = CellCircle(BaseColor.WHITE, "I", textFont);

                epd3.BorderWidthTop = 1f;
                epd3.BorderWidthLeft = 0f;
                epd3.BorderWidthBottom = i.Equals(array8.Length - 1) ? 1f : 0f;
                epd3.BorderWidthRight = 1f;

                s_epd.AddCell(epd3);

                cellSe3D4.AddElement(s_epd);
            }

            tablesE3D3.AddCell(cellSe3D4);
            #endregion Engrosamiento Calsificacion

            #region Engrosamiento Extension
            tablesE3D3.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });

            var cellSe3D5 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };
            var array9 = new string[] { "EPD_EXTENSIONPAREDPERFILOP", "EPD_EXTENSIONPAREDFRENTEOP" };
            var array10 = new string[] { "EPD_EXTENSIONPAREDPERFILSE", "EPD_EXTENSIONPAREDFRENTESE" };

            for (int i = 0; i < 2; i++)
            {
                var c_ex = new PdfPTable(4);

                if (data[array9[i]].Equals("O") || data[array9[i]].Equals("I"))
                {
                    PdfPCell cex1 = CellCircle(BaseColor.RED, data[array9[i]].Equals("O") ? "O" : " I", textFont);

                    cex1.BorderWidthTop = 1f;
                    cex1.BorderWidthLeft = 1f;
                    cex1.BorderWidthBottom = i.Equals(1) ? 1f : 0f;
                    cex1.BorderWidthRight = 1f;

                    c_ex.AddCell(cex1);

                    PdfPCell cex2;

                    if (data[array10[i]].Equals("1"))
                        cex2 = CellCircle(BaseColor.RED, "1", textFont);
                    else
                        cex2 = CellCircle(BaseColor.WHITE, "1", textFont);

                    cex2.BorderWidthTop = 1f;
                    cex2.BorderWidthLeft = 0f;
                    cex2.BorderWidthBottom = i.Equals(1) ? 1f : 0f;
                    cex2.BorderWidthRight = 0f;

                    c_ex.AddCell(cex2);

                    PdfPCell cex3;

                    if (data[array10[i]].Equals("2"))
                        cex3 = CellCircle(BaseColor.RED, "2", textFont);
                    else
                        cex3 = CellCircle(BaseColor.WHITE, "2", textFont);

                    cex3.BorderWidthTop = 1f;
                    cex3.BorderWidthLeft = 0f;
                    cex3.BorderWidthBottom = i.Equals(1) ? 1f : 0f;
                    cex3.BorderWidthRight = 0f;

                    c_ex.AddCell(cex3);

                    PdfPCell cex4;

                    if (data[array10[i]].Equals("3"))
                        cex4 = CellCircle(BaseColor.RED, "3", textFont);
                    else
                        cex4 = CellCircle(BaseColor.WHITE, "3", textFont);

                    cex4.BorderWidthTop = 1f;
                    cex4.BorderWidthLeft = 0f;
                    cex4.BorderWidthBottom = i.Equals(1) ? 1f : 0f;
                    cex4.BorderWidthRight = 1f;

                    c_ex.AddCell(cex4);
                }
                else if (data[array9[i]].Equals("D"))
                {
                    PdfPCell cex1 = CellCircle(BaseColor.RED, "D", textFont);

                    cex1.BorderWidthTop = 1f;
                    cex1.BorderWidthLeft = 1f;
                    cex1.BorderWidthBottom = i.Equals(0) ? 0f : 1f;
                    cex1.BorderWidthRight = 1f;

                    c_ex.AddCell(cex1);

                    PdfPCell cex2;

                    if (data[array10[i]].Equals("1"))
                        cex2 = CellCircle(BaseColor.RED, "1", textFont);
                    else
                        cex2 = CellCircle(BaseColor.WHITE, "1", textFont);

                    cex2.BorderWidthTop = 1f;
                    cex2.BorderWidthLeft = 0f;
                    cex2.BorderWidthBottom = i.Equals(0) ? 0f : 1f;
                    cex2.BorderWidthRight = 0f;

                    c_ex.AddCell(cex2);

                    PdfPCell cex3;

                    if (data[array10[i]].Equals("2"))
                        cex3 = CellCircle(BaseColor.RED, "2", textFont);
                    else
                        cex3 = CellCircle(BaseColor.WHITE, "2", textFont);

                    cex3.BorderWidthTop = 1f;
                    cex3.BorderWidthLeft = 0f;
                    cex3.BorderWidthBottom = i.Equals(0) ? 0f : 1f;
                    cex3.BorderWidthRight = 0f;

                    c_ex.AddCell(cex3);

                    PdfPCell cex4;

                    if (data[array10[i]].Equals("3"))
                        cex4 = CellCircle(BaseColor.RED, "3", textFont);
                    else
                        cex4 = CellCircle(BaseColor.WHITE, "3", textFont);

                    cex4.BorderWidthTop = 1f;
                    cex4.BorderWidthLeft = 0f;
                    cex4.BorderWidthBottom = i.Equals(0) ? 0f : 1f;
                    cex4.BorderWidthRight = 1f;

                    c_ex.AddCell(cex4);
                }
                else
                {
                    if (array9[i].Equals("EPD_EXTENSIONPAREDPERFILOP"))
                    {
                        PdfPCell cex1 = CellCircle(BaseColor.WHITE, " ", textFont);

                        cex1.BorderWidthTop = 1f;
                        cex1.BorderWidthLeft = 1f;
                        cex1.BorderWidthBottom = 0f;
                        cex1.BorderWidthRight = 1f;

                        c_ex.AddCell(cex1);

                        PdfPCell cex2 = CellCircle(BaseColor.WHITE, "1", textFont);

                        cex2.BorderWidthTop = 1f;
                        cex2.BorderWidthLeft = 0f;
                        cex2.BorderWidthBottom = 0f;
                        cex2.BorderWidthRight = 0f;

                        c_ex.AddCell(cex2);

                        PdfPCell cex3 = CellCircle(BaseColor.WHITE, "2", textFont);

                        cex3.BorderWidthTop = 1f;
                        cex3.BorderWidthLeft = 0f;
                        cex3.BorderWidthBottom = 0f;
                        cex3.BorderWidthRight = 0f;

                        c_ex.AddCell(cex3);

                        PdfPCell cex4 = CellCircle(BaseColor.WHITE, "3", textFont);

                        cex4.BorderWidthTop = 1f;
                        cex4.BorderWidthLeft = 0f;
                        cex4.BorderWidthBottom = 0f;
                        cex4.BorderWidthRight = 1f;

                        c_ex.AddCell(cex4);
                    }
                    else
                    {
                        PdfPCell cex1 = CellCircle(BaseColor.WHITE, " ", textFont);

                        cex1.BorderWidthTop = 1f;
                        cex1.BorderWidthLeft = 1f;
                        cex1.BorderWidthBottom = 1f;
                        cex1.BorderWidthRight = 1f;

                        c_ex.AddCell(cex1);

                        PdfPCell cex2 = CellCircle(BaseColor.WHITE, "1", textFont);

                        cex2.BorderWidthTop = 1f;
                        cex2.BorderWidthLeft = 0f;
                        cex2.BorderWidthBottom = 1f;
                        cex2.BorderWidthRight = 0f;

                        c_ex.AddCell(cex2);

                        PdfPCell cex3 = CellCircle(BaseColor.WHITE, "2", textFont);

                        cex3.BorderWidthTop = 1f;
                        cex3.BorderWidthLeft = 0f;
                        cex3.BorderWidthBottom = 1f;
                        cex3.BorderWidthRight = 0f;

                        c_ex.AddCell(cex3);

                        PdfPCell cex4 = CellCircle(BaseColor.WHITE, "3", textFont);

                        cex4.BorderWidthTop = 1f;
                        cex4.BorderWidthLeft = 0f;
                        cex4.BorderWidthBottom = 1f;
                        cex4.BorderWidthRight = 1f;

                        c_ex.AddCell(cex4);
                    }
                }

                cellSe3D5.AddElement(c_ex);
            }

            cellSe3D5.AddElement(CellData(new PdfPTable(1), new string[] { "Para 1/4 de la pared lateral = 1" }, true));
            cellSe3D5.AddElement(CellData(new PdfPTable(1), new string[] { "1/4 a 1/2 de pared lateral = 2" }, true));
            cellSe3D5.AddElement(CellData(new PdfPTable(1), new string[] { "> a 1/2 de pared lateral = 3" }, true));

            tablesE3D3.AddCell(cellSe3D5);
            #endregion Engrosamiento Extension

            tablesE3D3.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });

            var cellSe3D6 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };
            var array11 = new string[] { "EPD_ANCHODERECHAOP", "EPD_ANCHOIZQUIERDAOP" };
            var array12 = new string[] { "EPD_ANCHODERECHASE", "EPD_ANCHOIZQUIERDASE" };

            for (int i = 0; i < 2; i++)
            {
                var c_an = new PdfPTable(4);

                if (data[array11[i]].Equals("D"))
                {
                    PdfPCell can1 = CellCircle(BaseColor.RED, "D", textFont);

                    can1.BorderWidthTop = 1f;
                    can1.BorderWidthLeft = 1f;
                    can1.BorderWidthBottom = 0f;
                    can1.BorderWidthRight = 1f;

                    c_an.AddCell(can1);

                    PdfPCell can2;

                    if (data[array12[i]].Equals("a"))
                        can2 = CellCircle(BaseColor.RED, "a", textFont);
                    else
                        can2 = CellCircle(BaseColor.WHITE, "a", textFont);

                    can2.BorderWidthTop = 1f;
                    can2.BorderWidthLeft = 0f;
                    can2.BorderWidthBottom = 0f;
                    can2.BorderWidthRight = 0f;

                    c_an.AddCell(can2);

                    PdfPCell can3;

                    if (data[array12[i]].Equals("b"))
                        can3 = CellCircle(BaseColor.RED, "b", textFont);
                    else
                        can3 = CellCircle(BaseColor.WHITE, "b", textFont);

                    can3.BorderWidthTop = 1f;
                    can3.BorderWidthLeft = 0f;
                    can3.BorderWidthBottom = 0f;
                    can3.BorderWidthRight = 0f;

                    c_an.AddCell(can3);

                    PdfPCell can4;

                    if (data[array12[i]].Equals("c"))
                        can4 = CellCircle(BaseColor.RED, "c", textFont);
                    else
                        can4 = CellCircle(BaseColor.WHITE, "c", textFont);

                    can4.BorderWidthTop = 1f;
                    can4.BorderWidthLeft = 0f;
                    can4.BorderWidthBottom = 0f;
                    can4.BorderWidthRight = 1f;

                    c_an.AddCell(can4);
                }
                else if (data[array11[i]].Equals("I"))
                {

                    PdfPCell can1 = CellCircle(BaseColor.RED, " I", textFont);

                    can1.BorderWidthTop = 1f;
                    can1.BorderWidthLeft = 1f;
                    can1.BorderWidthBottom = 1f;
                    can1.BorderWidthRight = 1f;

                    c_an.AddCell(can1);

                    PdfPCell can2;

                    if (data[array12[i]].Equals("a"))
                        can2 = CellCircle(BaseColor.RED, "a", textFont);
                    else
                        can2 = CellCircle(BaseColor.WHITE, "a", textFont);

                    can2.BorderWidthTop = 1f;
                    can2.BorderWidthLeft = 0f;
                    can2.BorderWidthBottom = 1f;
                    can2.BorderWidthRight = 0f;

                    c_an.AddCell(can2);

                    PdfPCell can3;

                    if (data[array12[i]].Equals("b"))
                        can3 = CellCircle(BaseColor.RED, "b", textFont);
                    else
                        can3 = CellCircle(BaseColor.WHITE, "b", textFont);

                    can3.BorderWidthTop = 1f;
                    can3.BorderWidthLeft = 0f;
                    can3.BorderWidthBottom = 1f;
                    can3.BorderWidthRight = 0f;

                    c_an.AddCell(can3);

                    PdfPCell can4;

                    if (data[array12[i]].Equals("c"))
                        can4 = CellCircle(BaseColor.RED, "c", textFont);
                    else
                        can4 = CellCircle(BaseColor.WHITE, "c", textFont);

                    can4.BorderWidthTop = 1f;
                    can4.BorderWidthLeft = 0f;
                    can4.BorderWidthBottom = 1f;
                    can4.BorderWidthRight = 1f;

                    c_an.AddCell(can4);
                }
                else
                {
                    if (array9[i].Equals("EPD_ANCHODERECHAOP"))
                    {
                        PdfPCell cex1 = CellCircle(BaseColor.WHITE, "D", textFont);

                        cex1.BorderWidthTop = 1f;
                        cex1.BorderWidthLeft = 1f;
                        cex1.BorderWidthBottom = 0f;
                        cex1.BorderWidthRight = 1f;

                        c_an.AddCell(cex1);

                        PdfPCell cex2 = CellCircle(BaseColor.WHITE, "1", textFont);

                        cex2.BorderWidthTop = 1f;
                        cex2.BorderWidthLeft = 0f;
                        cex2.BorderWidthBottom = 0f;
                        cex2.BorderWidthRight = 0f;

                        c_an.AddCell(cex2);

                        PdfPCell cex3 = CellCircle(BaseColor.WHITE, "2", textFont);

                        cex3.BorderWidthTop = 1f;
                        cex3.BorderWidthLeft = 0f;
                        cex3.BorderWidthBottom = 0f;
                        cex3.BorderWidthRight = 0f;

                        c_an.AddCell(cex3);

                        PdfPCell cex4 = CellCircle(BaseColor.WHITE, "3", textFont);

                        cex4.BorderWidthTop = 1f;
                        cex4.BorderWidthLeft = 0f;
                        cex4.BorderWidthBottom = 0f;
                        cex4.BorderWidthRight = 1f;

                        c_an.AddCell(cex4);
                    }
                    else
                    {
                        PdfPCell cex1 = CellCircle(BaseColor.WHITE, " I", textFont);

                        cex1.BorderWidthTop = 1f;
                        cex1.BorderWidthLeft = 1f;
                        cex1.BorderWidthBottom = 1f;
                        cex1.BorderWidthRight = 1f;

                        c_an.AddCell(cex1);

                        PdfPCell cex2 = CellCircle(BaseColor.WHITE, "1", textFont);

                        cex2.BorderWidthTop = 1f;
                        cex2.BorderWidthLeft = 0f;
                        cex2.BorderWidthBottom = 1f;
                        cex2.BorderWidthRight = 0f;

                        c_an.AddCell(cex2);

                        PdfPCell cex3 = CellCircle(BaseColor.WHITE, "2", textFont);

                        cex3.BorderWidthTop = 1f;
                        cex3.BorderWidthLeft = 0f;
                        cex3.BorderWidthBottom = 1f;
                        cex3.BorderWidthRight = 0f;

                        c_an.AddCell(cex3);

                        PdfPCell cex4 = CellCircle(BaseColor.WHITE, "3", textFont);

                        cex4.BorderWidthTop = 1f;
                        cex4.BorderWidthLeft = 0f;
                        cex4.BorderWidthBottom = 1f;
                        cex4.BorderWidthRight = 1f;

                        c_an.AddCell(cex4);
                    }
                }
                cellSe3D6.AddElement(c_an);
            }

            cellSe3D6.AddElement(CellData(new PdfPTable(1), new string[] { "3 a 5mm = 1" }, true));
            cellSe3D6.AddElement(CellData(new PdfPTable(1), new string[] { "5 a 10mm = 2" }, true));
            cellSe3D6.AddElement(CellData(new PdfPTable(1), new string[] { "> a 10mm = 3" }, true));

            tablesE3D3.AddCell(cellSe3D6);

            tablesE3D3.AddCell(new PdfPCell(new Phrase("", textFontSub)) { Border = PdfPCell.NO_BORDER });

            rowSe3Dcelda1.AddElement(tablesE3D3);

            tableSe3D.AddCell(rowSe3Dcelda1);

            doc.Add(tableSe3D);

            PdfPTable tableSe4A = new PdfPTable(1);
            tableSe4A.WidthPercentage = 100;

            float[] rowColumnas4A = new float[] { 100f };

            tableSe4A.SetWidths(rowColumnas4A);

            var rowSe4Acelda1 = new PdfPCell() { PaddingBottom = 5f };

            var tableSe4A1 = new PdfPTable(4);
            float[] rowColumnasSe4A = new float[] { 3f, 30f, 17f, 50F };

            tableSe4A1.SetWidths(rowColumnasSe4A);

            tableSe4A1.WidthPercentage = 100;
            tableSe4A1.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe4A1.AddCell(new PdfPCell(new Phrase("4A", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tableSe4A1.AddCell(new PdfPCell(new Phrase("OTRAS ANORMALIDADES: ", textFont)) { Border = PdfPCell.NO_BORDER });

            var cellSe4A = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };

            var tb4A1 = new PdfPTable(2) { WidthPercentage = 100 };

            if (data["OTRASANORMALIDADES"].ToString().Equals("SI"))
                tb4A1.AddCell(CellCircle(BaseColor.RED, "SI", textFont));
            else
                tb4A1.AddCell(CellCircle(BaseColor.WHITE, "SI", textFont));

            if (data["OTRASANORMALIDADES"].ToString().Equals("NO"))
                tb4A1.AddCell(CellCircle(BaseColor.RED, "NO", textFont));
            else
                tb4A1.AddCell(CellCircle(BaseColor.WHITE, "NO", textFont));

            cellSe4A.AddElement(tb4A1);

            tableSe4A1.AddCell(cellSe4A);

            tableSe4A1.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe4Acelda1.AddElement(tableSe4A1);

            tableSe4A.AddCell(rowSe4Acelda1);

            doc.Add(tableSe4A);

            PdfPTable tableSe4B = new PdfPTable(1);
            tableSe4B.WidthPercentage = 100;

            float[] rowColumnas4B = new float[] { 100f };

            tableSe4B.SetWidths(rowColumnas4B);

            var rowSe4Bcelda = new PdfPCell() { PaddingBottom = 5f };

            var tableSe4B1 = new PdfPTable(3);
            float[] rowColumnasSe4B = new float[] { 3f, 35f, 62f };

            tableSe4B1.SetWidths(rowColumnasSe4B);

            tableSe4B1.WidthPercentage = 100;
            tableSe4B1.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe4B1.AddCell(new PdfPCell(new Phrase("4B", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tableSe4B1.AddCell(new PdfPCell(new Phrase("SÍMBOLOS: ", textFont)) { Border = PdfPCell.NO_BORDER });
            tableSe4B1.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe4Bcelda.AddElement(tableSe4B1);

            #region Symbols
            var tableSe4B2 = new PdfPTable(3);
            tableSe4B2.WidthPercentage = 100;

            tableSe4B2.SetWidths(new float[] { 3f, 94f, 3F });
            tableSe4B2.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe4B2.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            var _symbol = new string[] { "aa", "at", "ax", "bu", "ca", "cg", "cn", "co", "cp", "cv", "di", "ef", "em", "es", "fr", "hi", "ho", "id", "hi", "kl", "me", "pa", "pb", "pi", "px", "ra", "rp", "tb", "od*" };
            var _symbolE = new string[] { "SIMBOLO_AA", "SIMBOLO_AT", "SIMBOLO_AX", "SIMBOLO_BU", "SIMBOLO_CA", "SIMBOLO_CG", "SIMBOLO_CN", "SIMBOLO_CO", "SIMBOLO_CP", "SIMBOLO_CV", "SIMBOLO_DI", "SIMBOLO_EF", "SIMBOLO_EM", "SIMBOLO_ES", "SIMBOLO_FR", "SIMBOLO_HI", "SIMBOLO_HO", "SIMBOLO_ID", "SIMBOLO_IH", "SIMBOLO_KL", "SIMBOLO_ME", "SIMBOLO_PA", "SIMBOLO_PB", "SIMBOLO_PI", "SIMBOLO_PX", "SIMBOLO_RA", "SIMBOLO_RP", "SIMBOLO_TB", "SIMBOLO_OD" };

            var cellSe4B1 = new PdfPCell() { BorderWidth = PdfPCell.NO_BORDER };

            for (int i = 0; i < 1; i++)
                cellSe4B1.AddElement(CellData(new PdfPTable(29) { WidthPercentage = 100 }, _symbol));

            var tb4B = new PdfPTable(29) { WidthPercentage = 100 };

            var textsymbol = FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);


            for (int i = 0; i < _symbolE.Length; i++)
            {
                PdfPCell _box;

                if (data[_symbolE[i]].Equals(1))
                {
                    _box = CellCircle(BaseColor.RED, ".", textsymbol);
                    _box.Border = PdfPCell.BOX;
                    _box.BorderColor = BaseColor.BLACK;
                    _box.BorderWidth = 1f;
                    _box.PaddingLeft = -2f;
                    _box.PaddingRight = 10f;
                }
                else
                    _box = new PdfPCell(new Phrase(".", textFontSel)) { Border = PdfPCell.BOX, BorderColor = BaseColor.BLACK, BorderWidth = 1f };

                _box.HorizontalAlignment = Element.ALIGN_LEFT;
                _box.VerticalAlignment = Element.ALIGN_MIDDLE;

                tb4B.AddCell(_box);
            }

            cellSe4B1.AddElement(tb4B);

            tableSe4B2.AddCell(cellSe4B1);

            tableSe4B2.AddCell(new PdfPCell(new Phrase("", textFont)) { Border = PdfPCell.NO_BORDER });

            rowSe4Bcelda.AddElement(tableSe4B2);

            tableSe4B.AddCell(rowSe4Bcelda);

            doc.Add(tableSe4B);
            #endregion Symbols

            PdfPTable tableSe4C = new PdfPTable(1) { WidthPercentage = 100 };

            tableSe4C.SetWidths(new float[] { 100f });

            var rowSe4Ccelda = new PdfPCell() { PaddingBottom = 5f };

            var tableSe4C1 = new PdfPTable(3);

            tableSe4C1.SetWidths(new float[] { 3f, 20f, 77f });

            tableSe4C1.WidthPercentage = 100;
            tableSe4C1.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableSe4C1.AddCell(new PdfPCell(new Phrase("4C", textFontSeccion)) { Border = PdfPCell.NO_BORDER, BackgroundColor = BaseColor.GRAY });
            tableSe4C1.AddCell(new PdfPCell(new Phrase("Comentarios: ", textFontSub)) { Border = PdfPCell.NO_BORDER });
            tableSe4C1.AddCell(new PdfPCell(new Phrase(String.Format("{0}", data["COMENTARIOGEN"].ToString()), textFontSub)) { Border = PdfPCell.NO_BORDER });

            rowSe4Ccelda.AddElement(tableSe4C1);

            tableSe4C.AddCell(rowSe4Ccelda);

            doc.Add(tableSe4C);

            PdfPTable tableFN = new PdfPTable(1) { WidthPercentage = 100 };

            tableFN.SetWidths(new float[] { 100f });

            var rowFN = new PdfPCell() { PaddingBottom = 10f };

            var tableFNS = new PdfPTable(1);

            tableFNS.SetWidths(new float[] { 100f });

            tableFNS.WidthPercentage = 100;
            tableFNS.DefaultCell.Border = PdfPCell.NO_BORDER;
            tableFNS.AddCell(new PdfPCell(new Phrase(string.Format("FECHA LECTURA: {0}", data["FECHALECTURA"].ToString()), textFontSub)) { Border = PdfPCell.NO_BORDER });

            rowFN.AddElement(tableFNS);

            tableFN.AddCell(rowFN);

            doc.Add(tableFN);

            var firma = new PdfPTable(1) { WidthPercentage = 100 }; ;

            firma.SetWidths(new float[] { 100f });

            var rowFR = new PdfPCell();

            var tableFIR = new PdfPTable(2);

            tableFIR.SetWidths(new float[] { 20f, 80f });

            tableFIR.WidthPercentage = 100;
            tableFIR.DefaultCell.Border = PdfPCell.NO_BORDER;

            tableFIR.AddCell(new PdfPCell(new Phrase("FIRMA: ", textFontSub)) { Border = PdfPCell.NO_BORDER, VerticalAlignment = Element.ALIGN_MIDDLE });

            var url = ConfigurationManager.AppSettings["urlFirma"];
            var imagePath = url + data["FIRMA"].ToString();

            if (!data["FIRMA"].ToString().Equals(""))
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                using (var client = new System.Net.WebClient())
                {
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    byte[] imageData = client.DownloadData(imagePath);
                    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(imageData);

                    imagen.ScaleToFit(130f, 130f);

                    var celdaConImagen = new PdfPCell(imagen);
                    celdaConImagen.HorizontalAlignment = Element.ALIGN_CENTER;
                    celdaConImagen.Border = PdfPCell.NO_BORDER;

                    tableFIR.AddCell(celdaConImagen);
                }
            }

            rowFR.AddElement(tableFIR);

            firma.AddCell(rowFR);

            doc.Add(firma);

            rowFR.AddElement(tableFIR);

            doc.Close();

            memoryStream.Position = 0;

            return memoryStream;
        }

        private static void AddTitle(Document document, string title, iTextSharp.text.Font font)
        {
            Paragraph titleParagraph = new Paragraph(title, font)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 15f
            };
            document.Add(titleParagraph);
        }

        private static PdfPTable CellData(PdfPTable table, string[] text, bool sw)
        {
            var fontN = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);
            var fontS = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);

            foreach (string str in text)
            {
                if (str.Equals(string.Empty) || sw)
                    table.AddCell(new PdfPCell(new Phrase(str, fontS)) { Border = PdfPCell.NO_BORDER });
                else
                    table.AddCell(new PdfPCell(new Phrase(str, fontS)) { Border = PdfPCell.BOX, BorderWidth = 1f, BorderColor = BaseColor.BLACK });
            }

            return table;
        }

        private static PdfPTable CellData(PdfPTable table, string[] text)
        {
            var fontN = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);
            var fontS = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);

            foreach (string str in text)
            {
                table.AddCell(new PdfPCell(new Phrase(str, fontS)) { Border = PdfPCell.BOX, BorderWidth = 1f, BorderColor = BaseColor.BLACK, HorizontalAlignment = Element.ALIGN_CENTER });
            }

            return table;
        }

        private static PdfPCell CellCircle(BaseColor interior, string text, iTextSharp.text.Font font, float ofs)
        {
            var cellWithCircle = new PdfPCell(new Phrase(text, font))
            {
                Border = PdfPCell.NO_BORDER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                HorizontalAlignment = Element.ALIGN_LEFT,
                PaddingLeft = 2f,
                PaddingBottom = 5f
            };

            cellWithCircle.CellEvent = new CellEventCircle(interior, BaseColor.BLACK, ofs);

            return cellWithCircle;
        }

        private static PdfPCell CellCircle(BaseColor interior, string text, iTextSharp.text.Font font)
        {
            PdfPCell _cir = CellCircle(interior, text, font, 2f);

            return _cir;
        }
        #endregion
    }

    public class CellEventCircle : IPdfPCellEvent
    {
        private readonly BaseColor _circleColor;
        private readonly BaseColor _borderColor;
        private readonly float _offsetX;
        private readonly float _offsetY;

        public CellEventCircle(BaseColor circleColor, BaseColor borderColor, float offsetX, float offsety = 0)
        {
            _circleColor = circleColor;
            _borderColor = borderColor;
            _offsetX = offsetX;
            _offsetY = offsety;
        }

        public void CellLayout(PdfPCell cell, iTextSharp.text.Rectangle rect, PdfContentByte[] canvas)
        {
            PdfContentByte cb = canvas[PdfPTable.BACKGROUNDCANVAS];

            float centerX = (rect.Left + rect.Right) / 2 + _offsetX; // Centro horizontal de la celda
            float centerY = (rect.Bottom + rect.Top) / 2 + _offsetY; // Centro vertical de la celda
            float radius = 4f; // Radio del círculo

            cb.SetColorFill(_circleColor); // Establecer color de relleno
            cb.Circle(centerX, centerY, radius); // Dibujar el círculo
            cb.Fill(); // Aplicar el relleno

            cb.SetColorStroke(_borderColor); // Color del borde
            cb.SetLineWidth(0.5f); // Grosor del borde
            cb.Circle(centerX, centerY, radius); // Dibujar el círculo
            cb.Stroke(); // Aplicar el borde
        }
    }
}
