using System;
using KOF.Desafios.Application.Common.Pagination;

namespace KOF.Desafios.Application.Entities.Desafios.Request;

public class RequestBase
{
    public int? Pagina { get; set; }
    public int? TamanoPagina { get; set; }
    public RequestBase()
    {
        Pagina = 0;
        TamanoPagina = 100;
    }
    public void SetPageAndSize()
    {
        TamanoPagina = Pagination.SetPageSize(TamanoPagina);
        Pagina = Pagination.SetPageNumber(Pagina);
    }
}
