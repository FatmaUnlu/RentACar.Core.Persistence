using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId> //Entity, Id
    {
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate, //where koşulu ile sorgulama yapmak için
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, //Join kullanabilmek için. null join kullanılmama durumu da olabileceği için.
            bool withDeleted = false, //silinenleri getirmemesi için,
            bool enableTracking = true, //ef nin izlenme etkinliği için
            CancellationToken cancellationToken = default //iptal işlemi için.defaultsa iptal durumu kullanılmaz.
            );


        //Task<Paginate<TEntity>> GetListAsync(
        //    Expression<Func<TEntity, bool>>? predicate = null, //null parametre kullanılmama durumu da olabileceği için
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, //orderby yapılabilir.
        //    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        //    int index = 0,
        //    int size = 10,
        //    bool withDeleted = false,
        //    bool enableTracking = true,
        //    CancellationToken cancellationToken = default
        //);

        //dinamik sorgulama
        //Task<Paginate<TEntity>> GetListByDynamicAsync(
        //    DynamicQuery dynamic,
        //    Expression<Func<TEntity, bool>>? predicate = null,
        //    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        //    int index = 0,
        //    int size = 10,
        //    bool withDeleted = false,
        //    bool enableTracking = true,
        //    CancellationToken cancellationToken = default
        //);
        Task<bool> AnyAsync(
           Expression<Func<TEntity, bool>>? predicate = null,
           bool withDeleted = false,
           bool enableTracking = true,
           CancellationToken cancellationToken = default
       );

        Task<TEntity> AddAsync(TEntity entity);

        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);

        Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false); //permanent:false kalıcı olarak silme anlamında

        Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false);



    }
}
