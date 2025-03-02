﻿using System.Collections.Generic;

namespace NitroxModel.OS.Unix
{
    public sealed class UnixFileSystem : FileSystem
    {
        public override IEnumerable<string> GetDefaultPrograms(string file)
        {
            yield return "xdg-open";
        }

        public override bool SetFullAccessToCurrentUser(string directory)
        {
            throw new System.NotImplementedException();
        }
    }
}
