﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public static class IQuarablePaginateExtensions
    {
        public static async Task<Paginate<T>> ToPaginateAsync<T>(
            this IQueryable<T> source,
            int index, //ilgili sayfa indexi
            int size, //sayfadaki bulunacak verinin sayısı
            CancellationToken cancellationToken = default //async işlemler için
            )
        {
            int count = await source.CountAsync(cancellationToken).ConfigureAwait(false); //await konf yapma

            List<T> items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

            Paginate<T> list = new()
            {
                Index = index,
                Count = count,
                Items = items,
                Size = size,
                Pages = (int)Math.Ceiling(count / (double)size),
            };

            return list;
        }

        public static Paginate<T> ToPaginate<T>(this IQueryable<T> source, int index, int size)
        {
            int count = source.Count();
            var items = source.Skip(index * size).Take(size).ToList();

            Paginate<T> list =
                new()
                {
                    Index = index,
                    Size = size,
                    Count = count,
                    Items = items,
                    Pages = (int)Math.Ceiling(count / (double)size)
                };
            return list;
        }
    }
}
