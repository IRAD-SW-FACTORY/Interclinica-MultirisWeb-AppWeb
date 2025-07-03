// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Data.Util.MeddreamsUtil
// Assembly: MultiRisWeb.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 154C708F-6ECF-41A7-A55F-B49957B942BE
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.Data.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MultiRisWeb.Data.Util
{
    public class MeddreamsUtil
    {
        public string generarToken(string cod_examen, int id_institucion)
        {
            string str = "";
            string s = "";
            try
            {
                InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
                MeddreamsDomain byIdInstitucion = MeddreamsDataAccess.GetByIdInstitucion(id_institucion);
                string url = byIdInstitucion.url;
                string method = byIdInstitucion.method;
                s = byIdInstitucion.json;
                s = s.Replace("#CODEXAMEN#", cod_examen);
                s = s.Replace("#AETITLE#", byId.aetitle);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                httpWebRequest.Accept = "text/plain";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = method;
                httpWebRequest.Headers.Add("Authorization", "No Auth");
                byte[] bytes = new ASCIIEncoding().GetBytes(s);
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                str = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd().ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
                ApiErrorDataAccess.Save(new ApiErrorDomain()
                {
                    staktrace = "MEDDREAMS - " + ex.ToString(),
                    id_institucion = id_institucion
                });
            }
            if (str != "")
                ApiErrorDataAccess.Save(new ApiErrorDomain()
                {
                    staktrace = "MEDDREAMS OK - " + s + " TOKEN - " + str,
                    id_institucion = id_institucion
                });
            return str;
        }

        public string generarStringVisores(
          string codexamen,
          int id_institucion,
          bool estudio_actual,
          long id_usuario = 0)
        {
            string str = string.Empty;
            IList<VisorDomain> allForState = VisorDataAccess.GetAllForState(1);
            InstitucionDomain byId = InstitucionDataAccess.GetById(Convert.ToInt32(id_institucion));
            RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen((long)id_institucion, byId.aetitle, codexamen);           
            bool flag = true;//StudyDataAccess.GetByStudyInstanceUID(codexamen).StudyInstanceUid != "";
            if (flag)
            {
                foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>)allForState)
                {
                    InstitucionVisorDomain institucionAndVisor = InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId.id_institucion, visorDomain.id_visor);
                    if (flag && institucionAndVisor.id_institucion_visor > 0)
                    {
                        if (visorDomain.id_visor == 2)
                        {
                            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
                            MeddreamsDataAccess.GetByIdInstitucion(institucionAndVisor.id_institucion);
                            string cod_examen = codexamen;
                            int idInstitucion = byId.id_institucion;
                            //string newValue = meddreamsUtil.generarToken(cod_examen, idInstitucion);
                            //str = str + "&nbsp;<a href='" + institucionAndVisor.url.Replace("#TOKEN#", newValue) + "' target='_blank' onclick='LogMeddream(" + institucionCodExamen.id_ris_examen + ");' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "' ></a>";
                            str = str + "&nbsp;<a href='" + institucionAndVisor.url + codexamen + "&storage="+ byId.aetitle +"&add=true" + "' target='_blank' onclick='LogMeddream(" + institucionCodExamen.id_ris_examen + ");' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "' ></a>";
                        }
                        else if (visorDomain.id_visor != 6)
                            str = str + "&nbsp;<a href='" + institucionAndVisor.url.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", codexamen).Replace("#modalidad#", institucionCodExamen.modalidad) + "' target='_blank' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "'  style='max-width:25px !important' ></a>";
                    }
                }
            }
            else
            {
                foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>)allForState)
                {
                    InstitucionVisorDomain institucionAndVisor = InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId.id_institucion, visorDomain.id_visor);
                    if (byId.flagContingencia == 1)
                    {
                        if (visorDomain.id_visor == 6)
                        {
                            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
                            MeddreamsDataAccess.GetByIdInstitucion(institucionAndVisor.id_institucion);
                            string cod_examen = codexamen;
                            int idInstitucion = byId.id_institucion;
                            //meddreamsUtil.generarToken(cod_examen, idInstitucion);
                            str = str + "&nbsp;<a href='" + institucionAndVisor.url.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", codexamen).Replace("#modalidad#", institucionCodExamen.modalidad) + "' target='_blank' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "'  style='max-width:25px !important' ></a>";
                        }
                    }
                    else
                    {
                        str = str + "&nbsp;<a href='#' title='Importar' onclick='ImportStudy(&apos;" + codexamen + "&apos;, " + id_institucion.ToString() + ");'><img class='imgvisor' src='../icon/importar.png'  style='max-width:25px !important' ></a>";
                        break;
                    }
                }
            }
            return str;
        }

        public string generarStringVisoresSinImportar(
          string codexamen,
          int id_institucion,
          bool estudio_actual,
          long id_usuario = 0)
        {
            string str = string.Empty;
            IList<VisorDomain> allForState = VisorDataAccess.GetAllForState(1);
            InstitucionDomain byId = InstitucionDataAccess.GetById(Convert.ToInt32(id_institucion));
            
            RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen((long)id_institucion, byId.aetitle, codexamen);
            bool flag = true;//StudyDataAccess.GetByStudyInstanceUID(codexamen).StudyInstanceUid != "";
            if (flag)
            {
                foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>)allForState)
                {
                    InstitucionVisorDomain institucionAndVisor = InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId.id_institucion, visorDomain.id_visor);
                    if (flag && institucionAndVisor.id_institucion_visor > 0)
                    {
                        if (visorDomain.id_visor == 2)
                        {
                            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
                            MeddreamsDataAccess.GetByIdInstitucion(institucionAndVisor.id_institucion);
                            string cod_examen = codexamen;
                            int idInstitucion = byId.id_institucion;
                            //string newValue = meddreamsUtil.generarToken(cod_examen, idInstitucion);
                            //str = str + "&nbsp;<a href='" + institucionAndVisor.url.Replace("#TOKEN#", newValue) + "' target='_blank' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "' ></a>";
                            str = str + "&nbsp;<a href='" + institucionAndVisor.url + codexamen + "&storage=" + byId.aetitle + "&add=true" + "' target='_blank' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "' ></a>";
                          
                        }
                        else if (visorDomain.id_visor != 6)
                            str = str + "&nbsp;<a href='" + institucionAndVisor.url.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", codexamen).Replace("#modalidad#", institucionCodExamen.modalidad) + "' target='_blank' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "' ></a>";
                    }
                }
            }
            else
            {
                foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>)allForState)
                {
                    InstitucionVisorDomain institucionAndVisor = InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId.id_institucion, visorDomain.id_visor);
                    if (byId.flagContingencia == 1)
                    {
                        if (visorDomain.id_visor == 6)
                        {
                            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
                            MeddreamsDataAccess.GetByIdInstitucion(institucionAndVisor.id_institucion);
                            string cod_examen = codexamen;
                            int idInstitucion = byId.id_institucion;
                            //meddreamsUtil.generarToken(cod_examen, idInstitucion);
                            str = str + "&nbsp;<a href='" + institucionAndVisor.url.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", codexamen).Replace("#modalidad#", institucionCodExamen.modalidad) + "' target='_blank' title='Ver con " + visorDomain.nombre + "' ><img class='imgvisor' src='../icon/" + visorDomain.icono + "'  style='max-width:25px !important' ></a>";
                        }
                    }
                    else
                    {
                        str = str + "&nbsp;<a href='#' title='Importar' onclick='ImportStudy(&apos;" + codexamen + "&apos;, " + id_institucion.ToString() + ");'><img class='imgvisor' src='../icon/importar.png'  style='max-width:25px !important' ></a>";
                        break;
                    }
                }
            }
            return str;
        }

        public string generarStringMeddreams(
          string cod_examen_actual,
          string cod_examen_anterior,
          int id_institucion,
          bool estudio_actual)
        {
            string str = "";
            IList<VisorDomain> allForState = VisorDataAccess.GetAllForState(1);
            InstitucionDomain byId = InstitucionDataAccess.GetById(Convert.ToInt32(id_institucion));
            RisExamenDomain institucionCodExamen = RisExamenDataAccess.GetByInstitucionCodExamen((long)id_institucion, byId.aetitle, cod_examen_actual); 
            RisExamenDataAccess.GetByInstitucionCodExamen((long)id_institucion, byId.aetitle, cod_examen_anterior);
            foreach (VisorDomain visorDomain in (IEnumerable<VisorDomain>)allForState)
            {
                InstitucionVisorDomain institucionAndVisor = InstitucionVisorDataAccess.GetAllForInstitucionAndVisor(byId.id_institucion, visorDomain.id_visor);
                MeddreamsDomain byIdInstitucion = MeddreamsDataAccess.GetByIdInstitucion(institucionAndVisor.id_institucion);
                if (byIdInstitucion.id_meddreams > 0 && byIdInstitucion.id_estado == 1 && visorDomain.id_visor == 2)
                {
                    //string newValue = new MeddreamsUtil().generarToken(institucionCodExamen.codexamen, byId.id_institucion);
                    //str = institucionAndVisor.url.Replace("#TOKEN#", newValue);
                   
                    str = institucionAndVisor.url+ cod_examen_actual + "&storage=" + byId.aetitle + "&add=true";
                }
            }
            return str;
        }

        public string obtenerComandoRegeditMeddreams(int id)
        {
            string str = "";
            switch (id)
            {
                case 1:
                    str = "#ABRIRMONITOR1#";
                    break;
                case 2:
                    str = "#ABRIRMONITOR2#";
                    break;
            }
            return str;
        }

        public string obtenerComandoCierreMeddreams() => "console.log('meddreams://#CERRARMONITOR1'); window.open('meddreams://#CERRARMONITOR1');";
    }
}
