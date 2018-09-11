﻿using System.Data;
using System.Linq;

namespace Dapper.UnitOfWork.Example.Data.Queries
{
	public class GetCustomerByIdQuery : IQuery<CustomerEntity>
	{
		private const string Sql = @"
			SELECT
				CustomerID AS CustomerId,
				CompanyName
			FROM
				Customers
			WHERE
				CustomerID = @customerId
		";

		private readonly string _customerId;

		public GetCustomerByIdQuery(string customerId)
		{
			_customerId = customerId;
		}

		public CustomerEntity Execute(IDbConnection connection, IDbTransaction transaction)
		{
			// this is pure Dapper code
			return connection.Query<CustomerEntity>(Sql, new
			{
				customerId = _customerId
			}, transaction).FirstOrDefault();
		}
	}
}