using System;
using KOF.Desafios.Application.Common.Pagination;

namespace KOF.Desafios.Application.Dtos.Desafios.Request;

public class RequestBaseDto
{
    public int? Pagina { get; set; }
    public int? TamanoPagina { get; set; }
    public RequestBaseDto()
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
