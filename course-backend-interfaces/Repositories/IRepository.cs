﻿namespace course_backend_interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetById(int id);
    IEnumerable<TEntity> GetAll();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}