using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using AppControleReceita.Models;

namespace AppControleReceita
{
    public class Util
    {
        private DataContext db = new DataContext();

        public string PopularPeriodo()
        {
            return System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + " - " + System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
        }

        public void FormatarPeriodoData(string pPeriodo, out string pDataini, out string pDatafim, bool pEDatabr = false)
        {
            string[] aux = pPeriodo.Split('-');
            DateTime dataini, datafim;
            dataini = DateTime.Parse(aux[0].ToString().Trim());
            datafim = DateTime.Parse(aux[1].ToString().Trim());

            if (!pEDatabr)
            {
                pDataini = dataini.ToString("yyyyMMdd");
                pDatafim = datafim.ToString("yyyyMMdd");
            }
            else
            {
                pDataini = dataini.ToString("dd/MM/yyyy");
                pDatafim = datafim.ToString("dd/MM/yyyy");
            }

        }

        //public HttpRequestBase Request { get; }
        //public string IP_Usuario()
        //{
        //    return Request.UserHostAddress;
        //}

        //public string IP_Usuario()
        //{

        //string nome = Dns.GetHostName();
        //IPAddress[] ip = Dns.GetHostAddresses(nome);

        //string server_ip = string.Empty;
        //foreach (IPAddress a in ip)
        //{ if (a.IsIPv6LinkLocal == false)
        //    {
        //        server_ip = server_ip + a.ToString() + "/";
        //    }
        //}

        //return server_ip;
        //System.Web.HttpContext context = System.Web.HttpContext.Current;
        //string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //if (!string.IsNullOrEmpty(ipAddress))
        //{
        //    string[] addresses = ipAddress.Split(',');
        //    if (addresses.Length != 0)
        //    {
        //        return addresses[0];
        //    }
        //}

        //return context.Request.ServerVariables["REMOTE_ADDR"];
        //}



        //public string IP_Usuario()
        //{
        //    string lNome = Dns.GetHostName();
        //    IPAddress[] lIp = Dns.GetHostAddresses(lNome);
        //    return IpLocal(lIp[1].ToString());
        //}

        public string ExibirComponente()
        {
            return "style=display:block !important";
        }

        //public static string IpLocal(string host)
        //{
        //    try
        //    { // get host IP addresses
        //        IPAddress[] hostIPs = Dns.GetHostAddresses(host);
        //        // get local IP addresses
        //        IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

        //        // test if any host IP equals to any local IP or to localhost
        //        foreach (IPAddress hostIP in hostIPs)
        //        {
        //            // is localhost
        //            if (IPAddress.IsLoopback(hostIP)) return hostIP.ToString();
        //            // is local address
        //            foreach (IPAddress localIP in localIPs)
        //            {
        //                if (hostIP.Equals(localIP)) return hostIP.ToString();
        //            }
        //        }
        //    }
        //    catch { }
        //    return "";
        //}

        private class ListaModulos
        {
            public string modCodigo { get; set; }
        }

        //public string MontarMenu(object pSegUsuario)
        //{
        //    #region [Instancias]
        //    DataContext db = new DataContext();
        //    StringBuilder lStrBuilder = new StringBuilder();
        //    string lDominio = ConfigurationManager.AppSettings["Dominio"].ToString();
        //    #endregion

        //    try
        //    {
        //        int lPerfil = ((seg_usuario)pSegUsuario).PER_CODIGO;

        //        var lModuloPorPerfil = db.Dbseg_modulo_perfil.Where(x => x.PER_CODIGO.Equals(lPerfil)).ToList();


        //        foreach (var Modulo in lModuloPorPerfil)
        //        {
        //            var lListaDeModulos = db.Dbseg_modulo.Where(x => x.MOD_CODIGO.Equals(Modulo.MOD_CODIGO)).ToList();

        //            foreach (var Nivel1 in lListaDeModulos)
        //            {
        //                string lIcone = Nivel1.MOD_ICONE;
        //                string lNomeModulo = Nivel1.MOD_NOME;

        //                lStrBuilder.AppendFormat("<li class='treeview' id='{0}'>  ", Nivel1.MOD_CODIGO);
        //                lStrBuilder.AppendFormat("   <a href = '#'> ");
        //                lStrBuilder.AppendFormat("      <i class='fa fa-{0}'></i> <span>{1}</span>", lIcone, lNomeModulo);
        //                lStrBuilder.AppendFormat("      <span class='pull-right-container'> ");
        //                lStrBuilder.AppendFormat("           <i class='fa fa-angle-left pull-right'></i> ");
        //                lStrBuilder.AppendFormat("       </span> ");
        //                lStrBuilder.AppendFormat("   </a> ");
        //                lStrBuilder.AppendFormat("   <ul class='treeview-menu'> ");


        //                //SELECT* FROM seg_acesso_modulo amo
        //                //inner join seg_acesso ace on amo.ACE_CODIGO = ace.ACE_CODIGO
        //                //where amo.MOD_CODIGO in (1, 2)

        //               var ListaDelinkPorModulos = (from amo in db.Dbseg_acesso_modulo
        //                                 join ace in db.Dbseg_acesso on new { amo.ACE_CODIGO } equals new { ace.ACE_CODIGO }
        //                                 where amo.MOD_CODIGO.Equals(Nivel1.MOD_CODIGO)
        //                                 select new AcessosPorModuloDto()
        //                                 {
        //                                     ace_codigo = ace.ACE_CODIGO,
        //                                     mod_codigo = amo.MOD_CODIGO,
        //                                     ace_nome = ace.ACE_NOME,
        //                                     ace_link = ace.ACE_LINK,
        //                                 }).ToList<AcessosPorModuloDto>();

        //                foreach (var link in ListaDelinkPorModulos)
        //                {
        //                    lStrBuilder.AppendFormat("<li id='{0}'><a href='" + lDominio + "{1}' style='font-size: 14px' > {2}</a></li>", link.ace_link.ToString().Replace("/", "_"), link.ace_link, link.ace_nome);//<i class='fa fa-caret-right'></i>
        //                }
                        


        //                lStrBuilder.AppendFormat("   </ul>");
        //                lStrBuilder.AppendFormat("</li> ");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return lStrBuilder.ToString();
        //}

        public class AcessosPorModuloDto
        {
            public int ace_codigo { get; set; }
            public int mod_codigo { get; set; }
            public string ace_nome { get; set; }
            public string ace_link { get; set; }
        }

        //public string RetornarDataAtualSistema()
        //{
        //    DataContext db = new DataContext();
        //    List<CadDat> lCadDat = (from x in db.DbCadDat where (x.chrDat_SitDia.Equals("A")) select x).ToList();
        //    return lCadDat[0].dtmDat_Atu.ToString("dd/MM/yyyy");
        //}

        //public string VerificarDiaUtil(DateTime pDataMov)
        //{
        //    DataContext db = new DataContext();
        //    List<CadDat> lCadDat = (from x in db.DbCadDat where (x.dtmDat_Atu.Equals(pDataMov)) select x).ToList();
        //    if (lCadDat.Count > 0)
        //    {
        //        return "1";
        //    }
        //    else
        //    {
        //        return "0";
        //    }
        //}

        //public bool VerificarAcesso(object pRetorno, string pUrl, out string pScript)
        //{
        //    bool lRetorno = false;
        //    string lNomeSistema = ConfigurationManager.AppSettings["NomeSistema"].ToString();
        //    DataTable lObjetoSGA = new DataTable();
        //    try
        //    {
        //        if (pUrl.ToLower().Equals("/" + lNomeSistema + "/home") || pUrl.ToLower().Equals("/" + lNomeSistema + "/home/index") || pUrl.ToLower().Equals("/home") || pUrl.ToLower().Equals("/home/index"))
        //        {
        //            lRetorno = true;
        //        }
        //        else
        //        {
        //            DataTable lObjetosSGA = pRetorno.Tables["permissoesobjetos"].DefaultView.ToTable();

        //            //string lLink = pUrl.Substring(1, pUrl.Length-1).ToString();//remove a barra inicial
        //            string lLink = string.Empty;

        //            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Dominio"].ToString()))
        //            {
        //                lLink = pUrl.ToLower().Remove(0, 1).Replace(ConfigurationManager.AppSettings["Dominio"].ToString().ToLower().Remove(0, 1), "").Remove(0, 1);
        //            }
        //            else
        //            {
        //                lLink = pUrl.ToLower().Remove(0, 1);
        //            }

        //            lObjetoSGA = lObjetosSGA.AsEnumerable()
        //                                        .Where(x => x["nomeobjeto"].ToString().ToLower().Equals(lLink.ToString().ToLower()))
        //                                        .CopyToDataTable();

        //            if (lObjetoSGA.Rows.Count == 1)
        //            {
        //                lRetorno = true;
        //            }
        //        }

        //        if (lObjetoSGA.Rows.Count > 0)
        //        {
        //            StringBuilder lStrBuild = new StringBuilder();
        //            string lNomeObjeto = lObjetoSGA.Rows[0]["nomeobjeto"].ToString().Replace("/", "_");
        //            string[] lPartes = lNomeObjeto.Split('_');

        //            string lModulo = lPartes[0].ToLower();

        //            lStrBuild.AppendFormat("$('#{0}').attr('class', 'treeview active');", lModulo.Equals("cadastro") ? "cad" : lModulo.Equals("relatorio") ? "rel" : lModulo.Equals("consulta") ? "con" : lModulo.Equals("processamentos") ? "pro" : "");
        //            lStrBuild.AppendFormat("$('#{0}').attr('class', 'active');", lObjetoSGA.Rows[0]["idmodulo"].ToString());
        //            lStrBuild.AppendFormat("$('#{0}').attr('class', 'active');", lNomeObjeto);

        //            pScript = lStrBuild.ToString();
        //        }
        //        else
        //        {
        //            pScript = "";
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return lRetorno;

        //}

        public string RetornarCampoEspecifico(string pNomeTabela, string pNomeCampo, DataSet pRetorno)
        {
            return pRetorno.Tables[pNomeTabela].Rows[0][pNomeCampo].ToString();
        }

        public string RetornarCampoEspecificoObjeto(string pNomeCampo, DataSet pRetorno, string pUrlAcessada)
        {
            if (pRetorno == null)
            {
                return "False";
            }

            string lLink = string.Empty;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Dominio"].ToString()))
            {
                lLink = pUrlAcessada.ToLower().Remove(0, 1).Replace(ConfigurationManager.AppSettings["Dominio"].ToString().ToLower().Remove(0, 1), "").Remove(0, 1);
            }
            else
            {
                lLink = pUrlAcessada.ToLower().Remove(0, 1);
            }

            DataTable lObjetosSGA = pRetorno.Tables["permissoesobjetos"].DefaultView.ToTable();

            lObjetosSGA = lObjetosSGA.AsEnumerable()
                                        .Where(x => x["nomeobjeto"].ToString().ToLower().Equals(lLink.ToString().ToLower()))
                                        .CopyToDataTable();

            return lObjetosSGA.Rows[0][pNomeCampo].ToString();
        }

        //static public string NomeMaquina()
        //{
        //    return SystemInformation.ComputerName;
        //}

        public class Msg
        {
            public string CodMsg { get; set; }
            public string StrMsg { get; set; }
        }

        public enum TipoMensagem
        {
            Alerta,
            Erro,
            Sucesso,
        }

        public Msg Mensagem(TipoMensagem pTipoMensagem, string pTextoMensagem)
        {
            Msg lMsg = new Msg();

            switch (pTipoMensagem)
            {
                case TipoMensagem.Alerta:
                    lMsg.CodMsg = "Alerta";
                    break;
                case TipoMensagem.Erro:
                    lMsg.CodMsg = "Erro";
                    break;
                case TipoMensagem.Sucesso:
                    lMsg.CodMsg = "Sucesso";
                    break;
                default:
                    break;
            }

            lMsg.StrMsg = pTextoMensagem;

            return lMsg;
        }

        //public bool EnviarEmail(DtoEmail pDtoEmail)
        //{
        //    try
        //    {
        //        //envia o e-mail
        //        // Estancia da Classe de Mensagem
        //        MailMessage _mailMessage = new MailMessage();

        //        // Remetente
        //        _mailMessage.From = new MailAddress(pDtoEmail.email_remetente);

        //        // Destinatario
        //        _mailMessage.To.Add(pDtoEmail.email_destinatario);

        //        // Assunto
        //        _mailMessage.Subject = pDtoEmail.email_assunto;

        //        // A mensagem é do tipo HTML ou Texto Puro?
        //        _mailMessage.IsBodyHtml = pDtoEmail.email_tipo_html;

        //        // Corpo da Mensagem
        //        _mailMessage.Body = pDtoEmail.email_mensagem;
        //        if (pDtoEmail.email_arquivo != null)
        //        {
        //            //arquivo
        //            MemoryStream MS = new MemoryStream(pDtoEmail.email_arquivo);

        //            // Anexa o Stream do arquivo
        //            Attachment anexo = new Attachment(MS, pDtoEmail.email_nome_arquivo);

        //            _mailMessage.Attachments.Add(anexo);
        //        }

        //        // Estancia a Classe de Envio
        //        SmtpClient _smtpClient = new SmtpClient(pDtoEmail.email_smtp);
        //        _smtpClient.EnableSsl = pDtoEmail.EnableSsl;
        //        // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
        //        _smtpClient.UseDefaultCredentials = pDtoEmail.UseDefaultCredentials;


        //        _smtpClient.Port = pDtoEmail.email_porta;
        //        _smtpClient.Credentials = new NetworkCredential(pDtoEmail.email_remetente, pDtoEmail.email_senha);

        //        // Envia a mensagem

        //        _smtpClient.Send(_mailMessage);
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }


        //    return true;
        //}

        public IEnumerable<ValidationResult> getValidationErros(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }

        //public void AuditoriaSGA(DataSet pRetorno, string pContextoLog, string pOperacaoLog)
        //{
        //    if (pRetorno != null)
        //    {
        //        TB_LOGSE_LOG lTB_LOGSE_LOG = new TB_LOGSE_LOG();

        //        lTB_LOGSE_LOG.CD_USUARIO_LOGSE_LOG = Convert.ToInt32(RetornarCampoEspecifico("infousuario", "idusuario", pRetorno));
        //        lTB_LOGSE_LOG.DT_HORA_OPERA_LOG = DateTime.Now;
        //        lTB_LOGSE_LOG.TX_NOME_USUAR_LOG = RetornarCampoEspecifico("infousuario", "logonusuario", pRetorno);
        //        lTB_LOGSE_LOG.TX_CONTX_LOGSEG = pContextoLog;
        //        lTB_LOGSE_LOG.TX_OPERA_LOG = pOperacaoLog;
        //        lTB_LOGSE_LOG.TX_IP_USUAR_REDE_LOG = RetornarCampoEspecifico("infousuario", "ipacesso", pRetorno);
        //        lTB_LOGSE_LOG.TX_NOME_USUAR_REDE_LOG = NomeUsuarioRede();
        //        lTB_LOGSE_LOG.TX_LOGIN_USUAR_LOG = RetornarCampoEspecifico("infousuario", "logonusuario", pRetorno);
        //        lTB_LOGSE_LOG.TX_MATRI_STEMA_LOG = ConfigurationManager.AppSettings["MatriculaSistema"].ToString();
        //        lTB_LOGSE_LOG.TX_NOME_STEMA_LOG = ConfigurationManager.AppSettings["NomeSistema"].ToString();//gDados.RetornarCampoEspecifico("infousuario", "nome", pRetorno);
        //        lTB_LOGSE_LOG.IN_TIPO_LOG = 1;

        //        db.DbTB_LOGSE_LOG.Add(lTB_LOGSE_LOG);
        //        db.SaveChanges().ToString();
        //    }
        //}

        //public void AuditoriaSGA(string pContextoLog, string pOperacaoLog, string pIp, int pCdUsuario = 999999999)
        //{
        //    TB_LOGSE_LOG lTB_LOGSE_LOG = new TB_LOGSE_LOG();

        //    lTB_LOGSE_LOG.CD_USUARIO_LOGSE_LOG = pCdUsuario;
        //    lTB_LOGSE_LOG.DT_HORA_OPERA_LOG = DateTime.Now;
        //    lTB_LOGSE_LOG.TX_NOME_USUAR_LOG = NomeUsuarioRede();
        //    lTB_LOGSE_LOG.TX_CONTX_LOGSEG = pContextoLog;
        //    lTB_LOGSE_LOG.TX_OPERA_LOG = pOperacaoLog;
        //    lTB_LOGSE_LOG.TX_IP_USUAR_REDE_LOG = pIp;
        //    lTB_LOGSE_LOG.TX_NOME_USUAR_REDE_LOG = NomeUsuarioRede();
        //    lTB_LOGSE_LOG.TX_LOGIN_USUAR_LOG = NomeUsuarioRede();
        //    lTB_LOGSE_LOG.TX_MATRI_STEMA_LOG = ConfigurationManager.AppSettings["MatriculaSistema"].ToString();
        //    lTB_LOGSE_LOG.TX_NOME_STEMA_LOG = ConfigurationManager.AppSettings["NomeSistema"].ToString();
        //    lTB_LOGSE_LOG.IN_TIPO_LOG = 1;

        //    db.DbTB_LOGSE_LOG.Add(lTB_LOGSE_LOG);
        //    db.SaveChanges().ToString();
        //}

        public string NomeUsuarioRede()
        {
            return Environment.UserName;
        }

        public string CriarXmlRequisicao(string strMatricSistema, string usuarioSistema, string ipusuario, string usuariorede, string strAutenticacaoCriptografada = "", string strCaminhoCPR = "", string pSenha = "")
        {
            //Rotina que Gera a string de Requisição da Autenticação
            string strRetorno = "";
            string strNomeArquivoXML = "";
            XmlTextWriter xmlRequisicao = default(XmlTextWriter);
            XmlDocument docXML = default(XmlDocument);
            StreamReader SR = default(StreamReader);

            try
            {
                if (!System.IO.Directory.Exists(ConfigurationSettings.AppSettings["CaminhoXML"].ToString() + "\\XML\\"))
                    System.IO.Directory.CreateDirectory(ConfigurationSettings.AppSettings["CaminhoXML"].ToString() + "\\XML\\");

                //Procura por um nome de arquivo que ainda não exista
                //strNomeArquivoXML = AppDomain.CurrentDomain.BaseDirectory + "\\XML\\XML_REQ_AUT_" + String.Format(DateTime.Now, "ddMMyyyyhhmmss") + ".xml";
                strNomeArquivoXML = ConfigurationSettings.AppSettings["CaminhoXML"].ToString() + "\\XML\\XML_REQ_AUT_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".xml";
                while (System.IO.File.Exists(strNomeArquivoXML))
                {
                    strNomeArquivoXML = AppDomain.CurrentDomain.BaseDirectory + "\\XML\\XML_REQ_AUT_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".xml";
                }

                xmlRequisicao = new System.Xml.XmlTextWriter(strNomeArquivoXML, System.Text.Encoding.UTF8);

                //INÍCIO DO DOCUMENTO XML
                xmlRequisicao.WriteStartDocument();

                //INÍCIO DA TAG 'REQUISICAO'
                xmlRequisicao.WriteStartElement("requisicao");
                xmlRequisicao.WriteAttributeString("xmlns", "http://ntconsult.com.br/webservices/");
                xmlRequisicao.WriteAttributeString("versao", "0.10");

                //Caso a Autenticação seja criptografia RSA então este elemento deverá ser criado: AutenticacaoCriptografada
                //Caso o parâmetro tenha sido informado e não esteja em branco efetua a autenticação através de RSA
                if ((strAutenticacaoCriptografada != null))
                {
                    if (!string.IsNullOrEmpty(strAutenticacaoCriptografada.Trim()))
                    {
                        xmlRequisicao.WriteElementString("AutenticacaoCriptografada", strAutenticacaoCriptografada);
                    }
                }
                else
                {
                    xmlRequisicao.WriteElementString("usr", usuarioSistema);
                    xmlRequisicao.WriteElementString("senha", pSenha);
                }
                xmlRequisicao.WriteElementString("matricsistema", strMatricSistema);
                xmlRequisicao.WriteElementString("usuariorede", usuariorede);
                xmlRequisicao.WriteElementString("ipusuario", ipusuario);






                //FIM DA TAG 'REQUISICAO'
                xmlRequisicao.WriteEndElement();

                //FIM DO DOCUMENTO XML
                xmlRequisicao.WriteEndDocument();
                xmlRequisicao.Flush();
                xmlRequisicao.Close();


                docXML = new XmlDocument();
                docXML.PreserveWhitespace = false;

                SR = File.OpenText(strNomeArquivoXML);
                docXML.LoadXml(SR.ReadToEnd());
                SR.Close();

                strRetorno = docXML.InnerXml.ToString();

                //apos usar o arquivo, apaga-lo
                File.Delete(strNomeArquivoXML);

                return strRetorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public string VerificarParametros(string pParamentro)
        //{
        //    string lRetorno = string.Empty;
        //    List<CadPar> lCadPar = db.DbCadPar.ToList();
        //    if (lCadPar.Count > 0)
        //    {
        //        if (pParamentro == "PerPgoPar")
        //            lRetorno = lCadPar[0].chrPar_PerPgoPar;
        //        else if (pParamentro == "AgnCenCtb") { }
        //        //lRetorno = Format(rsPar!intPar_AgnCenCtb, "000")
        //        else if (pParamentro == "ValBnf") { }
        //        //lRetorno = Format(rsPar!intPar_ValBnf, "0000")
        //        else if (pParamentro == "AutImpAut") { }
        //        //lRetorno = rsPar!chrPar_AutImpAut
        //        else if (pParamentro == "AdmPerPgo") { }
        //        //lRetorno = rsPar!chrPar_AdmPerPgo
        //        else if (pParamentro == "PosCenCtb") { }
        //        //lRetorno = Format(rsPar!intPar_PosCenCtb, "00")
        //        else if (pParamentro == "AdmPgoCnt") { }
        //        //lRetorno = rsPar!chrPar_AdmPgoCnt
        //        else if (pParamentro == "QtdVnc") { }
        //        //lRetorno = rsPar!numPar_QtdVnc
        //        else
        //        {
        //            lRetorno = "erro";
        //        }

        //    }

        //    return lRetorno;
        //}

        //public int funMaxMovSeq(string pMatricula, short pSeq)
        //{
        //    int lRetorno = 0;

        //    decimal lMatricula = decimal.Parse(pMatricula);
        //    List<cadmov> lList = db.Dbcadmov.Where(l => l.numBen_Mat.Equals(lMatricula) && l.sinBen_TipCad == pSeq).ToList();

        //    lRetorno = (from x in lList select x.intMov_Seq).Max();




        //    return lRetorno;
        //}

        public string VersaoSistema()
        {
            return "1.0.0.0";
        }
    }
}