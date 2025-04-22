// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Examen.JsonGetDropdown
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace MultiRisWeb.Web.Examen
{
  public class JsonGetDropdown : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Session["id_usuario"] == null)
        return;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      UsuarioDomain byId1 = UsuarioDataAccess.GetById(Convert.ToInt64(this.Session["id_usuario"].ToString()));
      PerfilDomain byId2 = PerfilDataAccess.GetById(byId1.id_perfil);
      DataTable dataTable = new DataTable();
      IList<UsuarioDomain> usuarioDomainList = (IList<UsuarioDomain>) new List<UsuarioDomain>();
      if (byId2.id_perfil_visualizacion == 1)
      {
        foreach (UsuarioDomain usuarioDomain in (IEnumerable<UsuarioDomain>) UsuarioDataAccess.GetAll())
        {
          if (usuarioDomain.estado == 1 && (usuarioDomain.id_perfil == 3 || usuarioDomain.id_perfil == 7 || usuarioDomain.id_perfil == 6 || usuarioDomain.id_perfil == 10))
            usuarioDomainList.Add(usuarioDomain);
        }
      }
      else if (byId2.id_perfil_visualizacion == 2)
        UsuarioDataAccess.GetTableByUsername("Amis");
      else if (byId2.id_perfil_visualizacion == 3)
        UsuarioDataAccess.GetLitByUsernameAndIdUsuario("Amis", byId1.id_usuario);
      else if (byId2.id_perfil_visualizacion == 4)
        UsuarioDataAccess.GetTableByUsername(byId1.username);
      string str1 = empty2 + "<select name='ddlUsuarioAsignacion' id='ddlUsuarioAsignacion' class='form-control' style='color: white!important;'><option value='0'>--Seleccione--</option>";
      foreach (UsuarioDomain usuarioDomain in (IEnumerable<UsuarioDomain>) usuarioDomainList)
        str1 = str1 + "<option value='" + usuarioDomain.id_usuario.ToString() + "'>" + usuarioDomain.nombre_completo + "</option>";
      string str2 = str1 + "</select>";
      int num = byId2.asignar ? 1 : 0;
      string s = "{" + (empty1 + "\"out\":\"ok\"" + ",\"usuario_asignar\":\"" + str2 + "\"" + ",\"asignar\":\"" + num.ToString() + "\"") + "}";
      this.Response.Clear();
      this.Response.ContentType = "text/plain";
      this.Response.Write(s);
    }
  }
}
