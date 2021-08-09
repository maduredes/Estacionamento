using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Estacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {
        private readonly Context _contexto;
        public EstacionamentoController(Context contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Estacionamentos.ToListAsync());
        }
        public async Task<IActionResult> SearchEstacionamento(string id)
        {
            //caso nao tenha nada digitado na barra de pesquisa ele vai atualizar a tabela com todos os valores adicionados
            if (id != null)
            {
                return View("~/Views/Estacionamento/Index.cshtml", await _contexto.Estacionamentos.Where(w => w.Placa.Contains(id.ToUpper())).ToListAsync());
            }
            else
            {
                return View("~/Views/Estacionamento/Index.cshtml",await  _contexto.Estacionamentos.ToListAsync());
            }
        }
        [HttpGet]
        public IActionResult MarcarEntrada()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MarcarEntrada(Estacionamento estacionamento)
        {
            await _contexto.Estacionamentos.AddAsync(estacionamento);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> MarcarSaida(int Id)
        {
            Estacionamento estacionamento = await _contexto.Estacionamentos.FindAsync(Id);
            return View(estacionamento);
        }

        [HttpPost]
        public async Task<IActionResult> MarcarSaida(Estacionamento estacionamento)
        {
            Estacionamento est = new Estacionamento();
            var Tempoduracao = est.TempoDuracao(estacionamento.HorarioChegada, estacionamento.HorarioSaida);
            var duracao = Convert.ToDateTime(Tempoduracao);
            var horaCobrada = est.TempoCobrado(duracao);
           
            var precoHoraCobrado= duracao.Hour!=0 ? duracao.Hour + horaCobrada : 1;

            var valorAPagar = est.TabelaPreco(duracao, precoHoraCobrado);
            estacionamento.ValorPagar = valorAPagar;

            estacionamento.HoraCobrada = precoHoraCobrado;

            estacionamento.Duracao =duracao;
            estacionamento.Preco = " R$2.00";

            _contexto.Estacionamentos.Update(estacionamento);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}