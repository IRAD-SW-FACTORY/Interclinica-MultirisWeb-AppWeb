using MultiRisWeb.ConsumirServicios;
using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Examen
{
    public partial class InformarExamenPrevios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var idPaciente = Request.QueryString["idPaciente"];
                var idIdInstitucion = Request.QueryString["idInstitucion"];
                var codExamen = Request.QueryString["codExamen"];

                hddIdPaciente.Value = idPaciente;
                hddCodExamen.Value = codExamen;
                hddIdInstitucion.Value = idIdInstitucion;
            }
        }
        [WebMethod]
        public static string ObtenerInformesPrevios(string id_paciente, int id_institucion, string codexamen)
        {
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            DataTable dataTable = new DataTable();
            string urlInforme = InstitucionDataAccess.getURLInforme();
            string str1 = "";
            if (byId.id_institucion > 0)
            {
                InstitucionDatosDomain methodAndInstitucion = InstitucionDatosDataAccess.GetByIdMethodAndInstitucion(9, byId.id_institucion);
                if (byId.id_tipo_conexion == 1)
                    dataTable = InformarExamenPrevios.normalizaDataTableEstudiosRelacionados(new ConsumirApi().ApiObtenerDataTable(methodAndInstitucion.url, methodAndInstitucion.metodo, InformarExamenPrevios.jsonEstudiosRelacionados(id_paciente), id_institucion), id_institucion, id_paciente, codexamen);
                else if (byId.id_tipo_conexion == 2)
                {
                    ConsumirWS consumirWs = new ConsumirWS();
                    dataTable = InformarExamenPrevios.normalizaDataTableEstudiosRelacionados(ConsumirWS.GetEstudiosRelacionados(id_paciente, id_institucion), id_institucion, id_paciente, codexamen);
                }
            }
            if (dataTable.Rows.Count > 0)
            {
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = "Fecha_examen DESC";
                DataTable table = defaultView.ToTable();
                string str2 = str1 + "<table class=\"table_informes_previos\">";
                int num = 0;
                foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
                {
                    ++num;
                    string str3 = "btn_identificador" + num.ToString();
                    if (!(row["descripcion"].ToString() == "ESTUDIO SOLO CON IMAGENES"))
                    {
                        str2 += "<tr>";
                        str2 += "<td>";
                        string codeExamen = row["informe"].ToString().Split('=')[1].Split('&')[0];
                        int examenConteo = RisExamenDataAccess.GetExamenConteo(codeExamen);
                        string examenAetitle = RisExamenDataAccess.GetExamenAetitle(codeExamen);
                        string informeIdInforme = RisInformeDataAccess.GetInformeIdInforme(codeExamen);
                        if (examenConteo > 0)
                            str2 = str2 + "<button style=\"min-width:100% !important\" id=\"" + str3 + "\" class=\"btn btn-verde\" onclick=\"cargarInforme('" + urlInforme.Replace("#IDINFORME#", informeIdInforme).Replace("#AETITLE#", examenAetitle) + "'); return false;\">" + row["descripcion"].ToString().ToUpper() + "</button>";
                        else
                            str2 = str2 + "<button  style=\"min-width:100% !important\" id=\"" + str3 + "\" class=\"btn btn-verde\" onclick=\"cargarInforme('" + row["informe"]?.ToString() + "', '" + str3 + "'); return false;\">" + row["descripcion"].ToString().ToUpper() + "</button>";
                        str2 += "</td>";
                        str2 += "</tr>";
                    }
                }
                str1 = str2 + "</table>";
            }
            return str1;
        }
        private static DataTable normalizaDataTableEstudiosRelacionados(DataTable dtOrigen, int id_institucion, string id_paciente, string codexamen)
        {
            InstitucionDomain byId = InstitucionDataAccess.GetById(id_institucion);
            DataTable dataTable = new DataTable();
            int num = 0;
            dataTable.Columns.Add("fecha_examen");
            dataTable.Columns.Add("descripcion");
            dataTable.Columns.Add("modalidad");
            dataTable.Columns.Add("informe");
            dataTable.Columns.Add("descargar_examen");
            dataTable.Columns.Add("visualizadores");
            dataTable.Columns.Add(nameof(id_institucion));
            dataTable.Columns.Add(nameof(id_paciente));
            dataTable.Columns.Add("identificador");
            MeddreamsUtil meddreamsUtil = new MeddreamsUtil();
            foreach (DataRow row1 in (InternalDataCollectionBase)dtOrigen.Rows)
            {
                DataRow row2 = dataTable.NewRow();
                ++num;
                string str = "btn_identificador" + num.ToString();
                row2["fecha_examen"] = row1["fecha_examen"];
                row2["descripcion"] = (object)row1["descripcion"].ToString().ToUpper();
                row2["modalidad"] = row1["modalidad"];
                row2["informe"] = (object)byId.url_informe.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", row1[nameof(codexamen)].ToString()).Replace("#IDINFORME#", row1["idinforme"].ToString());
                row2["descargar_examen"] = (object)byId.url_descarga.Replace("#AETITLE#", byId.aetitle).Replace("#CODEXAMEN#", row1[nameof(codexamen)].ToString());
                row2[nameof(id_institucion)] = (object)id_institucion;
                row2[nameof(id_paciente)] = (object)id_paciente;
                row2["identificador"] = (object)str;
                row2["visualizadores"] = "";//(object)meddreamsUtil.generarStringVisores(row1[nameof(codexamen)].ToString(), byId.id_institucion, false, Convert.ToInt64(HttpContext.Current.Session["id_usuario"].ToString()));
                dataTable.Rows.Add(row2);
            }
            return dataTable;
        }
        private static string jsonEstudiosRelacionados(string id_paciente) => "{\"id_paciente\":\"" + id_paciente + "\"}";
    }
}