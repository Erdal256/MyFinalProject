using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccsess
{
    //generic constraint
    //class : Referans tip olabilir demek
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //tüm listele getir
        T Get(Expression<Func<T, bool>> filter); //listedeki bir şeyin ayrıntısına gitmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}