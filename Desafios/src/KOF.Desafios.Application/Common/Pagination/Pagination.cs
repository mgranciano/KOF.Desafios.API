using System;

namespace KOF.Desafios.Application.Common.Pagination;


public static class Pagination
{
    public static int SetPageSize(int? pageSize, int defaultPageSize = 0)
    {
        if (pageSize == 0 || pageSize == null || pageSize < 0)
        {
            pageSize = defaultPageSize == 0 ? 1000 : defaultPageSize;
        }
        return pageSize.Value;
    }

    public static int SetPageNumber(int? pageNumber)
    {
        if (pageNumber == null || pageNumber < 0)
        {
            pageNumber = 0;
        }
        else if (pageNumber > 0)
        {
            pageNumber--;
        }
        return pageNumber.Value;
    }
}