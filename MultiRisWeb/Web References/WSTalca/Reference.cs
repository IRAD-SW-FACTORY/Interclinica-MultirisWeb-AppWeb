// Decompiled with JetBrains decompiler
// Type: MultiRisWeb.WSTalca.ServiceMultiris
// Assembly: MultiRisWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD4E84AD-C410-4DA9-A64F-45EBA0DF4441
// Assembly location: D:\Descompilacion7\Multiris\Compilado\bin\MultiRisWeb.dll

using MultiRisWeb.Properties;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace MultiRisWeb.WSTalca
{
  [GeneratedCode("System.Web.Services", "4.8.9032.0")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [WebServiceBinding(Name = "ServiceMultirisSoap", Namespace = "http://tempuri.org/")]
  public class ServiceMultiris : SoapHttpClientProtocol
  {
    private SendOrPostCallback GetcomentarioTMOperationCompleted;
    private SendOrPostCallback GetDocumentosExamenOperationCompleted;
    private SendOrPostCallback GetEstudiosRelacionadosOperationCompleted;
    private SendOrPostCallback InsertInformeOperationCompleted;
    private SendOrPostCallback InsertarInformePDFOperationCompleted;
    private SendOrPostCallback InsertInformeOITOperationCompleted;
    private SendOrPostCallback InsertInformeDatoOperationCompleted;
    private SendOrPostCallback InsertInformePrestacionOperationCompleted;
    private SendOrPostCallback GetComentariosOperationCompleted;
    private SendOrPostCallback SaveComentarioOperationCompleted;
    private SendOrPostCallback SolicitudExamenOperationCompleted;
    private SendOrPostCallback UpdateStateExamenOperationCompleted;
    private SendOrPostCallback UpdateAddendumOperationCompleted;
    private SendOrPostCallback SolicitarimagenesOperationCompleted;
    private SendOrPostCallback InsertarExamenCabDetalleOperationCompleted;
    private bool useDefaultCredentialsSetExplicitly;

    public ServiceMultiris()
    {
      this.Url = Settings.Default.MultiRisWeb_WSTalca_ServiceMultiris;
      if (this.IsLocalFileSystemWebService(this.Url))
      {
        this.UseDefaultCredentials = true;
        this.useDefaultCredentialsSetExplicitly = false;
      }
      else
        this.useDefaultCredentialsSetExplicitly = true;
    }

    public new string Url
    {
      get => base.Url;
      set
      {
        if (this.IsLocalFileSystemWebService(base.Url) && !this.useDefaultCredentialsSetExplicitly && !this.IsLocalFileSystemWebService(value))
          base.UseDefaultCredentials = false;
        base.Url = value;
      }
    }

    public new bool UseDefaultCredentials
    {
      get => base.UseDefaultCredentials;
      set
      {
        base.UseDefaultCredentials = value;
        this.useDefaultCredentialsSetExplicitly = true;
      }
    }

    public event GetcomentarioTMCompletedEventHandler GetcomentarioTMCompleted;

    public event GetDocumentosExamenCompletedEventHandler GetDocumentosExamenCompleted;

    public event GetEstudiosRelacionadosCompletedEventHandler GetEstudiosRelacionadosCompleted;

    public event InsertInformeCompletedEventHandler InsertInformeCompleted;

    public event InsertarInformePDFCompletedEventHandler InsertarInformePDFCompleted;

    public event InsertInformeOITCompletedEventHandler InsertInformeOITCompleted;

    public event InsertInformeDatoCompletedEventHandler InsertInformeDatoCompleted;

    public event InsertInformePrestacionCompletedEventHandler InsertInformePrestacionCompleted;

    public event GetComentariosCompletedEventHandler GetComentariosCompleted;

    public event SaveComentarioCompletedEventHandler SaveComentarioCompleted;

    public event SolicitudExamenCompletedEventHandler SolicitudExamenCompleted;

    public event UpdateStateExamenCompletedEventHandler UpdateStateExamenCompleted;

    public event UpdateAddendumCompletedEventHandler UpdateAddendumCompleted;

    public event SolicitarimagenesCompletedEventHandler SolicitarimagenesCompleted;

    public event InsertarExamenCabDetalleCompletedEventHandler InsertarExamenCabDetalleCompleted;

    [SoapDocumentMethod("http://tempuri.org/GetcomentarioTM", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public string GetcomentarioTM(CredencialesParameters credenciales, string codexamen) => (string) this.Invoke(nameof (GetcomentarioTM), new object[2]
    {
      (object) credenciales,
      (object) codexamen
    })[0];

    public void GetcomentarioTMAsync(CredencialesParameters credenciales, string codexamen) => this.GetcomentarioTMAsync(credenciales, codexamen, (object) null);

    public void GetcomentarioTMAsync(
      CredencialesParameters credenciales,
      string codexamen,
      object userState)
    {
      if (this.GetcomentarioTMOperationCompleted == null)
        this.GetcomentarioTMOperationCompleted = new SendOrPostCallback(this.OnGetcomentarioTMOperationCompleted);
      this.InvokeAsync("GetcomentarioTM", new object[2]
      {
        (object) credenciales,
        (object) codexamen
      }, this.GetcomentarioTMOperationCompleted, userState);
    }

    private void OnGetcomentarioTMOperationCompleted(object arg)
    {
      if (this.GetcomentarioTMCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetcomentarioTMCompleted((object) this, new GetcomentarioTMCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/GetDocumentosExamen", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public DataTable GetDocumentosExamen(
      CredencialesParameters credenciales,
      DocumentosParameters documentosParameters)
    {
      return (DataTable) this.Invoke(nameof (GetDocumentosExamen), new object[2]
      {
        (object) credenciales,
        (object) documentosParameters
      })[0];
    }

    public void GetDocumentosExamenAsync(
      CredencialesParameters credenciales,
      DocumentosParameters documentosParameters)
    {
      this.GetDocumentosExamenAsync(credenciales, documentosParameters, (object) null);
    }

    public void GetDocumentosExamenAsync(
      CredencialesParameters credenciales,
      DocumentosParameters documentosParameters,
      object userState)
    {
      if (this.GetDocumentosExamenOperationCompleted == null)
        this.GetDocumentosExamenOperationCompleted = new SendOrPostCallback(this.OnGetDocumentosExamenOperationCompleted);
      this.InvokeAsync("GetDocumentosExamen", new object[2]
      {
        (object) credenciales,
        (object) documentosParameters
      }, this.GetDocumentosExamenOperationCompleted, userState);
    }

    private void OnGetDocumentosExamenOperationCompleted(object arg)
    {
      if (this.GetDocumentosExamenCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetDocumentosExamenCompleted((object) this, new GetDocumentosExamenCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/GetEstudiosRelacionados", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public DataTable GetEstudiosRelacionados(
      CredencialesParameters credenciales,
      string id_paciente)
    {
      return (DataTable) this.Invoke(nameof (GetEstudiosRelacionados), new object[2]
      {
        (object) credenciales,
        (object) id_paciente
      })[0];
    }

    public void GetEstudiosRelacionadosAsync(
      CredencialesParameters credenciales,
      string id_paciente)
    {
      this.GetEstudiosRelacionadosAsync(credenciales, id_paciente, (object) null);
    }

    public void GetEstudiosRelacionadosAsync(
      CredencialesParameters credenciales,
      string id_paciente,
      object userState)
    {
      if (this.GetEstudiosRelacionadosOperationCompleted == null)
        this.GetEstudiosRelacionadosOperationCompleted = new SendOrPostCallback(this.OnGetEstudiosRelacionadosOperationCompleted);
      this.InvokeAsync("GetEstudiosRelacionados", new object[2]
      {
        (object) credenciales,
        (object) id_paciente
      }, this.GetEstudiosRelacionadosOperationCompleted, userState);
    }

    private void OnGetEstudiosRelacionadosOperationCompleted(object arg)
    {
      if (this.GetEstudiosRelacionadosCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetEstudiosRelacionadosCompleted((object) this, new GetEstudiosRelacionadosCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/InsertInforme", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public long InsertInforme(
      CredencialesParameters credenciales,
      InformeParameters InformeParameters)
    {
      return (long) this.Invoke(nameof (InsertInforme), new object[2]
      {
        (object) credenciales,
        (object) InformeParameters
      })[0];
    }

    public void InsertInformeAsync(
      CredencialesParameters credenciales,
      InformeParameters InformeParameters)
    {
      this.InsertInformeAsync(credenciales, InformeParameters, (object) null);
    }

    public void InsertInformeAsync(
      CredencialesParameters credenciales,
      InformeParameters InformeParameters,
      object userState)
    {
      if (this.InsertInformeOperationCompleted == null)
        this.InsertInformeOperationCompleted = new SendOrPostCallback(this.OnInsertInformeOperationCompleted);
      this.InvokeAsync("InsertInforme", new object[2]
      {
        (object) credenciales,
        (object) InformeParameters
      }, this.InsertInformeOperationCompleted, userState);
    }

    private void OnInsertInformeOperationCompleted(object arg)
    {
      if (this.InsertInformeCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.InsertInformeCompleted((object) this, new InsertInformeCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/InsertarInformePDF", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public Respuesta InsertarInformePDF(
      CredencialesParameters credenciales,
      InformePDFParameters[] informePDF)
    {
      return (Respuesta) this.Invoke(nameof (InsertarInformePDF), new object[2]
      {
        (object) credenciales,
        (object) informePDF
      })[0];
    }

    public void InsertarInformePDFAsync(
      CredencialesParameters credenciales,
      InformePDFParameters[] informePDF)
    {
      this.InsertarInformePDFAsync(credenciales, informePDF, (object) null);
    }

    public void InsertarInformePDFAsync(
      CredencialesParameters credenciales,
      InformePDFParameters[] informePDF,
      object userState)
    {
      if (this.InsertarInformePDFOperationCompleted == null)
        this.InsertarInformePDFOperationCompleted = new SendOrPostCallback(this.OnInsertarInformePDFOperationCompleted);
      this.InvokeAsync("InsertarInformePDF", new object[2]
      {
        (object) credenciales,
        (object) informePDF
      }, this.InsertarInformePDFOperationCompleted, userState);
    }

    private void OnInsertarInformePDFOperationCompleted(object arg)
    {
      if (this.InsertarInformePDFCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.InsertarInformePDFCompleted((object) this, new InsertarInformePDFCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/InsertInformeOIT", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public long InsertInformeOIT(
      CredencialesParameters credenciales,
      InformeOITParameters InformeOITParameters)
    {
      return (long) this.Invoke(nameof (InsertInformeOIT), new object[2]
      {
        (object) credenciales,
        (object) InformeOITParameters
      })[0];
    }

    public void InsertInformeOITAsync(
      CredencialesParameters credenciales,
      InformeOITParameters InformeOITParameters)
    {
      this.InsertInformeOITAsync(credenciales, InformeOITParameters, (object) null);
    }

    public void InsertInformeOITAsync(
      CredencialesParameters credenciales,
      InformeOITParameters InformeOITParameters,
      object userState)
    {
      if (this.InsertInformeOITOperationCompleted == null)
        this.InsertInformeOITOperationCompleted = new SendOrPostCallback(this.OnInsertInformeOITOperationCompleted);
      this.InvokeAsync("InsertInformeOIT", new object[2]
      {
        (object) credenciales,
        (object) InformeOITParameters
      }, this.InsertInformeOITOperationCompleted, userState);
    }

    private void OnInsertInformeOITOperationCompleted(object arg)
    {
      if (this.InsertInformeOITCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.InsertInformeOITCompleted((object) this, new InsertInformeOITCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/InsertInformeDato", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public long InsertInformeDato(
      CredencialesParameters credenciales,
      InformeDatoParameters InformeDatoParameters)
    {
      return (long) this.Invoke(nameof (InsertInformeDato), new object[2]
      {
        (object) credenciales,
        (object) InformeDatoParameters
      })[0];
    }

    public void InsertInformeDatoAsync(
      CredencialesParameters credenciales,
      InformeDatoParameters InformeDatoParameters)
    {
      this.InsertInformeDatoAsync(credenciales, InformeDatoParameters, (object) null);
    }

    public void InsertInformeDatoAsync(
      CredencialesParameters credenciales,
      InformeDatoParameters InformeDatoParameters,
      object userState)
    {
      if (this.InsertInformeDatoOperationCompleted == null)
        this.InsertInformeDatoOperationCompleted = new SendOrPostCallback(this.OnInsertInformeDatoOperationCompleted);
      this.InvokeAsync("InsertInformeDato", new object[2]
      {
        (object) credenciales,
        (object) InformeDatoParameters
      }, this.InsertInformeDatoOperationCompleted, userState);
    }

    private void OnInsertInformeDatoOperationCompleted(object arg)
    {
      if (this.InsertInformeDatoCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.InsertInformeDatoCompleted((object) this, new InsertInformeDatoCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/InsertInformePrestacion", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public long InsertInformePrestacion(
      CredencialesParameters credenciales,
      InformePrestacionParameters informePrestacionParameters)
    {
      return (long) this.Invoke(nameof (InsertInformePrestacion), new object[2]
      {
        (object) credenciales,
        (object) informePrestacionParameters
      })[0];
    }

    public void InsertInformePrestacionAsync(
      CredencialesParameters credenciales,
      InformePrestacionParameters informePrestacionParameters)
    {
      this.InsertInformePrestacionAsync(credenciales, informePrestacionParameters, (object) null);
    }

    public void InsertInformePrestacionAsync(
      CredencialesParameters credenciales,
      InformePrestacionParameters informePrestacionParameters,
      object userState)
    {
      if (this.InsertInformePrestacionOperationCompleted == null)
        this.InsertInformePrestacionOperationCompleted = new SendOrPostCallback(this.OnInsertInformePrestacionOperationCompleted);
      this.InvokeAsync("InsertInformePrestacion", new object[2]
      {
        (object) credenciales,
        (object) informePrestacionParameters
      }, this.InsertInformePrestacionOperationCompleted, userState);
    }

    private void OnInsertInformePrestacionOperationCompleted(object arg)
    {
      if (this.InsertInformePrestacionCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.InsertInformePrestacionCompleted((object) this, new InsertInformePrestacionCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/GetComentarios", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public DataTable GetComentarios(
      CredencialesParameters credenciales,
      DocumentosParameters documentosParameters)
    {
      return (DataTable) this.Invoke(nameof (GetComentarios), new object[2]
      {
        (object) credenciales,
        (object) documentosParameters
      })[0];
    }

    public void GetComentariosAsync(
      CredencialesParameters credenciales,
      DocumentosParameters documentosParameters)
    {
      this.GetComentariosAsync(credenciales, documentosParameters, (object) null);
    }

    public void GetComentariosAsync(
      CredencialesParameters credenciales,
      DocumentosParameters documentosParameters,
      object userState)
    {
      if (this.GetComentariosOperationCompleted == null)
        this.GetComentariosOperationCompleted = new SendOrPostCallback(this.OnGetComentariosOperationCompleted);
      this.InvokeAsync("GetComentarios", new object[2]
      {
        (object) credenciales,
        (object) documentosParameters
      }, this.GetComentariosOperationCompleted, userState);
    }

    private void OnGetComentariosOperationCompleted(object arg)
    {
      if (this.GetComentariosCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.GetComentariosCompleted((object) this, new GetComentariosCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/SaveComentario", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public long SaveComentario(
      CredencialesParameters credenciales,
      ComentariosParameters comentarios)
    {
      return (long) this.Invoke(nameof (SaveComentario), new object[2]
      {
        (object) credenciales,
        (object) comentarios
      })[0];
    }

    public void SaveComentarioAsync(
      CredencialesParameters credenciales,
      ComentariosParameters comentarios)
    {
      this.SaveComentarioAsync(credenciales, comentarios, (object) null);
    }

    public void SaveComentarioAsync(
      CredencialesParameters credenciales,
      ComentariosParameters comentarios,
      object userState)
    {
      if (this.SaveComentarioOperationCompleted == null)
        this.SaveComentarioOperationCompleted = new SendOrPostCallback(this.OnSaveComentarioOperationCompleted);
      this.InvokeAsync("SaveComentario", new object[2]
      {
        (object) credenciales,
        (object) comentarios
      }, this.SaveComentarioOperationCompleted, userState);
    }

    private void OnSaveComentarioOperationCompleted(object arg)
    {
      if (this.SaveComentarioCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.SaveComentarioCompleted((object) this, new SaveComentarioCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/SolicitudExamen", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public bool SolicitudExamen(
      CredencialesParameters credenciales,
      string codexamen,
      string destino)
    {
      return (bool) this.Invoke(nameof (SolicitudExamen), new object[3]
      {
        (object) credenciales,
        (object) codexamen,
        (object) destino
      })[0];
    }

    public void SolicitudExamenAsync(
      CredencialesParameters credenciales,
      string codexamen,
      string destino)
    {
      this.SolicitudExamenAsync(credenciales, codexamen, destino, (object) null);
    }

    public void SolicitudExamenAsync(
      CredencialesParameters credenciales,
      string codexamen,
      string destino,
      object userState)
    {
      if (this.SolicitudExamenOperationCompleted == null)
        this.SolicitudExamenOperationCompleted = new SendOrPostCallback(this.OnSolicitudExamenOperationCompleted);
      this.InvokeAsync("SolicitudExamen", new object[3]
      {
        (object) credenciales,
        (object) codexamen,
        (object) destino
      }, this.SolicitudExamenOperationCompleted, userState);
    }

    private void OnSolicitudExamenOperationCompleted(object arg)
    {
      if (this.SolicitudExamenCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.SolicitudExamenCompleted((object) this, new SolicitudExamenCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/UpdateStateExamen", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public long UpdateStateExamen(DatosExamenParameters ExamenParameters) => (long) this.Invoke(nameof (UpdateStateExamen), new object[1]
    {
      (object) ExamenParameters
    })[0];

    public void UpdateStateExamenAsync(DatosExamenParameters ExamenParameters) => this.UpdateStateExamenAsync(ExamenParameters, (object) null);

    public void UpdateStateExamenAsync(DatosExamenParameters ExamenParameters, object userState)
    {
      if (this.UpdateStateExamenOperationCompleted == null)
        this.UpdateStateExamenOperationCompleted = new SendOrPostCallback(this.OnUpdateStateExamenOperationCompleted);
      this.InvokeAsync("UpdateStateExamen", new object[1]
      {
        (object) ExamenParameters
      }, this.UpdateStateExamenOperationCompleted, userState);
    }

    private void OnUpdateStateExamenOperationCompleted(object arg)
    {
      if (this.UpdateStateExamenCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.UpdateStateExamenCompleted((object) this, new UpdateStateExamenCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/UpdateAddendum", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public long UpdateAddendum(CredencialesParameters credenciales, AddendumParameters RisAddendum) => (long) this.Invoke(nameof (UpdateAddendum), new object[2]
    {
      (object) credenciales,
      (object) RisAddendum
    })[0];

    public void UpdateAddendumAsync(
      CredencialesParameters credenciales,
      AddendumParameters RisAddendum)
    {
      this.UpdateAddendumAsync(credenciales, RisAddendum, (object) null);
    }

    public void UpdateAddendumAsync(
      CredencialesParameters credenciales,
      AddendumParameters RisAddendum,
      object userState)
    {
      if (this.UpdateAddendumOperationCompleted == null)
        this.UpdateAddendumOperationCompleted = new SendOrPostCallback(this.OnUpdateAddendumOperationCompleted);
      this.InvokeAsync("UpdateAddendum", new object[2]
      {
        (object) credenciales,
        (object) RisAddendum
      }, this.UpdateAddendumOperationCompleted, userState);
    }

    private void OnUpdateAddendumOperationCompleted(object arg)
    {
      if (this.UpdateAddendumCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.UpdateAddendumCompleted((object) this, new UpdateAddendumCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/Solicitarimagenes", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public bool Solicitarimagenes(
      CredencialesParameters credenciales,
      string codexamen,
      string aetitle_destino)
    {
      return (bool) this.Invoke(nameof (Solicitarimagenes), new object[3]
      {
        (object) credenciales,
        (object) codexamen,
        (object) aetitle_destino
      })[0];
    }

    public void SolicitarimagenesAsync(
      CredencialesParameters credenciales,
      string codexamen,
      string aetitle_destino)
    {
      this.SolicitarimagenesAsync(credenciales, codexamen, aetitle_destino, (object) null);
    }

    public void SolicitarimagenesAsync(
      CredencialesParameters credenciales,
      string codexamen,
      string aetitle_destino,
      object userState)
    {
      if (this.SolicitarimagenesOperationCompleted == null)
        this.SolicitarimagenesOperationCompleted = new SendOrPostCallback(this.OnSolicitarimagenesOperationCompleted);
      this.InvokeAsync("Solicitarimagenes", new object[3]
      {
        (object) credenciales,
        (object) codexamen,
        (object) aetitle_destino
      }, this.SolicitarimagenesOperationCompleted, userState);
    }

    private void OnSolicitarimagenesOperationCompleted(object arg)
    {
      if (this.SolicitarimagenesCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.SolicitarimagenesCompleted((object) this, new SolicitarimagenesCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    [SoapDocumentMethod("http://tempuri.org/InsertarExamenCabDetalle", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    public Respuesta InsertarExamenCabDetalle(
      CredencialesParameters credenciales,
      InformeExternoCabeceraParameters[] informeExterno,
      PrestacionesExternasParameters[] detalleExterno)
    {
      return (Respuesta) this.Invoke(nameof (InsertarExamenCabDetalle), new object[3]
      {
        (object) credenciales,
        (object) informeExterno,
        (object) detalleExterno
      })[0];
    }

    public void InsertarExamenCabDetalleAsync(
      CredencialesParameters credenciales,
      InformeExternoCabeceraParameters[] informeExterno,
      PrestacionesExternasParameters[] detalleExterno)
    {
      this.InsertarExamenCabDetalleAsync(credenciales, informeExterno, detalleExterno, (object) null);
    }

    public void InsertarExamenCabDetalleAsync(
      CredencialesParameters credenciales,
      InformeExternoCabeceraParameters[] informeExterno,
      PrestacionesExternasParameters[] detalleExterno,
      object userState)
    {
      if (this.InsertarExamenCabDetalleOperationCompleted == null)
        this.InsertarExamenCabDetalleOperationCompleted = new SendOrPostCallback(this.OnInsertarExamenCabDetalleOperationCompleted);
      this.InvokeAsync("InsertarExamenCabDetalle", new object[3]
      {
        (object) credenciales,
        (object) informeExterno,
        (object) detalleExterno
      }, this.InsertarExamenCabDetalleOperationCompleted, userState);
    }

    private void OnInsertarExamenCabDetalleOperationCompleted(object arg)
    {
      if (this.InsertarExamenCabDetalleCompleted == null)
        return;
      InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs) arg;
      this.InsertarExamenCabDetalleCompleted((object) this, new InsertarExamenCabDetalleCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
    }

    public new void CancelAsync(object userState) => base.CancelAsync(userState);

    private bool IsLocalFileSystemWebService(string url)
    {
      if (url == null || url == string.Empty)
        return false;
      Uri uri = new Uri(url);
      return uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0;
    }
  }
}
