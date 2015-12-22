﻿using System;
using System.Linq.Expressions;
using BeiDream.Core.Security.Authorization;
using BeiDream.Core.Security.Criterias;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Infrastructure.Repositories.DataPermissions.UserCriterias
{
    /// <summary>
    /// 只能查看自己创建的数据的数据权限
    /// </summary>
    public class LookSelfCreateUser : PermissionCriteriaBase<User>
    {
        public LookSelfCreateUser(IPermissionManager permissionManager) : base(permissionManager)
        {
        }

        protected override string GetPermissionCode()
        {
            return PermissionCode.LookSelfCreateUser;
        }

        protected override Expression<Func<User, bool>> CreatePredicate()
        {
            var currentUserId = GetApplicationContext().Name;
            return p => p.CreatorUserId == currentUserId;
        }
    }
}