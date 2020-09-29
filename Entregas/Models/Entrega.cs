using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Models
{
    class Entrega
    {
        public int Id { get; set; }
        public string Situacao { get; set; }
        public DateTime DataEntrega{ get; set; }
        public String Remetente { get; set; }
        public String Destinatario { get; set; }
        public String EnderecoDestinatario { get; set; }
        public float ValorEntrega { get; set; }
        public string Observacao { get; set; }
        public String Entregador { get; set; }

        public Entrega(int id, string situacao, DateTime dataEntrega, string remetente, string destinatario, string enderecoDestinatario, float valorEntrega, string observacao, string entregador)
        {
            Id = id;
            Situacao = situacao ?? throw new ArgumentNullException(nameof(situacao));
            DataEntrega = dataEntrega;
            Remetente = remetente ?? throw new ArgumentNullException(nameof(remetente));
            Destinatario = destinatario ?? throw new ArgumentNullException(nameof(destinatario));
            EnderecoDestinatario = enderecoDestinatario ?? throw new ArgumentNullException(nameof(enderecoDestinatario));
            ValorEntrega = valorEntrega;
            Observacao = observacao ?? throw new ArgumentNullException(nameof(observacao));
            Entregador = entregador ?? throw new ArgumentNullException(nameof(entregador));
        }

        public Entrega(string situacao, DateTime dataEntrega, string remetente, string destinatario, string enderecoDestinatario, float valorEntrega, string observacao, string entregador)
        {
            Situacao = situacao ?? throw new ArgumentNullException(nameof(situacao));
            DataEntrega = dataEntrega;
            Remetente = remetente ?? throw new ArgumentNullException(nameof(remetente));
            Destinatario = destinatario ?? throw new ArgumentNullException(nameof(destinatario));
            EnderecoDestinatario = enderecoDestinatario ?? throw new ArgumentNullException(nameof(enderecoDestinatario));
            ValorEntrega = valorEntrega;
            Observacao = observacao ?? throw new ArgumentNullException(nameof(observacao));
            Entregador = entregador ?? throw new ArgumentNullException(nameof(entregador));
        }
    }
}
