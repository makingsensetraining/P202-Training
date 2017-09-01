﻿using NHibernate;
using P202.Training.Data.Entities;
using System.Collections.Generic;

namespace P202.Training.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly INHibernateSessionManager _sessionManager;

        public RoleRepository(INHibernateSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void CreateRole(Role role)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(role);
                transaction.Commit();
            }
        }

        public IList<Role> GetAllRoles()
        {
            using (var session = _sessionManager.OpenSession())
            {
                // Create the criteria and load data
                ICriteria criteria = session.CreateCriteria<Role>();
                return criteria.List<Role>();
            }
        }

        public void DeleteRole(Role role)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(role);
                transaction.Commit();
            }
        }
    }
}