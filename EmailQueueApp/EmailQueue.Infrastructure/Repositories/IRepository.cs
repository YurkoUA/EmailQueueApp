﻿using System;
using System.Collections.Generic;

namespace EmailQueueApp.Infrastructure.Repositories
{
    public interface IRepository
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity Get<TEntity>(int id) where TEntity : class;

        int Insert<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(int id) where TEntity : class;

        void ExecuteQuery(string query, object paramModel = null);
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string query, object paramModel = null) where TEntity : class;
        TEntity ExecuteQuerySingle<TEntity>(string query, object paramModel = null) where TEntity : class;

        TAggregate ExecuteAggregateQuery<TAggregate>(string query, object paramModel = null);

        void ExecuteSP(string spName, object paramModel = null);
        IEnumerable<TEntity> ExecuteSP<TEntity>(string spName, object paramModel = null) where TEntity : class;
        TEntity ExecuteSPSingle<TEntity>(string spName, object paramModel = null) where TEntity : class;

        IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TReturn>(string spName, Func<TFirst, TSecond, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TReturn>(string spName, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TFourth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteQuery<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteQuery<TFirst, TSecond, TThird, TFourth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteQuery<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class;
    }
}
