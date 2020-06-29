using FluentMigrator;
using NzbDrone.Core.Datastore.Migration.Framework;

namespace NzbDrone.Core.Datastore.Migration
{
    [Migration(25)]
    public class rename_restrictions_to_release_profiles : NzbDroneMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Rename.Table("Restrictions").To("ReleaseProfiles");
            Alter.Table("ReleaseProfiles").AddColumn("IncludePreferredWhenRenaming").AsInt32().WithDefaultValue(true);
        }
    }
}
