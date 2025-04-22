// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.JsonSaveAsignacion
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using MultiRisWeb.Data.Util;
using System;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
    public class JsonSaveAsignacion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["id_usuario"] == null)
                return;
            string empty = string.Empty;
            string[] strArray = ParamUtil.GetParamString((object)this.Request["id_asignacion"], string.Empty).Replace("'", "").Split(',');
            UsuarioDomain byId1 = UsuarioDataAccess.GetById(ParamUtil.GetParamLong((object)this.Request["id_radiologo"], 0L));
            UsuarioDomain byId2 = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
            string str;
            try
            {
                if (byId1.id_usuario > 0L)
                {
                    if (strArray.Length != 0)
                    {
                        for (int index = 0; index < strArray.Length; ++index)
                        {
                            if (strArray[index] != "")
                            {
                                RisExamenDomain byId3 = RisExamenDataAccess.GetById(Convert.ToInt64(strArray[index]));
                                byId3.usernameRadiologo = byId1.username;
                                byId3.idradiologo = Convert.ToInt32(byId1.id_usuario);
                                byId3.asignado = byId3.idradiologo;

                                RisExamenDataAccess.Save(byId3);
                                RisLogDataAccess.SaveReturn(new RisLogDomain()
                                {
                                    sistema = "MULTIRISWEB",
                                    observacion = "Estudio con ACC " + byId3.numeroacceso + " y id_ris_examen " + byId3.id_ris_examen.ToString() + " asignado a " + byId1.username + " con id_usuario " + byId1.id_usuario.ToString(),
                                    id_institucion = byId3.id_institucion,
                                    codexamen = byId3.codexamen,
                                    id_ris_examen = byId3.id_ris_examen,
                                    id_usuario = byId2.id_usuario
                                });
                            }
                        }
                        empty += "\"out\":\"ok\"";
                        str = empty + ",\"mensaje\":\"Estudios Asignados\"";
                    }
                    else
                    {
                        empty += "\"out\":\"err\"";
                        str = empty + ",\"mensaje\":\"Estudios no seleccionados\"";
                    }
                }
                else
                {
                    empty += "\"out\":\"err\"";
                    str = empty + ",\"mensaje\":\"Radiólogo no Seleccionado\"";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                str = empty + "\"out\":\"err\"" + ",\"mensaje\":\"Intente nuevamente\"";
            }
            string s = "{" + str + "}";
            this.Response.Clear();
            this.Response.ContentType = "text/plain";
            this.Response.Write(s);
        }
    }
}
