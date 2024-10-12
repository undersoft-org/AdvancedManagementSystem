﻿// ********************************************************
//   Copyright (c) Undersoft. All Rights Reserved.
//   Licensed under the MIT License.
//   author: Dariusz Hanc
//   email: dh@undersoft.pl
//   server: Undersoft.SVC.Service.Server
// ********************************************************

using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.AMS.Catalog.Service.Server.Subjects.Controllers.Open
{
    using Undersoft.AMS.Service.Contracts.Subjects;
    using Undersoft.SDK.Service.Server.Controller.Open;

    public class GroupController
        : OpenCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Domain.Entities.Subject,
            Group,
            ServiceManager
        >
    {
        public GroupController(IServicer servicer)
            : base(
                servicer,
                EventPublishMode.PropagateCommand,
                new QueryParameters<Domain.Entities.Subject>()
                {
                    Filter = p =>
                        (p.Type & Domain.Entities.Enums.SubjectType.Group) > 0,
                }
            ) { }
    }
}
