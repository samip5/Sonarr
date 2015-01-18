﻿using FluentMigrator;
using NzbDrone.Core.Datastore.Migration.Framework;

namespace NzbDrone.Core.Datastore.Migration
{
    [Migration(75)]
    public class force_lib_update : NzbDroneMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Update.Table("ScheduledTasks")
                .Set(new { LastExecution = "2014-01-01 00:00:00" })
                .Where(new { TypeName = "NzbDrone.Core.Tv.Commands.RefreshSeriesCommand" });

            Update.Table("Series")
                .Set(new { LastInfoSync = "2014-01-01 00:00:00" })
                .AllRows();
        }
    }


}
