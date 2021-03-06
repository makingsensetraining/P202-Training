﻿using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

namespace P202.Training.WCF.Handlers
{
    public class RoleReadAllHandler : RequestHandler<RoleReadAllRequest, RoleReadAllResponse>
    {
        private readonly IRoleService _roleService;

        public RoleReadAllHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public override Response Handle(RoleReadAllRequest request)
        {
            var response = CreateTypedResponse();
            response.Roles = _roleService.ListRoles();
            return response;
        }
    }
}