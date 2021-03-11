using AppControleReceita.Models;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;


namespace AppControleReceita.Controllers
{
    public class HomeController : Controller
    {
        private Util gUtil = new Util();
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            loadDropDowns();
            //LoadDropsMesAno("","");
            return View();
        }

        public void loadDropDowns()
        {
            var lCategoria = db.Dbfin_categoria
                    .Select(s => new { item = s.CAT_NOME, value = s.CAT_CODIGO })
                    .ToList();

            ViewBag.vBCategoria = new SelectList(lCategoria, "value", "item");
        }

        [HttpPost]
        public ActionResult LoadDropsPorTipo(string pParam)
        {
            var lCategoria = db.Dbfin_categoria.Where(x => x.CAT_TIPO == pParam).ToList();

            return Json(lCategoria, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SalvarRegistro(fin_credito_debito pfincreditodebito)
        {
            string lMsg = "{0} Registrado com Sucesso!";
            try
            {
                fin_credito_debito lfincreditodebito = new fin_credito_debito();
                lfincreditodebito.FCD_DATA_CADASTRO = DateTime.Now;
                lfincreditodebito.FCD_VALOR = decimal.Parse(pfincreditodebito.FCD_VALORS);
                lfincreditodebito.CAT_CODIGO = pfincreditodebito.CAT_CODIGO;

                if (pfincreditodebito.FCD_TIPO.Equals("D"))
                    lMsg = string.Format(lMsg, "Débito");
                else
                    lMsg = string.Format(lMsg, "Crédito");

                db.Dbfin_credito_debito.Add(lfincreditodebito);
                db.SaveChanges().ToString();
            }
            catch (Exception e)
            {
                return Json(gUtil.Mensagem(Util.TipoMensagem.Erro, "Não foi possível Salvar. <br /> Erro: " + e.Message));
                throw;
            }

            return Json(gUtil.Mensagem(Util.TipoMensagem.Sucesso, lMsg));
        }

        [HttpPost]
        public ActionResult LoadDropsMesAno(string pTipo, string pCategoria)
        {
            List<Relfin_credito_debitoDto> lList = new List<Relfin_credito_debitoDto>();
            var Query = (from fcd in db.Dbfin_credito_debito
                         join cat in db.Dbfin_categoria on new { fcd.CAT_CODIGO } equals new { cat.CAT_CODIGO }

                         select new Relfin_credito_debitoDto()
                         {
                             MesAnoPesquisa = fcd.FCD_DATA_CADASTRO,
                             CAT_TIPO = cat.CAT_TIPO,
                             CAT_CODIGO = fcd.CAT_CODIGO
                         });

            if (!pTipo.Equals(""))
            {
                Query = Query.Where(a => a.CAT_TIPO == pTipo);

            }
            if (!pCategoria.Equals(""))
            {
                int lCatCod = int.Parse(pCategoria);
                Query = Query.Where(a => a.CAT_CODIGO == lCatCod);
            }

            lList = Query.ToList<Relfin_credito_debitoDto>();
            lList = lList.GroupBy(c => c.MesAnoPesquisa).Select(x => x.First()).OrderByDescending(l => l.MesAnoPesquisa).ToList();


            return Json(lList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CarregarRegistros(fin_credito_debito pfincreditodebito)
        {
            try
            {
                List<Relfin_credito_debitoDto> lList = new List<Relfin_credito_debitoDto>();
                var lConsulta = (from fcd in db.Dbfin_credito_debito
                                 join cat in db.Dbfin_categoria on new { fcd.CAT_CODIGO } equals new { cat.CAT_CODIGO }

                                 select new Relfin_credito_debitoDto()
                                 {
                                     FCD_CODIGO = fcd.FCD_CODIGO,
                                     MesAnoPesquisa = fcd.FCD_DATA_CADASTRO,
                                     CAT_TIPO = cat.CAT_TIPO,
                                     CAT_CODIGO = fcd.CAT_CODIGO,
                                     CAT_NOME = cat.CAT_NOME,
                                     FCD_VALOR = fcd.FCD_VALOR
                                 });

                if (!string.IsNullOrEmpty(pfincreditodebito.CAT_TIPO))
                {
                    lConsulta = lConsulta.Where(l => l.CAT_TIPO == pfincreditodebito.CAT_TIPO);
                }
                if (pfincreditodebito.CAT_CODIGO > 0)
                {
                    lConsulta = lConsulta.Where(l => l.CAT_CODIGO == pfincreditodebito.CAT_CODIGO);
                }
                if (!string.IsNullOrEmpty(pfincreditodebito.MesAnoPesquisa))
                {

                    String lteste = "03/2021";
                    String p = lteste.Substring(3, 4);

                    lConsulta = lConsulta.Where(l => l.MesAnoPesquisa.ToString().Substring(5, 2) == pfincreditodebito.MesAnoPesquisa.Substring(0, 2) && l.MesAnoPesquisa.ToString().Substring(0, 4) == pfincreditodebito.MesAnoPesquisa.Substring(3, 4));
                }
                lList = lConsulta.OrderByDescending(l => l.FCD_CODIGO).ToList<Relfin_credito_debitoDto>();


                return Json(lList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Não foi possível Carregar. <br /> Erro: " + e.Message);
            }
        }

        [HttpPost]
        public JsonResult DeletarPorFcdCodigo(string pFcdCodigo)
        {
            try
            {
                if (!string.IsNullOrEmpty(pFcdCodigo))
                {
                    int lFcdCodigo = int.Parse(pFcdCodigo);

                    fin_credito_debito Usuario = db.Dbfin_credito_debito.Find(lFcdCodigo);
                    db.Dbfin_credito_debito.Remove(Usuario);
                    db.SaveChanges();

                    return Json(gUtil.Mensagem(Util.TipoMensagem.Sucesso, "Registro Excluído!"));
                }
                else
                {
                    return Json(gUtil.Mensagem(Util.TipoMensagem.Alerta, "Não foi possível excluir o registro."));
                }
            }
            catch (Exception e)
            {
                return Json(gUtil.Mensagem(Util.TipoMensagem.Erro, "Não foi possível excluir o registro. <br /> Erro: " + e.Message));
            }
        }

        [HttpPost]
        public ActionResult LoadDropsAno()
        {
            List<Relfin_credito_debitoDto> lList = new List<Relfin_credito_debitoDto>();
            var Query = (from fcd in db.Dbfin_credito_debito
                         join cat in db.Dbfin_categoria on new { fcd.CAT_CODIGO } equals new { cat.CAT_CODIGO }

                         select new Relfin_credito_debitoDto()
                         {
                             AnoPesquisa = fcd.FCD_DATA_CADASTRO.ToString().Substring(0, 4),

                         });//9999/99/99


            lList = Query.ToList<Relfin_credito_debitoDto>();
            lList = lList.GroupBy(c => c.AnoPesquisa).Select(x => x.First()).OrderByDescending(l => l.AnoPesquisa).ToList();


            return Json(lList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CarregarRegistrosAnual(string pAnoPesquisa)
        {
            try
            {
                List<MySqlParameter> parametros = new List<MySqlParameter>
                {
                    new MySqlParameter("@pAno", pAnoPesquisa),
    
                };

                var result = db.Database.SqlQuery<Relfin_credito_debitoAnualDto>(
                                 @"SELECT CONCAT(month(FCD_DATA_CADASTRO) , '/' , year(FCD_DATA_CADASTRO))'AnoPesquisa', sum(fcd_valor)'TotalCreditoAnual'

                                ,

                                (SELECT sum(fcds.fcd_valor)'debito' FROM fin_credito_debito fcds inner join fin_categoria cats on fcds.cat_codigo = cats.CAT_CODIGO 
                                    where cats.cat_tipo = 'D' and year(fcds.fcd_data_cadastro) = @pAno 
                                    and  year(fcds.FCD_DATA_CADASTRO) = year(fcd.FCD_DATA_CADASTRO) and month(fcds.FCD_DATA_CADASTRO) = month(fcd.FCD_DATA_CADASTRO)
                                    group by year(fcds.FCD_DATA_CADASTRO), month(fcds.FCD_DATA_CADASTRO)) 'TotalDebitoAnual'

                                FROM fin_credito_debito fcd
                                inner join fin_categoria cat on fcd.cat_codigo = cat.CAT_CODIGO	

                                where
                                cat.cat_tipo = 'C' and
                                year(fcd.fcd_data_cadastro) = @pAno

                                group by month(fcd.FCD_DATA_CADASTRO), year(fcd.FCD_DATA_CADASTRO)",
                                   parametros.ToArray()
                                ).ToList();
                
                var lList = result.OrderByDescending(l => l.AnoPesquisa).ToList<Relfin_credito_debitoAnualDto>();


                return Json(lList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Não foi possível Carregar. <br /> Erro: " + e.Message);
            }
        }
    }
}