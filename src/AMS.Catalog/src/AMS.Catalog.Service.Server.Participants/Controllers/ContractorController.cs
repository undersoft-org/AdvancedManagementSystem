﻿// ********************************************************
//   Copyright (c) Undersoft. All Rights Reserved.
//   Licensed under the MIT License.
//   author: Dariusz Hanc
//   email: dh@undersoft.pl
//   server: Undersoft.SVC.Service.Server
// ********************************************************

using Undersoft.AMS.Service.Contracts.Participants;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Data.Query;

namespace Undersoft.AMS.Catalog.Service.Server.Participants.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    using Undersoft.SDK.Service.Server.Controller.Api;

    [Route($"api/data/catalog/participants/Contractor")]
    public class ContractorController
        : ApiCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Domain.Entities.Participant,
            Contractor,
            ServiceManager
        >
    {
        public ContractorController(IServicer servicer)
             : base(
                servicer,
                EventPublishMode.PropagateCommand,
                new QueryParameters<Domain.Entities.Participant>()
                {
                    Filter = p =>
                        p.ParticipantType == Domain.Entities.Enums.ParticipantType.Contractor,
                }
            )
        { }
    }
}

namespace Undersoft.AMS.Catalog.Service.Server.Participants.Controllers.Open
{
    using Undersoft.SDK.Service.Server.Controller.Open;

    public class ContractorController
        : OpenCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Domain.Entities.Participant,
            Contractor,
            ServiceManager
        >
    {
        public ContractorController(IServicer servicer)
            : base(
                servicer,
                EventPublishMode.PropagateCommand,
                new QueryParameters<Domain.Entities.Participant>()
                {
                    Filter = p =>
                        p.ParticipantType == Domain.Entities.Enums.ParticipantType.Contractor,
                }
            ) { }
    }
}
