using MultiRisWeb.Data.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MultiRisWeb.ResponseEntity
{
    [JsonObject]
    [Serializable]
    public class RequestInforme
    {
        public string RISEXAMEN { get; set; }
        public string RISINFORME { get; set; }
        public string IDESTADO { get; set; }
        public string IDUSUARIO { get; set; }
        public string CODEXAMEN { get; set; }
        public string PRESTACION { get; set; }
        public string NUMRADIOGRAFIA { get; set; }
        public string RADIOGRAFIADIG { get; set; }
        public string NEGASTOCOPIA { get; set; }
        public string CALIDAD { get; set; }
        public string RADIOGRAFIANOR { get; set; }
        public string COMENTARIO { get; set; }
        public string PARENQUIMATOSA { get; set; }
        public string OPACIPRIMARIAC1 { get; set; }
        public string OPACIPRIMARIAC2 { get; set; }
        public string OPACISECUNDARIAC1 { get; set; }
        public string OPACISECUNDARIAC2 { get; set; }
        public string OPACIDADZONAD1 { get; set; }
        public string OPACIDADZONAD2 { get; set; }
        public string OPACIDADZONAD3 { get; set; }
        public string OPACIDADZONAI1 { get; set; }
        public string OPACIDADZONAI2 { get; set; }
        public string OPACIDADZONAI3 { get; set; }
        public string OPACPROFUSION { get; set; }
        public string OPACIDAGRANDE { get; set; }
        public string ANORMALPLEURAL { get; set; }
        public string PLACAPLEURAL { get; set; }
        public string PP_SITIOPERFIL { get; set; }
        public string PP_SITIOFRENTE { get; set; }
        public string PP_SITIODIAGRAMA { get; set; }
        public string PP_SITIOOTRO { get; set; }
        public string PP_CALSIFICACIONPERFIL { get; set; }
        public string PP_CALSIFICACIONFRENTE { get; set; }
        public string PP_CALSIFICACIONDIAGRAMA { get; set; }
        public string PP_CALSIFICACIONOTRO { get; set; }
        public string PP_EXTENSIONPAREDPERFILOP { get; set; }
        public string PP_EXTENSIONPAREDPERFILSE { get; set; }
        public string PP_EXTENSIONPAREDFRENTEOP { get; set; }
        public string PP_EXTENSIONPAREDFRENTESE { get; set; }
        public string PP_ANCHODERECHAOP { get; set; }
        public string PP_ANCHODERECHASE { get; set; }
        public string PP_ANCHOIZQUIERDAOP { get; set; }
        public string PP_ANCHOIZQUIERDASE { get; set; }
        public string OBLITERACION { get; set; }
        public string ENGROSAPLERURALDIFUSO { get; set; }
        public string EPD_SITIOPERFIL { get; set; }
        public string EPD_SITIOFRENTE { get; set; }
        public string EPD_CALSIFICACIONPERFIL { get; set; }
        public string EPD_CALSIFICACIONFRENTE { get; set; }
        public string EPD_EXTENSIONPAREDPERFILOP { get; set; }
        public string EPD_EXTENSIONPAREDPERFILSE { get; set; }
        public string EPD_EXTENSIONPAREDFRENTEOP { get; set; }
        public string EPD_EXTENSIONPAREDFRENTESE { get; set; }
        public string EPD_ANCHODERECHAOP { get; set; }
        public string EPD_ANCHODERECHASE { get; set; }
        public string EPD_ANCHOIZQUIERDAOP { get; set; }
        public string EPD_ANCHOIZQUIERDASE { get; set; }
        public string OTRASANORMALIDADES { get; set; }
        public string SIMBOLO_AA { get; set; }
        public string SIMBOLO_AT { get; set; }
        public string SIMBOLO_AX { get; set; }
        public string SIMBOLO_BU { get; set; }
        public string SIMBOLO_CA { get; set; }
        public string SIMBOLO_CG { get; set; }
        public string SIMBOLO_CN { get; set; }
        public string SIMBOLO_CO { get; set; }
        public string SIMBOLO_CP { get; set; }
        public string SIMBOLO_CV { get; set; }
        public string SIMBOLO_DI { get; set; }
        public string SIMBOLO_EF { get; set; }
        public string SIMBOLO_EM { get; set; }
        public string SIMBOLO_ES { get; set; }
        public string SIMBOLO_FR { get; set; }
        public string SIMBOLO_HI { get; set; }
        public string SIMBOLO_HO { get; set; }
        public string SIMBOLO_ID { get; set; }
        public string SIMBOLO_IH { get; set; }
        public string SIMBOLO_KL { get; set; }
        public string SIMBOLO_ME { get; set; }
        public string SIMBOLO_PA { get; set; }
        public string SIMBOLO_PB { get; set; }
        public string SIMBOLO_PI { get; set; }
        public string SIMBOLO_PX { get; set; }
        public string SIMBOLO_RA { get; set; }
        public string SIMBOLO_RP { get; set; }
        public string SIMBOLO_TB { get; set; }
        public string SIMBOLO_OD { get; set; }
        public string COMENTARIOGEN { get; set; }

        public static InformeOITDomain ConvertTo(RequestInforme informe)
        {
            var data = new InformeOITDomain();

            data.RISEXAMEN = Convert.ToInt64(informe.RISEXAMEN);
            data.RISINFORME = informe.RISINFORME.Equals("") ? 0 : Convert.ToInt64(informe.RISINFORME);
            data.IDESTADO = Convert.ToInt16(informe.IDESTADO);
            data.IDUSUARIO = Convert.ToInt64(informe.IDUSUARIO) ;
            data.CODEXAMEN = informe.CODEXAMEN;
            data.PRESTACION = informe.PRESTACION;
            data.NUMRADIOGRAFIA = informe.NUMRADIOGRAFIA;
            data.RADIOGRAFIADIG = informe.RADIOGRAFIADIG;
            data.NEGASTOCOPIA = informe.NEGASTOCOPIA;
            data.CALIDAD = informe.CALIDAD ;
            data.RADIOGRAFIANOR = informe.RADIOGRAFIANOR;
            data.COMENTARIO = informe.COMENTARIO;
            data.PARENQUIMATOSA = informe.PARENQUIMATOSA;
            data.OPACIPRIMARIAC1 = informe.OPACIPRIMARIAC1;
            data.OPACIPRIMARIAC2 = informe.OPACIPRIMARIAC2;
            data.OPACISECUNDARIAC1 = informe.OPACISECUNDARIAC1;
            data.OPACISECUNDARIAC2 = informe.OPACISECUNDARIAC2;
            data.OPACIDADZONAD1 = informe.OPACIDADZONAD1;
            data.OPACIDADZONAD2 = informe.OPACIDADZONAD2;
            data.OPACIDADZONAD3 = informe.OPACIDADZONAD3;
            data.OPACIDADZONAI1 = informe.OPACIDADZONAI1;
            data.OPACIDADZONAI2 = informe.OPACIDADZONAI2;
            data.OPACIDADZONAI3 = informe.OPACIDADZONAI3;
            data.OPACPROFUSION = informe.OPACPROFUSION;
            data.OPACIDAGRANDE = informe.OPACIDAGRANDE;
            data.ANORMALPLEURAL = informe.ANORMALPLEURAL;
            data.PLACAPLEURAL = informe.PLACAPLEURAL;
            data.PP_SITIOPERFIL = informe.PP_SITIOPERFIL;
            data.PP_SITIOFRENTE = informe.PP_SITIOFRENTE;
            data.PP_SITIODIAGRAMA = informe.PP_SITIODIAGRAMA;
            data.PP_SITIOOTRO = informe.PP_SITIOOTRO;
            data.PP_CALSIFICACIONPERFIL = informe.PP_CALSIFICACIONPERFIL;
            data.PP_CALSIFICACIONFRENTE = informe.PP_CALSIFICACIONFRENTE;
            data.PP_CALSIFICACIONDIAGRAMA = informe.PP_CALSIFICACIONDIAGRAMA;
            data.PP_CALSIFICACIONOTRO = informe.PP_CALSIFICACIONOTRO;
            data.PP_EXTENSIONPAREDPERFILOP = informe.PP_EXTENSIONPAREDPERFILOP;
            data.PP_EXTENSIONPAREDPERFILSE = informe.PP_EXTENSIONPAREDPERFILSE;
            data.PP_EXTENSIONPAREDFRENTEOP = informe.PP_EXTENSIONPAREDFRENTEOP;
            data.PP_EXTENSIONPAREDFRENTESE = informe.PP_EXTENSIONPAREDFRENTESE;
            data.PP_ANCHODERECHAOP = informe.PP_ANCHODERECHAOP;
            data.PP_ANCHODERECHASE = informe.PP_ANCHODERECHASE;
            data.PP_ANCHOIZQUIERDAOP = informe.PP_ANCHOIZQUIERDAOP;
            data.PP_ANCHOIZQUIERDASE = informe.PP_ANCHOIZQUIERDASE;
            data.OBLITERACION = informe.OBLITERACION;
            data.ENGROSAPLERURALDIFUSO = informe.ENGROSAPLERURALDIFUSO;
            data.EPD_SITIOPERFIL = informe.EPD_SITIOPERFIL;
            data.EPD_SITIOFRENTE = informe.EPD_SITIOFRENTE;
            data.EPD_CALSIFICACIONPERFIL = informe.EPD_CALSIFICACIONPERFIL;
            data.EPD_CALSIFICACIONFRENTE = informe.EPD_CALSIFICACIONFRENTE;
            data.EPD_EXTENSIONPAREDPERFILOP = informe.EPD_EXTENSIONPAREDPERFILOP;
            data.EPD_EXTENSIONPAREDPERFILSE = informe.EPD_EXTENSIONPAREDPERFILSE;
            data.EPD_EXTENSIONPAREDFRENTEOP = informe.EPD_EXTENSIONPAREDFRENTEOP;
            data.EPD_EXTENSIONPAREDFRENTESE = informe.EPD_EXTENSIONPAREDFRENTESE;
            data.EPD_ANCHODERECHAOP = informe.EPD_ANCHODERECHAOP;
            data.EPD_ANCHODERECHASE = informe.EPD_ANCHODERECHASE;
            data.EPD_ANCHOIZQUIERDAOP = informe.EPD_ANCHOIZQUIERDAOP;
            data.EPD_ANCHOIZQUIERDASE = informe.EPD_ANCHOIZQUIERDASE;
            data.OTRASANORMALIDADES = informe.OTRASANORMALIDADES;
            data.SIMBOLO_AA = Convert.ToInt16(informe.SIMBOLO_AA);
            data.SIMBOLO_AT = Convert.ToInt16(informe.SIMBOLO_AT);
            data.SIMBOLO_AX = Convert.ToInt16(informe.SIMBOLO_AX);
            data.SIMBOLO_BU = Convert.ToInt16(informe.SIMBOLO_BU);
            data.SIMBOLO_CA = Convert.ToInt16(informe.SIMBOLO_CA);
            data.SIMBOLO_CG = Convert.ToInt16(informe.SIMBOLO_CG);
            data.SIMBOLO_CN = Convert.ToInt16(informe.SIMBOLO_CN);
            data.SIMBOLO_CO = Convert.ToInt16(informe.SIMBOLO_CO);
            data.SIMBOLO_CP = Convert.ToInt16(informe.SIMBOLO_CP);
            data.SIMBOLO_CV = Convert.ToInt16(informe.SIMBOLO_CV);
            data.SIMBOLO_DI = Convert.ToInt16(informe.SIMBOLO_DI);
            data.SIMBOLO_EF = Convert.ToInt16(informe.SIMBOLO_EF);
            data.SIMBOLO_EM = Convert.ToInt16(informe.SIMBOLO_EM);
            data.SIMBOLO_ES = Convert.ToInt16(informe.SIMBOLO_ES);
            data.SIMBOLO_FR = Convert.ToInt16(informe.SIMBOLO_FR);
            data.SIMBOLO_HI = Convert.ToInt16(informe.SIMBOLO_HI);
            data.SIMBOLO_HO = Convert.ToInt16(informe.SIMBOLO_HO);
            data.SIMBOLO_ID = Convert.ToInt16(informe.SIMBOLO_ID);
            data.SIMBOLO_IH = Convert.ToInt16(informe.SIMBOLO_IH);
            data.SIMBOLO_KL = Convert.ToInt16(informe.SIMBOLO_KL);
            data.SIMBOLO_ME = Convert.ToInt16(informe.SIMBOLO_ME);
            data.SIMBOLO_PA = Convert.ToInt16(informe.SIMBOLO_PA);
            data.SIMBOLO_PB = Convert.ToInt16(informe.SIMBOLO_PB);
            data.SIMBOLO_PI = Convert.ToInt16(informe.SIMBOLO_PI);
            data.SIMBOLO_PX = Convert.ToInt16(informe.SIMBOLO_PX);
            data.SIMBOLO_RA = Convert.ToInt16(informe.SIMBOLO_RA);
            data.SIMBOLO_RP = Convert.ToInt16(informe.SIMBOLO_RP);
            data.SIMBOLO_TB = Convert.ToInt16(informe.SIMBOLO_TB);
            data.SIMBOLO_OD = Convert.ToInt16(informe.SIMBOLO_OD);
            data.COMENTARIOGEN = informe.COMENTARIOGEN;

            return data;
        }

        public static RequestInforme ConvertTo(InformeOITDomain informe) {
            var propertyNames = new List<string> {
                 "RISEXAMEN", "RISINFORME", "IDESTADO", "IDUSUARIO", "CODEXAMEN", "PRESTACION", "NUMRADIOGRAFIA", "RADIOGRAFIADIG", "NEGASTOCOPIA", "CALIDAD", "RADIOGRAFIANOR", "COMENTARIO", "PARENQUIMATOSA", "OPACIPRIMARIAC1"
                ,"OPACIPRIMARIAC2", "OPACISECUNDARIAC1", "OPACISECUNDARIAC2", "OPACIDADZONAD1", "OPACIDADZONAD2", "OPACIDADZONAD3", "OPACIDADZONAI1", "OPACIDADZONAI2", "OPACIDADZONAI3", "OPACPROFUSION", "OPACIDAGRANDE"
                ,"ANORMALPLEURAL", "PLACAPLEURAL", "PP_SITIOPERFIL", "PP_SITIOFRENTE","PP_SITIODIAGRAMA", "PP_SITIOOTRO", "PP_CALSIFICACIONPERFIL", "PP_CALSIFICACIONFRENTE", "PP_CALSIFICACIONDIAGRAMA", "PP_CALSIFICACIONOTRO"
                ,"PP_EXTENSIONPAREDPERFILOP", "PP_EXTENSIONPAREDPERFILSE", "PP_EXTENSIONPAREDFRENTEOP", "PP_EXTENSIONPAREDFRENTESE", "PP_ANCHODERECHAOP", "PP_ANCHODERECHASE", "PP_ANCHOIZQUIERDAOP", "PP_ANCHOIZQUIERDASE", "OBLITERACION"
                ,"ENGROSAPLERURALDIFUSO", "EPD_SITIOPERFIL", "EPD_SITIOFRENTE", "EPD_CALSIFICACIONPERFIL", "EPD_CALSIFICACIONFRENTE", "EPD_EXTENSIONPAREDPERFILOP", "EPD_EXTENSIONPAREDPERFILSE", "EPD_EXTENSIONPAREDFRENTEOP"
                ,"EPD_EXTENSIONPAREDFRENTESE", "EPD_ANCHODERECHAOP", "EPD_ANCHODERECHASE", "EPD_ANCHOIZQUIERDAOP", "EPD_ANCHOIZQUIERDASE", "OTRASANORMALIDADES", "SIMBOLO_AA", "SIMBOLO_AT", "SIMBOLO_AX", "SIMBOLO_BU", "SIMBOLO_CA"
                ,"SIMBOLO_CG", "SIMBOLO_CN", "SIMBOLO_CO", "SIMBOLO_CP", "SIMBOLO_CV", "SIMBOLO_DI", "SIMBOLO_EF", "SIMBOLO_EM", "SIMBOLO_ES", "SIMBOLO_FR", "SIMBOLO_HI", "SIMBOLO_HO", "SIMBOLO_ID", "SIMBOLO_IH", "SIMBOLO_KL"
                ,"SIMBOLO_ME", "SIMBOLO_PA", "SIMBOLO_PB", "SIMBOLO_PI", "SIMBOLO_PX", "SIMBOLO_RA", "SIMBOLO_RP", "SIMBOLO_TB", "SIMBOLO_OD", "COMENTARIOGEN"
            };

            var _out = new RequestInforme();

            Type type1 = typeof(InformeOITDomain);
            Type type2 = typeof(RequestInforme);

            foreach (PropertyInfo property in type1.GetProperties())
            {
                var value = property.GetValue(informe);

                PropertyInfo targetProperty = type2.GetProperty(property.Name);

                targetProperty.SetValue(_out, value.ToString());
            }

            return _out;
        }
    }
}