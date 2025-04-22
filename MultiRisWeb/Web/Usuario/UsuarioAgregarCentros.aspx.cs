// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.Web.Usuario.UsuarioAgregarCentros
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Data.DataAccess;
using MultiRisWeb.Data.Domain;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MultiRisWeb.Web.Usuario
{
  public class UsuarioAgregarCentros : Page
  {
    protected HtmlForm form1;
    protected Button btnAgregarUsuarioCentro;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!(this.Request.UrlReferrer == (Uri) null))
        return;
      this.Response.Redirect("../../Default.aspx");
    }

    protected void btnAgregarUsuarioCentro_Click(object sender, EventArgs e)
    {
      IList<UsuarioDomain> all1 = UsuarioDataAccess.GetAll();
      IList<InstitucionDomain> all2 = InstitucionDataAccess.GetAll();
      foreach (UsuarioDomain usuarioDomain in (IEnumerable<UsuarioDomain>) all1)
      {
        foreach (InstitucionDomain institucionDomain in (IEnumerable<InstitucionDomain>) all2)
        {
          UsuarioInstitucionDomain byUserAndInst = UsuarioInstitucionDataAccess.GetByUserAndInst(usuarioDomain.id_usuario, institucionDomain.id_institucion);
          if (byUserAndInst.id_usuario_institucion == 0L)
          {
            byUserAndInst.id_tipo_firma = 3;
            byUserAndInst.id_usuario = usuarioDomain.id_usuario;
            byUserAndInst.id_institucion = institucionDomain.id_institucion;
            UsuarioInstitucionDataAccess.Save(byUserAndInst);
          }
        }
      }
    }
  }
}
