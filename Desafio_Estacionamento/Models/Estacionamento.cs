using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Estacionamento.Models
{
    public class Estacionamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O número da placa é obrigatório!")]
        public String Placa { get; set; }

        [Display(Name = "Horario de chegada")]
        [Required(ErrorMessage = "O horário de chegada é obrigatório")]

        public DateTime HorarioChegada { get; set; }
        [Display(Name = "Horario de saída")]

        public DateTime HorarioSaida { get; set; }
        [Display(Name = "Tempo cobrado(Hora)")]

        public int HoraCobrada { get; set; }
        [Display(Name = "Preço")]

        public String Preco { get; set; }
        [Display(Name = "Valor a pagar")]

        public double ValorPagar { get; set; }
        [Display(Name = "Duração")]

        public DateTime Duracao { get; set; }


        public String TempoDuracao(DateTime horarioChegada, DateTime HorarioSaida)
        {


            TimeSpan horaTotal = new TimeSpan(horarioChegada.Ticks - HorarioSaida.Ticks);

            string total = horaTotal.ToString(@"hh\:mm\:ss");
            return total;
        }

        public double TabelaPreco(DateTime duracao,int horaCobrada)
        {
            //valor inicial do preco
            double preco = 1.00;
            double precoHoraInicial = 2.00;
            var total = 0.00;
            if (duracao.Hour > 0)
            {

                // condicao que cobra as horas adicionais
                if (duracao.Hour >= 1 && duracao.Minute >= 15)
                {
                  
                      total= horaCobrada * precoHoraInicial;
                        
                    
                    return total;

                }
                else
                {
                    total = horaCobrada * precoHoraInicial;

                    return total;

                }


            }
            //entao a pessoa ficou minutos
            else
            {
                //se o preco for menor ou igual a 30min
                if (duracao.Minute <= 30)
                {
                    total = preco;
                    return total;
                }
                //caso contrario cobro preço adicional
                else
                {
                    total = precoHoraInicial;
                    return total;
                }
            }
        }

        public int TempoCobrado(DateTime duracao)
        {
            if (duracao.Hour >= 1 && duracao.Minute >= 15)
            {
                return 1;
            }
            else
            {
                return 0;
            }


        }
    }
}
