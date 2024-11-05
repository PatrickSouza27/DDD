using NerdStore.Core.Commands;

namespace NerdStore.Vendas.Application.Commands;

public class AplicarVoucherPedidoCommand : Command
{
    public Guid ClienteId { get; private set; }
    public Guid PedidoId { get; private set; }
    public string CodigoVoucher { get; private set; }

    public AplicarVoucherPedidoCommand(Guid clienteId, Guid pedidoId, string codigoVoucher)
    {
        ClienteId = clienteId;
        PedidoId = pedidoId;
        CodigoVoucher = codigoVoucher;
    }
}